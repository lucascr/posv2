using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System.Management;
using System.Windows;


namespace POSV2
{
    public partial class frm_pos_config : Form
    {

        public frm_pos_config()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.frm_pos_config : ");
            InitializeComponent();
        }
        public frm_pos_config(string error_db)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.frm_pos_config : "+ error_db);

            InitializeComponent();
            lbl_config_db_errors.Text = error_db;
        }
        private void frm_pos_config_Load(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.frm_pos_config_Load : ");
            
            grp_step2_company.Visible = false;            

            //lbl_config_db_errors.Text = "";
            loadDBTypes();
            getcheckKeys();
            CheckInitialConfiguration();
        }
        private void CheckInitialConfiguration()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.CheckInitialConfiguration : ");
            if (DB.conectado) { 
                DB.CreateloadLanguage(mnuS1, this);
            }
            if (cmb_config_db_type.Text == "")
            {
                //First Time
                //cmb_language.Items.Clear();
                //cmb_language.Items.Add(new cbi("English", "language_english") );
                p_install.Visible = false;
            }
            else
            {
                //Check DB Status                
                first myFirst = first.GetInstance();
                pb1.Style = ProgressBarStyle.Marquee;
                string err = myFirst.conectDBMysql();
                pb1.Style = ProgressBarStyle.Blocks;
                if (err.ToString() == "1")
                {
                    grp_step1_db_setup.Visible = false;
                    grp_step2_company.Visible = true;
                    init_step2();

                    
                }
                else
                {
                    DB myDB = DB.GetInstance();
                    MySqlException myEx = myDB.get_error();
                    if (myEx == null)
                    {
                        lbl_config_db_errors.Text = "-Error on DB Type";
                    }
                    else
                    {
                        lbl_config_db_errors.Text = myEx.Message.ToString() + " ... " + myEx.Number;
                    }
                }
            }
        }
        private void getcheckKeys()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.getcheckKeys : ");
            first myFirst = first.GetInstance();
            cmb_config_db_type.Text = myFirst.get_str_config_db_type();
            txt_config_db_host.Text = myFirst.get_str_config_db_host();
            txt_config_db_username.Text = myFirst.get_str_config_db_username();
            txt_config_db_password.Text = myFirst.get_str_config_db_password();
            txt_config_db_database.Text = myFirst.get_str_config_db_database();
            txt_config_db_port.Text = myFirst.get_str_config_db_port();

            cmb_debug_login.Text = myFirst.get_str_debug_login();
            cmb_debug_language.Text = myFirst.get_str_debug_language();

            if (myFirst.get_str_install_pass() != "")
            {
                p_install.Visible = true; //Ya está instalado y hay llave de instalación
            }else {
                p_install.Visible = false;
            }
                /*cmb_config_db_type.Text = str_config_db_type.ToString();
                txt_config_db_host.Text = encryptdecrypt.Decrypt(str_config_db_host.ToString(), "lucas");
                c= encryptdecrypt.Decrypt(str_config_db_username.ToString(), "lucas");
                txt_config_db_password.Text = encryptdecrypt.Decrypt(str_config_db_password.ToString(), "lucas");
                txt_config_db_database.Text = encryptdecrypt.Decrypt(str_config_db_database.ToString(), "lucas");*/
            }
        private void loadDBTypes()
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.loadDBTypes : ");
            cmb_config_db_type.Items.Clear();
            cmb_config_db_type.Items.Add("MySQL");
            cmb_config_db_type.Items.Add("MySQL Local");
            cmb_config_db_type.Text = "MySQL";

            cmb_debug_login.Items.Clear();
            cmb_debug_login.Items.Add("Login");
            cmb_debug_login.Items.Add("No-Login");
            cmb_debug_login.Text = "Login";

            cmb_debug_language.Items.Clear();
            cmb_debug_language.Items.Add("Normal");
            cmb_debug_language.Items.Add("Debug");
            cmb_debug_language.Text = "Normal";

            //cmb_config_db_type.Items.Add("Sqlite");
            //cmb_config_db_type.Items.Add("SQL Server");
        }
        private void btn_config_db_save_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.btn_config_db_save_Click : ");
            lbl_config_db_errors.Text = "";

            first myFirst = first.GetInstance();
            //panel_step1
            //When the programm start check than this keys exist, if they exist should go to connect and sho login screen instead of first install configuration screen (this one)
            //Step 2 and Step 3 are hidden until Step1 is ready
            //Based in the cmb_config_db_type, if MYSQL save
            // cmb_config_db_type,txt_config_db_host,txt_config_db_username,txt_config_db_password,txt_config_db_database
            //if SQL server save  
            // cmb_config_db_type,txt_config_db_host,txt_config_db_username,txt_config_db_password,txt_config_db_database
            // if sqlite save , but not sure if we need the databasename, the filename will be at txt_config_db_host and the other options should be disabled
            //cmb_config_db_type,txt_config_db_host,txt_config_db_password 
            //keys example is in sympos.reg, but everithing have to be create from this software
            //the mysql script to be create is loaded by the user , like a manual installation , later we can talk about an installer than put the mysql and create the scheme 

            //Then after everything if check, have to jump to step2 i left all the functions should be program in init_step2 , that have to be saved in the database table company panel_step2
            //Then Step 3 saved into table hacienda panel_step3
            //Because we will have 3 db engines i will left a example of variables i want for each engine
            //On error display error in lbl_config_db_errors

            /*Microsoft.Win32.RegistryKey symposRegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SYMPOS");
            symposRegistryKey.SetValue("Name", cmb_config_db_type.Text.ToString() );
            symposRegistryKey.Close();*/
            //HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS


            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS", "config_db_type", cmb_config_db_type.Text.ToString());
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "config_db_database", encryptdecrypt.Encrypt(txt_config_db_database.Text.ToString(), myFirst.get_myp() ));
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "config_db_host", encryptdecrypt.Encrypt(txt_config_db_host.Text.ToString(), myFirst.get_myp()));
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "config_db_username", encryptdecrypt.Encrypt(txt_config_db_username.Text.ToString(), myFirst.get_myp()));
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "config_db_password", encryptdecrypt.Encrypt(txt_config_db_password.Text.ToString(), myFirst.get_myp()));
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "config_db_port", encryptdecrypt.Encrypt(txt_config_db_port.Text.ToString(), myFirst.get_myp()));
            

            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "config_install", encryptdecrypt.Encrypt(txt_installation.Text.ToString(), myFirst.get_myp()));
            
            CheckInitialConfiguration();
        }
        private void loadLocalKeys() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.loadLocalKeys : ");
            first myFirst = first.GetInstance();
            string pos_type = myFirst.getKey("pos_type");
            if (pos_type == "1")
            {
                rdo_pos_type_regular.Checked = true;
            }
            else if (pos_type == "2")
            {
                rdo_pos_type_touch_screen.Checked = true;
            }
            string pos_printer_type = myFirst.getKey("pos_printer_type");
            if (pos_printer_type == "1")
            {
                rdo_printer_regular.Checked = true;
            }
            else if (pos_printer_type == "2")
            {
                rdo_printer_pos.Checked = true;
            }
            else if (pos_printer_type == "3")
            {
                rdo_printer_none.Checked = true;
            }

            string printer_list = myFirst.getKey("cmb_printer_list");
            if (printer_list != "")
            {
                DB.sel_combo(ref cmb_printer_list, printer_list);
            }

            txt_company_local_pos_sucursal.Text = myFirst.getKey("pos_sucursal");
            txt_company_local_pos_terminal.Text = myFirst.getKey("pos_terminal");


            if (cmb_config_db_type.Text == "MySQL Local" && cmb_debug_login.Text == "No-Login")
            {
                grp_local_db.Visible = true;
                DB.loadDBNAME(ref cmb_change_db);
                cmb_change_db.Text = myFirst.get_str_config_db_database(); 
            }
        }
        private void init_step2()
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.init_step2 : ");
            DB.loadCmbIdType(ref cmb_company_id_type);
            DB.LoadProvince(ref cmb_company_province, ref cmb_company_canton, ref cmb_company_district);
            clearTxtCompany();
            DB.LoadCmbPrinters(ref cmb_printer_list);
            
            LoadLvCompany();
            loadApiTypes();
            loadLocalKeys();
        }
        private void LoadActividades() {
            grp_actividades_economicas.Enabled = true;

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.LoadLvCompany : ");
            DB.debugLV(lv_actividades_economicas);


            lv_actividades_economicas.Items.Clear();
            lv_actividades_economicas.Columns.Clear();
            lv_actividades_economicas.Columns.Add("Id", 0);
            lv_actividades_economicas.Columns.Add("lbl_actividad_code", 50);
            lv_actividades_economicas.Columns.Add(DB.get_language("lbl_actividad_desc"), 180);



            string sql_load_company_mysql = "select * from company_actividad where company_id= " + lbl_edit_company_id.Text;
            string sql_load_company_sqlserver = "";
            string sql_load_company_sqlite = "";

            DataTable tDt = DB.q(sql_load_company_mysql, sql_load_company_sqlserver, sql_load_company_sqlite);

            foreach (DataRow r in tDt.Rows)
            {

                //lvCompany.Items.Add();
                string[] row = { r["actividad_id"].ToString(), r["actividad_codigo"].ToString(), r["actividad_descripcion"].ToString()};
                var lvi = new ListViewItem(row);
                lv_actividades_economicas.Items.Add(lvi);

                //cmb_company_type.Items.Add(new cbi(r["tipo"].ToString(), r["codigo"].ToString()));

            }
        }
        private void clearTxtCompany()
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.clearTxtCompany : ");
            txt_company_phone_country_number.Text = "506";
            txt_company_identification.Text = "";
            txt_company_name.Text = "";
            txt_company_commercial_name.Text = "";
            txt_company_phone_number.Text = "";

            lbl_edit_company_id.Text = "";
        }
        
        private void cargarInventarioTipo(string company_id) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.cargarInventarioTipo : ");

            panel_inventario.Enabled = true;

            rdo_pos_type_inventario_no.Checked = true;
            string sql_mysql_license = "select * from company_pos_config where pos_name='inventario1' and pos_var='" + company_id + "' and activo=1 ";


            DataTable tDtpc = DB.q(sql_mysql_license, "", "");
            foreach (DataRow row in tDtpc.Rows)
            {

                if (row["pos_val"].ToString() == "2")
                {
                    rdo_pos_type_inventario_hasta_cero.Checked = true;
                }
                else if (row["pos_val"].ToString() == "3")
                {
                    rdo_pos_type_inventario_hasta_menos.Checked = true;
                }
            }
        }

        private void btn_company_inventario_Click(object sender, EventArgs e)
        {
            string tipo_inventario = "";
            //Delete
            string sql_insert_tipo_inventario = "";

            string sql_delete = "delete from company_pos_config where pos_name='inventario1' and pos_var='" + lbl_edit_company_id.Text.ToString() + "'";
            DB.e(sql_delete, "", "");
            if (rdo_pos_type_inventario_hasta_cero.Checked)
            {
                tipo_inventario = "2";
                sql_insert_tipo_inventario= "insert into company_pos_config set pos_var='" + lbl_edit_company_id.Text.ToString() + "'," +
                    "pos_name='inventario1',pos_val='" + tipo_inventario.ToString() + "'";
                DB.e(sql_insert_tipo_inventario, "", "");
                cargarInventarioTipo(lbl_edit_company_id.Text.ToString());
            }
            else if (rdo_pos_type_inventario_hasta_menos.Checked)
            {
                tipo_inventario = "3";
                sql_insert_tipo_inventario = "insert into company_pos_config set pos_var='" + lbl_edit_company_id.Text.ToString() + "'," +
                    "pos_name='inventario1',pos_val='" + tipo_inventario.ToString() + "'";
                DB.e(sql_insert_tipo_inventario, "", "");
                cargarInventarioTipo(lbl_edit_company_id.Text.ToString());
            }
            else
            {
                
            }
        }
        private void LoadCompanybyId(string company_id)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.LoadCompanybyId : ");
            string sql_load_company_mysql = "select * from company where company_id=" + company_id;
            string sql_load_company_sqlserver = "";
            string sql_load_company_sqlite = "";


            DataTable tDt = DB.q(sql_load_company_mysql, sql_load_company_sqlserver, sql_load_company_sqlite);

            if (tDt.HasErrors) {
                MessageBox.Show("-Error loading company");
            } else {
                clearTxtCompany();

                DB.sel_combo(ref cmb_company_id_type, tDt.Rows[0]["company_type"].ToString());

                txt_company_identification.Text = tDt.Rows[0]["company_identification"].ToString();
                txt_company_name.Text = tDt.Rows[0]["company_name"].ToString();

                txt_company_commercial_name.Text = tDt.Rows[0]["company_commercial_name"].ToString();

                txt_company_phone_country_number.Text = tDt.Rows[0]["company_phone_country_number"].ToString();
                txt_company_phone_number.Text = tDt.Rows[0]["company_phone_number"].ToString();

                txt_company_email.Text = tDt.Rows[0]["company_email"].ToString();

                DB.sel_combo(ref cmb_company_province, tDt.Rows[0]["company_addr_province"].ToString());
                DB.sel_combo(ref cmb_company_canton, tDt.Rows[0]["company_addr_canton"].ToString(),"3");
                DB.sel_combo(ref cmb_company_district, tDt.Rows[0]["company_addr_district"].ToString());

                lbl_edit_company_id.Text = company_id;
                btn_company_update.Enabled = true;
                btn_company_local_pos_db.Enabled = true;

                LoadActividades();
                /*
                if (tDt.Rows[0]["pos_type"].ToString() == "1")
                {
                    rdo_pos_type_regular.Checked = true;
                }
                else if (tDt.Rows[0]["pos_type"].ToString() == "2")
                {
                    rdo_pos_type_touch_screen.Checked = true;
                }

                if (tDt.Rows[0]["printer_type"].ToString() == "1")
                {
                    rdo_printer_regular.Checked = true;
                }
                else if (tDt.Rows[0]["printer_type"].ToString() == "2")
                {
                    rdo_printer_pos.Checked = true;
                }
                else if (tDt.Rows[0]["printer_type"].ToString() == "3")
                {
                    rdo_printer_none.Checked = true;
                }
                if (tDt.Rows[0]["printer_name"].ToString() != "")
                {
                    DB.sel_combo(ref cmb_printer_list, tDt.Rows[0]["printer_name"].ToString());
                }
                */

                cargarInventarioTipo(lbl_edit_company_id.Text);
            }
            
                
        }
        private void saveCompanySym(string crud)
        {

            #region Verification
            bool errores = false;
            string allErrors = "";

            DB.check_cmb(ref cmb_company_id_type, "lbl_company_type", ref errores, ref allErrors, 1, 999);
            DB.check_text(ref txt_company_identification, "lbl_company_identification", ref errores, ref allErrors, 9, 12);

            DB.check_cmb(ref cmb_company_province, "lbl_company_province", ref errores, ref allErrors, 1, 999);
            DB.check_cmb(ref cmb_company_canton, "lbl_company_canton", ref errores, ref allErrors, 1, 999);
            DB.check_cmb(ref cmb_company_district, "lbl_company_district", ref errores, ref allErrors, 1, 999);


            DB.check_text(ref txt_company_name, "lbl_company_name", ref errores, ref allErrors, 1, 80);
            //DB.check_text(ref txt_company_commercial_name, "lbl_company_commercial_name", ref errores, ref allErrors, 1, 80);

            DB.check_text(ref txt_company_phone_country_number, "lbl_company_phone_country_number", ref errores, ref allErrors, 1, 3);
            DB.check_text(ref txt_company_phone_number, "lbl_company_phone_number", ref errores, ref allErrors, 1, 20);

            DB.check_text(ref txt_company_email, "lbl_company_email", ref errores, ref allErrors, 4, 60);
            DB.check_text_email(ref txt_company_email, ref errores, ref allErrors);

            #endregion
            #region Combox
            string pos_type = "";
            if (rdo_pos_type_regular.Checked)
            {
                pos_type = "1";// rdo_pos_type_regular.Text.ToString();

            }
            else if (rdo_pos_type_touch_screen.Checked)
            {
                pos_type = "2"; // rdo_pos_type_touch_screen.Text.ToString();
            }
            else
            {
                errores = true;
                allErrors += System.Environment.NewLine + " POS Type";
            }

            string pos_printer_type = "";
            if (rdo_printer_regular.Checked)
            {
                pos_printer_type = "1";

            }
            else if (rdo_printer_pos.Checked)
            {
                pos_printer_type = "2";
            }
            else if (rdo_printer_none.Checked)
            {
                pos_printer_type = "3";
            }
            else
            {
                errores = true;
                allErrors += System.Environment.NewLine + " POS Printer Type";
            }
            #endregion
            #region SaveCompany
            if (errores)
            {
                MessageBox.Show(DB.get_language("var_err") + " > " + allErrors);
            }
            else
            {
                string sql_save_company_mysql = "";
                string sql_w = "";
                if (crud == "1")
                {
                    sql_save_company_mysql = "insert into company set company_cd=now() ";
                    sql_w = " ";
                }
                else
                {
                    sql_save_company_mysql = "update company set company_ud=now() ";
                    sql_w = " where company_id='" + lbl_edit_company_id.Text.ToString() + "'";
                }
                //string sql_save_company_mysql = "insert into company set company_cd=now(),company_ud=now() ";
                sql_save_company_mysql += " ,company_type = '" + ((cbi)cmb_company_id_type.SelectedItem).HiddenValue + "'";// cmb_company_type.SelectedItem.ToString();
                sql_save_company_mysql += " ,company_identification = '" + txt_company_identification.Text.ToString().PadLeft(12,'0') + "'";

                sql_save_company_mysql += " ,company_name = '" + txt_company_name.Text.ToString() + "'";
                sql_save_company_mysql += " ,company_commercial_name = '" + txt_company_commercial_name.Text.ToString() + "'";
                //sql_save_company_mysql += " ,company_invoice_address = " + cmb_company_type.ToString();
                //if (cmb_company_province.SelectedItem != null) { 

                sql_save_company_mysql += " ,company_addr_province = '" + ((cbi)cmb_company_province.SelectedItem).HiddenValue + "'"; // cmb_company_province.SelectedItem.ToString();                                                                                                                                      //}
                sql_save_company_mysql += " ,company_addr_canton = '" + ((cbc)cmb_company_canton.SelectedItem).hv_save + "'"; // cmb_company_canton.SelectedItem.ToString();
                sql_save_company_mysql += " ,company_addr_district = '" + ((cbi)cmb_company_district.SelectedItem).HiddenValue + "'"; // cmb_company_district.SelectedItem.ToString();

                //sql_save_company_mysql += " ,company_addr_barrio = " + cmb_company_type.ToString();
                //sql_save_company_mysql += " ,company_addr_senas = " + cmb_company_type.ToString();N
                sql_save_company_mysql += " ,company_phone_country_number = '" + txt_company_phone_country_number.Text.ToString() + "'";
                sql_save_company_mysql += " ,company_phone_number = '" + txt_company_phone_number.Text.ToString() + "'";
                sql_save_company_mysql += " ,company_email = '" + txt_company_email.Text.ToString() + "'";
                /*
                sql_save_company_mysql += " ,printer_type = '" + pos_printer_type + "'";
                sql_save_company_mysql += " ,pos_type = '" + pos_type + "'";
                if (cmb_printer_list.SelectedItem != null)
                {
                    sql_save_company_mysql += " ,printer_name = '" + cmb_printer_list.SelectedItem.ToString() + "'";
                }
                */
                
                //sql_save_company_mysql += " ,company_addr_district = " + cmb_company_district.SelectedItem.ToString();
                //sql_save_company_mysql += " ,company_addr_district = " + cmb_company_district.SelectedItem.ToString();

                string sql_save_company_sqlserver = "";
                string sql_save_company_sqlite = "";

                DB.e(sql_save_company_mysql + sql_w, sql_save_company_sqlserver, sql_save_company_sqlite);

                if (crud == "1")
                {
                    //DB.e(sql_create_mysql, sql_create_mysql, sql_create_mysql);
                    btn_company_update.Enabled = false;
                }
                else {
                    btn_company_update.Enabled = false;
                }
                    LoadLvCompany();
                    clearTxtCompany();
                }
            #endregion
        }
        private void LoadLvCompany()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.LoadLvCompany : ");
            DB.debugLV(lvCompany);
            
            DB.CheckCompanyPOS(true);

            grp_actividades_economicas.Enabled = false;
            //Load Companies
            lvCompany.Items.Clear();
            lvCompany.Columns.Clear();
            lvCompany.Columns.Add("Id", 24);
            lvCompany.Columns.Add(DB.get_language("lbl_company_type"), 145);
            lvCompany.Columns.Add(DB.get_language("lbl_company_identification"), 135);
            lvCompany.Columns.Add(DB.get_language("lbl_company_name"), 220);
            lvCompany.Columns.Add(DB.get_language("lbl_company_email"), 205);
            lvCompany.Columns.Add(DB.get_language("Credits"), 95);
            lvCompany.Columns.Add(DB.get_language("API"), 95);
            
            string sql_load_company_mysql = "select * from company";
            string sql_load_company_sqlserver = "";
            string sql_load_company_sqlite = "";

            DataTable tDt = DB.q(sql_load_company_mysql, sql_load_company_sqlserver, sql_load_company_sqlite);

            foreach (DataRow r in tDt.Rows)
            {

                //lvCompany.Items.Add();
                string[] row = { r["company_id"].ToString(), r["company_type"].ToString(), r["company_identification"].ToString(), r["company_name"].ToString(), r["company_email"].ToString(),"", r["active"].ToString() + " " + r["cloud_api_type"].ToString() };
                var lvi = new ListViewItem(row);
                lvCompany.Items.Add(lvi);

                //cmb_company_type.Items.Add(new cbi(r["tipo"].ToString(), r["codigo"].ToString()));

            }
        }
        private void loadApiTypes()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.loadApiTypes : ");
            cmb_hacienda_api_type.Items.Clear();
            cmb_hacienda_api_type.Items.Add("Produccion");
            cmb_hacienda_api_type.Items.Add("Testing");
        }
        private void btn_company_save_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.btn_company_save_Click : " );            
            saveCompanySym("1");
        }        
        private void txt_company_identification_KeyDown(object sender, KeyEventArgs e)
        {
            // TODOs
            //if cmb_company_type = 01 then txt_company_identification only 9 numbers
            //if cmb_company_type = 02 then txt_company_identification only 10 numbers
            //if cmb_company_type = 03 then txt_company_identification only 11 or 12 numbers
            //if cmb_company_type = 04 then txt_company_identification only 12 numbers

        }
        private void txt_company_phone_country_number_KeyDown(object sender, KeyEventArgs e)
        {
            // TODOs
            //Only numbers max 3
        }
        private void txt_company_phone_number_KeyDown(object sender, KeyEventArgs e)
        {
            // TODOs
            //Only numbers max 20
        }
        private void txt_company_name_KeyDown(object sender, KeyEventArgs e)
        {
            // TODOs
            //String max 80
        }
        private void txt_company_commercial_name_KeyDown(object sender, KeyEventArgs e)
        {
            // TODOs
            //String max 80
        }
        private void btn_hacienda_save_Click(object sender, EventArgs e)
        {
            // TODOs
            //if rdo_hacienda_yes save 1 to hacienda_configuration_api_active , else rdo_hacienda_no save 2 to hacienda_configuration_api_active
            //1 will always be yes and 2 no

            //save rdo_printer_pos or rdo_printer_regular  in column printer_configuration_type
            //save cmb_printer_list selection in column printer_configuration_printer_name

            //save rdo_pos_type_touch_screen, rdo_pos_type_regular

            //save all hacienda data into table hacienda cmb_hacienda_api_type,txt_hacienda_api_prod_url,txt_hacienda_api_test_url,txt_hacienda_api_user

            //Load login screen frm_pos_login();

        }
        private void invoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_pos_main.CargarForm("Invoice");
            /*frm_pos_invoice frmInvoice = new frm_pos_invoice();
            //Application.Run(new frmInvoice());
            
            // Show the settings form   
            frmInvoice.Show();
            this.Close();*/
            /*var frmInvoice = new frm_pos_invoice();
            //frmInvoice.Closed += (s, args) => this.Close();
            frmInvoice.ShowDialog();
            this.Close();*/

        }
        private void lvCompany_MouseClick(object sender, MouseEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.lvCompany_MouseClick : ");
            if (e.Button == MouseButtons.Right)
            {
                LoadLvCompany();
            }
        }
        private void lvCompany_DoubleClick(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.lvCompany_DoubleClick : ");
            DialogResult result = MessageBox.Show(DB.get_language("var_edit"), "Config", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                LoadCompanybyId(lvCompany.SelectedItems[0].Text.ToString() );
            }
            else if (result == DialogResult.No)
            {
                //do something else
            }


        }
        private void txt_installation_KeyPress(object sender, KeyPressEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.txt_installation_KeyPress : ");
            first myFirst = first.GetInstance();
            if (e.KeyChar == (char)13)
            {
                if (txt_installation.Text.ToString() == myFirst.get_str_install_pass())
                {
                    p_install.Visible = false;
                }
                else {
                    p_install.Visible = true;
                    MessageBox.Show("Install password invalid");                    
                }
            }
        }
        private void btn_company_update_Click(object sender, EventArgs e)
        {
            saveCompanySym("2");
        }
        private void btn_debug_save_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.btn_debug_save_Click : ");
            first myFirst = first.GetInstance();
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "debug_login", encryptdecrypt.Encrypt(cmb_debug_login.Text.ToString(), myFirst.get_myp()));
            //Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "debug_login1", cmb_debug_login.Text.ToString());
            
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "debug_language", encryptdecrypt.Encrypt(cmb_debug_language.Text.ToString(), myFirst.get_myp()));
        }
        private void btn_step1_visible_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.btn_step1_visible_Click : ");
            /*if (grp_step1_db_setup.Visible)
            {
                grp_step1_db_setup.Visible = false;
                grp_step2_company.Visible = true;
            }
            else
            {
                grp_step1_db_setup.Visible = true;
                grp_step2_company.Visible = false;
            }*/
            grp_step1_db_setup.Visible = true;
            grp_step2_company.Visible = false;
        }
        private void btn_company_local_info_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.btn_company_local_info_Click : ");

            bool errores = false;
            string allErrors = "";

            string pos_type = "";
            if (rdo_pos_type_regular.Checked)
            {
                pos_type = "1";// rdo_pos_type_regular.Text.ToString();

            }
            else if (rdo_pos_type_touch_screen.Checked)
            {
                pos_type = "2"; // rdo_pos_type_touch_screen.Text.ToString();
            }
            else
            {
                errores = true;
                allErrors += System.Environment.NewLine + " POS Type";
            }

            string pos_printer_type = "";
            if (rdo_printer_regular.Checked)
            {
                pos_printer_type = "1";

            }
            else if (rdo_printer_pos.Checked)
            {
                pos_printer_type = "2";
            }
            else if (rdo_printer_none.Checked)
            {
                pos_printer_type = "3";
            }
            else
            {
                errores = true;
                allErrors += System.Environment.NewLine + " POS Printer Type";
            }

            if (errores)
            {
                MessageBox.Show(DB.get_language("var_err") + " > " + allErrors);
            }
            else
            {
                first myFirst = first.GetInstance();
                if (cmb_printer_list.SelectedItem != null)
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "cmb_printer_list", encryptdecrypt.Encrypt(cmb_printer_list.Text.ToString(), myFirst.get_myp()));
                }
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "pos_type", encryptdecrypt.Encrypt(pos_type, myFirst.get_myp()));
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "pos_printer_type", encryptdecrypt.Encrypt(pos_printer_type, myFirst.get_myp()));
                MessageBox.Show(DB.get_language("var_ok"));
            }
                

        }

        private void btn_cloud_sync_Click(object sender, EventArgs e)
        {

        }

        private void btn_company_local_pos_Click(object sender, EventArgs e)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.btn_company_local_pos_Click : ");

            bool errores = false;
            string allErrors = "";
            DB.check_text(ref txt_company_local_pos_sucursal, "lbl_company_local_pos_sucursal", ref errores, ref allErrors, 1, 3);
            DB.check_text(ref txt_company_local_pos_terminal, "lbl_company_local_pos_terminal", ref errores, ref allErrors, 1, 5);
            if (errores)
            {
                MessageBox.Show(DB.get_language("var_err") + " > " + allErrors);
            }
            else
            {
                first myFirst = first.GetInstance();
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "pos_sucursal", encryptdecrypt.Encrypt(txt_company_local_pos_sucursal.Text.ToString().PadLeft(3,'0'), myFirst.get_myp()));
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "pos_terminal", encryptdecrypt.Encrypt(txt_company_local_pos_terminal.Text.ToString().PadLeft(5, '0'), myFirst.get_myp()));
                MessageBox.Show(DB.get_language("var_ok"));

                txt_company_local_pos_sucursal.Text = txt_company_local_pos_sucursal.Text.ToString().PadLeft(3, '0');
                txt_company_local_pos_terminal.Text = txt_company_local_pos_terminal.Text.ToString().PadLeft(5, '0');
            }

        }

        private void btn_company_local_pos_db_Click(object sender, EventArgs e)
        {
            //            PadLeft(4, '0');

            string suc = txt_company_local_pos_sucursal.Text.ToString();
            string ter = txt_company_local_pos_terminal.Text.ToString();
            string idc = txt_company_identification.Text.ToString();
            string tn = "prod";
            string sql_create_mysql = "";
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_fe like de_a_tm; "; //factura electronica
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_nc like de_a_tm; "; //nota credito
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_nd like de_a_tm; "; //nota debito
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_te like de_a_tm; "; //tiquete electronico
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_cg like de_a_tm; "; //Contingencia            
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_cc like de_a_tm; "; //cotizacion
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_fp like de_a_tm; "; //factura proforma
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_ft like de_a_tm; "; //factura temporal
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_mr like de_a_tm; "; //Mensaje Receptor
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_fec like de_a_tm; "; //Factura ELEC. Compra

            tn = "test";
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_fe like de_a_tm; "; //factura electronica
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_nc like de_a_tm; "; //nota credito
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_nd like de_a_tm; "; //nota debito
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_te like de_a_tm; "; //tiquete electronico
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_cg like de_a_tm; "; //Contingencia            
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_cc like de_a_tm; "; //cotizacion
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_fp like de_a_tm; "; //factura proforma
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_ft like de_a_tm; "; //factura temporal
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_mr like de_a_tm; "; //Mensaje Receptor
            sql_create_mysql += "create table IF NOT EXISTS de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_fec like de_a_tm; "; //Factura ELEC. Compra

            DB.e(sql_create_mysql, sql_create_mysql, sql_create_mysql);
            btn_company_local_pos_db.Enabled = false;
        }

        private void grp_step2_company_Enter(object sender, EventArgs e)
        {

        }

        private void btn_change_db_Click(object sender, EventArgs e)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.btn_change_db_Click : ");
            lbl_config_db_errors.Text = "";

            first myFirst = first.GetInstance();            
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + cmb_config_db_type.Text.ToString(), "config_db_database", encryptdecrypt.Encrypt(cmb_change_db.Text.ToString(), myFirst.get_myp()));

            CheckInitialConfiguration();
        }

        private void btn_company_actividad_save_Click(object sender, EventArgs e)
        {
            #region Verification
            bool errores = false;
            string allErrors = "";

            DB.check_text(ref txt_company_actividad_code, "lbl_actividad_code", ref errores, ref allErrors, 6, 6);
            DB.check_text(ref txt_company_actividad_desc, "lbl_actividad_desc", ref errores, ref allErrors, 1, 255);

            #endregion
            #region SaveActividad
            if (errores)
            {
                MessageBox.Show(DB.get_language("var_err") + " > " + allErrors);
            }
            else
            {
                string sql_insert_actividad = "insert into company_actividad set company_id='" + lbl_edit_company_id.Text.ToString() + "',actividad_codigo='" + txt_company_actividad_code.Text.ToString() + "',actividad_descripcion='" + txt_company_actividad_desc.Text.ToString() + "'";
                DB.e(sql_insert_actividad,"","");
                LoadActividades();
            }
            #endregion
        }

    }
}