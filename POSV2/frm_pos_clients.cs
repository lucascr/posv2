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
    public partial class frm_pos_clients : Form
    {
        bool module_asada = false;
        public frm_pos_clients()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run clients.frm_pos_clients : ");
            InitializeComponent();
            DB.CreateloadLanguage(mnuS1, this);

            
            DB.loadCmbIdType(ref cmb_clients_id_type,2);

            DB.LoadProvince(ref cmb_clients_province, ref cmb_clients_canton, ref cmb_clients_district,2);
            clearTxtClient();

            //ASADA
            if (DB.checkAsada()) {
                module_asada = true;
                grp_asada.Visible = true;
                LoadAsadaTipo();
            }
           // LoadLvClients();
        }
        #region ASADA
        private void LoadAsadaTipo() {

            cmb_clients_asada_tipo.Items.Clear();
            string sql_load_pos_config_mysql = "select * from asada_tipo_tarifa order by asada_titulo ";

            DataTable tDtpc = DB.q(sql_load_pos_config_mysql, "", "");
            foreach (DataRow r in tDtpc.Rows)
            {
                cmb_clients_asada_tipo.Items.Add(
                    new cba(r["asada_titulo"].ToString(), r["asada_consumo_fija_id"].ToString(), r["asada_monto_fija"].ToString(), r["asada_dom_emp_id"].ToString(), r["id_asada_tipo_tarifa"].ToString()));
            }
        }
        private string getAsadaTipo(string id_asada_tipo_tarifa) {

            string ret= "";
            foreach (var X in cmb_clients_asada_tipo.Items)
            {
                first.cld(" s :" + X.ToString());
                if (id_asada_tipo_tarifa == ((cba)X).hv_idTarifa ) //CBA Asadas
                {
                    ret = ((cba)X).ToString();
                }
            }
            return ret;
        }
        #endregion ASADA
        private void LoadClientbyId(string client_id)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run clients.LoadClientbyId : ");
            string sql_load_clients_mysql = "select * from clients where client_id=" + client_id;
            
            DataTable tDt = DB.q(sql_load_clients_mysql, "", "");

            if (tDt.HasErrors)
            {
                MessageBox.Show(DB.get_language("var_err") + " > " + "-Error loading client");
            }
            else
            {
                clearTxtClient();

                txt_clients_name.Text = tDt.Rows[0]["client_name"].ToString();

                txt_clients_commercial_name.Text = tDt.Rows[0]["client_commercial_name"].ToString();

                txt_clients_email.Text = tDt.Rows[0]["client_email"].ToString();

                DB.sel_combo(ref cmb_clients_id_type, tDt.Rows[0]["client_identification_type"].ToString());
                txt_clients_identification.Text = tDt.Rows[0]["client_identification"].ToString();


                txt_clients_phone_country_number.Text = tDt.Rows[0]["client_phone_country_number"].ToString();
                txt_clients_phone_number.Text = tDt.Rows[0]["client_phone_number"].ToString();

                DB.sel_combo(ref cmb_clients_province, tDt.Rows[0]["client_addr_province"].ToString());
                DB.sel_combo(ref cmb_clients_canton, tDt.Rows[0]["client_addr_canton"].ToString(),"3");
                DB.sel_combo(ref cmb_clients_district, tDt.Rows[0]["client_addr_district"].ToString());

                txt_clients_full_address.Text = tDt.Rows[0]["client_addr_senas"].ToString();

                lbl_edit_client_id.Text = tDt.Rows[0]["client_id"].ToString();


                txt_clients_whastapp.Text = tDt.Rows[0]["client_phone_whatsapp"].ToString();
                DB.sel_combo(ref cmb_clients_credit_tipo, tDt.Rows[0]["client_credit_type"].ToString());
                txt_clients_credit_maximo.Text = tDt.Rows[0]["client_credit_amount"].ToString();
                txt_clients_credit_days.Text = tDt.Rows[0]["client_credit_days"].ToString();

                btn_clients_update.Enabled = true;
                if (module_asada) {
                    string sql_load_clients_asada_mysql = "select * from asada_cli_info where client_id=" + client_id;

                    DataTable tDtAsada = DB.q(sql_load_clients_asada_mysql, "", "");

                    if (tDtAsada.Rows.Count > 0)                    {
                        foreach (DataRow r in tDtAsada.Rows)                        {
                            DB.sel_combo(ref cmb_clients_asada_tipo, r["id_asada_tipo_tarifa"].ToString(), "4");
                            txt_client_asada_lectura.Text = r["asada_primer_lectura"].ToString();
                            txt_client_asada_medidor.Text = r["asada_medidor"].ToString();
                        }
                    }
                }
            } //Cliente

        }
        public void LoadClientsCmb()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run clients.loadCmb : ");

            DB.loadCmbIdType(ref cmb_clients_search_id_type, 3);
            cmb_clients_search_id_type.SelectedIndex = 0;



            cmb_clients_credit_tipo.Items.Clear();
            cmb_clients_credit_tipo.Items.Add(new cbi("Sin Crédito", "0"));
            cmb_clients_credit_tipo.Items.Add(new cbi("Con Crédito", "1"));
            cmb_clients_credit_tipo.SelectedIndex = 0;

            cmb_clients_action.Items.Clear();
            cmb_clients_action.Items.Add(new cbi(DB.get_language("cmb_action_select"), ""));
            cmb_clients_action.Items.Add(new cbi("Activar los Seleccionados", "1"));
            cmb_clients_action.Items.Add(new cbi("Desactivar los Seleccionados", "2"));
            cmb_clients_action.SelectedIndex = 0;
        }
        private void clearTxtClient()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run clients.clearTxtUser : ");

            LoadClientsCmb();
            txt_clients_name.Text = "";

            cmb_clients_id_type.SelectedIndex = 0;
            txt_clients_identification.Text = "";

            txt_clients_email.Text = "";
            txt_clients_commercial_name.Text = "";

            txt_clients_phone_country_number.Text = "506";
            txt_clients_phone_number.Text = "";
            txt_clients_whastapp.Text = "";

            cmb_clients_province.SelectedIndex = 0;
            txt_clients_full_address.Text = "";

            //ASADA
            txt_client_asada_medidor.Text = "";
            txt_client_asada_lectura.Text = "";
        }
        public void LoadLvClients()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run clients.LoadLvClients : ");
            DB.debugLV(lv_clients_serach_results);

            

            //Load Users
            lv_clients_serach_results.Items.Clear();
            lv_clients_serach_results.Columns.Clear();

            lv_clients_serach_results.Columns.Add("Id", 24);
            lv_clients_serach_results.Columns.Add(DB.get_language("lbl_clients_identification_type"), 35);
            lv_clients_serach_results.Columns.Add(DB.get_language("lbl_clients_identification"), 95);
            lv_clients_serach_results.Columns.Add(DB.get_language("lbl_clients_name"), 210);
            lv_clients_serach_results.Columns.Add(DB.get_language("lbl_clients_email"), 145);
            lv_clients_serach_results.Columns.Add(DB.get_language("lbl_clients_phone_number"), 75);
            lv_clients_serach_results.Columns.Add(DB.get_language("lbl_clients_whatsapp"), 75);
            if (module_asada) {
                lv_clients_serach_results.Columns.Add(DB.get_language("lbl_client_asada_tipo"), 121);
                lv_clients_serach_results.Columns.Add(DB.get_language("lbl_client_asada_medidor"), 65);
                lv_clients_serach_results.Columns.Add(DB.get_language("lbl_client_asada_lectura"), 60);
                lv_clients_serach_results.Columns.Add(DB.get_language("lbl_client_asada_lectura"), 60);
                
            }
                string sql_w = " where ";
            string sql_a = "";
            string sql_s = "";

            if (txt_clients_search_all.Text.Length > 0)
            {
                string srh = txt_clients_search_all.Text.ToString();

                sql_s += sql_w + sql_a + " (client_name like '%" + srh + "%'|| client_identification like '%" + srh + "%'|| client_commercial_name like '%" + srh + "%'|| client_email like '%" + srh + "%')";
                sql_w = "";
                sql_a = " and ";
            }

            
            if (((cbi)cmb_clients_search_id_type.SelectedItem).HiddenValue != "")
            {
                sql_s += sql_w + sql_a + " client_identification_type = '" + ((cbi)cmb_clients_search_id_type.SelectedItem).HiddenValue + "'";
                sql_w = "";
                sql_a = " and ";
            }

            sql_s += sql_w + sql_a + " active = 1 ";
            sql_w = "";
            sql_a = " and ";

            string sql_load_users_mysql = "select * from clients ";
            string sql_limit = " limit 500";

            string sql_asada_inner_join = "";
            if (module_asada)
            {
                sql_asada_inner_join = " left join asada_cli_info using (client_id) ";
            }

                DataTable tDt = DB.q(sql_load_users_mysql + sql_asada_inner_join +sql_s + sql_limit, sql_load_users_mysql, sql_load_users_mysql);
            //TODOs
            foreach (DataRow r in tDt.Rows)
            {
                string[] row = { r["client_id"].ToString(), r["client_identification_type"].ToString(), r["client_identification"].ToString(), r["client_name"].ToString(), r["client_email"].ToString(), r["client_phone_number"].ToString(), r["client_phone_whatsapp"].ToString() };

                if (module_asada)
                {
                    string[] rowAsada = { getAsadaTipo(r["id_asada_tipo_tarifa"].ToString()), r["asada_medidor"].ToString(), r["asada_primer_lectura"].ToString(), r["asada_ultima_lectura"].ToString() };

                    string[] row3 = row.Concat(rowAsada).ToArray();
                    row = row3;
                }
                var lvi = new ListViewItem(row);
                lv_clients_serach_results.Items.Add(lvi);
            }

        }
        private void saveClient(string crud)
        {
            DB.debugLV(lv_clients_serach_results);
            #region Verification

            bool errores = false;
            string allErrors = "";


            DB.check_text(ref txt_clients_name, "lbl_clients_name", ref errores, ref allErrors, 1, 80);

            if (txt_clients_email.Text.Length > 0) {  //Optional
                DB.check_text_email(ref txt_clients_email, ref errores, ref allErrors);
            }

            //Optional
            if (txt_clients_identification.Text.Length > 0) {
                DB.check_cmb(ref cmb_clients_id_type, "lbl_clients_identification_type", ref errores, ref allErrors, 1, 999);
                DB.check_text(ref txt_clients_identification, "lbl_clients_identification", ref errores, ref allErrors, 1, 12);
                DB.check_id(ref txt_clients_identification, ref cmb_clients_id_type, ref errores, ref allErrors);
            }

            //Optional
            if (cmb_clients_province.SelectedIndex > 0) {
                DB.check_cmb(ref cmb_clients_province, "lbl_clients_province", ref errores, ref allErrors, 1, 999);
                DB.check_cmb(ref cmb_clients_canton, "lbl_clients_canton", ref errores, ref allErrors, 1, 999);
                DB.check_cmb(ref cmb_clients_district, "lbl_clients_district", ref errores, ref allErrors, 1, 999);
                if (txt_clients_full_address.Text.Length > 0) {
                    DB.check_text(ref txt_clients_full_address, "lbl_clients_full_address", ref errores, ref allErrors, 1, 160);
                }
            }
            if (((cbi)cmb_clients_credit_tipo.SelectedItem).HiddenValue=="2") {
                if (txt_clients_credit_maximo.Text.Length > 0){

                }else {

                }
            }
            //Optional
            if (txt_clients_commercial_name.Text.Length > 0)
            {
                DB.check_text(ref txt_clients_commercial_name, "lbl_clients_commercial_name", ref errores, ref allErrors, 1, 80);
            }

            //Optional
            if (txt_clients_phone_number.Text.Length > 0) { 
                DB.check_text(ref txt_clients_phone_country_number, "lbl_clients_phone_country_number", ref errores, ref allErrors, 1, 3);
               DB.check_text(ref txt_clients_phone_number, "lbl_clients_phone_number", ref errores, ref allErrors, 1, 20);

            }
            //ASADA
            if (module_asada) {
                DB.check_cmb(ref cmb_clients_asada_tipo, "lbl_client_asada_tipo", ref errores, ref allErrors, 1, 999,"4");
                DB.check_text(ref txt_client_asada_medidor, "lbl_client_asada_medidor", ref errores, ref allErrors, 1, 20);
                if (((cba)cmb_clients_asada_tipo.SelectedItem).hv_tipo_tarifaDOMEMP == "2")
                {
                    DB.check_text(ref txt_client_asada_lectura, "lbl_client_asada_lectura", ref errores, ref allErrors, 1, 255);
                }
                else { txt_client_asada_lectura.Text = "0"; }
            }
            #endregion
            
            #region Clients
            if (errores)
            {
                MessageBox.Show(DB.get_language("var_err") + " > " + allErrors);
            }
            else
            {
                string sql_save_clients_mysql = "";
                string sql_update_lecturas = "";
                string sql_insert_lecturas = "";
                string sql_w = "";

                if (crud == "1")
                {
                    sql_save_clients_mysql = "insert into clients set client_cd=now() ";
                    sql_w = " ";
                }
                else
                {
                    sql_save_clients_mysql = "update clients set cliente_ud=now() ";
                    sql_w = " where client_id='" + lbl_edit_client_id.Text.ToString() + "'";
                }

                sql_save_clients_mysql += " ,client_name = '" + txt_clients_name.Text.ToString() + "'";

                //Optional
                if (cmb_clients_id_type.SelectedItem != null && cmb_clients_id_type.SelectedIndex>0) { 
                    sql_save_clients_mysql += " ,client_identification_type = '" + ((cbi)cmb_clients_id_type.SelectedItem).HiddenValue + "'";
                    sql_save_clients_mysql += " ,client_identification = '" + txt_clients_identification.Text.ToString() + "'";
                }
                //Optional
                sql_save_clients_mysql += " ,client_commercial_name = '" + txt_clients_commercial_name.Text.ToString() + "'";

                //Optional
                sql_save_clients_mysql += " ,client_email = '" + txt_clients_email.Text.ToString() + "'";

                //Optional
                sql_save_clients_mysql += " ,client_phone_country_number = '" + txt_clients_phone_country_number.Text.ToString() + "'";
                sql_save_clients_mysql += " ,client_phone_number = '" + txt_clients_phone_number.Text.ToString() + "'";

                sql_save_clients_mysql += " ,client_phone_whatsapp = '" + txt_clients_whastapp.Text.ToString() + "'";

                sql_save_clients_mysql += " ,client_credit_type = '" + ((cbi)cmb_clients_credit_tipo.SelectedItem).HiddenValue.ToString() + "'";
                sql_save_clients_mysql += " ,client_credit_amount = '" + txt_clients_credit_maximo.Text.ToString() + "'";
                sql_save_clients_mysql += " ,client_credit_days = '" + txt_clients_credit_days.Text.ToString() + "'";

                
                    
                //Optional
                //sql_save_clients_mysql += " ,user_email = '" + txt_clients_email.Text.ToString() + "'";

                //Optional
                if (cmb_clients_province.SelectedItem != null && cmb_clients_province.SelectedIndex>0)
                {
                    sql_save_clients_mysql += " ,client_addr_province = '" + ((cbi)cmb_clients_province.SelectedItem).HiddenValue + "'";
                    sql_save_clients_mysql += " ,client_addr_canton = '" + ((cbc)cmb_clients_canton.SelectedItem).hv_save + "'";
                    sql_save_clients_mysql += " ,client_addr_district = '" + ((cbi)cmb_clients_district.SelectedItem).HiddenValue + "'";
                    sql_save_clients_mysql += " ,client_addr_senas = '" + txt_clients_full_address.Text.ToString() + "'";
                }
                DB.e(sql_save_clients_mysql + sql_w, sql_save_clients_mysql, sql_save_clients_mysql);

                string last_id = "";
                if (crud == "1")
                {
                    last_id = DB.lId;
                }
                else
                {
                    last_id = lbl_edit_client_id.Text.ToString();
                }
                if (module_asada)
                {

                    string sql_insert_client_asada_mysql = "insert into asada_cli_info set " +
                    "client_id='" + last_id + "',asada_cd=now(),";
                    string sql_save_client_asada_mysql = "" +
                        "id_asada_tipo_tarifa='" + ((cba)cmb_clients_asada_tipo.SelectedItem).hv_idTarifa + "'," +
                        "asada_tipo_tarifa='" + ((cba)cmb_clients_asada_tipo.SelectedItem).hv_tipo_tarifaDOMEMP + "'," +
                        "asada_medidor='" + txt_client_asada_medidor.Text + "',asada_primer_lectura='" + txt_client_asada_lectura.Text + "'";
                    string sql_client_asada_mysql = sql_insert_client_asada_mysql + sql_save_client_asada_mysql +
                        " ON DUPLICATE KEY update asada_ud=now()," + sql_save_client_asada_mysql + " ";
                    DB.e(sql_client_asada_mysql,"","");

                }
                if (DB.conectado)
                {
                    MessageBox.Show(DB.get_language("var_ok"));
                    LoadLvClients();
                    btn_clients_update.Enabled = false;
                    lbl_edit_client_id.Text = "";
                    clearTxtClient();
                }
                else
                {
                    MessageBox.Show(DB.get_language("var_err"));
                }

            }
            #endregion
        }
        private void frm_pos_clients_Load(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run clients.frm_pos_clients_Load : ");
        }
        private void btn_clients_add_Click(object sender, EventArgs e)
        {
            saveClient("1");
        }
        private void btn_clients_update_Click(object sender, EventArgs e)
        {
            saveClient("2");
        }
        private void btn_users_search_Click(object sender, EventArgs e)
        {
            LoadLvClients();
        }
        private void btn_clients_import_Click(object sender, EventArgs e)
        {
            clearTxtClient();
        }

        private void lv_clients_serach_results_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(DB.get_language("var_edit"), "Config", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                LoadClientbyId(lv_clients_serach_results.SelectedItems[0].Text.ToString());
            }
            else if (result == DialogResult.No)
            {
                //do something else
            }
        }

        private void txt_clients_search_all_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                LoadLvClients();
            }
        }

        private void frm_pos_clients_Shown(object sender, EventArgs e)
        {
            DB.specialRun = "callback_clients";
        }

        private void lv_clients_serach_results_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_clients_province_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if ( > 0) { 
            if (cmb_clients_province.SelectedItem != null) {
                lbl_id_province.Text = ((cbi)cmb_clients_province.SelectedItem).HiddenValue;
            }
            //}
        }

        private void cmb_clients_canton_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_clients_canton.SelectedItem != null)
            {
                lbl_id_canton.Text = ((cbc)cmb_clients_canton.SelectedItem).hv_save;
            }
        }


        private void lbl_edit_client_id_DoubleClick(object sender, EventArgs e)
        {
            lbl_id_canton.Visible = true;
            lbl_id_province.Visible = true;
            lbl_id_distric.Visible = true;
        }

        private void cmb_clients_district_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_clients_district.SelectedItem != null)
            {
                lbl_id_distric.Text = ((cbi)cmb_clients_district.SelectedItem).HiddenValue;
            }
        }
        private void actionList(string newActive ) {
            if (lv_clients_serach_results.Items.Count > 0) { 
            string sql_update_clients = "";
            int count_update = 0;
            foreach (ListViewItem Xvi in lv_clients_serach_results.Items)
            {
                if (Xvi.Checked)
                {
                    if (newActive == "1") {
                        sql_update_clients = "update clients set active=1 where client_id="+Xvi.SubItems[0].Text.ToString();
                    } else if (newActive == "2") { 
                        sql_update_clients = "update clients set active=0 where client_id=" + Xvi.SubItems[0].Text.ToString();
                    }
                    count_update++;
                    DB.q(sql_update_clients, "", "");
                        LoadLvClients();
                    }
                
            }
            MessageBox.Show("Se actualizaron " + count_update + " Clientes");

            }
        }
        private void cmb_clients_action_SelectedIndexChanged(object sender, EventArgs e)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.cmb_clients_action_SelectedIndexChanged : ");
            string cmd_selected = ((cbi)cmb_clients_action.SelectedItem).HiddenValue;
            if (cmd_selected != "")
            {
                if (cmd_selected == "1")
                {
                    //Activar
                    actionList("1");
                }
                else if (cmd_selected == "2")
                {
                    //Desactivar
                    actionList("2");
                }
                else if (cmd_selected == "3")
                {
                    
                }
                else if (cmd_selected == "4")
                {
                    
                }
            }
        }
    }
}
