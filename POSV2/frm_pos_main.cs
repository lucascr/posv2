using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Deployment.Application;
using System.Globalization;

//mt.exe -manifest "$(ProjectDir)$(TargetName).exe.manifest" -updateresource:"$(TargetDir)$(TargetName).exe;#1"
namespace POSV2
{
    public partial class frm_pos_main : Form
    {
        private int activo_lucas = 0;


        private SYMPOS_db_backup _symposbk;

        public static bool firstShow = true;
        public static string my_version = "";
        public frm_pos_main()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.frm_pos_main : ");
            InitializeComponent();
            first myFirst = first.GetInstance();
            myFirst.mainFrm = this;            
        }
        private void pendientesCABYS() {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run pendientesCABYS : " + firstShow);
            try {

                string sql_mysql_cabys_prod = "SELECT count(*) as cuenta,isnull(products.product_codigo_cabys) as pendientes FROM products GROUP BY isnull(products.product_codigo_cabys) ";
                string pendientes = "",listos="";
                DataTable tDtpc = DB.q(sql_mysql_cabys_prod, "", "", false);
                foreach (DataRow r in tDtpc.Rows)
                {
                    if (r["pendientes"].ToString() == "1"){
                        pendientes = r["cuenta"].ToString();
                    }
                    else {
                        listos= r["cuenta"].ToString();
                    }
                }
                lbl_cabys_product_pendientes.Text = listos + " / " + pendientes;

                string sql_mysql_cabys = "select count(*) as cuenta from cabys";
                DataTable tDtpc_cabys = DB.q(sql_mysql_cabys, "", "",false);
                foreach (DataRow r in tDtpc_cabys.Rows)
                {
                    lbl_cabys_count_total.Text= r["cuenta"].ToString();
                }
            } catch {

            }
        }
        private void show_vars() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.show_vars: ");

