using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.Data;
using System.Management;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Drawing;

namespace POSV2
{
    class DB
    {        
        private static DB dbconec;
        MySqlBackup Myb;
        public static bool loadLanguage;
        public static string specialRun;

        public static string lId;
        public static string ND5="N5"; //Decimal Format
        public static string ND2 = "N2"; //Decimal Format
        public static int RD5 = 5; //Round 
        public static int RD2 = 2; //Round 

        public static string user_login_id;

        public static bool conectado;
        static  string g_db_type;
        public static string g_strconnection;
        MySqlException g_ex;
        static  MySqlConnection g_conn;
        static MySqlConnection g_conn_bk;
        static DataTable g_dt_language;
        static string g_s_language;
        public static bool last_sql_injection_error=false;

        public static MySqlDataReader public_dr;
        public static  string last_error = "";
        public static bool last_error_happen = false;

        private static bool reader_active = false;

        private static  VarCompany last_id_company;
        private static bool last_id_company_loaded = false;

        public static bool simplificado = false;

        public static SYMLicense This_licencia = new SYMLicense();
        public static  int cancelado_lucas = 0;

        public static string SuperClave;

        //Database
        private DB() {}//private constructor so that it cannot be instantiated outside this class
        public static DB GetInstance(){
            if (dbconec == null) //check if  an instance has been created else  can create a new instance
            {
                dbconec = new DB();
            }
            return dbconec;
        }
        public string get_db_type() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.estado : ");
            return g_db_type;
        }
        public MySqlException get_error(){
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.get_error : ");
            return g_ex;
        }        
        public static void e(string sql_mysql, string sql_sqlserver, string sql_sqlite,bool th_bg = false){
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.e : "+ sql_mysql);
            MySqlConnection this_conn;
            if (!DB.conectado)
            {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.e : !db.conectado" );
                first myFirst = first.GetInstance();
                myFirst.conectDBMysql();
                reader_active = false;
            }
            if (DB.conectado)
            {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.e : db.conectado");
                MySqlCommand cmd = null;
                if (g_db_type == "MySQL" || g_db_type == "MySQL Local")
                {
                    try
                    {

                        WaitForEndOfRead();
                        lId = "";
                        
                        if (th_bg) {
                            this_conn = g_conn_bk;
                        } else {
                            this_conn = g_conn;
                        }
                        cmd = new MySqlCommand(sql_mysql, this_conn); //"if a=1"+1
                        cmd.ExecuteNonQuery();
                        lId = cmd.LastInsertedId.ToString();
                        first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.e :  myId " + lId.ToString());
                    }

                    catch (System.InvalidOperationException sEx)
                    {
                        first.cld("InvalidOperationException : " + sEx.ToString());
                        //MessageBox.Show("db 10x101 " + sEx.ToString());
                        DB.enviar("db 10x101", first.debug_number + " e:" + sql_mysql + "\r\n th_bg: " + th_bg.ToString() + " \r\n <BR> InvalidOperationException:" + sEx.ToString());
                        DB.conectado = false;
                    }
                    catch (MySqlException mEx)
                    {
                        first.cld("Catch : " + mEx.ToString());
                        //MessageBox.Show("db 10x102 " + mEx.ToString());
                        DB.enviar("db 10x102", first.debug_number + " e:" + sql_mysql + "\r\n th_bg: " + th_bg.ToString() + " \r\n <BR> MySqlException:" + mEx.ToString());
                        DB.conectado = false;
                    }
                    if (!DB.conectado) {
                        try {
                            using (MySqlConnection local_conn = new MySqlConnection(g_strconnection))
                            {
                                local_conn.Open();
                                using (MySqlCommand local_cmd = new MySqlCommand(sql_mysql, local_conn))
                                {
                                    local_cmd.ExecuteNonQuery();
                                    lId = local_cmd.LastInsertedId.ToString();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            DB.enviar("db 10x103", first.debug_number + " e:" + sql_mysql + "\r\n th_bg: " + th_bg.ToString() + " \r\n <BR> MySqlException:" + ex.ToString());
                            //Log exception
                            //Display Error message
                        }
                        
                            


                    }
                }
            }
            else {
                MessageBox.Show("DB Not connected");
            }
        }
        public static void WaitForEndOfRead()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run WaitForEndOfRead : "+ g_conn.State + " / " + reader_active);
            int count = 0;
            Console.WriteLine(g_conn.State);
            Console.WriteLine(reader_active);
            
            while (g_conn.State == ConnectionState.Fetching)
            {
                Application.DoEvents();
                Thread.Sleep(2500);
                count++;
                if (count > 50)
                {
                    break;
                }
            }
            while (reader_active == true)
            {

                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run WaitForEndOfRead.2 : ");
                Application.DoEvents();
                Thread.Sleep(1000);
                count++;
                if (count > 1)
                {
                    reader_active = false;
                    break;
                }
            }
            
        }
        public static DataTable q(string sql_mysql, string sql_sqlserver, string sql_sqlite, bool error_show = true,bool th_bg = false,bool timeOutLucas = true)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.q : "+ sql_mysql);
            DataTable myDT = new DataTable();
            DB.last_error_happen = false;
            DB.last_error = "";
            DB.public_dr = null;
            myDT.Clear();
            myDT.Columns.Clear();
            myDT.Rows.Clear();
            MySqlConnection this_conn;
            //myDT.Clear();
            // .EnforceConstraints = false;

            /*bool errores = false;
            string allErrors = "";
            //DB.s(sql_mysql,ref errores, ref allErrors);

            if (errores)
            {
                MessageBox.Show(DB.get_language("var_err") + allErrors);
            }
            else
            { */
            if (DB.last_sql_injection_error)
            {

            }
            else { 
                if (!DB.conectado)
                {
                    first myFirst = first.GetInstance();
                    myFirst.conectDBMysql();
                    reader_active = false;
                }
                if (DB.conectado)
                {
                    MySqlCommand cmd = null;
                    if (g_db_type == "MySQL" || g_db_type == "MySQL Local")
                    {
                        try
                        {
                            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.q : before WaitForEndOfRead ");
                            WaitForEndOfRead();
                            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.q : after WaitForEndOfRead ");
                            reader_active = true;
                            if (th_bg) {
                                this_conn = g_conn_bk;
                            } else {
                                this_conn = g_conn;
                            }
                            using (cmd = new MySqlCommand(sql_mysql, this_conn))
                            {
                                if (timeOutLucas== false) {
                                    cmd.CommandTimeout = 0;
                                }
                                

                                using (MySqlDataReader dr = cmd.ExecuteReader())
                                {

                                    //Work with dr in here.
                                    if (dr.FieldCount > 0)
                                    {
                                        myDT.Load(dr);
                                    }
                                    else {
                                        Console.WriteLine(dr.RecordsAffected.ToString());
                                        DB.public_dr = dr;
                                    }

                                    dr.Close();
                                    
                                }
                            }
                            reader_active = false;

                            //cmd.ExecuteReader();

                            // if (dr.RecordsAffected > 0) { 

                            //}

                        }
                        catch (System.InvalidOperationException sEx)
                        {
                            first.cld("InvalidOperationException : " + sEx.ToString());
                            DB.last_error = "InvalidOperationException : " + sEx.ToString();
                            DB.last_error_happen = true;

                            if (error_show) {
                                //MessageBox.Show("db 10x001 " + sEx.ToString());
                            }
                            DB.enviar("db 10x001", first.debug_number +  " q:"+ sql_mysql + "\r\n error_show: " + error_show.ToString() + "\r\n th_bg: " + th_bg.ToString() +  " \r\n <BR> InvalidOperationException:" + sEx.ToString());
                            DB.conectado = false;
                        }
                        catch (MySqlException mEx)
                        {
                            first.cld("Catch : " + mEx.ToString());
                            DB.last_error = "MySqlException : " + mEx.ToString();
                            DB.last_error_happen = true;

                            if (error_show)
                            {
                                MessageBox.Show("db 10x002 " + mEx.ToString());
                            }
                            DB.enviar("db 10x002", first.debug_number + " q:" + sql_mysql + "\r\n error_show: " + error_show.ToString() + "\r\n th_bg: " + th_bg.ToString() + " \r\n <BR> MySqlException:" + mEx.ToString());
                            DB.conectado = false;
                        }
                        catch (Exception ex)
                        {
                            first.cld("Catch : " + ex.ToString());
                            DB.last_error = "Exception : " + ex.ToString();
                            DB.last_error_happen = true;

                            if (error_show)
                            {
                                MessageBox.Show("db 10x003 " + ex.ToString());
                            }
                            DB.enviar("db 10x003", first.debug_number + " q:" + sql_mysql + "\r\n error_show: " + error_show.ToString() + "\r\n th_bg: " + th_bg.ToString() + " \r\n <BR> Exception:" + ex.ToString());
                            DB.conectado = false;
                        }
                        finally
                        {
                            //g_conn.Close();
                            //DB.conectado = false;

                        }

                        if (!DB.conectado)
                        {
                            try
                            {
                                using (MySqlConnection local_conn = new MySqlConnection(g_strconnection))
                                {
                                    local_conn.Open();

                                    using (cmd = new MySqlCommand(sql_mysql, local_conn))
                                    {

                                        using (MySqlDataReader dr = cmd.ExecuteReader())
                                        {

                                            //Work with dr in here.
                                            if (dr.FieldCount > 0)
                                            {
                                                myDT.Load(dr);
                                            }
                                            else
                                            {
                                                Console.WriteLine(dr.RecordsAffected.ToString());
                                                DB.public_dr = dr;
                                            }
                                            dr.Close();

                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                DB.enviar("db 10x004", first.debug_number + " e:" + sql_mysql + "\r\n th_bg: " + th_bg.ToString() + " \r\n <BR> MySqlException:" + ex.ToString());
                                //Log exception
                                //Display Error message
                            }




                        }
                        /*
                        if (!DB.conectado)
                        {
                         error save
                        }*/

                    }
                }
                else
                {
                    DB.last_error = "DB Not connected";
                    DB.last_error_happen = true;

                    MessageBox.Show("DB Not connected");
                }
            }
            last_sql_injection_error = false;
            return myDT;
        }
        public string conectar(string db_type, string host, string user, string pass, string db,string port)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.conectar : ");
            if (conectado) {
                try
                {
                    first.cld("Closing... ");
                    g_conn.Close();
                    g_conn_bk.Close();
                }
                catch (MySqlException ex)
                {
                    first.cld("Catch " + ex.Message.ToString());
                    g_ex = ex;
                    return ex.Message;
                }
            }

            conectado = false;
            g_ex = null;
            Application.DoEvents();
            if (db_type == "MySQL" || db_type == "MySQL Local")
            {
                try
                {
                    //create a string connection
                    string strconnection;
                    strconnection = "Server=" + host + ";Port=" + port+ ";Database =" + db + ";Uid = " + user + ";Password =" + pass + ";CharSet=utf8;Connect Timeout=60;SslMode=none;convert zero datetime=True";
                    g_strconnection = strconnection;
                    g_db_type = db_type;
                    //initialize the connection to DB
                    Application.DoEvents();
                    first.cld("Connecting... ");
                    MySqlConnection conn = new MySqlConnection(strconnection);
                    MySqlConnection conn_bk = new MySqlConnection(strconnection);
                    Application.DoEvents();
                    conn.Open();
                    conn_bk.Open();
                    g_conn = conn;
                    g_conn_bk = conn_bk;
                    Application.DoEvents();
                    conectado = true;
                    first.cld("1");
                    return "1";
                    //conn.Close();
                }
                catch (MySqlException ex)
                {
                    first.cld("Catch " + ex.Message.ToString());
                    g_ex = ex;
                    return ex.Message;
                }
            }
            else
            {
                first.cld("No DbType 0");
                return "0";
            }
        }
        
        public static void sync()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.sync : " );
            //get version dbs

        }
        public static void syncFE()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.syncFE : ");
            //CheckInternet

            //Send Invoice
            
            //Get results

            //Check respuestas
        }
        //Login
        public static bool SuperLoginForm( string SuperClave = "")
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.SuperLoginForm " );

