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
    public partial class frm_invoice_asadas : Form
    {

        public frm_invoice_asadas()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run asadas.frm_invoice_asadas : ");
            InitializeComponent();

            cmb_clients_asada_tipo.Items.Clear();
            string sql_load_pos_config_mysql = "select * from asada_tipo_tarifa  ";

            DataTable tDtpc = DB.q(sql_load_pos_config_mysql, "", "");
            foreach (DataRow r in tDtpc.Rows)
            {
                cmb_clients_asada_tipo.Items.Add(new cba(r["asada_titulo"].ToString(), r["asada_consumo_fija_id"].ToString(), r["asada_dom_emp_id"].ToString(), r["asada_monto_fija"].ToString(), r["id_asada_tipo_tarifa"].ToString()));
            }

        }
        private void buscarMedidores(string tipo) {
            grp_asadas_medidores.Visible = true;

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run cxc.buscarCliente : ");
            DB.debugLV(lv_asadas_clients_medidores);

            //Load Users
            lv_asadas_clients_medidores.Items.Clear();
            lv_asadas_clients_medidores.Columns.Clear();

            lv_asadas_clients_medidores.Columns.Add("Id", 24);
            lv_asadas_clients_medidores.Columns.Add(DB.get_language("lbl_clients_asadas_medidor_tipo_tarifa"), 145);
            lv_asadas_clients_medidores.Columns.Add(DB.get_language("lbl_clients_asadas_medidor_numero"), 135);
            lv_asadas_clients_medidores.Columns.Add(DB.get_language("lbl_clients_asadas_medidor_lectura"), 220);
            lv_asadas_clients_medidores.Columns.Add(DB.get_language("lbl_clients_asadas_medidor_estado"), 205);


            string sql_w = " where ";
            string sql_a = "";
            string sql_s = "";


            string sql_load_users_mysql = "select * from asada_cli_info ";
            string sql_limit = " limit 100";
            DataTable tDt = DB.q(sql_load_users_mysql + sql_s + sql_limit, sql_load_users_mysql, sql_load_users_mysql);
            //TODOs
            foreach (DataRow r in tDt.Rows)
            {
                string[] row = { r["client_id"].ToString(), r["client_identification_type"].ToString(), r["client_identification"].ToString(), r["client_name"].ToString(), r["client_email"].ToString(), r["client_phone_number"].ToString(), r["client_phone_whatsapp"].ToString() };
                var lvi = new ListViewItem(row);
                lv_asadas_clients_medidores.Items.Add(lvi);
            }


        }
        #region SearchClients
        private void buscarCliente(string tipo)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run cxc.buscarCliente : ");
            DB.debugLV(lv_asadas_clients_search_results);

            //Load Users
            lv_asadas_clients_search_results.Items.Clear();
            lv_asadas_clients_search_results.Columns.Clear();

            lv_asadas_clients_search_results.Columns.Add("Id", 24);
            lv_asadas_clients_search_results.Columns.Add(DB.get_language("lbl_clients_identification_type"), 145);
            lv_asadas_clients_search_results.Columns.Add(DB.get_language("lbl_clients_identification"), 135);
            lv_asadas_clients_search_results.Columns.Add(DB.get_language("lbl_clients_name"), 220);
            lv_asadas_clients_search_results.Columns.Add(DB.get_language("lbl_clients_email"), 205);
            lv_asadas_clients_search_results.Columns.Add(DB.get_language("lbl_clients_phone_number"), 95);
            lv_asadas_clients_search_results.Columns.Add(DB.get_language("lbl_clients_whatsapp"), 95);

            string sql_w = " where ";
            string sql_a = "";
            string sql_s = "";

            if (txt_clients_search_all.Text.Length > 0)
            {
                string srh = txt_clients_search_all.Text.ToString();

                sql_s += sql_w + sql_a + " ( client_id like '%" + srh + "%'|| client_phone_number like '%" + srh + "%'|| client_name like '%" + srh + "%'|| client_identification like '%" + srh + "%'|| client_commercial_name like '%" + srh + "%'|| client_email like '%" + srh + "%')";
                sql_w = "";
                sql_a = " and ";
            }


            sql_s += sql_w + sql_a + " active = 1 ";
            sql_w = "";
            sql_a = " and ";

            string sql_load_users_mysql = "select * from clients ";
            string sql_limit = " limit 100";
            DataTable tDt = DB.q(sql_load_users_mysql + sql_s + sql_limit, sql_load_users_mysql, sql_load_users_mysql);
            //TODOs
            foreach (DataRow r in tDt.Rows)
            {
                string[] row = { r["client_id"].ToString(), r["client_identification_type"].ToString(), r["client_identification"].ToString(), r["client_name"].ToString(), r["client_email"].ToString(), r["client_phone_number"].ToString(), r["client_phone_whatsapp"].ToString() };
                var lvi = new ListViewItem(row);
                lv_asadas_clients_search_results.Items.Add(lvi);
            }
        }
        private void btn_asadas_buscar_Click(object sender, EventArgs e)
        {
            buscarCliente("1");

        }
        private void txt_clients_search_all_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                buscarCliente("1");
            }
        }
        #endregion

        private void lv_asadas_clients_search_results_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lv_asadas_clients_search_results.Items.Count > 0 && lv_asadas_clients_search_results.SelectedItems.Count == 1)
            {
                //cleanTotals();
                buscarMedidores(lv_asadas_clients_search_results.SelectedItems[0].Text.ToString());
                //buscarAbonos(lv_clients_search_results.SelectedItems[0].Text.ToString());
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_asadas_cliente_medidores_add_Click(object sender, EventArgs e)
        {

            #region Verification
            bool errores = false;
            string allErrors = "";

            DB.check_text(ref txt_client_asada_medidor, "lbl_client_asada_medidor", ref errores, ref allErrors, 6, 6);
            DB.check_text(ref txt_client_asada_lectura, "lbl_client_asada_lectura", ref errores, ref allErrors, 1, 255);

            #endregion
            #region SaveActividad
            if (errores)
            {
                MessageBox.Show(DB.get_language("var_err") + " > " + allErrors);
            }
            else
            {
                //string sql_insert_actividad = "insert into company_actividad set company_id='" + txt_client_asada_medidor.Text.ToString() + "',actividad_codigo='" + txt_client_asada_lectura.Text.ToString() + "',actividad_descripcion='" + txt_company_actividad_desc.Text.ToString() + "'";
                string sql_insert_actividad = "";
                DB.e(sql_insert_actividad, "", "");
            }
            #endregion
        }

    }
}