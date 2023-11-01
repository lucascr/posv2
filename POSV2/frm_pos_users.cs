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
    public partial class frm_pos_users : Form
    {
        public frm_pos_users()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run users.frm_pos_users : ");

            InitializeComponent();
            DB.CreateloadLanguage(mnuS1, this);

            LoadAccess();
            clearTxtUser();
            LoadLvUsers();
        }
        public void LoadAccess() {
            //DB.debugLV(lvAL1);

            DB.LoadState(ref cmb_users_state);

            DB.LoadState(ref cmb_users_search_state);
            cmb_users_search_state.Items.Add(new cbi(DB.get_language("var_all"), ""));

            lv_users_access_list.Columns.Clear();
            lv_users_access_list.Columns.Add("",20);
            lv_users_access_list.Columns.Add("Nivel",160);

            lv_users_access_list.Items.Clear();

            cmb_users_search_access_level.Items.Clear();            
            cmb_users_search_access_level.Items.Add(new cbi(DB.get_language("var_all"), ""));
            cmb_users_search_access_level.SelectedIndex = 0;

            string sql_mysql = "select * from users_access_levels";
            DataTable tDt = DB.q(sql_mysql, sql_mysql, sql_mysql);
            if (tDt.Rows.Count > 0)
            {
                foreach (DataRow r in tDt.Rows)
                {
                    string[] row = { r["access_level"].ToString(), DB.get_language ( r["access_level_var"].ToString())};
                    var lvi = new ListViewItem(row);
                    lv_users_access_list.Items.Add(lvi); 

                    cmb_users_search_access_level.Items.Add(new cbi(DB.get_language( r["access_level_var"].ToString()), r["access_level"].ToString()));
                }
            }
        }
        private void clearTxtUser()
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.clearTxtUser : ");
            txt_users_username.Text = "";
            txt_users_password.Text = "";
            txt_users_initials.Text = "";
            txt_users_fullname.Text = "";
            txt_users_email.Text = "";
        }
        private void LoadUserbyId(string user_id)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.LoadUserbyId : ");
            string sql_load_users_mysql = "select * from users where user_id=" + user_id;

            DataTable tDt = DB.q(sql_load_users_mysql, sql_load_users_mysql, sql_load_users_mysql);

            if (tDt.HasErrors)
            {
                MessageBox.Show(DB.get_language("var_err") + " > " + "-Error loading");
            }
            else
            {
                clearTxtUser();
                //DB.sel_combo(ref cmb_company_id_type, tDt.Rows[0]["user_id"].ToString());

                txt_users_initials.Text = tDt.Rows[0]["user_initials"].ToString();
                txt_users_fullname.Text = tDt.Rows[0]["user_fullname"].ToString();

                txt_users_email.Text = tDt.Rows[0]["user_email"].ToString();

                txt_users_username.Text = tDt.Rows[0]["user_username"].ToString();
                //txt_users_password.Text = tDt.Rows[0]["user_password"].ToString();

                DB.sel_combo(ref cmb_users_state, tDt.Rows[0]["user_active"].ToString());
                DB.sel_lv(ref lv_users_access_list, tDt.Rows[0]["user_access_level"].ToString());

                lbl_edit_user_id.Text= tDt.Rows[0]["user_id"].ToString(); 
                btn_users_update.Enabled = true;

            }


        }
        public void LoadLvUsers()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run config.LoadLvUsers : ");
            DB.debugLV(lv_users_search_results);
            //Load Users
            lv_users_search_results.Items.Clear();
            lv_users_search_results.Columns.Clear();
            lv_users_search_results.Columns.Add("Id", 24);
            lv_users_search_results.Columns.Add(DB.get_language("lbl_users_fullname"), 185);
            lv_users_search_results.Columns.Add(DB.get_language("lbl_users_username"), 90);
            lv_users_search_results.Columns.Add(DB.get_language("lbl_users_email"), 130);
            lv_users_search_results.Columns.Add(DB.get_language("lbl_users_initials"), 55);
            lv_users_search_results.Columns.Add(DB.get_language("lbl_users_access_level"), 380);
            lv_users_search_results.Columns.Add(DB.get_language("lbl_state"), 95);
            string sql_w= " where ";
            string sql_a = "";
            string sql_s = "";
            if (txt_users_search_all.Text.Length > 0) {
                string srh = txt_users_search_all.Text.ToString();

                sql_s  += sql_w+ sql_a + " (user_username like '%" + srh + "%'|| user_initials like '%" + srh + "%'|| user_fullname like '%" + srh + "%'|| user_email like '%" + srh + "%')";
                sql_w = "";
                sql_a = " and ";
            }
            if (((cbi)cmb_users_search_state.SelectedItem).HiddenValue != "")
            {
                sql_s += sql_w + sql_a + " user_active = '" + ((cbi)cmb_users_search_state.SelectedItem).HiddenValue + "'";
                sql_w = "";
                sql_a = " and ";
            }

            if (((cbi)cmb_users_search_access_level.SelectedItem).HiddenValue != "")
            {
                sql_s += sql_w + sql_a + " user_access_level like '%" + ((cbi)cmb_users_search_access_level.SelectedItem).HiddenValue + "%'";
                sql_w = "";
                sql_a = " and ";                
            }
            string sql_load_users_mysql = "select * from users ";

            DataTable tDt = DB.q(sql_load_users_mysql+ sql_s, sql_load_users_mysql, sql_load_users_mysql);
            //TODOs
            //user_access_level

            foreach (DataRow r in tDt.Rows)
            {
                string[] row = { r["user_id"].ToString(), r["user_fullname"].ToString(), r["user_username"].ToString(), r["user_email"].ToString(), r["user_initials"].ToString(), DB.get_lv(lv_users_access_list, r["user_access_level"].ToString()), DB.getState(r["user_active"].ToString()) };
                var lvi = new ListViewItem(row);
                lv_users_search_results.Items.Add(lvi);
            }
        }
        private void frm_pos_users_Load(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run users.frm_pos_users_Load : ");
            
        }
        private void txt_users_username_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt_users_fullname_TextChanged(object sender, EventArgs e)
        {

        }
        private void btn_users_save_Click(object sender, EventArgs e)
        {
            saveUser("1");
        }
        private void saveUser(string crud) {
            DB.debugLV(lv_users_search_results);
            #region Verification

            bool errores = false;
            string allErrors = "";
            DB.check_text(ref txt_users_fullname, "lbl_users_fullname", ref errores, ref allErrors, 1, 80);
            DB.check_text(ref txt_users_initials, "lbl_users_initials", ref errores, ref allErrors, 1, 12);

            DB.check_text(ref txt_users_username, "lbl_users_username", ref errores, ref allErrors, 1, 80);

            if (crud != "2")
            {
                DB.check_text(ref txt_users_password, "lbl_users_password", ref errores, ref allErrors, 4, 80);
            }
            

            DB.check_text_email(ref txt_users_email, ref errores, ref allErrors);

            #endregion
            #region AccessList
            string access_list = "";
            string cc = "";
            foreach (ListViewItem Xvi in lv_users_access_list.Items)
            {
                if (Xvi.Checked)
                {
                    access_list += cc + Xvi.Text;
                    cc = "-";
                }
            }
            #endregion
            #region Users
            if (errores)
            {
                MessageBox.Show(DB.get_language("var_err") + " > " + allErrors);
            }
            else
            {


                string sql_save_user_mysql = "";
                string sql_w = "";

                if (crud == "1")
                {
                    sql_save_user_mysql = "insert into users set user_cd=now() ";
                    sql_w = " ";
                }
                else
                {
                    sql_save_user_mysql = "update users set user_ud=now() ";
                    sql_w = " where user_id='" + lbl_edit_user_id.Text.ToString() + "'";
                }

                sql_save_user_mysql += " ,user_username = '" + txt_users_username.Text.ToString() + "'";
                if (txt_users_password.Text.Length > 0) {
                    sql_save_user_mysql += " ,user_password = md5('" + txt_users_password.Text.ToString() + "')";
                }

                sql_save_user_mysql += " ,user_initials = '" + txt_users_initials.Text.ToString() + "'";
                sql_save_user_mysql += " ,user_fullname = '" + txt_users_fullname.Text.ToString() + "'";
                sql_save_user_mysql += " ,user_email = '" + txt_users_email.Text.ToString() + "'";

                sql_save_user_mysql += " ,user_active = " + ((cbi)cmb_users_state.SelectedItem).HiddenValue;// cmb_company_type.SelectedItem.ToString();

                sql_save_user_mysql += " ,user_access_level = '" + access_list.ToString() + "'";

                DB.e(sql_save_user_mysql + sql_w, sql_save_user_mysql, sql_save_user_mysql);
                if (DB.conectado)
                {
                    MessageBox.Show(DB.get_language("var_ok"));
                    LoadLvUsers();
                    btn_users_update.Enabled = false;
                    lbl_edit_user_id.Text = "";
                }
                else {
                    MessageBox.Show(DB.get_language("var_err"));
                }
            }
            #endregion
        }
        private void frm_pos_users_Shown(object sender, EventArgs e)
        {
            DB.specialRun = "callback_users";
        }
        private void lv_users_DoubleClick(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(DB.get_language("var_edit"), "Config", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                LoadUserbyId(lv_users_search_results.SelectedItems[0].Text.ToString());
            }
            else if (result == DialogResult.No)
            {
                //do something else
            }

        }
        private void btn_users_update_Click(object sender, EventArgs e)
        {
            saveUser("2");
        }
        private void lv_users_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btn_users_search_Click(object sender, EventArgs e)
        {
            LoadLvUsers();
        }
        private void txt_user_search_all_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                LoadLvUsers();
            }
        }
    }
}