            first myFirst = first.GetInstance();
            DB.specialRun = "";
            DB.SuperClave = SuperClave;

            frm_pos_login frmActivo = new frm_pos_login();

            if (myFirst.get_str_debug_login().ToString() == "Login")
            {
                myFirst.activeFrm = frmActivo;
                frmActivo.ShowDialog();
            }
            else
            {
                frmActivo.login_successfull = true;
            }
            first.cld(frmActivo.login_successfull);
            return frmActivo.login_successfull;
        }
        //Helpers
        public static string ds(string t)
        {
            t = t.Replace("  ", " ");
            t = t.Trim();
            return t;
        }
        public static string i(string t)
        {
            //string allErrors = "";

            //t.Replace("'", "");
            t = t.Replace("\'", "");
            t = t.Replace("\"", "");
            t = t.Replace("update", "");
            return t;
        }
        public static string s(string t)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.s sqlInjection: ");
            bool errores = false;
            //string allErrors = "";
            if (t.ToLower().IndexOf("'") != -1)
            {
                errores = true;
            }
            if (t.ToLower().IndexOf("update") != -1)
            {
                errores = true;
            }
            if (t.ToLower().IndexOf("delete") != -1)
            {
                errores = true;
            }
            if (t.ToLower().IndexOf("drop") != -1)
            {
                errores = true;
            }
            if (t.ToLower().IndexOf("/") != -1)
            {
                errores = true;
            }
            if (t.ToLower().IndexOf(";") != -1)
            {
                errores = true;
            }
            if (t.ToLower().IndexOf("\\") != -1)
            {
                errores = true;
            }
            if (errores)
            {
                MessageBox.Show(DB.get_language("var_err") + System.Environment.NewLine + DB.get_language("var_data_error"));
            }
            last_sql_injection_error = errores;
            return t;
        }
        public static void sel_combo(ref ComboBox cmb,string sel, string tipo = "1")
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.sel_combo : ");
            string hv = "";
            foreach (var X in cmb.Items)
            {
                first.cld(" s :" + X.ToString() );
                if (tipo == "4") //CBA Asadas
                {
                    hv = ((cba)X).hv_idTarifa;
                }
                else if (tipo == "3") //Cantones
                {
                    hv = ((cbc)X).hv_save;
                }
                else if (tipo == "2") //Combo Sym
                {
                    hv = ((csym)X).h_sym;
                }
                else {
                    hv = ((cbi)X).HiddenValue;
                }
                    if ( hv== sel) {
                    cmb.SelectedItem = X;
                    break;
                }
            }
        }
        public static void sel_lv(ref ListView lv, string sel)
        {
            var auser_access_level = sel.ToString().Split('-');
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.sel_lv : ");
            foreach (ListViewItem Xvi in lv.Items)
            {
                Xvi.Checked = false;
                foreach (string aal in auser_access_level)
                {
                    if (aal == Xvi.Text.ToString())
                    {
                        Xvi.Checked = true;
                    }
                }
            }
        }
        public static string get_lv(ListView lv, string sel)
        {
            string ret = "";
            string pret = "";
            var auser_access_level = sel.ToString().Split('-');
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.sel_lv : ");
            foreach (ListViewItem Xvi in lv.Items)
            {
                Xvi.Checked = false;
                foreach (string aal in auser_access_level)
                {
                    if (aal == Xvi.Text.ToString())
                    {
                        ret += pret  + Xvi.SubItems[1].Text.ToString();
                        pret = ",";
                    }
                }
            }
            return ret;
        }
        public static void get_text(Form elForm)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.get_text : ");
            first myFirst = first.GetInstance();
            var c = myFirst.GetAll(elForm, typeof(TextBox));
            foreach (Control X in c)
            {
                first.cld(" T :" + X.Name);
            }
        }        
        public static void check_text(ref TextBox txt_textbox,string var_language, ref bool errores, ref string allErrors,int min, int max) {
            //DB.check_text(ref txt_company_identification, ref errores, ref allErrors);
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.check_text : ");
            if (txt_textbox.Text.ToString().Length < min || txt_textbox.Text.ToString().Length > max)
            {
                errores = true;
                allErrors += System.Environment.NewLine + DB.get_language(var_language);
            }

            //DB.s(txt_textbox.Text.ToString(), ref errores,ref allErrors);
        }
        /* public static void s(string t, ref bool errores,ref string allErrors)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.s sqlInjection: ");
            if (t.IndexOf("'") != -1)
            {
                errores = true;
                allErrors += System.Environment.NewLine + DB.get_language("var_data_error");
            }

            if (t.IndexOf("update") != -1)
            {
                errores = true;
                allErrors += System.Environment.NewLine + DB.get_language("var_data_error");
            }

            if (t.IndexOf("delete") != -1)
            {
                errores = true;
                allErrors += System.Environment.NewLine + DB.get_language("var_data_error");
            }

        } */
        
        public static void check_string(string txt_textbox, string var_language, ref bool errores, ref string allErrors, int min, int max)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.check_string : ");
            if (txt_textbox.Length < min || txt_textbox.Length > max)
            {
                errores = true;
                allErrors += System.Environment.NewLine + DB.get_language(var_language);
            }
        }
        public static void check_text_email(ref TextBox txt_textbox, ref bool errores, ref string allErrors) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.check_text_email : ");
            RegexUtilities util = new RegexUtilities();
            if (!util.IsValidEmail(txt_textbox.Text.ToString())){
                errores = true;
                allErrors += System.Environment.NewLine + DB.get_language("err_email");
            }
        }
        public static void check_cmb(ref ComboBox cmb_box, string var_language, ref bool errores, ref string allErrors, int min, int max, string tipo = "")
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.check_cmb : ");
            string hv = "";
            string mySelText = "";
            if (cmb_box.SelectedItem != null)
            {
                mySelText = cmb_box.SelectedItem.ToString();
                if (tipo == "4") //CBA Asadas
                {
                    hv = ((cba)cmb_box.SelectedItem).hv_idTarifa;
                }else if (tipo == "2")
                {
                    hv = ((csym)cmb_box.SelectedItem).h_sym;
                }
                else if (tipo == "1")
                {
                    hv = ((cbi)cmb_box.SelectedItem).HiddenValue;
                }

            }
            else {
                errores = true;
                allErrors += System.Environment.NewLine + DB.get_language(var_language);
            }
            if (tipo == "")
            {
                if (mySelText.Length < min || mySelText.Length > max)
                {
                    errores = true;
                    allErrors += System.Environment.NewLine + DB.get_language(var_language);
                }
            }
            else {
                if (hv.Length == 0) { 
                    errores = true;
                    allErrors += System.Environment.NewLine + DB.get_language(var_language);
                }
            }
        }
        public static void check_id(ref TextBox txt_textbox, ref ComboBox cmb_box, ref bool errores, ref string allErrors)
        {
            
        }
        public static bool isNumber(char ch, string text)
        {
            bool res = true;
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            //check if it´s a decimal separator and if doesn´t already have one in the text string
            if (ch == decimalChar && text.IndexOf(decimalChar) != -1)
            {
                res = false;
                return res;
            }

            //check if it´s a digit, decimal separator and backspace
            if (!Char.IsDigit(ch) && ch != decimalChar && ch != (char)Keys.Back)
                res = false;

            return res;
        }
        //Address
        public static void LoadProvince(ref ComboBox pCB, ref ComboBox cCb, ref ComboBox dCb, int tipo = 1)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.LoadProvince : ");
            string sql_mysql = "select * from shared_addr_province order by province";
            string sql_sqlserver = "";
            string sql_sqlite = "";


            pCB.SelectedIndexChanged += new EventHandler(DB.pCB_addr_SelectedIndexChanged);
            pCB.Tag = cCb;

            cCb.Items.Clear();
            cCb.SelectedIndexChanged += new EventHandler(DB.cCB_addr_SelectedIndexChanged);
            cCb.Tag = dCb;

            DataTable tDt = DB.q(sql_mysql, sql_sqlserver, sql_sqlite);
            if (tDt.Rows.Count > 0)
            {
                pCB.Items.Clear();

                if (tipo == 2)
                {
                    pCB.Items.Add(new cbi("", ""));
                }
                foreach (DataRow r in tDt.Rows)
                {
                    pCB.Items.Add(new cbi(r["province"].ToString(), r["id_province"].ToString()));
                }
            }
        }
        public static void pCB_addr_SelectedIndexChanged(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.Province pCB_addr_SelectedIndexChanged : ");

            ComboBox pCB = new ComboBox();
            ComboBox cCB = new ComboBox();
            ComboBox dCB = new ComboBox();

            pCB = (ComboBox)sender;

            if (pCB.Tag != null)
            {
                cCB = (ComboBox)pCB.Tag;
                if (cCB.Tag != null)
                {
                    dCB = (ComboBox)cCB.Tag;
                    dCB.Items.Clear();
                }
                string sql_mysql = "select * from shared_addr_canton where id_province='"+ ((cbi)pCB.SelectedItem).HiddenValue + "' order by canton";
                string sql_sqlserver = "";
                string sql_sqlite = "";

                cCB.Items.Clear();
                DataTable tDt = DB.q(sql_mysql, sql_sqlserver, sql_sqlite);                
                if (tDt.Rows.Count > 0)
                {
                    
                    foreach (DataRow r in tDt.Rows)
                    {
                        cCB.Items.Add(new cbc(r["canton"].ToString(), r["addr_canton_id"].ToString(), r["id_canton"].ToString()));
                    }
                }
                
                
            }
        }
        public static void cCB_addr_SelectedIndexChanged(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.Province cCB_addr_SelectedIndexChanged : ");

            ComboBox cCB = new ComboBox();
            ComboBox dCB = new ComboBox();

            cCB = (ComboBox)sender;

            if (cCB.Tag != null)
            {
                dCB = (ComboBox)cCB.Tag;

                string sql_mysql = "select * from shared_addr_district where id_canton='" + ((cbc)cCB.SelectedItem).hv_search + "' order by district";
                string sql_sqlserver = "";
                string sql_sqlite = "";

                DataTable tDt = DB.q(sql_mysql, sql_sqlserver, sql_sqlite);
                if (tDt.Rows.Count > 0)
                {
                    dCB.Items.Clear();
                    foreach (DataRow r in tDt.Rows)
                    {
                        dCB.Items.Add(new cbi(r["district"].ToString(), r["id_district"].ToString()));
                    }
                }
                
                
            }
        }
        //Language
        public static void CreateloadLanguage(MenuStrip elMenu,Form myForm)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.CreateloadLanguage : "+myForm.Name.ToString());
            first myFirst = first.GetInstance();
            myFirst.activeFrm = myForm;

            ToolStripComboBox tsCB = new ToolStripComboBox();
            loadLanguage = false;
            if (elMenu.Items["tsCB_language"] == null)
            {

                tsCB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
                tsCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                tsCB.Name = "tsCB_language";
                tsCB.SelectedIndexChanged += new EventHandler(DB.tsCB_language_SelectedIndexChanged);
                elMenu.Items.Add(tsCB);

                tsCB.Items.Clear();
                DB.add_language(tsCB, "English", "language_english");
                
            }
            else {
                tsCB =(ToolStripComboBox) elMenu.Items["tsCB_language"];
            }


            string sql_mysql = "select * from shared_languages_available";
            string sql_sqlserver = "";
            string sql_sqlite = "";
            string selected_language = myFirst.getLanguageKeys();
            DataTable tDt = DB.q(sql_mysql, sql_sqlserver, sql_sqlite);
            if (tDt.Rows.Count > 0)
            {
                tsCB.Items.Clear();
                foreach (DataRow r in tDt.Rows)
                {
                    //cmb_company_type.Items.Add(new cbi(r["language_name"].ToString(), r["language_var"].ToString()));
                    //= r["language_var"].ToString()
                    DB.add_language(tsCB, r["language_name"].ToString(), r["language_var"].ToString());
                    if (selected_language == r["language_var"].ToString()) {
                        //tsCB.SelectedText = r["language_name"].ToString();
                        tsCB.SelectedIndex = (tsCB.Items.Count-1);
                    }
                }
            }
            loadLanguage = true;
            tsCB_language_SelectedIndexChanged(tsCB, EventArgs.Empty);




            //tsCB_language_SelectedIndexChanged(tsc)
        }
        public static void tsCB_language_SelectedIndexChanged(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.tsCB_language_SelectedIndexChanged : "+ loadLanguage);
            if (DB.conectado && loadLanguage)
            {
                ToolStripComboBox tsCB = new ToolStripComboBox();
                tsCB = (ToolStripComboBox)sender;
                first myFirst = first.GetInstance();
                if (tsCB.Text != "")
                {
                    //ToolStripComboBox my = (ToolStripComboBox)sender;
                    ToolStripMenuItem mi = (ToolStripMenuItem)tsCB.SelectedItem;
                    if (mi.Tag != null)
                    {
                        DB.ch_language(mi.Tag.ToString(), myFirst.activeFrm);
                        //Save to Keys
                        myFirst.saveLanguageKeys(mi.Tag.ToString());                        
                    }
                }
                else
                {
                    MessageBox.Show("Language error");
                }
            }
        }
        public static string get_language(string var_language, string var_temporal = ""){
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.get_language : ");
            string ret = "";
            var finded = false;
            bool debug = false;
            bool update_lang = true;
            
            if (g_dt_language == null) {
                MessageBox.Show("Glogal Datarow language empty");
            }
            ret = var_language;
            foreach (DataRow r in g_dt_language.Rows){
                if (debug) {
                    first.cld(r["language_var"].ToString() + " : " + r["idioma"].ToString());
                }                
                if (var_language == r["language_var"].ToString()){
                    if (r["idioma"].ToString().Length>0){
                        ret = r["idioma"].ToString();
                        if (update_lang) {
                            DB.q("update shared_language set in_use=2 where language_var='"+ var_language + "'", "", "");
                        }
                    } else {
                        ret = r["language_var"].ToString();
                    }
                    finded = true;
                    break;
                }
            }
            if (finded == false){
                first.cld(" O :" + var_language);
                if (var_temporal.Length > 0)
                {
                    ret = var_temporal;
                }
                
            }
            return ret;
        }
        public static void ch_language(string new_language, Form elForm){
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.ch_language : " + elForm.Name.ToString());
            DataTable lDt = DB.changeLanguage(new_language);
            first myFirst = first.GetInstance();
            bool debug = true;
            bool update_lang = true;
            first.cld("DB-ST : Esta en db pero sin text, NO-DB : No esta en db, T = Textbox,Combobox,RadioBox");
            var c = myFirst.GetAll(elForm, typeof(Label)).Concat(myFirst.GetAll(elForm, typeof(Button))).Concat(myFirst.GetAll(elForm, typeof(GroupBox)));
            foreach (Control X in c){
                var finded = false;
                foreach (DataRow r in lDt.Rows){                    
                    if (X.Name == r["language_var"].ToString()){
                        finded = true;
                        if (r["idioma"].ToString() != ""){
                            (X).Text = r["idioma"].ToString();

                            if (debug)
                            {
                                //   first.cld(r["language_var"].ToString() + " : " + r["idioma"].ToString());
                                first.cld("  DB > " + X.Name);

                                if (update_lang)
                                {
                                    DB.q("update shared_language set in_use=1 where language_var='" + X.Name + "'", "", "");
                                }
                            }
                            break;
                        }else{
                            first.cld("  DB-ST > " + X.Name);
                            (X).Text = r["language_var"].ToString();
                            if (update_lang)
                            {
                                DB.q("update shared_language set in_use=9 where language_var='" + X.Name + "'", "", "");
                            }
                        }
                    }
                }
                if (finded == false){
                    first.cld(" NO-DB :" + X.Name);
                    if (first.auto_debug) { 
                        bool Debug_language = false;
                        if (Debug_language) {
                            DB.q("insert ignore into shared_language_debug set in_use='99',language_var='" + X.Name + "',language_text='" + (X).Text.ToString() +  "',screen='" + myFirst.activeFrm.Name.ToString() + "' ","","",false);
                        }
                    }
                }
            }

            var d = myFirst.GetAll(elForm, typeof(TextBox)).Concat(myFirst.GetAll(elForm, typeof(ComboBox))).Concat(myFirst.GetAll(elForm, typeof(RadioButton)));
            foreach (Control X in d){                
                first.cld(" T :" + X.Name);
            }

            if (DB.specialRun == "callback_users")
            {
                if (elForm.Tag == "users")
                {
                    frm_pos_users el_frm_pos_users = (frm_pos_users)elForm;
                    el_frm_pos_users.LoadAccess();
                    el_frm_pos_users.LoadLvUsers();
                }
                
            }
            else if (DB.specialRun == "callback_clients")
            {
                frm_pos_clients el_frm_pos_clients = (frm_pos_clients)elForm;
                el_frm_pos_clients.LoadClientsCmb();
                el_frm_pos_clients.LoadLvClients();
            }
            else if (DB.specialRun == "callback_products")
            {
                frm_pos_products el_frm_pos_products = (frm_pos_products)elForm;
                el_frm_pos_products.LoadCmbAction();
                el_frm_pos_products.LoadProductSym();
            }
            else if (DB.specialRun == "callback_invoice")
            {
                //if(typeof(elForm) != frm_pos_invoice) { 
                try
                {
                    frm_pos_invoice el_frm_pos_products = (frm_pos_invoice)elForm;
                    el_frm_pos_products.cleanLvInvoice();
                    el_frm_pos_products.LoadCmbAction();
                }
                catch
                {
                }
                
                //}
            }
            /*
                foreach (DataRow r in lDt.Rows){

                    var c= myFirst.GetAll(this, typeof(Label));
                    var finded = false;
                    foreach (Control X in c){
                            if (X.Name == r["language_var"].ToString()){
                                finded = true;
                                if (r["idioma"].ToString() != "") {
                                    ((Label)X).Text = r["idioma"].ToString();
                                }
                            }
                    }
                    if (finded == false) {
                   //     first.cld(X.Name);
                    }
                }*/
        }
        public static void add_language(ToolStripComboBox tsCB, string language_name,string language_var) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.add_language : ");
            ToolStripMenuItem item = new ToolStripMenuItem(language_name);
            item.Tag = language_var;
            tsCB.Items.Add(item);
            if (item.Tag.ToString() == "language_english")
            {
                tsCB.Text = item.Text;
            }
        }
        public static DataTable changeLanguage(string language_var) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.changeLanguage : ");
            DataTable myDT = new DataTable();
            if (g_s_language != language_var)
            {
                g_s_language = language_var;
                myDT = DB.q("select language_var," + language_var + " as idioma from shared_language", "", "");
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.changeLanguage.Use Query: ");
                g_dt_language = myDT;
            }
            else {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.changeLanguage.Use Global : ");
                myDT = g_dt_language;
            }
            return myDT;
        }
        //Specific
        public static void loadDBNAME(ref ComboBox cmb_db_name)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.cmb_db_name : ");
            cmb_db_name.Items.Clear();
            DataTable tDt = DB.q("show databases like 'symposv2%'", "", "");
            foreach (DataRow r in tDt.Rows)
            {
                //cmb_db_name.Items.Add(new cbi(r["tipo"].ToString(), r["codigo"].ToString()));
                cmb_db_name.Items.Add(new cbi(r[0].ToString(), r[0].ToString()));
            }
        }
        public static void readscript(string filename) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run readscript  ");
            try
            {
                MySql.Data.MySqlClient.MySqlScript script = new MySql.Data.MySqlClient.MySqlScript(g_conn, File.ReadAllText(filename));
                script.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run readscript  error " + ex.ToString());
            }
            

        }
        public static VarCompany CheckCompanyPOS(bool force=false) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.CheckCompanyPOS : ");
            if (last_id_company_loaded && !force && last_id_company.cloud_api_token!="") {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.fast: ");
                return last_id_company;
            }
            last_id_company_loaded = false;
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.sqlLoad: ");
            //TODOS 
            //Check Sucursal y Terminal
            //SHOW TABLES LIKE 'yourtable';

            //VarCompany ret_id_company = new VarCompany("","","","");
            VarCompany ret_id_company = new VarCompany();
            
            string sql_mysql_company_count = "select count(*) as cuenta from company where active=1";
            DataTable tDt = DB.q(sql_mysql_company_count, sql_mysql_company_count, sql_mysql_company_count);
            if (tDt.Rows.Count > 0){
                //return true;
                DataRow r = tDt.Rows[0];
                if (Int32.Parse(r["cuenta"].ToString()) > 0)
                {
                    if (Int32.Parse(r["cuenta"].ToString()) > 1)
                    {
                        //Todos
                        //Seleccionar
                    }
                    else
                    {
                        string sql_mysql_company_sel = "select * from company where active=1";
                        DataTable tDtcs = DB.q(sql_mysql_company_sel, "", "");
                        DataRow rcs = tDtcs.Rows[0];

                        // ret_id_company= new VarCompany();     
                        ret_id_company.id_company = rcs["company_id"].ToString();
                        ret_id_company.company_type = rcs["company_type"].ToString();
                        ret_id_company.company_identification = rcs["company_identification"].ToString();
                        ret_id_company.company_name = rcs["company_name"].ToString();

                        ret_id_company.company_email = rcs["company_email"].ToString();
                        ret_id_company.company_addr_province = rcs["company_addr_province"].ToString();
                        ret_id_company.company_addr_canton = rcs["company_addr_canton"].ToString();
                        ret_id_company.company_addr_district = rcs["company_addr_district"].ToString();

                        ret_id_company.cloud_api_token = rcs["cloud_api_token"].ToString();
                        ret_id_company.cloud_api_type = rcs["cloud_api_type"].ToString();
                        ret_id_company.cloud_api_prod = rcs["cloud_api_prod"].ToString();
                        ret_id_company.cloud_api_test = rcs["cloud_api_test"].ToString();
                        ret_id_company.cloud_sync = rcs["cloud_sync"].ToString();

                        last_id_company = ret_id_company;
                        last_id_company_loaded = true;

                        ret_id_company.company_inventario = "1";

                        string sql_mysql_license = "select * from company_pos_config where pos_name='inventario1' and pos_var='" + ret_id_company.id_company + "' and activo=1 ";


                        DataTable tDtpc = DB.q(sql_mysql_license, "", "");
                        foreach (DataRow row in tDtpc.Rows)
                        {
                            first.cld(row["pos_val"].ToString());
                            ret_id_company.company_inventario = row["pos_val"].ToString();
                        }

                        /*
         ret_id_company = new VarCompany(
             rcs["company_id"].ToString(),
             rcs["company_type"].ToString(),
             rcs["company_identification"].ToString(),
             rcs["company_name"].ToString(),
             rcs["cloud_api_token"].ToString(),
             rcs["cloud_api_type"].ToString(),
             rcs["cloud_api_prod"].ToString(),
             rcs["cloud_api_test"].ToString(),
             rcs["cloud_sync"].ToString()
             );*/

                    }
                    }
                else
                {
                    //No hay
                }
            }
            else
            {
                //Error
            }
            //ret_id_company.set

            return ret_id_company;
        }
        public static bool checkCompany()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.checkCompany : ");
            string sql_mysql_company_count = "select count(*) as cuenta from company where active=1";

            DataTable tDt = DB.q(sql_mysql_company_count, sql_mysql_company_count, sql_mysql_company_count);
            if (tDt.Rows.Count > 0)
            {
                //return true;
                DataRow r = tDt.Rows[0];
                if (Int32.Parse(r["cuenta"].ToString())  > 0)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
        public static void LoadCmbPrinters(ref ComboBox cmb_printer_list)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.LoadCmbPrinters : ");
            //Todos
            //Selectec default printer from keys
            cmb_printer_list.Items.Clear();
            try
            {

                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    //cmb_printer_list.Items.Add(printer);
                    cmb_printer_list.Items.Add(new cbi(printer, printer));
                }
            }
            catch
            {
                MessageBox.Show("No printer detected");
            }
        }
        public static string GetCabys(string cabys_code) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.GetCabys : ");
            DataTable tDt = DB.q("select F18 from cabys where F17 = '"+ cabys_code + "'","", "");
            string ret = "";
            foreach (DataRow r in tDt.Rows)
            {
                //cmb_db_name.Items.Add(new cbi(r["tipo"].ToString(), r["codigo"].ToString()));
                ret= r[0].ToString();
            }
            return ret;
        }
        public static void loadCmbIdType(ref ComboBox cmb_id_type, int tipo = 1)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.loadCmbIdType : ");
            string sql_load_tipo_identificacion_mysql = "select * from shared_tipo_identificacion";
            string sql_load_tipo_identificacion_sqlserver = "";
            string sql_load_tipo_identificacion_sqlite = "";

            cmb_id_type.Items.Clear();
            if (tipo == 2)
            {
                cmb_id_type.Items.Add(new cbi("", ""));
            }
            else if (tipo == 3)
            {
                cmb_id_type.Items.Add(new cbi(DB.get_language("var_all"), ""));
            }
                DataTable tDt = DB.q(sql_load_tipo_identificacion_mysql, sql_load_tipo_identificacion_sqlserver, sql_load_tipo_identificacion_sqlite);

            foreach (DataRow r in tDt.Rows)
            {
                cmb_id_type.Items.Add(new cbi(r["tipo"].ToString(), r["codigo"].ToString()));
            }
        }

        public static void loadAdvCmbUnit(ref ComboBox cmb_prod_unit, int tipo = 1,int activo =1)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.loadCmbUnit : ");
            string sql_load_product_unit_mysql = "";
            if (activo == 1)
            {
                sql_load_product_unit_mysql = "select * from products_adv_unit where active=1 order by orden asc";
            }
            else if(activo == 2)
            {
                sql_load_product_unit_mysql = "select * from products_adv_unit order by orden desc";
            }
            else {
                sql_load_product_unit_mysql = "select * from products_adv_unit order by orden asc";
            }
            cmb_prod_unit.Items.Clear();
            if (tipo == 2)
            {
                cmb_prod_unit.Items.Add(new cbi("", ""));
            }
            else if (tipo == 3)
            {
                cmb_prod_unit.Items.Add(new cbi(DB.get_language("var_all"), ""));
            }
            DataTable tDt = DB.q(sql_load_product_unit_mysql, "", "");

            foreach (DataRow r in tDt.Rows)
            {
                cmb_prod_unit.Items.Add(new cbi(r["products_adv_unit_descripcion"].ToString(), r["products_adv_unit_simbolo"].ToString()));
            }
        }
        public static void loadAdvCmbproducts_code_type(ref ComboBox cmb_products_code_type, int tipo = 1, int activo = 1)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.loadAdvCmbproducts_code_type : ");
            string sql_load_products_code_type_mysql = "";
            if (activo == 1)
            {
                sql_load_products_code_type_mysql = "select * from products_adv_code_type where active=1 order by orden asc";
            }
            else
            {
                sql_load_products_code_type_mysql = "select * from products_adv_code_type order by orden asc";
            }
            cmb_products_code_type.Items.Clear();
            if (tipo == 2)
            {
                cmb_products_code_type.Items.Add(new cbi("", ""));
            }
            else if (tipo == 3)
            {
                cmb_products_code_type.Items.Add(new cbi(DB.get_language("var_all"), ""));
            }
            DataTable tDt = DB.q(sql_load_products_code_type_mysql, "", "");

            foreach (DataRow r in tDt.Rows)
            {
                cmb_products_code_type.Items.Add(new cbi(r["products_adv_code_type_tipo"].ToString(), r["products_adv_code_type_codigo"].ToString()));
            }
        }

        public static void loadAdvCmbproducts_adv_tax(ref ComboBox cmb_products_adv_tax, int tipo = 1, int activo = 1)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.loadAdvCmbproducts_adv_tax : ");
            string sql_load_products_adv_tax_mysql = "";
            if (activo == 1)
            {
                sql_load_products_adv_tax_mysql = "select * from products_adv_tax where active=1 order by orden asc";
            }
            else
            {
                sql_load_products_adv_tax_mysql = "select * from products_adv_tax order by orden asc";
            }
            cmb_products_adv_tax.Items.Clear();
            if (tipo == 2)
            {
                cmb_products_adv_tax.Items.Add(new cbi("", ""));
            }
            else if (tipo == 3)
            {
                cmb_products_adv_tax.Items.Add(new cbi(DB.get_language("var_all"), ""));
            }
            DataTable tDt = DB.q(sql_load_products_adv_tax_mysql, "", "");

            foreach (DataRow r in tDt.Rows)
            {
                cmb_products_adv_tax.Items.Add(new cbi(r["products_adv_tax_impuesto"].ToString(), r["products_adv_tax_codigo"].ToString()));
            }
        }
        public static void loadCmbProdSym(ref ComboBox cmb_prod_sym, int tipo = 1)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.loadCmbProdSym : ");
            string sql_load_product_unit_mysql = "select * from products_sym where active=1 order by orden asc";

            cmb_prod_sym.Items.Clear();
            if (tipo == 2){
                //cmb_prod_sym.Items.Add(new cbi("", ""));
                cmb_prod_sym.Items.Add(new csym(DB.get_language("cmb_select"), "", "", "", "","","",""));
            }else if (tipo == 3){
                //cmb_prod_sym.Items.Add(new cbi(DB.get_language("var_all"), ""));
            }else if (tipo == 4){
                cmb_prod_sym.Items.Add(new csym(DB.get_language("var_all"), "%", "", "", "", "", "", ""));
            }

            DataTable tDt = DB.q(sql_load_product_unit_mysql, "", "");

            foreach (DataRow r in tDt.Rows)
            {
                //cmb_prod_sym.Items.Add(new csym(r["product_sym_description"].ToString(), r["product_sym"].ToString(), r["product_sym_code_type"].ToString(),  r["product_sym_unit"].ToString(), r["product_sym_tax_code"].ToString(), r["product_sym_tax_code_iva"].ToString(), r["product_sym_tax_code_iva_tax"].ToString(), r["product_inventory_type"].ToString() ) );

                cmb_prod_sym.Items.Add(
                    new csym(r["product_sym_description"].ToString(), r["product_sym"].ToString(), r["product_sym_code_type"].ToString(), r["product_sym_unit"].ToString(), r["product_sym_tax_code"].ToString(), r["product_sym_tax_code_iva_code"].ToString(), r["product_sym_tax_code_iva_tax"].ToString(), r["product_inventory_type"].ToString())
                    );
            }
        }
        public static void loadCmbActividadEconomica(ref ComboBox cmb_cur, int activo = 1) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.loadCmbActividadEconomica : ");

            string sql_load_company_actividad_mysql = "";
            if (activo == 1)
            {
                sql_load_company_actividad_mysql = "select * from company_actividad order by actividad_orden asc";
            }
            else
            {
                sql_load_company_actividad_mysql = "select * from company_actividad order by actividad_descripcion asc";
            }
            cmb_cur.Items.Clear();

            DataTable tDt = DB.q(sql_load_company_actividad_mysql, "", "");
            int count_AE = 0;
            foreach (DataRow r in tDt.Rows)
            {
                cmb_cur.Items.Add(new cbi(r["actividad_descripcion"].ToString(), r["actividad_codigo"].ToString()));
                count_AE++;
            }
            /*if (count_AE == 0) {
                cmb_cur.Items.Add(new cbi("N/D", "0"));
            }*/
        }
            
        public static void loadCmbCur(ref ComboBox cmb_cur, int tipo = 1, int activo = 1)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.loadCmbProdCur : ");
            
            string sql_load_shared_cur_mysql = "";
            if (activo == 1)
            {
                sql_load_shared_cur_mysql = "select * from shared_currency where active=1 order by orden asc";
            }
            else
            {
                sql_load_shared_cur_mysql = "select * from shared_currency order by orden asc";
            }
            cmb_cur.Items.Clear();
            if (tipo == 2)
            {
                //cmb_prod_unit.Items.Add(new cbi("", ""));
                cmb_cur.Items.Add(new cbi(DB.get_language("cmb_select"), ""));
            }
            else if (tipo == 3)
            {
                cmb_cur.Items.Add(new cbi(DB.get_language("var_all"), ""));
            }
            DataTable tDt = DB.q(sql_load_shared_cur_mysql, "", "");

            foreach (DataRow r in tDt.Rows)
            {
                if (tipo == 4)
                {
                    cmb_cur.Items.Add(new cbi(r["currency_codigo"].ToString(), r["currency_exchange"].ToString()));
                }else if (tipo == 5)
                {
                    cmb_cur.Items.Add(new cbi(r["currency_moneda"].ToString(), r["currency_codigo"].ToString()));
                }
                else {
                    cmb_cur.Items.Add(new cbi(r["currency_codigo"].ToString(), r["currency_codigo"].ToString()));
                    
                }
            }
        }
        public static void loadCmbSubCat(ref ComboBox cmb_subcat, int tipo = 1, int activo = 1)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.loadCmbSubCat : ");

            string sql_load_product_sub_cat_mysql = "";
            if (activo == 1)
            {
                sql_load_product_sub_cat_mysql = "select * from product_sub_category where active=1 order by orden desc,product_sub_category";
            }
            else
            {
                sql_load_product_sub_cat_mysql = "select * from product_sub_category order by orden desc,product_sub_category";
            }
            cmb_subcat.Items.Clear();
            if (tipo == 2)
            {
                cmb_subcat.Items.Add(new cbi(DB.get_language("cmb_select"), ""));
            }
            else if (tipo == 3)
            {
                cmb_subcat.Items.Add(new cbi(DB.get_language("var_all"), ""));
            }
            DataTable tDt = DB.q(sql_load_product_sub_cat_mysql, "", "");

            foreach (DataRow r in tDt.Rows)
            {
                if (tipo == 4)
                {
                    cmb_subcat.Items.Add(new cbi(r["product_sub_category"].ToString(), r["product_sub_category_id"].ToString()));
                }
                else if (tipo == 5)
                {
                    cmb_subcat.Items.Add(new cbi(r["product_sub_category"].ToString(), r["product_sub_category_id"].ToString()));
                }
                else
                {
                    cmb_subcat.Items.Add(new cbi(r["product_sub_category"].ToString(), r["product_sub_category_id"].ToString()));

                }
            }
        }
        
        public static void LoadState(ref ComboBox cmb_state)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.LoadState : ");
            //TO-DOs
            cmb_state.Items.Clear();
            cmb_state.Items.Add(new cbi(DB.get_language("var_active"), "1"));
            cmb_state.SelectedIndex = 0;
            cmb_state.Items.Add(new cbi(DB.get_language("var_inactive"), "0"));
        }
        public static string getState(string var_state) {
            //TO-DOs
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.getState : ");
            string ret = "";
            if (var_state == "1")
            {
                ret=DB.get_language("var_active");
            }
            else if (var_state == "1")
            {
                ret=DB.get_language("var_inactive");
            }
            else
            {
                ret=DB.get_language("var_err");
            }
            return ret;
        }
        public static string getDocType(string var_state,bool prefix = false)
        {
            //TO-DOs
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.getState : ");
            string ret = "";
            if (var_state == "01"){
                ret= prefix ? "FE" : "Factura Electrónica";
            }else if (var_state == "03"){
                ret = prefix ? "NC" : "Nota de crédito";
            }else if (var_state == "04"){
                ret = prefix ? "TE" : "Tiquete Electrónico";
            }else if (var_state == "05"){
                ret = prefix ? "MR A" : "Mensaje Aceptar";
            }else if (var_state == "06"){
                ret = prefix ? "MR AP" : "Mensaje Aceptar Parcialmente";
            }else if (var_state == "07"){
                ret = prefix ? "MR R" : "Mensaje Rechazar";
            }else{
                ret = var_state;
            }
            return ret;
        }
        public static void ASA(ref string[] row,string toAdd )
        {
            row = row.Concat(new string[] { toAdd }).ToArray();
        }
        //DB.enviar("db 10x001", first.debug_number + " q:" + sql_mysql + " \r\n <BR> MySqlException:" + mEx.ToString());
        public static void enviar(string subject, string body) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run ENVIAR : " + subject + " : " + body);
            if (first.ping_error) {
                return;
            }
            VarCompany my_company = DB.CheckCompanyPOS();
            string myToken = my_company.cloud_api_token;
            string myserver = my_company.cloud_api_type.ToString() == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;
            

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                NameValueCollection inputsD = new NameValueCollection();
                inputsD.Add("token", my_company.cloud_api_token);
                inputsD.Add("computer", Environment.MachineName.ToString());
                inputsD.Add("version", first.pos_version);
                inputsD.Add("data", "52");
                inputsD.Add("error_subject", subject);
                inputsD.Add("error_body", body);


                try
                {

                    byte[] bretD = client.UploadValues(myserver + "/apiInvoice.php", inputsD);
                    string result = Encoding.UTF8.GetString(bretD);
                    if (result.ToString() == "0")
                    {

                    }

                }
                catch
                {
                    MessageBox.Show("Ocurrio un error descargando 52x01");
                }
            }
        }
        public static void TemporalUpdateGastos() {

            string sql_gastos = "update invoice set invoice_ref_FechaEmision_cd = REPLACE(SUBSTRING(TRIM(invoice_ref_FechaEmision), 1, 19), 'T', ' ')  where(invoice_tipo_doc = '05' or invoice_tipo_doc = '06' or invoice_tipo_doc = '07')and invoice_ref_FechaEmision != '' and invoice_ref_FechaEmision_cd is null";
            DB.e(sql_gastos, "", "");

        }
        public static bool checkAE() {
            bool ret = true;

            string version_check = "select count(*) as cuenta from company_actividad ";
            string resultD, resultU;
            DataTable tDtVC = DB.q(version_check, "", "");
            if (DB.last_error_happen) { return ret; }

            string count = "0";
            if (tDtVC.Rows.Count > 0)
            {
                foreach (DataRow r in tDtVC.Rows)
                {
                    count = r["cuenta"].ToString();

                }

            }
            if (count == "")
            {
                ret = false;
            }
            else
            {
                int count_int;
                int.TryParse(count, out count_int);
                if (count_int > 0)
                {
                    ret = true;
                }
            }
            return ret;
        }
        public static bool checkiva()
        {
            bool ret = false;

            string version_check = "select * from version where activo =1 limit 1";
            string resultD, resultU;
            DataTable tDtVC = DB.q(version_check, "", "");
            if (DB.last_error_happen) { return ret; }
            string count = "0";
            if (tDtVC.Rows.Count > 0)
            {
                foreach (DataRow r in tDtVC.Rows)
                {
                    count = r["version"].ToString();

                }


            }
            if (count == "") {
                ret = false;
            } else {
                int count_int;
                int.TryParse(count, out count_int);
                if (count_int > 34) {
                    ret = true;
                }
                ret = true;
            }

            return ret;
        }
        public static void checkVersion()
        {
            SYMPOS_internet _li = new SYMPOS_internet();
            if (!_li.check_internet()) {
                first.ping_error = true;
                return;
            }
                string json = "";



            string version_check = "select * from version where activo =1 limit 1";
            string resultD, resultU;
            DataTable tDtVC = DB.q(version_check, "", "");
            if (DB.last_error_happen) { return; }
            string count = "0";
            if (tDtVC.Rows.Count > 0)
            {
                foreach (DataRow r in tDtVC.Rows)
                {
                    count = r["version"].ToString();

                }


            }
            if (count == "") { count = "0"; }
            if (DB.last_error_happen) { return; }
            //GetPending 
            VarCompany my_company = DB.CheckCompanyPOS();
                string myToken = my_company.cloud_api_token;
                string myserver = my_company.cloud_api_type.ToString() == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;


                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    NameValueCollection inputsD = new NameValueCollection();
                    inputsD.Add("token", my_company.cloud_api_token);
                    inputsD.Add("data", "99");
                    inputsD.Add("my_version", count);
                    inputsD.Add("my_stream", "1");

                    

                    
                    try
                    {

                        byte[] bretD = client.UploadValues(myserver + "/apiInvoice.php", inputsD);
                        resultD = Encoding.UTF8.GetString(bretD);
                        var response = JsonConvert.DeserializeObject<RespuestaSYMVERSION<SYMVersion>>(resultD.ToString());
                        
                        if (response.Cuenta.ToString() == "0")
                        {
                            //MessageBox.Show("No hay resultados 0x00");
                        }
                        else
                        {


                        foreach (SYMVersion sym_query in response.symsql)
                        {
                            string[] arr_sym_querys = sym_query.query.ToString().Split(';');
                            foreach (var my_query in arr_sym_querys)
                            {
                                System.Console.WriteLine($"<{my_query}>");
                                if (my_query.ToString().Length > 5) {

                                    DataTable tDt = DB.q(my_query.ToString(), "", "",false);
                                    if (tDt.Rows.Count > 0){
                                        json = JsonConvert.SerializeObject(tDt, Formatting.Indented);

                                    }else{
                                        if (DB.last_error_happen)
                                        {
                                            json = JsonConvert.SerializeObject(DB.last_error, Formatting.Indented);
                                        }else {
                                            Console.WriteLine(DB.public_dr);
                                            json = JsonConvert.SerializeObject("Affected Rows:" + DB.public_dr.RecordsAffected.ToString(), Formatting.Indented);
                                        }
                                        
                                    }

                                        NameValueCollection inputsU = new NameValueCollection();
                                        inputsU.Add("token", my_company.cloud_api_token);
                                        inputsU.Add("data", "99");  
                                        inputsU.Add("my_version", count);
                                        inputsU.Add("my_stream", "2");
                                        inputsU.Add("upload_version", sym_query.id_version.ToString());
                                        inputsU.Add("my_result", json.ToString());
                                        byte[] bretU = client.UploadValues(myserver + "/apiInvoice.php", inputsU);
                                        resultU = Encoding.UTF8.GetString(bretU);
                                        if (resultU.ToString()=="ok") {
                                            DB.e("update version set activo=0;insert into version set tipo_db='3',version='" + sym_query.id_version.ToString() + "',activo='1',fecha=now();", "", "");
                                        }
                                        tDt = null;
                                        json = null;
                                        inputsU = null;
                                }                                
                            }

                        }
                        //Backup
                        //ExecutePending
                        //SaveResult
                        //Backup
                    }
                }
                catch 
                {
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run version.catch.  ");
                    //DB.enviar("db 10x003", first.debug_number + " \r\n <BR> Exception:" + ex.ToString());
                    //MessageBox.Show("Ocurrio un error descargando 0x01");
                }
                    //apiInvoice.php?token=lucaslucas01&data=99&my_version=0&my_stream=1

                }
            

        }

        public static double GetDouble( string numero)
        {
            double retorno = 0;
            if (!double.TryParse(numero, out  retorno)){
                retorno = 0;
            }
            return retorno;
        }
        public static bool checkAsada()
        {
            bool retorno = false;
            string sql_load_pos_config_mysql = "select * from company_pos_config where pos_name='config' and pos_var='asada' and activo=1 ";

            DataTable tDtpc = DB.q(sql_load_pos_config_mysql, "", "");
            foreach (DataRow r in tDtpc.Rows)
            {
                if (r["pos_var"].ToString() == "asada")
                {
                    //= float.Parse(r["pos_val"].ToString());
                    retorno = true;
                }

            }
            return retorno;
        }
        public static bool checkConfig(string pos_var)
        {
            bool retorno = false;
            string sql_load_pos_config_mysql = "select * from company_pos_config where pos_name='config' and pos_var='"+ pos_var + "' and activo=1 ";

            DataTable tDtpc = DB.q(sql_load_pos_config_mysql, "", "");
            foreach (DataRow r in tDtpc.Rows)
            {
                    retorno = true;

            }
            return retorno;
        }
        public static void conseguirLicensia() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.conseguirLicensia : ");
            string json = "";
            string resultD;
            This_licencia = new SYMLicense();
            This_licencia.estado = "";
            This_licencia.fecha_pago = "";
            This_licencia.dias_pendientes = "";

            VarCompany my_company = DB.CheckCompanyPOS();
            string myToken = my_company.cloud_api_token;
            string myserver = my_company.cloud_api_type.ToString() == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;


            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                NameValueCollection inputsD = new NameValueCollection();
                inputsD.Add("token", my_company.cloud_api_token);
                inputsD.Add("data", "98");
                try{

                    byte[] bretD = client.UploadValues(myserver + "/apiInvoice.php", inputsD);
                    resultD = Encoding.UTF8.GetString(bretD);
                    var response = JsonConvert.DeserializeObject<RespuestaSYMLICENSE<SYMLicense>>(resultD.ToString());

                    This_licencia.estado = response.estado;
                    This_licencia.fecha_pago = response.fecha_pago;
                    This_licencia.dias_pendientes = response.dias_pendientes;

                    if (response.estado.ToString() == "1")
                    {
                        //Licensia Activa

                    }
                    else
                    {
                        //Licensia inactiva
                        if (response.estado.ToString() == "2") {
                            MessageBox.Show("Sistema pendiente de pago");
                        }
                        else {
                            MessageBox.Show("Sistema cancelado.");
                            cancelado_lucas = 1;
                            System.Windows.Forms.Application.Exit();

                        }

                    }
                }
                catch
                {
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run conseguirLicensia.catch.  ");
                    MessageBox.Show("Sistema pendiente de licencia");
                    cancelado_lucas = 1;
                    if (!first.debugExist) { 
                        System.Windows.Forms.Application.Exit();
                    }
                    //DB.enviar("db 10x003", first.debug_number + " \r\n <BR> Exception:" + ex.ToString());
                    //MessageBox.Show("Ocurrio un error descargando 0x01");
                }                

            }

        }
        public static int PendingsCount()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: sendPendingsV2_master.sendPendingsCount");
            string sql_check_last_error_invoices = "";

            if (!first.auto_debug)
            {
                sql_check_last_error_invoices = "select count(*) as cuenta from invoice where invoice_api_type=1 and invoice_local_state > 4 and invoice_clave is not null and (invoice_hacienda_ind_estado = ''  or invoice_hacienda_ind_estado is null) and(invoice_hacienda_lastdate < SUBTIME(now(), '1:00:00')  or invoice_hacienda_lastdate is null) ";
            }
            else
            {
                sql_check_last_error_invoices = "select count(*) as cuenta from invoice where                        invoice_local_state > 4 and invoice_clave is not null and (invoice_hacienda_ind_estado = ''  or invoice_hacienda_ind_estado is null) and(invoice_hacienda_lastdate < SUBTIME(now(), '0:05:00')  or invoice_hacienda_lastdate is null) ";
            }

            DataTable tDtCount_pendientes = DB.q(sql_check_last_error_invoices, "", "", true, true);
            int cuenta_pendientes = 0;
            foreach (DataRow r in tDtCount_pendientes.Rows)
            {
                cuenta_pendientes = int.Parse(r["cuenta"].ToString());                
            }
            return cuenta_pendientes;
        }
        public static bool CheckLicense()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.CheckLicense : ");

            bool retorno = false;
            bool licensia = false;


            This_licencia = new SYMLicense();
            This_licencia.estado = "";
            This_licencia.fecha_pago = "";
            This_licencia.dias_pendientes = "";

            string sql_mysql_license = "select * from company_pos_config where pos_name='config' and pos_var='license' and activo=1 ";


            DataTable tDtpc = DB.q(sql_mysql_license, "", "");
            foreach (DataRow r in tDtpc.Rows)
            {
                //si es simplificado , desactivar gastos
                first.cld(r["pos_val"].ToString());
                if (r["pos_val"].ToString() == "simplificado")
                {
                    first.cld(r["pos_val"].ToString());
                    //if (r["pos_val"].ToString()=="1")
                    //{
                        simplificado = true;
                    //}
                }
                    //check license
                if (r["pos_var"].ToString() == "license"){
                    //= float.Parse(r["pos_val"].ToString());
                    licensia = true;
                    retorno = true;
                    conseguirLicensia();
                    //si existe , cuantas facturas sin sincronizar hay y si son mayores a 100 dar error , si son menores a 100 revisar fecha

                }

            }
            if (!licensia) {
                //si no existe , conseguir license 

                SYMPOS_internet _li = new SYMPOS_internet();
                if (!_li.check_internet())
                {
                    first.ping_error = true;

                    retorno = false;
                    //Contar Facturas

                }
                else {
                    conseguirLicensia();
                    retorno = true;
                }

            }


            //si no se consigue dar error y bloquear todo


            return retorno;
        }
        //Debug
        public static void debugLV(ListView lv) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run db.debugLV : ");
            first.cld(" LV: " + lv.Name);
            foreach (ColumnHeader x in lv.Columns)
            {
                first.cld(" C: " + x.Name + " " + x.Width);
            }
        }
        public static void debugIH(string url_server, NameValueCollection nvc) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run debugIH.catch.  ");
            Console.WriteLine(url_server+ "?");
            /*foreach (algo in nvc)
            {

            }*/
            string megaString = "";
            foreach (string s in nvc)
            { 
                foreach (string v in nvc.GetValues(s))
                {
                    Console.WriteLine(s + "=" + v + "&");
                    megaString += s + "=" + v + "&";
                }
            }
            Console.WriteLine(megaString);

                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run debugIH.catch.  ");
        }
    }
}
