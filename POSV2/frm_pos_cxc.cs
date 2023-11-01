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
    public partial class frm_pos_cxc : Form
    {
        bool invoices_select_sum = true;
        string globla_id_cliente = "";
        public frm_pos_cxc()
        {
            InitializeComponent();
        }
        private void frm_pos_cxc_Load(object sender, EventArgs e)
        {
            cleanlvInvoicess();
            cleanlvAbonos();
            cleanTotals();
            DB.checkVersion();            
        }
        private void cleanTotals() {
            txt_cal_abono.Text = "0.00";
            txt_invoice_cxc_total.Text = "0.00";
            lbl_invoice_check_total.Text = "0";
        }
        #region SearchClients
        private void buscarCliente(string tipo) {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run cxc.buscarCliente : ");
            DB.debugLV(lv_clients_search_results);

            //Load Users
            lv_clients_search_results.Items.Clear();
            lv_clients_search_results.Columns.Clear();

            lv_clients_search_results.Columns.Add("Id", 24);
            lv_clients_search_results.Columns.Add(DB.get_language("lbl_clients_identification_type"), 145);
            lv_clients_search_results.Columns.Add(DB.get_language("lbl_clients_identification"), 135);
            lv_clients_search_results.Columns.Add(DB.get_language("lbl_clients_name"), 220);
            lv_clients_search_results.Columns.Add(DB.get_language("lbl_clients_email"), 205);
            lv_clients_search_results.Columns.Add(DB.get_language("lbl_clients_phone_number"), 95);
            lv_clients_search_results.Columns.Add(DB.get_language("lbl_clients_whatsapp"), 95);

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
                lv_clients_search_results.Items.Add(lvi);
            }
        }
        private void btn_cxc_buscar_Click(object sender, EventArgs e)
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

        #region SearchFacturas

        private void lv_clients_search_results_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lv_clients_search_results.Items.Count > 0 && lv_clients_search_results.SelectedItems.Count == 1)
            {
                cleanTotals();
                buscarFacturas(lv_clients_search_results.SelectedItems[0].Text.ToString());
                buscarAbonos(lv_clients_search_results.SelectedItems[0].Text.ToString());
            }
        }

        private void cleanlvInvoicess()
        {
            DB.debugLV(lv_invoices);
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run pos_cxc.lvInvoicess : ");
            lv_invoices.Columns.Clear();
            lv_invoices.Items.Clear();

            lv_invoices.Columns.Add(DB.get_language("lv_invoice_man_num"), 25); //0
            lv_invoices.Columns.Add(DB.get_language("lv_invoice_man_clave"), 55); //1
            lv_invoices.Columns.Add(DB.get_language("lv_invoice_man_consecutivo"), 132); //2

            lv_invoices.Columns.Add(DB.get_language("lv_invoice_man_fecha"), 61); //3
            lv_invoices.Columns.Add(DB.get_language("lbl_clients_identification"), 0); //4
            lv_invoices.Columns.Add(DB.get_language("lbl_invoice_client_name"), 133); //5 

            lv_invoices.Columns.Add(DB.get_language("invoice_TotalExento"), 65); //6
            lv_invoices.Columns.Add(DB.get_language("invoice_TotalGravado"), 91); //7
            lv_invoices.Columns.Add(DB.get_language("lbl_invoice_total_tax"), 82); //8
            lv_invoices.Columns.Add(DB.get_language("lbl_invoice_total"), 81); //9

            lv_invoices.Columns.Add(DB.get_language("api_type"), 0); //10
            lv_invoices.Columns.Add(DB.get_language("uuid"), 0); //11

            lv_invoices.Columns.Add(DB.get_language("estado_credito"), 40); //12
            lv_invoices.Columns.Add(DB.get_language("abono_credito"), 90); //13
            lv_invoices.Columns.Add(DB.get_language("saldo_credito"), 90); //14
        }
        private void buscarFacturas(string id_cliente) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run pos_cxc.buscarFacturas : "+ id_cliente.ToString());
            globla_id_cliente = id_cliente;
            cleanlvInvoicess();
            string sql_load_invoices_mysql = "select invoice.*,(invoice_TotalComprobante-invoice_abono_total) as abono_saldo from invoice where (invoice_tipo_doc='01' or invoice_tipo_doc='04') and  invoice_condicion_venta='02' and invoice_abono_estado<3 and invoice_client_id='" + id_cliente + "'  and invoice_TotalComprobante is not null  order by invoice_id asc";

            
            
            DataTable tDt = DB.q(sql_load_invoices_mysql , "", "");
            //TODOs
            //user_access_level

            foreach (DataRow r in tDt.Rows)
            {
                try
                {
                    string[] row = { r["invoice_id"].ToString(), r["invoice_clave"].ToString(), r["invoice_consecutivo"].ToString(),
                        r["invoice_cd"].ToString(), r["invoice_client_identification"].ToString(),  r["invoice_client_name"].ToString(),
                        decimal.Parse(r["invoice_TotalExento"].ToString()).ToString(DB.ND2),decimal.Parse(r["invoice_TotalGravado"].ToString()).ToString(DB.ND2),decimal.Parse(r["invoice_TotalImpuesto"].ToString()).ToString(DB.ND2) ,decimal.Parse(r["invoice_TotalComprobante"].ToString()).ToString(DB.ND2) ,
                        r["invoice_api_type"].ToString(),r["invoice_uuid"].ToString(),
                        r["invoice_abono_estado"].ToString(),decimal.Parse(r["invoice_abono_total"].ToString()).ToString(DB.ND2),decimal.Parse(r["abono_saldo"].ToString()).ToString(DB.ND2)
                        };
                    
                    var lvi = new ListViewItem(row);
                    lv_invoices.Items.Add(lvi);
                }
                catch
                {
                    MessageBox.Show("Error in db");
                }
            }
        }
        
        private void cleanlvAbonos()
        {
            DB.debugLV(lv_abonos);
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run pos_cxc.lv_abonos : ");
            lv_abonos.Columns.Clear();
            lv_abonos.Items.Clear();

            lv_abonos.Columns.Add(DB.get_language("abono_id"), 0); //14
            lv_abonos.Columns.Add(DB.get_language("lv_invoice_man_fecha"), 150); //0
            lv_abonos.Columns.Add(DB.get_language("lbl_invoice_total"), 150); //1
            lv_abonos.Columns.Add(DB.get_language("abono_estado"), 0); //14
        }
        private void buscarAbonos(string id_cliente) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run pos_cxc.buscarFacturas : " + id_cliente.ToString());
            //globla_id_cliente = id_cliente;
            cleanlvAbonos();
            string sql_load_invoices_mysql = "select * from invoice_abonos where abono_client_id='" + id_cliente + "' order by abono_id desc limit 100";

            DataTable tDt = DB.q(sql_load_invoices_mysql, "", "");
            //TODOs
            //user_access_level

            foreach (DataRow r in tDt.Rows)
            {
                try
                {
                    string[] row = { r["abono_id"].ToString(), r["abono_fecha"].ToString(),decimal.Parse(r["abono_monto"].ToString()).ToString(DB.ND2)};
                    var lvi = new ListViewItem(row);
                    lv_abonos.Items.Add(lvi);
                }
                catch
                {
                    MessageBox.Show("Error in db");
                }
            }
        }

        private void cleanlvInvoicesAbonos()
        {
            DB.debugLV(lv_facturas_abonos);
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run pos_cxc.lv_facturas_abonos : ");
            lv_facturas_abonos.Columns.Clear();
            lv_facturas_abonos.Items.Clear();

            lv_facturas_abonos.Columns.Add(DB.get_language("lv_invoice_man_num"), 0); //0
            lv_facturas_abonos.Columns.Add(DB.get_language("lv_invoice_man_clave"), 55); //1
            lv_facturas_abonos.Columns.Add(DB.get_language("lv_invoice_man_consecutivo"), 132); //2

            lv_facturas_abonos.Columns.Add(DB.get_language("lv_invoice_man_fecha"), 61); //3
            lv_facturas_abonos.Columns.Add(DB.get_language("lbl_clients_identification"), 0); //4
            lv_facturas_abonos.Columns.Add(DB.get_language("lbl_invoice_client_name"), 133); //5 

            lv_facturas_abonos.Columns.Add(DB.get_language("invoice_TotalExento"), 65); //6
            lv_facturas_abonos.Columns.Add(DB.get_language("invoice_TotalGravado"), 91); //7
            lv_facturas_abonos.Columns.Add(DB.get_language("lbl_invoice_total_tax"), 82); //8
            lv_facturas_abonos.Columns.Add(DB.get_language("lbl_invoice_total"), 81); //9

            lv_facturas_abonos.Columns.Add(DB.get_language("api_type"), 0); //10
            lv_facturas_abonos.Columns.Add(DB.get_language("uuid"), 0); //11

            lv_facturas_abonos.Columns.Add(DB.get_language("estado_credito"), 0); //12
            
                lv_facturas_abonos.Columns.Add(DB.get_language("abono_monto"), 90); //13
            lv_facturas_abonos.Columns.Add(DB.get_language("abono_credito"), 90); //13
            lv_facturas_abonos.Columns.Add(DB.get_language("saldo_credito"), 90); //14
        }
        
        private void buscarFacturasAbono(string id_abono) {
            cleanlvInvoicesAbonos();


            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run pos_cxc.buscarFacturasAbono : " + id_abono.ToString());
            string sql_load_invoices_mysql = "select invoice.*,(invoice_TotalComprobante-invoice_abono_total) as abono_saldo,abonos_x_invoice_monto  from invoice inner join ( select * from invoice_abonos_uuid where abono_id='" + id_abono.ToString() + "' ) as iau using (invoice_uuid)"; //"select invoice.*,(invoice_TotalComprobante-invoice_abono_total) as abono_saldo from invoice where (invoice_tipo_doc='01' or invoice_tipo_doc='04') and  invoice_condicion_venta='02' and invoice_abono_estado<3 and invoice_client_id='" + id_cliente + "' order by invoice_id asc";



            DataTable tDt = DB.q(sql_load_invoices_mysql, "", "");
            //TODOs
            //user_access_level

            foreach (DataRow r in tDt.Rows)
            {
                try
                {
                    string[] row = { r["invoice_id"].ToString(), r["invoice_clave"].ToString(), r["invoice_consecutivo"].ToString(),
                        r["invoice_cd"].ToString(), r["invoice_client_identification"].ToString(),  r["invoice_client_name"].ToString(),
                        decimal.Parse(r["invoice_TotalExento"].ToString()).ToString(DB.ND2),decimal.Parse(r["invoice_TotalGravado"].ToString()).ToString(DB.ND2),decimal.Parse(r["invoice_TotalImpuesto"].ToString()).ToString(DB.ND2) ,decimal.Parse(r["invoice_TotalComprobante"].ToString()).ToString(DB.ND2) ,
                        r["invoice_api_type"].ToString(),r["invoice_uuid"].ToString(),
                        r["invoice_abono_estado"].ToString(),decimal.Parse(r["abonos_x_invoice_monto"].ToString()).ToString(DB.ND2),decimal.Parse(r["invoice_abono_total"].ToString()).ToString(DB.ND2),decimal.Parse(r["abono_saldo"].ToString()).ToString(DB.ND2)
                        };

                    var lvi = new ListViewItem(row);
                    lv_facturas_abonos.Items.Add(lvi);
                }
                catch
                {
                    MessageBox.Show("Error in db");
                }
            }
        }
        #endregion

        private void sumar_invoices()   {

            decimal v_sym_abono_pendiente_total = 0;
            invoices_select_sum = true;
            int invoices_checked = 0;
            foreach (ListViewItem item in lv_invoices.Items)
            {
                if (item.Checked)
                {
                    v_sym_abono_pendiente_total += decimal.Parse(item.SubItems[14].Text);
                    invoices_checked++;
                }
            }
            txt_invoice_cxc_total.Text = v_sym_abono_pendiente_total.ToString(DB.ND2);
            lbl_invoice_check_total.Text = invoices_checked.ToString();
            btn_cxc_agregar_abono.Enabled = true;
        }

        private void chk_sel_all_Click(object sender, EventArgs e)
        {
            lv_invoices.BeginUpdate();
            invoices_select_sum = false;
            foreach (ListViewItem item in lv_invoices.Items)
            {
                if (chk_sel_all.Checked)
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked= false;
                }

            }
            lv_invoices.EndUpdate();
            sumar_invoices();
        }

        private void txt_cal_abono_TextChanged(object sender, EventArgs e)
        {
            btn_cxc_agregar_abono.Enabled = true;
        }

        private void salvarAbono() {

            btn_cxc_agregar_abono.Enabled = false;
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run cxc.salvarAbono ");
            string allErrors = "";
            decimal v_sym_cxc_pendiente_total = 0;
            decimal v_sym_abono_sumar = 0;
            decimal v_sym_total_sobrante = 0;
            string sql_abono_factura = "", sql_abono_update_factura="";
            string abono_id = "";
            string tipo_abono = "";
            bool continuar = true;

            decimal v_sym_total = decimal.Parse(txt_cal_abono.Text);
            if (v_sym_total < 1)
            {
                continuar = false;
                allErrors += System.Environment.NewLine + DB.get_language("var_cxc_abono_monto_error","Error en monto de abono");
            }
            if (int.Parse( lbl_invoice_check_total.Text.ToString()) < 1)
            {
                continuar = false;
                allErrors += System.Environment.NewLine + DB.get_language("var_cxc_abono_error", "Debe seleccionar una factura al menos");
            }

            decimal v_sym_cxc_pendiente= decimal.Parse(txt_invoice_cxc_total.Text);
            if (v_sym_cxc_pendiente < 1)
            {
                continuar = false;
                allErrors += System.Environment.NewLine + DB.get_language("var_cxc_abono_monto_error", "Error en monto pendiente");
            }

            if (v_sym_total>=v_sym_cxc_pendiente )
            {
                //continuar = false;
//                allErrors += System.Environment.NewLine + DB.get_language("var_cxc_abono_monto_error", "El monto a abonar es mayor al pendiente, el monto no puede ser mayor a las facturas seleccionadas");
            }
            if (continuar)
            {
                if (MessageBox.Show("Desea abonar ("+ v_sym_total.ToString(DB.ND2) + ") a las ("+ lbl_invoice_check_total.Text.ToString() + ") facturas seleccionadas ?", "POS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Crear abono
                    string sql_abono = "insert into invoice_abonos set abono_client_id='"+ globla_id_cliente+"',abono_fecha=now(),abono_monto='"+ decimal.Parse(txt_cal_abono.Text) + "',abono_id_user='"+ DB.user_login_id + "'";
                    DB.e(sql_abono, "", "");
                    abono_id = DB.lId;
                        v_sym_total_sobrante = v_sym_total;
                    foreach (ListViewItem item in lv_invoices.Items)
                    {
                        if (item.Checked)
                        {
                            v_sym_cxc_pendiente = decimal.Parse(item.SubItems[14].Text);
                            v_sym_cxc_pendiente_total += v_sym_cxc_pendiente;
                            if(v_sym_total_sobrante >= v_sym_cxc_pendiente)
                            {
                                v_sym_total_sobrante = v_sym_total_sobrante - v_sym_cxc_pendiente;
                                v_sym_abono_sumar = v_sym_cxc_pendiente;
                                tipo_abono = "3";
                            }
                            else
                            {
                                v_sym_abono_sumar=v_sym_total_sobrante;
                                v_sym_total_sobrante = 0;
                                tipo_abono = "2";
                            }

                            sql_abono_factura = "insert into invoice_abonos_uuid set invoice_id='" + item.SubItems[0].Text.ToString() + "',invoice_uuid='" + item.SubItems[11].Text.ToString() + "',abono_id='" + abono_id + "',abonos_x_invoice_monto='" + v_sym_abono_sumar + "',abonos_x_invoice_activo=1";
                            DB.e(sql_abono_factura, "", "");

                            sql_abono_update_factura = "update invoice set invoice_abono_estado='" + tipo_abono + "',invoice_abono_total=invoice_abono_total+'" + v_sym_abono_sumar + "' where invoice_uuid='" + item.SubItems[11].Text.ToString() + "'";
                                DB.e(sql_abono_update_factura, "", "");
                        }
                    }
                    
                    SYMPOSprint newFePrint = new POSV2.SYMPOSprint();
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: newFePrint.printposAbono");
                    newFePrint.printpos_abono(abono_id);
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "A: newFePrint.printposAbono");

                    if (v_sym_total_sobrante > 0)
                    {
                        DB.e( "update invoice_abonos set abono_monto='" + (v_sym_total- v_sym_total_sobrante).ToString() + "' where abono_id='"+abono_id+"'","","" );
                        
                        MessageBox.Show("Abono salvado, vuelto ("+ v_sym_total_sobrante.ToString() +")");
                    }else {
                        MessageBox.Show("Abono salvado");
                    }
                    buscarFacturas(globla_id_cliente);
                    buscarAbonos(globla_id_cliente);
                }
            }else {
                MessageBox.Show("11x001 " + DB.get_language("var_err") + allErrors);
                DB.e("insert into invoice_bita set invoice_id='0' ,user_id='', bita_date=now(), bita_type='11001000', bita_error='Error 01 - " + allErrors.ToString() + "'", "", "");
            }
            txt_cal_abono.Text = "0.00";
                btn_cxc_agregar_abono.Enabled = false;
        }
        private void btn_cxc_agregar_abono_Click(object sender, EventArgs e)
        {
            salvarAbono();
        }
        #region Lv_invoice        
        private void lv_invoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_invoices.SelectedItems.Count > 0)
            {
                if (invoices_select_sum)
                {
                    sumar_invoices();
                }

            }
        }
        private void lv_invoices_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
            if (ModifierKeys == Keys.Control || ModifierKeys == Keys.Shift)
            {
                e.NewValue = e.CurrentValue;
            }
        }
        private void lv_invoices_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

            sumar_invoices();
        }
        #endregion

        private void btn_abono_print_Click(object sender, EventArgs e)
        {
            if (lv_abonos.Items.Count > 0 && lv_abonos.SelectedItems.Count == 1)
            {
                SYMPOSprint newFePrint = new POSV2.SYMPOSprint();
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: newFePrint.printposAbono");
                newFePrint.printpos_abono(lv_abonos.SelectedItems[0].Text.ToString());
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "A: newFePrint.printposAbono");
                MessageBox.Show("Abono impreso");
            }
        }

        private void lv_abonos_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lv_abonos.Items.Count > 0 && lv_abonos.SelectedItems.Count == 1)
            {
                buscarFacturasAbono(lv_abonos.SelectedItems[0].Text.ToString());
            }
        }

        private void btn_invoice_cxc_saldos_Click(object sender, EventArgs e)
        {
            string sql_invoice_api_type = "";
            if (!first.auto_debug)
            {
                sql_invoice_api_type = "invoice_api_type =1 and ";
            }
            string sql_report_cxc_saldos_mysql = " select invoice_client_id,invoice_client_identification,invoice_client_name, invoice_client_phone_number, sum(invoice_TotalComprobante-invoice_abono_total) as abono_saldo from invoice ";
            sql_report_cxc_saldos_mysql  += "where " + sql_invoice_api_type + " invoice_ref_Codigo is null  and(invoice_abono_estado = 0 or invoice_abono_estado = 1 or invoice_abono_estado = 2) group by invoice_client_id order by abono_saldo desc ";

            invoice_generate_html gHtml = new invoice_generate_html();
            gHtml.crear("Reporte Saldos al "+ DateTime.Now.ToString("yyyy-M-d") );

            DataTable tDt = DB.q(sql_report_cxc_saldos_mysql, "", "");

            gHtml.addTD("ID Cliente");
            gHtml.addTD("Identificación");
            gHtml.addTD("Nombre");
            gHtml.addTD("Teléfono");
            gHtml.addTD("Saldo");

            gHtml.addTR();
            foreach (DataRow r in tDt.Rows)
            {
                gHtml.addTD(r["invoice_client_id"].ToString());
                gHtml.addTD(r["invoice_client_identification"].ToString());
                gHtml.addTD(r["invoice_client_name"].ToString());
                gHtml.addTD(r["invoice_client_phone_number"].ToString());
                gHtml.addTD(r["abono_saldo"].ToString());
                /*

                if (invoice_pos__r_medio_pago.Checked)
                {
                    gHtml.addTD(r["efectivo"].ToString());
                    gHtml.addTD(r["tarjeta"].ToString());
                }
                if (invoice_pos__r_condicion_venta.Checked)
                {
                    gHtml.addTD(r["contado"].ToString());
                    gHtml.addTD(r["credito"].ToString());
                }*/
                gHtml.addTR();
            }

            gHtml.crearTabla();

            invoice_wb1.Navigate("about:blank");
            if (invoice_wb1.Document != null)
            {
                invoice_wb1.Document.Write(string.Empty);
            }


            invoice_wb1.DocumentText = gHtml.GetHTML();

        }

        private void btn_invoice_cxc_antiguedad_saldos_Click(object sender, EventArgs e)
        {
            string sql_invoice_api_type = "";
            if (!first.auto_debug)
            {
                sql_invoice_api_type = "invoice_api_type =1 and ";
            }
            string sql_report_cxc_saldos_mysql = " select invoice_client_id,invoice_client_identification,invoice_client_name,invoice_client_phone_number,round(sum( abono_saldo ),2) as abono_saldo ,invoice_cd,round(sum(if( DATEDIFF(now(),invoice_cd) BETWEEN  0 and 30 , abono_saldo,'0')),2) as dia30, round(sum(if( DATEDIFF(now(),invoice_cd) BETWEEN  31 and 60 , abono_saldo,'0')),2) as dia60, round(sum(if( DATEDIFF(now(),invoice_cd) BETWEEN  61 and 90 , abono_saldo,'0')),2) as dia90, ";
            sql_report_cxc_saldos_mysql += "round(sum(if( DATEDIFF(now(),invoice_cd) > 90, abono_saldo,'0')),2) as dia90mas  from ( select invoice_client_id,invoice_client_identification,invoice_client_name, invoice_client_phone_number, (invoice_TotalComprobante-invoice_abono_total) as abono_saldo ,invoice_cd from invoice 	where " + sql_invoice_api_type + " invoice_ref_Codigo is null  and( invoice_abono_estado = 0 or invoice_abono_estado = 1 or invoice_abono_estado = 2)  ) as invoice_sub group by invoice_client_id order by abono_saldo desc";

            invoice_generate_html gHtml = new invoice_generate_html();
            gHtml.crear("Reporte Antiguedad de Saldos al " + DateTime.Now.ToString("yyyy-M-d"));

            DataTable tDt = DB.q(sql_report_cxc_saldos_mysql, "", "");

            gHtml.addTD("ID Cliente");
            gHtml.addTD("Identificación");
            gHtml.addTD("Nombre");
            gHtml.addTD("Teléfono");
            gHtml.addTD("Saldo Total");
            gHtml.addTD("Saldo 1-30");
            gHtml.addTD("Saldo 31-60");
            gHtml.addTD("Saldo 61-90");
            gHtml.addTD("Saldo 91+");

            gHtml.addTR();
            foreach (DataRow r in tDt.Rows)
            {
                gHtml.addTD(r["invoice_client_id"].ToString());
                gHtml.addTD(r["invoice_client_identification"].ToString());
                gHtml.addTD(r["invoice_client_name"].ToString());
                gHtml.addTD(r["invoice_client_phone_number"].ToString());
                gHtml.addTD(r["abono_saldo"].ToString());
                gHtml.addTD(r["dia30"].ToString());
                gHtml.addTD(r["dia60"].ToString());
                gHtml.addTD(r["dia90"].ToString());
                gHtml.addTD(r["dia90mas"].ToString());
                /*

                if (invoice_pos__r_medio_pago.Checked)
                {
                    gHtml.addTD(r["efectivo"].ToString());
                    gHtml.addTD(r["tarjeta"].ToString());
                }
                if (invoice_pos__r_condicion_venta.Checked)
                {
                    gHtml.addTD(r["contado"].ToString());
                    gHtml.addTD(r["credito"].ToString());
                }*/
                gHtml.addTR();
            }

            gHtml.crearTabla();

            invoice_wb1.Navigate("about:blank");
            if (invoice_wb1.Document != null)
            {
                invoice_wb1.Document.Write(string.Empty);
            }


            invoice_wb1.DocumentText = gHtml.GetHTML();

        }
    }
}
