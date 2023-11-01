
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace POSV2
{
    class first{
        private static first keysconect;
        public static bool auto_debug = false;
        public static bool auto_debug_encriptado = true;
        public static float debug_number = 0;
        public static string pos_version= "0";
        public Form activeFrm;
        public Form mainFrm;
        string str_config_db_database;
        string str_config_db_host;
        string str_config_db_username;
        string str_config_db_password;
        string str_config_db_type;
        string str_config_db_port;
        string str_config_language;
        string str_install_pass;

        string str_debug_login;        
        string str_debug_language;

        string str_pos_sucursal;
        string str_pos_terminal;

        private string myp = "lucas";
        
        public static bool has_keys;
        public static bool debugExist = false;
        public static bool debugNetExist = false;
        
        public static bool debugServerDown = false;

        public static bool ping_error = true;

        private first() {}//private constructor so that it cannot be instantiated outside this class
        public static first GetInstance(){
            first.checkDebug();
            if (keysconect == null) //check if  an instance has been created else  can create a new instance
            {
                keysconect = new first();
            }
            return keysconect;
        }
        public static void checkDebug() {
            //if (File.Exists(@"c:\debug")) {
            if (Directory.Exists(@"c:\debug")){                
                first.debugExist = true;
                ///DB.enviar("001x01", "checkDebug true" + "\r\n Computer :" + Environment.MachineName.ToString());
            }
            if (Directory.Exists(@"c:\debugnet"))
            {                
                first.debugNetExist = true;
                //DB.enviar("001x02", "checkDebugNet true" + "\r\n Computer :" + Environment.MachineName.ToString());
            }
            
            if (Directory.Exists(@"c:\debug\lucas")){
                
                first.auto_debug = true;
                first.auto_debug_encriptado = false;
                //DB.enviar("001x03", "checkDebug true lucas true" + "\r\n Computer :" + Environment.MachineName.ToString());
            }                
        }
        public string get_myp() { return myp; }
        public string get_str_config_db_type() {return str_config_db_type;}
        public string get_str_config_db_host() {return encryptdecrypt.Decrypt(str_config_db_host, myp);}
        public string get_str_config_db_username() {return encryptdecrypt.Decrypt(str_config_db_username, myp);}
        public string get_str_config_db_password() {return encryptdecrypt.Decrypt(str_config_db_password, myp);}
        public string get_str_config_db_database() {return encryptdecrypt.Decrypt(str_config_db_database, myp);}
        public string get_str_config_db_port() { return encryptdecrypt.Decrypt(str_config_db_port, myp); }
        
        public string get_str_install_pass() { return encryptdecrypt.Decrypt(str_install_pass, myp); }

        public string get_str_debug_login() { return encryptdecrypt.Decrypt(str_debug_login, myp); }
        public string get_str_debug_language() { return encryptdecrypt.Decrypt(str_debug_language, myp); }

        public void saveLanguageKeys(string language_var)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS", "config_language", language_var);
        }
        public string getLanguageKeys()
        {
            try
            {
                str_config_language = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS", "config_language", "NULL").ToString();
            if (str_config_language == null)
            {
                return "";
            }else {
                return str_config_language;
            }
            }
            catch (Exception ex)
            {
                
                first.cld("Catch 0");
                first.cld("" + ex.Message.ToString());
                return "language_english";
            }
        }
        public string getKey(string skey)
        {
            string get_key;
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run f.getKey: ");
            try{
                get_key = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + str_config_db_type, skey, "").ToString();
                if (get_key == null){
                    first.cld("key null 0 " + skey);
                    return "0";
                }else {
                    first.cld(encryptdecrypt.Decrypt(get_key, myp));
                    return encryptdecrypt.Decrypt(get_key, myp);
                }
            }catch (Exception ex){
                first.cld("Catch 0");
                first.cld("" + ex.Message.ToString());
                return "0";
            }
        }
        public string checkKeys() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run f.checkKeys : ");
            has_keys = false;
            try {
                str_config_db_type = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS", "config_db_type", "NULL").ToString();
                if (str_config_db_type == null) {//str_config_db_type.ToString() == "NULL" ||
                    first.cld("str_config_db_type null 0");
                    return "0";
                } else {
                    str_config_db_database = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\"+ str_config_db_type, "config_db_database", "NULL").ToString();
                    str_config_db_port = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + str_config_db_type, "config_db_port", encryptdecrypt.Encrypt("3306", myp)).ToString();
                    str_config_db_host = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + str_config_db_type, "config_db_host", "NULL").ToString();
                    str_config_db_username = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + str_config_db_type, "config_db_username", "NULL").ToString();
                    str_config_db_password = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + str_config_db_type, "config_db_password", "NULL").ToString();
                    str_install_pass = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + str_config_db_type, "config_install", "NULL").ToString();
                    
                    str_debug_login = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + str_config_db_type, "debug_login", encryptdecrypt.Encrypt("Login", myp)).ToString();                    
                    str_debug_language = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + str_config_db_type, "debug_language", encryptdecrypt.Encrypt("Normal", myp)).ToString();

                    str_pos_sucursal = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + str_config_db_type, "pos_sucursal", "NULL").ToString();
                    str_pos_terminal = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Socialymas.com\SYMPOS\" + str_config_db_type, "pos_terminal", "NULL").ToString();

                    if (str_config_db_database.Length > 0 && str_config_db_database != "NULL" )
                    {
                        has_keys = true;
                        first.cld("1");
                        return "1";
                    }else {
                        return "0";
                    }      
                    
                }
            }catch (Exception ex) {
                first.cld("Catch 0");
                first.cld(""+ex.Message.ToString());
                return "0";
            }
        }
        public string conectDBMysql() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run f.conectDBMysql : ");
            string err = "";
            if (checkKeys() == "1")
            {
                DB myDB = DB.GetInstance();
                Application.DoEvents();
                
                err = myDB.conectar(str_config_db_type, encryptdecrypt.Decrypt(str_config_db_host, myp), encryptdecrypt.Decrypt(str_config_db_username, myp), encryptdecrypt.Decrypt(str_config_db_password, myp), encryptdecrypt.Decrypt(str_config_db_database, myp), encryptdecrypt.Decrypt(str_config_db_port, myp));
                Application.DoEvents();
            }
            else {
                err = "No Keys";
            }
            first.cld(err);
            return err;
        }

        public void InitiaPRGTestDBMysql() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run f.InitiaPRGTestDBMysql : ");
            string err = conectDBMysql();
            if (err.ToString() ==   "1"){   
                if (DB.checkCompany()){
                    first.cld("APP RUN Invoice");
                    //Application.Run(new frm_pos_main("Invoice"));

                    Application.Run(new frm_pos_main("Main")); //Original
                    //Application.Run(new frm_pos_main("Gastos"));
                    //Application.Run(new frm_pos_main("Users"));
                    //Application.Run(new frm_pos_main("Clients"));
                    //Application.Run(new frm_pos_main("Products"));
                }
                else {
                    first.cld("APP RUN Config");
                    Application.Run(new frm_pos_main("Config"));
                }
            }
            else
            {
                first myFirst = first.GetInstance();
                if (has_keys)
                {
                    first.cld("APP RUN Main");
                    Application.Run(new frm_pos_main("Main", err.ToString()));
                }
                else
                {
                    first.cld("APP RUN Config");
                    Application.Run(new frm_pos_main("Config", err.ToString()));
                }

                //Application.Run(new frm_pos_main("Config"));
                //Application.Run(new frm_pos_config(err.ToString()));
                /*frm_pos_config frmMain = new frm_pos_config(err.ToString());
                frmMain.Show();*/
                //lbl_config_db_errors.Text = err.ToString();
            }
        }
        public static void cld(object wl){
            if (debugExist) {
                    debug_number++;
                    /*debug_client_c client = new debug_client_c();
                    client.enviar(wl.ToString());*/
                    DateTime now = DateTime.Now;

                    
                    string path = @"c:\debug\" + now.ToString("yyyyMMdd") +".txt";
                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("--Start--");
                        }
                    }

                    // This text is always added, making the file longer over time
                    // if it is not deleted.
                    try
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            if (auto_debug_encriptado){
                                first myFirst = first.GetInstance();
                                sw.WriteLine(encryptdecrypt.Encrypt(debug_number + " - " + wl.ToString(), myFirst.get_myp()).ToString() );
                            }else {
                                sw.WriteLine(debug_number + " - " + wl.ToString());
                            }
                            
                        }
                    }
                    catch {
                    }                    

            }
            Console.WriteLine(wl.ToString());
            if (debugExist)
            {
                try
                {
                    first myFirst = first.GetInstance();
                    myFirst.activeFrm.Text = debug_number.ToString();

                }
                catch { }
            }
            if (debugNetExist && !debugServerDown)
            {
                /*debug_client_c client = new debug_client_c();
                client.enviar(wl.ToString());*/
            }
        }
        public static void cldNVC(NameValueCollection wl) {
            foreach (string key in wl.AllKeys) // <-- No duplicates returned.
            {
                Console.WriteLine(key + " > " + wl.Get(key).ToString());
            }
        }
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
    }
}