            first myFirst = first.GetInstance();
            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {

                System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;

                lbl_version.Text = ad.CurrentVersion.ToString();                
                my_version = "1-" + ad.CurrentVersion.ToString();
            }
            else
            {
                lbl_version.Text = String.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Revision, version.Build);
                my_version = "2-" + String.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Revision, version.Build);
                if (!first.debugExist) {
                    MessageBox.Show("Ocurrió un error con la versión, por favor reinstale la aplicación 9x0001 , contactar de inmediato al proveedor. ");
                    MessageBox.Show("Ocurrió un error con la versión, por favor reinstale la aplicación 9x0001 , contactar de inmediato al proveedor. ");
                    MessageBox.Show("Ocurrió un error con la versión, por favor reinstale la aplicación 9x0001 , contactar de inmediato al proveedor. ");
                }


            }

            first.pos_version = lbl_version.Text;
            //mnuS1.Items.Add("Algo");
            string suc = myFirst.getKey("pos_sucursal");
            string ter = myFirst.getKey("pos_terminal");
            txt_company_ter.Text = DB.CheckCompanyPOS().cloud_api_type + ":" + suc + "-" + ter;



            txt_company_db_name.Text = myFirst.get_str_config_db_database();

        }
        public frm_pos_main(string str_form)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.frm_pos_main : " + str_form);
            InitializeComponent();
            DB.CreateloadLanguage(mnuS1, this);
            CargarForm(str_form);
            first myFirst = first.GetInstance();
            myFirst.mainFrm = this;
            if (str_form == "Main")
            {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.firstShow = false");
                firstShow = false;
            }
            //this.Hide();
            this.show_vars();


            //System.Reflection.Assembly AssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly();
            //var fieVersionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            //var version = executingAssembly.GetName().Version;
            //var version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();  //= AssemblyVersion.Major.ToString() + "." + AssemblyVersion.Minor.ToString() + "." + AssemblyVersion.Build.ToString() + "." + AssemblyVersion.Revision.ToString();


        }
        public frm_pos_main(string str_form, string error_db)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.frm_pos_main : " + str_form + " err" + error_db);
            InitializeComponent();
            DB.CreateloadLanguage(mnuS1, this);
            CargarForm(str_form);
            lbl_config_db_errors.Text = error_db;
            first myFirst = first.GetInstance();
            myFirst.mainFrm = this;
            if (str_form == "Main")
            {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.firstShow = false");
                firstShow = false;
            }
            //this.Hide();
        }
        private static bool LoginForm(Form elForm, Array acceso, string SuperClave =  "") {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.LoginForm " + elForm.Text.ToString());


            first myFirst = first.GetInstance();
            DB.specialRun = "";
            DB.SuperClave = SuperClave;

            frm_pos_login frmActivo = new frm_pos_login();

            if (myFirst.get_str_debug_login().ToString() == "Login")
            {
                myFirst.activeFrm = frmActivo;
                frmActivo.required_access = acceso;
                frmActivo.ShowDialog();
            }
            else {
                frmActivo.login_successfull = true;
            }
            //
            //frmActivo.login_successfull = true;
            first.cld(frmActivo.login_successfull);
            if (frmActivo.login_successfull)
            {
                myFirst.activeFrm = elForm;
                elForm.Show();
                elForm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }

            return frmActivo.login_successfull;
            //myFirst.activeFrm = elForm;

        }
        public static void CargarForm(string str_form)
        {
            bool frm_login_successfull;
            frm_login_successfull = false;
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.CargarForm : " + str_form);
            first myFirst = first.GetInstance();
            myFirst.conectDBMysql();
            //frm_pos_main frmActivoMain = new frm_pos_main();
            //myFirst.activeFrm = frmActivoMain;
            if (DB.conectado)
            {
                if (str_form == "Invoice")
                {
                    bool invoice_load = true;
                    //Verifica ID
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.frm_pos_invoice : ");
                    VarCompany my_company = DB.CheckCompanyPOS(true);
                    if (my_company.company_identification == null) {
                        //Error
                        MessageBox.Show("Sucedió un error con la información de customer 9x002");
                        invoice_load = false;
                    }

                    //Verifica Sucursal
                    if (myFirst.getKey("pos_sucursal").Length < 1 || myFirst.getKey("pos_terminal").Length < 1) {
                        MessageBox.Show("Sucedió un error con la información de sucursal y terminal 9x001");
                        //invoice_load = false;
                    }



                    //Console.WriteLine(myFirst.getKey("pos_sucursal").Length);
                    if (invoice_load)
                    {
                        DB.enviar("00x00", "frm_login_successfull" + "\r\n " + my_version.ToString() + "\r\n Computer :" + Environment.MachineName.ToString());
                        frm_pos_invoice frmActivo = new frm_pos_invoice();
                        frm_login_successfull = LoginForm(frmActivo, new[] { "1", "8" });
                    }

                }
                else if (str_form == "Config") //OK
                {
                    frm_pos_config frmActivo = new frm_pos_config();
                    frm_login_successfull = LoginForm(frmActivo, new[] { "1", "2" });
                }
                else if (str_form == "Reports")
                {
                    frm_pos_users frmActivo = new frm_pos_users();
                    frm_login_successfull = LoginForm(frmActivo, new[] { "1", "3" });

                }
                else if (str_form == "Users") //OK
                {
                    frm_pos_users frmActivo = new frm_pos_users();
                    frm_login_successfull = LoginForm(frmActivo, new[] { "1", "4" });

                }
                else if (str_form == "Products")
                {
                    frm_pos_products frmActivo = new frm_pos_products();
                    frm_login_successfull = LoginForm(frmActivo, new[] { "1", "5" });

                }
                else if (str_form == "Clients") //--
                {
                    frm_pos_clients frmActivo = new frm_pos_clients();
                    frm_login_successfull = LoginForm(frmActivo, new[] { "1", "6" });

                }
                else if (str_form == "InvoiceMaintenance")
                {
                    frm_pos_invoice_maintenance frmActivo = new frm_pos_invoice_maintenance();
                    frm_login_successfull = LoginForm(frmActivo, new[] { "1", "7" });

                }
                else if (str_form == "InvoiceReport")
                {
                    frm_pos_invoice_report frmActivo = new frm_pos_invoice_report();
                    frm_login_successfull = LoginForm(frmActivo, new[] { "1", "9" });

                }
                else if (str_form == "Gastos")
                {
                    frm_pos_gastos frmActivo = new frm_pos_gastos();
                    frm_login_successfull = LoginForm(frmActivo, new[] { "1", "11" });

                }
                else if (str_form == "Cxc")
                {
                    frm_pos_cxc frmActivo = new frm_pos_cxc();
                    frm_login_successfull = LoginForm(frmActivo, new[] { "1", "10" });

                }
                else if (str_form == "Asadas")
                {
                    frm_invoice_asadas frmActivo = new frm_invoice_asadas();
                    frm_login_successfull = LoginForm(frmActivo, new[] { "1", "12" });

                }

                else if (str_form == "Main")
                {
                    //myFirst.mainFrm.Show();                    
                }
                else
                {
                    MessageBox.Show(DB.get_language("var_err") + " > " + "-Error con el form");
                }
            }
            else
            {
                if (str_form == "Config")
                {
                    frm_pos_config frmActivo = new frm_pos_config();
                    myFirst.activeFrm = frmActivo;
                    frmActivo.Show();
                    frmActivo.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
            }
            if (!frm_login_successfull) {
                //firstShow = false;
                //frm_FormClosed_method();       

            }
        }
        private void frm_pos_main_Load(object sender, EventArgs e)
        {
            //this.Hide();
        }
        public static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.frm_FormClosed : ");

            frm_FormClosed_method();
        }
        public static void frm_FormClosed_method() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.frm_FormClosed_method : ");
            first myFirst = first.GetInstance();
            myFirst.activeFrm = myFirst.mainFrm;
            DB.specialRun = "";

            myFirst.mainFrm.Show();
        }
        protected override void OnShown(EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.OnShown : " + firstShow);
            if (firstShow)
            {
                this.Hide();
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.firstShow = false");
                firstShow = false;
                return;
            }
            base.OnShown(e);
            if (DB.conectado) { 
                test_internet();
                mainCheckLicense();
                OtrosModulos();
            if (first.auto_debug) { //----------------------------------------------------------------DEBUG -----------DEBUG -----------DEBUG -----------DEBUG -----------
                //CargarForm("Cxc");
                /*
                SYMPOS_asadas my_asada = new SYMPOS_asadas();

                
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + my_asada.getConsumo("1", "35")); //8900
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + my_asada.getConsumo("1", "9")); //4440
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + my_asada.getConsumo("1", "101")); //21395
                */

                //CargarForm("Invoice");
                //CargarForm("InvoiceMaintenance");
                //CargarForm("Config");

                //CargarForm("InvoiceReport");
                //CargarForm("Clients");
                //SYMPOSprint newFe = new SYMPOSprint();
                //CargarForm("Gastos");
                //newFe.printpos("1");
                /*try
                {
                    DB.BackupDB();
                }
                catch {
                }
                */
                DB.checkVersion();
                pendientesCABYS();
            }
            else {
                try
                {
                    _symposbk = new SYMPOS_db_backup();
                    _symposbk.th_do_backup();
                    _symposbk.ProgressChanged += BK_ProgressChanged;

                    //_symposbk.CABYS();
                    pendientesCABYS();
                }
                catch
                {
                }

            }

            }
            //lbl_version_Click("",e);

        }
        private void OtrosModulos() {

            string sql_mysql_license = "select * from company_pos_config where pos_name='config' and activo=1 ";


            DataTable tDtpc = DB.q(sql_mysql_license, "", "");
            foreach (DataRow r in tDtpc.Rows)
            {
                if (r["pos_val"].ToString() == "1") {
                    if (r["pos_var"].ToString() == "asada")
                    {
                        btn_asadas.Enabled = true;
                    }
                    else if(r["pos_var"].ToString() == "academia")
                    {
                        btn_academia.Enabled = true;
                    }
                }
            }
        }
        private void mainCheckLicense() {
            if (!DB.CheckLicense())
            {
                lbl_license.Text = "Sistema sin licencia";

            }else {
                if (DB.This_licencia.estado.ToString() == "1")
                {
                    lbl_license.Text = "licencia Activa ( " + DB.This_licencia.dias_pendientes.ToString()  + " días)";
                    
                }
                else {
                    lbl_license.Text = "Sistema sin licencia ( " + DB.This_licencia.estado.ToString() + " )";

                }

            }
        }
        private void frm_pos_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.frm_pos_main_FormClosing : ");
            if (DB.cancelado_lucas== 0) {
                if (MessageBox.Show("Are you sure you want to close?", "POS", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (!first.auto_debug && activo_lucas == 0)
                    {
                        try
                        {
                            e.Cancel = true;
                            _symposbk = new SYMPOS_db_backup();
                            _symposbk.th_do_backup_complete();
                            _symposbk.ProgressChanged += BK_ProgressChangedClose;
                        }
                        catch
                        {
                            e.Cancel = false;
                        }
                    }
                }
            }
                
            
        }
        private void btn_new_invoice_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.btn_new_invoice_Click : ");
            if (DB.checkiva())
            {
                if (DB.checkAE())
                {
                    if (DB.This_licencia.estado == "2") {
                        MessageBox.Show("Sistema desactivado");
                    }
                    else
                    {
                        CargarForm("Invoice");
                    }
                }
                else
                {
                    MessageBox.Show("Sistema tiene Actividades Economicas, por favor configurar.", "POS");
                }
            }
            else {
                MessageBox.Show("Sistema no está listo para IVA, el sistema se está actualizando, por favor intente de nuevo en 10 minutos", "POS");
            }
            
        }
        private void btn_config_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.btn_config_Click : ");
            CargarForm("Config");
        }
        private void btn_users_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.btn_users_Click : ");
            CargarForm("Users");
        }
        private void btn_clients_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.btn_clients_Click : ");
            CargarForm("Clients");
        }
        private void btn_products_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.btn_products_Click : ");
            CargarForm("Products");
        }
        private void btn_invoice_maintenance_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.btn_invoice_maintenance_Click : ");
            CargarForm("InvoiceMaintenance"); 
        }
        private void lbl_version_Click(object sender, EventArgs e)
        {
            /*
            SYMPOS_API_Fe _SYMFE;
            _SYMFE = new SYMPOS_API_Fe();
            _SYMFE.uploadFE("24"); //sendFE(invoice_id);
            */
        }
        private void btn_invoice_report_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.btn_invoice_report_Click : ");
            CargarForm("InvoiceReport");
        }        
        private void lbl_config_db_errors_Click(object sender, EventArgs e)
        {

        }
        private void BK_ProgressChanged(int progress)
        {
            try
            {
                lbl_backup.Text = progress.ToString();
                pb1.Value = progress;
            }
            catch
            {
            }
        }
        private void BK_ProgressChangedClose(int progress)
        {
            try
            {
                lbl_backup.Text = progress.ToString();
                pb1.Value = progress;
                if (progress == 100) {
                    System.Environment.Exit(1);
                }
            }
            catch
            {
            }
        }
        private void btn_backup_Click(object sender, EventArgs e)
        {
            first.cld("btn_backup_Click Backup");
            try
            {
                _symposbk = new SYMPOS_db_backup();
                _symposbk.th_do_backup();
                _symposbk.ProgressChanged += BK_ProgressChanged;
            }
            catch
            {
            }

            _symposbk.CABYS();
        }
        private void btn_gastos_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.btn_gastos_Click : ");
            CargarForm("Gastos");
        }

        private void btn_main_encrypt_Click(object sender, EventArgs e)
        {

            first myFirst = first.GetInstance();
            main_txt_then.Text = encryptdecrypt.Encrypt( main_txt_for.Text , myFirst.get_myp()).ToString();
        }

        private void btn_main_descrypt_Click(object sender, EventArgs e)
        {
            first myFirst = first.GetInstance();
            String[] s = main_txt_for.Text.Split('\r');
            main_txt_then.Text = "";
        for (int i = 0; i < s.Length; i++)
            {
                main_txt_then.Text += encryptdecrypt.Decrypt(s[i].ToString(), myFirst.get_myp()).ToString() + "\r\n";
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (activo_lucas == 1)
            {
                activo_lucas = 0;
            }else {
                activo_lucas = 1;
                //btn_asadas.Visible = true;
            }
            
        }

        private void pb1_Click(object sender, EventArgs e)
        {
            if (activo_lucas == 1)
            {
                grp_lucas.Location =  new Point( 16, 231);
                grp_lucas.Visible = true;
            }
        }

        private void PP_RunCompleted(bool  complete)
        {
            try
            {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : "+ complete);
                if (complete) {
                    pb_internet.Image = il_internet.Images[0];
                    first.ping_error = false;
                } else {
                    pb_internet.Image = il_internet.Images[3];
                    first.ping_error = true;
                    mainCheckLicense();
                }
            }
            catch
            {
            }
        }
        private void test_internet(){
                pb_internet.Image    = il_internet.Images[1];
                SYMPOS_internet _li = new SYMPOS_internet();
                _li.th_do_ping();
                _li.RunCompleted += PP_RunCompleted;
            //decimal prueba = 99999999999999;
            //Console.WriteLine(prueba.ToString());
            string uiSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (!uiSep.Equals("."))
            {
                MessageBox.Show("Hay un error con la configuracion de Decimales, por favor notificar al proveedor de inmediato");
            }

        }

        private void txt_company_db_name_DoubleClick(object sender, EventArgs e)
        {
            DB.checkVersion();
        }

        private void btn_cxc_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.btn_cxc_Click : ");
            CargarForm("Cxc");
        }

        private void pb_internet_Click(object sender, EventArgs e)
        {
            test_internet();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            first.debugNetExist = true;
        }

        private void btn_asadas_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.  _Click : ");
            CargarForm("Asadas");
        }

        private void btn_new_history_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.btn_history_Click : ");
            CargarForm("History");
        }

        private void btn_academia_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();

            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add("Cursos");
            contextMenuStrip1.Items.Add("Profesores");

            //contextMenuStrip1.Click += new EventHandler(contextMenuStrip1_ItemClicked);


            contextMenuStrip1.Show(btn_academia, new Point(0, btn_academia.Height));


            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(
                contextMenuStrip1_ItemClicked);

        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Cursos")
            {
                frm_academia_cursos frmActivo = new frm_academia_cursos();
                frmActivo.Show();
                //frm_login_successfull = LoginForm(frmActivo, new[] { "1", "12" });
            }
        }

        private void lbl_cabys_total_Click(object sender, EventArgs e)
        {

            pendientesCABYS();
        }

        private void lbl_cabys_total_DoubleClick(object sender, EventArgs e)
        {
        }

        private void lbl_cabys_count_total_DoubleClick(object sender, EventArgs e)
        {


        }

        private void btn_cabys_Click(object sender, EventArgs e)
        {



            bool frm_login_successfull;
            frm_login_successfull = false;
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run main.btn_cabys_Click : " );
            first myFirst = first.GetInstance();
            myFirst.conectDBMysql();
            //frm_pos_main frmActivoMain = new frm_pos_main();
            //myFirst.activeFrm = frmActivoMain;
            if (DB.conectado)
            {
                frm_pos_cabys frmcabys = new frm_pos_cabys();
                frm_login_successfull = LoginForm(frmcabys, new[] { "99" }, "cabys");
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
