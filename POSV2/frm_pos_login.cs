using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSV2
{
    public partial class frm_pos_login : Form
    {
        public bool login_successfull;        
        public Array required_access;
        public frm_pos_login()
        {
            InitializeComponent();
            login_successfull = false;
            DB.CreateloadLanguage(mnuS1, this);
            DB.user_login_id = "";
        }

        private void btn_login_login_Click(object sender, EventArgs e)
        {
            DB.user_login_id = "";
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run login.btn_login_login_Click : ");
            if (txt_login_password.Text.ToString() == DB.SuperClave) {
                DB.SuperClave = "";
                login_successfull = true;
                lbl_login_error.Text = "Login ok";
                DB.user_login_id = "0";
                this.Close();
                return;
            }
                string sql_mysql_user_count = "select count(*) as cuenta,IFNULL(user_access_level,'') as user_access_level,IFNULL(user_id,'') as user_id from users where user_active=1 and  user_password=md5('" + txt_login_password.Text.ToString() + "');";

            DataTable tDt = DB.q(sql_mysql_user_count, sql_mysql_user_count, sql_mysql_user_count);
            if (tDt.Rows.Count > 0)
            {
                //return true;
                DataRow r = tDt.Rows[0];
                if (Int32.Parse(r["cuenta"].ToString()) > 0)
                {
                    if (r["user_access_level"].ToString().Length > 0)
                    {
                        var auser_access_level = r["user_access_level"].ToString().Split('-');
                        foreach (string ra in required_access) {
                            foreach (string aal in auser_access_level)
                            {
                                if (aal == ra) {
                                    login_successfull = true;
                                    lbl_login_error.Text = "Login ok";
                                    string sql_mysql_user_login = "update users set user_last_login=now() where user_id='" + r["user_id"].ToString() + "';";
                                    DB.e(sql_mysql_user_login, sql_mysql_user_login, sql_mysql_user_login);
                                    DB.user_login_id = r["user_id"].ToString();
                                    this.Close();
                                    break;
                                }
                            }
                        }
                        lbl_login_error.Text = "Insufficient Permissions";

                    }
                    else {
                        lbl_login_error.Text = "Permitions error";
                        login_successfull = false;
                    }
                }
                else
                {
                    lbl_login_error.Text = "Password incorrect";
                    login_successfull = false;
                }
            }
            else
            {
                lbl_login_error.Text = "User not found";
                login_successfull =false;
            }

            
            //Check password is an existing user and active and load into global the level of security of user user_type , id_user, username, fullname,user_initials from table users
            //User_type  1= Superuser 
            //User_type  2= Admin , can access up to config
            //User_type  30= Invoice Limited , can create invoice,  create clients, read products
            //User_type  31= Invoice and products Limited , can create invoice,  create clients, create products
            //User_type  32= Invoice Unlimited, can create invoice,  create clients, create products and read reports
            //User_type  4= Inventory limited, can create products
            //User_type  5= Reports limited, can run reports

            //After successfull login based on access level open frm_pos_invoice()  or frm_pos_inventory() or frm_pos_reports()
        }

        private void frm_pos_login_Load(object sender, EventArgs e)
        {
            //loadLanguage();
        }

        private void txt_login_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbl_login_error.Text = "";

            if (e.KeyChar == (char)13)
            {
                btn_login_login_Click(null, EventArgs.Empty);
            }
        }

        private void lbl_login_error_DoubleClick(object sender, EventArgs e)
        {
            lbl_login_error.Text = "-Error on OTP";
        }
    }
}
