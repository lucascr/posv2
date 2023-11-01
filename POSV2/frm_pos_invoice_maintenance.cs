using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace POSV2
{
    public partial class frm_pos_invoice_maintenance: Form
    {
        bool invoices_select_sum = true;
        bool global_invoice_descuento = false;

        lv_names lvId = new lv_names();

        public frm_pos_invoice_maintenance()
        {
            InitializeComponent();
        }

        private void frm_pos_invoice_maintenance_Load(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_maintenance.frm_pos_invoice_maintenance_Load : ");
            //DB.CreateloadLanguage(mnuS1, this);
            if (DB.checkConfig("invoice_descuento"))
            {
                global_invoice_descuento = true;
            }

            cleanlvInvoicess();
            loadInvoices();
            cleanTipoDocs();
            LoadCmbSaleType();
            LoadCmbSaleCurrency();
            if (first.auto_debug)
            {
                //btn_anular.Enabled = true;
            }
        }
        private void LoadCmbSaleCurrency()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.LoadCmbSaleCurrency : ");


            string sql_load_invoice_sale_currency_mysql = "select * from shared_currency where active=1 or orden is not null order by orden asc";

            cmb_invoice_sale_currency.Items.Clear();
            DataTable tDt = DB.q(sql_load_invoice_sale_currency_mysql, "", "");
            //cmb_invoice_sale_type.Items.Add(new cbi("Todos","0"));
            foreach (DataRow r in tDt.Rows)
            {
                cmb_invoice_sale_currency.Items.Add(new cbi(r["currency_moneda"].ToString(), r["currency_codigo"].ToString()));
                cmb_invoice_sale_currency.SelectedIndex = 0;

            }
        }
        private void LoadCmbSaleType()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.LoadCmbSaleType : ");


            string sql_load_invoice_sale_type_mysql = "select * from invoice_condicion_venta where active=1 order by orden asc";

            cmb_invoice_sale_type.Items.Clear();
            DataTable tDt = DB.q(sql_load_invoice_sale_type_mysql, "", "");
            //cmb_invoice_sale_type.Items.Add(new cbi("Todos","0"));
            foreach (DataRow r in tDt.Rows)
            {
                cmb_invoice_sale_type.Items.Add(new cbi(r["condicionVenta"].ToString(), r["codigo"].ToString()));
                cmb_invoice_sale_type.SelectedIndex = 0;

            }
        }
        private void cleanTipoDocs() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_maintenance.cleanTipoDocs : ");
            chk_list_tipo_doc.Items.Clear();
            
            string sql_load_invoice_documento_referencia = "select * from invoice_documento_referencia where active =1 and hacienda > 0  order by orden asc";

            DataTable tDt = DB.q(sql_load_invoice_documento_referencia , "", "");
            foreach (DataRow r in tDt.Rows)
            {

                if (r["hacienda"].ToString() == "3")
                {
                    chk_list_tipo_doc.Items.Add(new cbi("MR (Gastos) Aceptar", "05"), true);
                    chk_list_tipo_doc.Items.Add(new cbi("MR (Gastos) Aceptar Parcialmente", "06"), true);
                    chk_list_tipo_doc.Items.Add(new cbi("MR (Gastos) Rechazar", "07"), true);
                    //cmb_invoice_document_type.SelectedIndex = 0;
                }
                else {
                    chk_list_tipo_doc.Items.Add(new cbi(r["documento"].ToString(), r["codigo"].ToString()) ,true);
                }
                //chk_list_tipo_doc.Items.Add(lvi);
            }
        }
        
        private void cleanlvInvoicess()
        {
            DB.debugLV(lv_invoices);
            DB.debugLV(lv_invoices_detail);
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_maintenance.lvInvoicess : ");
            lv_invoices.Columns.Clear();

            lv_invoices.Columns.Add(DB.get_language("lv_invoice_man_num"), 35); //0
            lvId["lv_invoice_man_num"] = lv_invoices.Columns.Count - 1;

            lv_invoices.Columns.Add(DB.get_language("lv_invoice_man_clave"), 83); //1
            lvId["lv_invoice_man_clave"] = lv_invoices.Columns.Count - 1;

            lv_invoices.Columns.Add(DB.get_language("lv_invoice_man_consecutivo"), 88); //2
            lvId["lv_invoice_man_consecutivo"] = lv_invoices.Columns.Count - 1;

            lv_invoices.Columns.Add(DB.get_language("lv_invoice_man_fecha"), 61); //3
            lv_invoices.Columns.Add(DB.get_language("lbl_clients_identification_type"), 0); //4
            lv_invoices.Columns.Add(DB.get_language("lbl_clients_identification"), 0); //5
            lv_invoices.Columns.Add(DB.get_language("lbl_invoice_client_name"), 133); //6

            lv_invoices.Columns.Add(DB.get_language("lbl_invoice_document_type"), 100); //7 DB.docType
            lv_invoices.Columns.Add(DB.get_language("lv_invoice_man_tipo_pago"), 40); //8
            lv_invoices.Columns.Add(DB.get_language("lbl_invoice_sale_type"), 55); //9

            lv_invoices.Columns.Add(DB.get_language("invoice_TotalExento"), 82); //10
            lv_invoices.Columns.Add(DB.get_language("invoice_TotalGravado"), 82); //11

            if (global_invoice_descuento)
            {
                lv_invoices.Columns.Add(DB.get_language("invoice_TotalDescuento"), 82); //12
            }
            else {
                lv_invoices.Columns.Add(DB.get_language("invoice_TotalDescuento"), 0); //12
            }

            lv_invoices.Columns.Add(DB.get_language("lbl_invoice_total_tax"), 82); //13

            lv_invoices.Columns.Add(DB.get_language("lbl_invoice_currency"), 40); //14

            lv_invoices.Columns.Add(DB.get_language("lbl_invoice_total"), 82); //15
            lvId["lbl_invoice_total"] = lv_invoices.Columns.Count - 1;

            lv_invoices.Columns.Add(DB.get_language("api_type"), 0); //16
            lvId["api_type"] = lv_invoices.Columns.Count - 1;

            lv_invoices.Columns.Add(DB.get_language("uuid"), 0); //17
            lvId["uuid"] = lv_invoices.Columns.Count - 1;

            lv_invoices.Columns.Add(DB.get_language("hacienda_state"), 98); //18
            lvId["hacienda_state"] = lv_invoices.Columns.Count - 1;

            lv_invoices.Columns.Add(DB.get_language("hacienda_respuesta"), 100); //19
            lvId["hacienda_respuesta"] = lv_invoices.Columns.Count - 1;

            lv_invoices.Columns.Add(DB.get_language("lbl_invoice_document_type"), 0); //20 original
            lvId["lbl_invoice_document_type"] = lv_invoices.Columns.Count - 1;

            lv_invoices.Columns.Add(DB.get_language("invoice_ref_TipoDoc"), 0); //21 original
            lv_invoices.Columns.Add(DB.get_language("invoice_ref_Numero"), 200); //22 original
            lv_invoices.Columns.Add(DB.get_language("invoice_ref_FechaEmision"), 0); //23 original
            lv_invoices.Columns.Add(DB.get_language("invoice_ref_Codigo"), 0); //24 original
            lvId["invoice_ref_Codigo"] = lv_invoices.Columns.Count - 1;

            lv_invoices.Columns.Add(DB.get_language("invoice_ref_Razon"), 0); //25 original

            lv_invoices.Columns.Add(DB.get_language("invoice_FechaEmision"), 0); //26
            lvId["invoice_FechaEmision"] = lv_invoices.Columns.Count - 1;

            lv_invoices.Columns.Add(DB.get_language("estado_credito"), 150); //27

            lv_invoices_detail.Columns.Clear();
            lv_invoices_detail.Columns.Add(DB.get_language("invoice_detail_line"), 36);
            lv_invoices_detail.Columns.Add(DB.get_language("invoice_detail_product_id"), 28);
            lv_invoices_detail.Columns.Add(DB.get_language("invoice_detail_product_sym"), 65);
            lv_invoices_detail.Columns.Add(DB.get_language("invoice_detail_product_sym_unit"), 41);

            lv_invoices_detail.Columns.Add(DB.get_language("invoice_detail_product_sym_barcode"), 124);

            lv_invoices_detail.Columns.Add(DB.get_language("invoice_detail_product_sym_description"), 173);
            lv_invoices_detail.Columns.Add(DB.get_language("invoice_detail_qty"), 82);
            lv_invoices_detail.Columns.Add(DB.get_language("invoice_detail_product_price"), 105);


            if (global_invoice_descuento)
            {
                lv_invoices_detail.Columns.Add(DB.get_language("lv_invoice_detail_price_MontoTotal"), 105);
                lv_invoices_detail.Columns.Add(DB.get_language("lv_invoice_detail_price_Descuento"), 105);
                lv_invoices_detail.Columns.Add(DB.get_language("lv_invoice_detail_price_Descuento_razon"), 173);
            }

            lv_invoices_detail.Columns.Add(DB.get_language("invoice_detail_SubTotal"), 105);
            lv_invoices_detail.Columns.Add(DB.get_language("invoice_detail_impuesto_Monto"), 105);
            lv_invoices_detail.Columns.Add(DB.get_language("invoice_detail_MontoTotalLinea"), 105);


            lv_invoices_detail.Columns.Add(DB.get_language("lbl_tax_code"), 100);
            lv_invoices_detail.Columns.Add(DB.get_language("lbl_tax_code_iva"), 100);
            lv_invoices_detail.Columns.Add(DB.get_language("lbl_tax_tarifa"), 100);


        }
        private void loadDetails(string id_invoice) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_maintenance.loadInvoices : ");

            if (lv_invoices.SelectedItems[0].SubItems[lvId["lbl_invoice_document_type"]].Text.ToString() == "05" || lv_invoices.SelectedItems[0].SubItems[lvId["lbl_invoice_document_type"]].Text.ToString() == "06" || lv_invoices.SelectedItems[0].SubItems[lvId["lbl_invoice_document_type"]].Text.ToString() == "07" ) {
                lv_invoices_detail.Items.Clear();
                string sql_s = " ";
                string sql_w = " where gastos_id='" + id_invoice + "'";
                string sql_load_invoice_detail_mysql = "select * from gastos_detail ";

                DataTable tDt = DB.q(sql_load_invoice_detail_mysql + sql_w, "", "");
                foreach (DataRow r in tDt.Rows)
                {
                    string[] row = { r["gastos_detail_line"].ToString(), r["gastos_detail_product_id"].ToString(), r["gastos_detail_product_sym"].ToString(),
                        r["gastos_detail_product_sym_unit"].ToString(), r["gastos_detail_product_sym_barcode"].ToString(),
                        r["gastos_detail_product_sym_description"].ToString(), r["gastos_detail_qty"].ToString(), r["gastos_detail_product_price"].ToString(),
                        r["gastos_detail_SubTotal"].ToString(),r["gastos_detail_impuesto_Monto"].ToString() ,r["gastos_detail_MontoTotalLinea"].ToString(),
                        r["gastos_detail_product_sym_tax_code"].ToString(),r["gastos_detail_product_sym_tax_code_iva"].ToString() ,r["gastos_detail_product_sym_tax"].ToString()
                    };

                    var lvi = new ListViewItem(row);
                    lv_invoices_detail.Items.Add(lvi);
                }
            } else { 

                lv_invoices_detail.Items.Clear();
                string sql_s = " ";
                string sql_w = " where invoice_id='"+id_invoice+"'";
                string sql_load_invoice_detail_mysql = "select * from invoice_detail ";

                DataTable tDt = DB.q(sql_load_invoice_detail_mysql + sql_w, "", "");
                foreach (DataRow r in tDt.Rows)
                {
                    string[] row;
                    if (global_invoice_descuento)
                    {
                    row = new string[] { r["invoice_detail_line"].ToString(), r["invoice_detail_product_id"].ToString(), r["invoice_detail_product_sym"].ToString(),
                        r["invoice_detail_product_sym_unit"].ToString(), r["invoice_detail_product_sym_barcode"].ToString(),
                        r["invoice_detail_product_sym_description"].ToString(), r["invoice_detail_qty"].ToString(), r["invoice_detail_product_price"].ToString(),
                        r["invoice_detail_MontoTotal"].ToString(),r["invoice_detail_MontoDescuento"].ToString(),r["invoice_detail_NaturalezaDescuento"].ToString(),
                        r["invoice_detail_SubTotal"].ToString(),r["invoice_detail_impuesto_Monto"].ToString() ,r["invoice_detail_MontoTotalLinea"].ToString()  };
                    }
                    else{
                    row = new string[]{ r["invoice_detail_line"].ToString(), r["invoice_detail_product_id"].ToString(), r["invoice_detail_product_sym"].ToString(),
                        r["invoice_detail_product_sym_unit"].ToString(), r["invoice_detail_product_sym_barcode"].ToString(),
                        r["invoice_detail_product_sym_description"].ToString(), r["invoice_detail_qty"].ToString(), r["invoice_detail_product_price"].ToString(),
                        r["invoice_detail_SubTotal"].ToString(),r["invoice_detail_impuesto_Monto"].ToString() ,r["invoice_detail_MontoTotalLinea"].ToString()  };

                    }
                    var lvi = new ListViewItem(row);
                    lv_invoices_detail.Items.Add(lvi);
                }
            }
        }
        private void loadInvoices()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_maintenance.loadInvoices : ");

            lv_invoices.Items.Clear();
            string sql_sel_tipo_doc = "";
            string sql_sel_tipo_doc_or = "";
            string sql_s = " ";
            string sql_w = " where ";
            string sql_load_invoices_mysql = "select * from invoice ";
            string sql_limit = " limit 50 ";
            if (chk_dates.Checked)
            {
                sql_limit = "";
                sql_s = sql_w + " invoice_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59' ";
                sql_w = " and ";
            }
            if (chk_sales_type.Checked) {
                sql_limit = "";
                sql_s = sql_s+ sql_w + " invoice_condicion_venta = '" + ((cbi)cmb_invoice_sale_type.SelectedItem).HiddenValue.ToString() + "'";
                
                    sql_w = " and ";
            }

            if (chk_sales_currency.Checked)
            {
                sql_limit = "";
                sql_s = sql_s + sql_w + " invoice_currency = '" + ((cbi)cmb_invoice_sale_currency.SelectedItem).HiddenValue.ToString() + "'";

                sql_w = " and ";
            }
            /*foreach (ListViewItem item in chk_list_tipo_doc.Item)
            {
                if(item)
                sql_sel_tipo_doc = sql_sel_tipo_doc + sql_sel_tipo_doc_or + " invoice_tipo_doc = '" + item.ToString() + "' ";
                sql_sel_tipo_doc_or = " or ";
            }*/
            bool chk_checked = false;
            for (int i = 0; i < chk_list_tipo_doc.Items.Count; i++)
            {
                CheckState st = chk_list_tipo_doc.GetItemCheckState(i);
                if (st == CheckState.Checked) {
                    sql_sel_tipo_doc = sql_sel_tipo_doc + sql_sel_tipo_doc_or + " invoice_tipo_doc = '" + ((cbi)chk_list_tipo_doc.Items[i]).HiddenValue.ToString() + "' ";
                    sql_sel_tipo_doc_or = " or ";
                    chk_checked = true;
                }
                else if (st == CheckState.Unchecked) {

                }else { 

                }
            }
            if (chk_checked) {
                sql_sel_tipo_doc =  " ( " + sql_sel_tipo_doc + " ) ";                
                sql_s = sql_s + sql_w + sql_sel_tipo_doc;
                sql_w = " and ";
            }
            if (txt_invoice_man_num.Text.Length > 0)
                {
                    string search_txt = DB.s(txt_invoice_man_num.Text.ToString() + "");
                    //sql_s = " and ( product_sym like '" + search_txt + "' or product_sym_barcode like '%" + search_txt + "' or product_sym_description like '%" + search_txt + "' )";
                    sql_s = sql_s+ sql_w + " ( invoice_uuid like '%" + search_txt + "%'  or invoice_clave like '%" + search_txt + "%' or invoice_id like '%" + search_txt + "%' or invoice_consecutivo like '%" + search_txt + "%' or invoice_ref_Numero like '%" + search_txt + "%' or invoice_client_name like '%" + search_txt + "%' or invoice_client_identification like '%" + search_txt + "%' ) order by invoice_cd desc  limit 50";
                    sql_w = " and ";
                }
                else
                {
                    sql_s = sql_s + " order by invoice_cd desc " + sql_limit;
                }
                DataTable tDt = DB.q(sql_load_invoices_mysql + sql_s, "", "");
                //TODOs
                //user_access_level

                foreach (DataRow r in tDt.Rows)
                {
                    try
                    {
                    string[] row =   { r["invoice_id"].ToString(), r["invoice_clave"].ToString(), r["invoice_consecutivo"].ToString(),
                        r["invoice_cd"].ToString(),r["invoice_client_type"].ToString(), r["invoice_client_identification"].ToString(),  r["invoice_client_name"].ToString(),
                        DB.getDocType(r["invoice_tipo_doc"].ToString()), r["invoice_medio_pago"].ToString(), r["invoice_condicion_venta"].ToString(),
                        r["invoice_TotalExento"].ToString(),r["invoice_TotalGravado"].ToString(),r["invoice_TotalDescuentos"].ToString() ,
                            r["invoice_TotalImpuesto"].ToString() ,r["invoice_currency"].ToString(),r["invoice_TotalComprobante"].ToString() ,
                        r["invoice_api_type"].ToString(),r["invoice_uuid"].ToString() ,r["invoice_hacienda_state"].ToString(),r["invoice_hacienda_ind_estado"].ToString(),r["invoice_tipo_doc"].ToString(),
                        r["invoice_ref_TipoDoc"].ToString(),r["invoice_ref_Numero"].ToString(),r["invoice_ref_FechaEmision"].ToString(),r["invoice_ref_Codigo"].ToString(),r["invoice_ref_Razon"].ToString(),r["invoice_fecha_emision"].ToString(),
                        };
                    /*
                    {
                     r["invoice_id"].ToString() 0
                     r["invoice_clave"].ToString() 1 
                     r["invoice_consecutivo"].ToString() 2
                     r["invoice_cd"].ToString() 3
                        r["invoice_client_type"].ToString(), r["invoice_client_identification"].ToString(),  r["invoice_client_name"].ToString(),
                        DB.getDocType(r["invoice_tipo_doc"].ToString()), r["invoice_medio_pago"].ToString(), r["invoice_condicion_venta"].ToString(),
                        r["invoice_TotalExento"].ToString(),r["invoice_TotalGravado"].ToString(),r["invoice_TotalImpuesto"].ToString() ,r["invoice_TotalComprobante"].ToString() ,
                        r["invoice_api_type"].ToString(),r["invoice_uuid"].ToString() ,r["invoice_hacienda_state"].ToString(),r["invoice_hacienda_ind_estado"].ToString(),r["invoice_tipo_doc"].ToString(),
                        r["invoice_ref_TipoDoc"].ToString(),r["invoice_ref_Numero"].ToString(),r["invoice_ref_FechaEmision"].ToString(),r["invoice_ref_Codigo"].ToString(),r["invoice_ref_Razon"].ToString(),r["invoice_fecha_emision"].ToString(),
                        };
                        
                     */
                    var lvi = new ListViewItem(row);
                        lv_invoices.Items.Add(lvi);
                    }
                    catch {
                        MessageBox.Show("Error in db");
                    }
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                cleanlvInvoicess();
                loadInvoices();
            }
            private void lv_invoices_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (lv_invoices.Items.Count > 0 && lv_invoices.SelectedItems.Count == 1) {
                    loadDetails(lv_invoices.SelectedItems[0].Text.ToString());

                    //btn_anular.Enabled = false;
                    Console.WriteLine(lv_invoices.SelectedItems[0].SubItems[lvId["invoice_ref_Codigo"]].Text.ToString());
                Console.WriteLine(lv_invoices.SelectedItems[0].SubItems[lvId["lbl_invoice_document_type"]].Text.ToString());
                Console.WriteLine(lv_invoices.SelectedItems[0].SubItems[lvId["hacienda_respuesta"]].Text.ToString());
                
                Console.WriteLine(lv_invoices.SelectedItems[0].SubItems[lvId["uuid"]].Text.ToString());
                
                //lv_invoices.SelectedItems[0].SubItems[lvId["hacienda_respuesta"]].Text.ToString() == "aceptado" && 

                if (lv_invoices.SelectedItems[0].SubItems[lvId["invoice_ref_Codigo"]].Text.ToString().Length == 0 && (lv_invoices.SelectedItems[0].SubItems[lvId["lbl_invoice_document_type"]].Text.ToString() == "04" || lv_invoices.SelectedItems[0].SubItems[lvId["lbl_invoice_document_type"]].Text.ToString() == "01"))
                    {
                        btn_anular.Enabled = true;
                    }
                    sumar_invoices();
                } else if (lv_invoices.SelectedItems.Count >0) {
                    if(invoices_select_sum)
                    {
                        sumar_invoices();
                    }
                    
                }

            }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            pb1.Value = 1;
            SYMPOS_API_Fe _SYMFE= new SYMPOS_API_Fe();
            string results = "";
            pb1.Maximum = lv_invoices.Items.Count+10;
            foreach (ListViewItem item in lv_invoices.Items)
            {

                try{
                    pb1.Value  +=1;
                    results = _SYMFE.getStatusApi(item.SubItems[lvId["uuid"]].Text.ToString(), item.SubItems[lvId["api_type"]].Text.ToString());
                    item.SubItems[lvId["hacienda_state"]].Text  = results.ToString().Split('|')[1];
                    item.SubItems[lvId["hacienda_respuesta"]].Text = results.ToString().Split('|')[2];
                    item.SubItems[lvId["invoice_FechaEmision"]].Text = results.ToString().Split('|')[3];
                }
                catch {
                    ////MessageBox.Show(DB.get_language("var_err") + " GetStatus");
                }
                //
            }
            pb1.Value = pb1.Maximum;
        }

        private void btn_download_xml_Click(object sender, EventArgs e)
        {
            txt_respuesta.Text = "";
            if (lv_invoices.SelectedIndices.Count > 0)
            {
                SYMPOS_API_Fe _SYMFE = new SYMPOS_API_Fe();

                foreach (ListViewItem item in lv_invoices.Items)
                    if (item.Selected)
                        //uuii , api
                        txt_respuesta.Text = _SYMFE.getXMLApi(item.SubItems[lvId["uuid"]].Text.ToString() , item.SubItems[lvId["api_type"]].Text.ToString()).Replace("><", ">\r\n<");

                tabControl1.SelectedIndex = 1;
                //lv_invoice_detail.Items.Remove( );

            }
            

        }

        private void btn_download_respuesta_Click(object sender, EventArgs e)
        {

//            txt_respuesta.Text = "";
            if (lv_invoices.SelectedIndices.Count > 0)
            {
                SYMPOS_API_Fe _SYMFE = new SYMPOS_API_Fe();

                foreach (ListViewItem item in lv_invoices.Items)
                    if (item.Selected)
                        txt_respuesta.Text = _SYMFE.getXMLRespuestasApi(item.SubItems[lvId["uuid"]].Text.ToString(), item.SubItems[lvId["api_type"]].Text.ToString());

                tabControl1.SelectedIndex = 1;
                //lv_invoice_detail.Items.Remove( );

            }

        }

        private void btn_download_respuesta_api_Click(object sender, EventArgs e)
        {
            txt_respuesta.Text = "";
            if (lv_invoices.SelectedIndices.Count > 0)
            {
                SYMPOS_API_Fe _SYMFE = new SYMPOS_API_Fe();

                foreach (ListViewItem item in lv_invoices.Items)
                    if (item.Selected)
                        txt_respuesta.Text = _SYMFE.getRespuestasApi(item.SubItems[lvId["uuid"]].Text.ToString(), item.SubItems[lvId["api_type"]].Text.ToString());

                tabControl1.SelectedIndex = 1;
                //lv_invoice_detail.Items.Remove( );

            }
        }


        private void btn_download_comprobantes_api_Click(object sender, EventArgs e)
        {
            txt_respuesta.Text = "";
            if (lv_invoices.SelectedIndices.Count > 0)
            {
                SYMPOS_API_Fe _SYMFE = new SYMPOS_API_Fe();

                foreach (ListViewItem item in lv_invoices.Items)
                    if (item.Selected)
                        txt_respuesta.Text = _SYMFE.getComprobantesApi(item.SubItems[lvId["uuid"]].Text.ToString(), item.SubItems[lvId["api_type"]].Text.ToString());

                tabControl1.SelectedIndex = 1;
                //lv_invoice_detail.Items.Remove( );

            }
        }
        private void btn_anular_Click(object sender, EventArgs e)
        {
            btn_anular.Enabled = false;
            DialogResult result = MessageBox.Show("Desea anular este documento electrónico?", "Anular", MessageBoxButtons.YesNo);
            string doc_error = "";
            if (result != DialogResult.Yes)
            {
                return;
            }
                string sql_load_invoices_detail_mysql = "";
            pb1.Maximum = 100;
            int lineasDetalle = 0;
            pb1.Value = 5;
            if (lv_invoices.SelectedIndices.Count > 0)
            {
                SYMPOS_API_Fe _SYMFE = new SYMPOS_API_Fe();
                foreach (ListViewItem item in lv_invoices.Items) {
                    if (item.Selected) {
                        doc_error = item.SubItems[lvId["lv_invoice_man_consecutivo"]].Text.ToString();
                        if (item.SubItems[lvId["hacienda_respuesta"]].Text.ToString().Length > 0)
                        {
                            if (item.SubItems[lvId["hacienda_respuesta"]].Text.ToString() != "aceptado")
                            {
                                MessageBox.Show("El documento electrónico ("+ doc_error +" ) no se puede anular porque se encuentra rechazado por hacienda");
                                continue;
                            }                            
                        }
                        else {
                            MessageBox.Show("El documento electrónico ("+ doc_error + " ) no se puede anular porque aún no se ha recibido respuesta de hacienda.");
                            continue;
                        }
                        
                        if (item.SubItems[lvId["hacienda_respuesta"]].Text.ToString().Length <1)
                        {
                            MessageBox.Show("El documento electrónico ("+ doc_error +" ) debe actualizarse antes de poder anularlo");
                            continue;
                        }

                        if (item.SubItems[lvId["invoice_ref_Codigo"]].Text.ToString().Length > 0 && chk_anular.Checked==false)
                        {
                            MessageBox.Show("El documento electrónico  (" + doc_error + " ) ya posee una referencia ");
                            continue;
                            /*DialogResult result = MessageBox.Show("Desea anular este documento electrónico?", "Anular", MessageBoxButtons.YesNo);
                            string doc_error = "";
                            if (result != DialogResult.Yes)
                            {
                                
                            }*/
                        }

                    string new_invoice_id = "";
                        bool errorLocalInvoice = false;
                        SYMPOS_local_fe newFe = new POSV2.SYMPOS_local_fe();
                        //malo
                        if (newFe.SYMsaveAnularInvoice(item.SubItems[lvId["uuid"]].Text.ToString() ) == 1) {
                            new_invoice_id = DB.lId;
                            int resSYMID = 0;
                            int resSYMTotalsID = 0;
                            pb1.Value = 10;
                            #region SaveInvoiceDetalle
                            sql_load_invoices_detail_mysql = "select * from invoice_detail where invoice_id='"+ item.SubItems[0].Text.ToString() + "' order by invoice_detail_line asc";
                            DataTable tDt = DB.q(sql_load_invoices_detail_mysql , "", "");
                            //TODOs
                            //user_access_level

                            foreach (DataRow r in tDt.Rows)
                            {
                                try
                                {
                                    /*
                string[] row = { ,, ,, ,
                    , , ,
                   , , };
*/
                        resSYMID = newFe.SYMsaveInvoiceDetail(new_invoice_id,
                                       r["invoice_detail_line"].ToString(),
                                       r["invoice_detail_product_id"].ToString(),
                                       r["invoice_detail_product_sym"].ToString(),
                                       r["invoice_detail_product_sym_unit"].ToString(),
                                       r["invoice_detail_product_sym_code_type"].ToString(),
                                       r["invoice_detail_product_sym_barcode"].ToString(),
                                       r["invoice_detail_product_sym_tax_code"].ToString(),
                                       r["invoice_detail_product_sym_tax_code_iva"].ToString(),
                                       r["invoice_detail_product_sym_tax"].ToString(),
                                       r["invoice_detail_product_sym_description"].ToString(),
                                       r["invoice_detail_qty"].ToString(),
                                       r["invoice_detail_product_price"].ToString(),
                                       r["invoice_detail_MontoTotal"].ToString(),
                                       r["invoice_detail_MontoDescuento"].ToString(),
                                       r["invoice_detail_NaturalezaDescuento"].ToString(),
                                       r["invoice_detail_SubTotal"].ToString(),
                                       r["invoice_detail_impuesto_Monto"].ToString(),
                                       r["invoice_detail_MontoTotalLinea"].ToString(),
                                       r["invoice_detail_product_codigo_cabys"].ToString()
                                       );

                                    if (resSYMID == 0)
                                    {
                                        DB.e("insert into invoice_bita set invoice_id='" + new_invoice_id + "' ,user_id='', bita_date=now(), bita_type='10001001', bita_error='SYMsaveInvoiceDetail 01'", "", "");
                                        MessageBox.Show(DB.get_language("var_err") + " SYMsaveInvoiceDetail");
                                        errorLocalInvoice = true;
                                    }
                                    else
                                    {
                                        lineasDetalle++;
                                    }   
                                }
                                catch {
                                    MessageBox.Show("Error in db");
                                }
                            }
                            #endregion
                            pb1.Value = 15;
                            #region SaveInvoiceDetailVerification
                            if (lineasDetalle == 0)
                            {
                                MessageBox.Show(DB.get_language("var_err") + " SYMsaveAnularInvoice SYMsaveInvoiceDetail");
                                
                                DB.e("insert into invoice_bita set invoice_id='" + new_invoice_id + "' ,user_id='', bita_date=now(), bita_type='30001002', bita_error='SYMsaveAnularInvoice SYMsaveInvoiceDetail 02'", "", "");
                                errorLocalInvoice = true;
                            }
                            if (!errorLocalInvoice)
                            {
                                DB.e(" update invoice set invoice_local_state=invoice_local_state+1 where invoice_id='" + new_invoice_id + "'", "", ""); //1
                            }
                            #endregion
                            pb1.Value = 20;
                            #region SaveInvoiceCompany
                            resSYMID = newFe.SYMUpdateInvoiceCompany(new_invoice_id, DB.CheckCompanyPOS());
                            if (resSYMID == 0)
                            {
                                MessageBox.Show(DB.get_language("var_err") + " SYMsaveAnularInvoice SYMUpdateInvoiceCompany");
                                errorLocalInvoice = true;
                            }
                            #endregion
                            string sql_load_invoices_main_mysql = "select * from invoice where invoice_id='" + item.SubItems[0].Text.ToString() + "' limit 1";
                            pb1.Value = 25;
                            #region SaveInvoiceClient
                            if (item.SubItems[4].Text.Length > 0)
                            {
                                VarCompany my_client = new VarCompany();                                
                                DataTable tDt_invoice_main = DB.q(sql_load_invoices_main_mysql, "", "");

                                foreach (DataRow r in tDt_invoice_main.Rows)
                                {
                                    my_client.company_type = r["invoice_client_type"].ToString();
                                    my_client.company_identification = r["invoice_client_identification"].ToString();
                                    my_client.company_name = r["invoice_client_name"].ToString();
                                    my_client.company_phone = r["invoice_client_phone_number"].ToString();
                                    my_client.company_email = r["invoice_client_email"].ToString();
                                }
                                

                                resSYMID = newFe.SYMUpdateInvoiceClient(new_invoice_id, my_client);
                                if (resSYMID == 0)
                                {
                                    MessageBox.Show(DB.get_language("var_err") + " SYMsaveAnularInvoice SYMUpdateInvoiceClient");
                                    errorLocalInvoice = true;
                                }

                            }
                            #endregion
                            pb1.Value = 30;
                            #region SaveInvoiceTotals
                            if (!errorLocalInvoice)
                            {
                                DataTable tDt_invoice_main = DB.q(sql_load_invoices_main_mysql, "", "");
                                foreach (DataRow r in tDt_invoice_main.Rows) { 
                                    resSYMTotalsID = newFe.SYMUpdateInvoiceTotals(new_invoice_id,
                                    r["invoice_TotalServGravados"].ToString(), r["invoice_TotalServExentos"].ToString(),
                                    r["invoice_TotalMercanciasGravadas"].ToString(), r["invoice_TotalMercanciasExentas"].ToString(),
                                    r["invoice_TotalGravado"].ToString(), r["invoice_TotalExento"].ToString(),
                                    r["invoice_TotalVenta"].ToString(), r["invoice_TotalDescuentos"].ToString(),
                                    r["invoice_TotalVentaNeta"].ToString(), r["invoice_TotalImpuesto"].ToString(), r["invoice_TotalComprobante"].ToString()
                                    );
                                }
                            }
                            if (resSYMTotalsID == 0)
                            {
                                MessageBox.Show(DB.get_language("var_err") + " SYMUpdateInvoiceTotals");
                                errorLocalInvoice = true;
                            }
                            #endregion
                            pb1.Value = 35;
                            if (!errorLocalInvoice)
                            {
                                //lv_fe_report.Items.Add("Factura Salvada...");
                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : Documento Salvado...");

                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Enviando");

                                
                                pb1.Value = 40;
                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: SYMPOS_API_Fe");
                                _SYMFE = new SYMPOS_API_Fe();
                                try
                                {
                                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: _SYMFE.sendFE");
                                    _SYMFE.sendFE(new_invoice_id);
                                }
                                catch
                                {
                                    MessageBox.Show(DB.get_language("var_err") + " FacturaElectronica");
                                }

                                pb1.Value = 40;
                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: _SYMFE.respuesta");
                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + " R : " + _SYMFE.respuesta);
                                //lv_fe_report.Items.Add(;

                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Enviada");
                                //lv_fe_report.Items.Add("Enviada");

                                Application.DoEvents();
                                if (_SYMFE.respuesta.ToString().Length > 0){
                                    if (_SYMFE.respuesta.ToString().Substring(0, 3) == "202"){
                                        if (newFe.SYMsaveAnularInvoiceReferenciaLocal(item.SubItems[lvId["uuid"]].Text.ToString() , new_invoice_id.ToString()) == 1){
                                            pb1.Value = 100;
                                            MessageBox.Show("Documento Anulado (" + doc_error + " )");
                                            
                                        }else {
                                            pb1.Value = 100;
                                            MessageBox.Show("Ocurrio un error anulando (" + doc_error + " )");
                                        }
                                    }else{
                                        pb1.Value = 0;
                                    }
                                }
                            }else {

                                MessageBox.Show(DB.get_language("var_err") + " SYMsaveInvoice");
                                DB.e("insert into invoice_bita set invoice_id='0' ,user_id='', bita_date=now(), bita_type='10001000', bita_error='SYMsaveInvoice 01'", "", "");
                                errorLocalInvoice = true;
                            }


                            }else {

                                MessageBox.Show(DB.get_language("var_err") + " SYMsaveInvoice");
                                DB.e("insert into invoice_bita set invoice_id='0' ,user_id='', bita_date=now(), bita_type='30001000', bita_error='SYMsaveAnularInvoice 01'", "", "");
                                errorLocalInvoice = true;
                            }

                        //}//endif Ya posee Referencias
                    }
                }

            }

            cleanlvInvoicess();
            loadInvoices();
        }

        private void lv_invoices_DoubleClick(object sender, EventArgs e)
        {
            txt_respuesta.Text = "";
            string nl = "\r\n";
            if (lv_invoices.SelectedIndices.Count > 0)
            {
                SYMPOS_API_Fe _SYMFE = new SYMPOS_API_Fe();

                foreach (ListViewItem item in lv_invoices.Items)
                    if (item.Selected)
                    {
                        txt_respuesta.Text = "UUID : " + item.SubItems[17].Text.ToString();
                        txt_respuesta.Text += nl + "CLAVE : " + item.SubItems[1].Text.ToString();
                        txt_respuesta.Text += nl + "CONSECUTIVO : " + item.SubItems[2].Text.ToString();
                        txt_respuesta.Text += nl + "FECHA EMISION : " + item.SubItems[3].Text.ToString();
                        txt_respuesta.Text += nl + "NUMERO REFERENCIA : " + item.SubItems[22].Text.ToString();

                        if (item.SubItems[21].Text.ToString().Length > 8)
                        {
                            string sql_load_invoice_referencia = "select * from invoice where invoice_clave='" + item.SubItems[22].Text.ToString() + "'";


                            DataTable tDt = DB.q(sql_load_invoice_referencia, "", "");

                            foreach (DataRow r in tDt.Rows)
                            {
                                if (r["invoice_hacienda_ind_estado"].ToString() == "rechazado")
                                {
                                    btn_anular.Enabled = true;
                                }

                            }

                        }

                    }
                tabControl1.SelectedIndex = 1;
            }
            
        }
        private void sumar_invoices() {
            decimal v_sym_total_monto=0;
            
            invoices_select_sum = true;
            foreach (ListViewItem item in lv_invoices.Items)
            {
                if (item.Selected) {

                    decimal my_qty;
                    if (!decimal.TryParse(item.SubItems[15].Text, out my_qty))
                    {
                        //txt_cal_pagacon.Text = "0";
                        //e.Handled = true;
                    }
                    else
                    {
                        v_sym_total_monto += my_qty;
                    }
                    

                    

                }
            }
            txt_invoice_line_price_total.Text = v_sym_total_monto.ToString(DB.ND2);
            
        }
        private void chk_sel_all_Click(object sender, EventArgs e)
        {
            invoices_select_sum = false;
            foreach (ListViewItem item in lv_invoices.Items)
            {
                if (chk_sel_all.Checked)
                {
                    item.Selected = true;
                }
                else {
                    item.Selected = false;
                }
                
            }
            sumar_invoices();
        }

        private void txt_invoice_man_num_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btn_invoice_man_print_Click(object sender, EventArgs e)
        {


            SYMPOSprint newFePrint = new POSV2.SYMPOSprint();
            //newFePrint.selFont = font;
            if (lv_invoices.Items.Count > 0 && lv_invoices.SelectedItems.Count > 0)
            {
                newFePrint.printpos(lv_invoices.SelectedItems[0].Text.ToString());
                //   loadDetails(lv_invoices.SelectedItems[0].Text.ToString());
                //MessageBox.Show("Impresión realizada");
            }
            else
            {
                MessageBox.Show("Debe seleecionar una factura para imprimr");
            }
            /*
            DialogResult result = fontDialog1.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                // Get Font.
                Font font = fontDialog1.Font;
                // Set TextBox properties.
                //this.textBox1.Text = string.Format("Font: {0}", font.Name);
                //this.textBox1.Font = font;

                SYMPOSprint newFePrint = new POSV2.SYMPOSprint();
                //newFePrint.selFont = font;
                if (lv_invoices.Items.Count > 0 && lv_invoices.SelectedItems.Count > 0)
                {
                    newFePrint.printpos(lv_invoices.SelectedItems[0].Text.ToString(),font);
                    //   loadDetails(lv_invoices.SelectedItems[0].Text.ToString());

                }

            }*/
        }

        private void btn_invoice_sendemail_copy_Click(object sender, EventArgs e) 
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run btn_invoice_sendemail_copy_Click : ");
            RegexUtilities util = new RegexUtilities();
            if (util.IsValidEmail(txt_invoice_email.Text.ToString()))
            {
                if (lv_invoices.SelectedIndices.Count > 0)
                {
                    SYMPOS_API_Fe _SYMFE = new SYMPOS_API_Fe();

                    foreach (ListViewItem item in lv_invoices.Items)
                        if (item.Selected)
                            MessageBox.Show( _SYMFE.sendEmail(item.SubItems[lvId["uuid"]].Text.ToString(), item.SubItems[lvId["api_type"]].Text.ToString(), txt_invoice_email.Text.ToString()) );
                    
                }

            }else {
                MessageBox.Show( System.Environment.NewLine + DB.get_language("err_client") + " Email" );

            }
        }

        private void chk_anular_CheckedChanged(object sender, EventArgs e)
        {
            btn_anular.Enabled = true;
        }

        private void btn_load_factura_Click(object sender, EventArgs e)
        {
            if (lv_invoices.Items.Count > 0 && lv_invoices.SelectedItems.Count == 1)
            {
                if (lv_invoices.SelectedItems[0].SubItems[lvId["lbl_invoice_document_type"]].Text.ToString() == "01" || lv_invoices.SelectedItems[0].SubItems[lvId["lbl_invoice_document_type"]].Text.ToString() == "04" )
                {

                    //loadDetails(lv_invoices.SelectedItems[0].Text.ToString());

                    frm_pos_invoice frmInvoice = new frm_pos_invoice();
                    frmInvoice.cargarDE(lv_invoices.SelectedItems[0].Text.ToString());
                    frmInvoice.Show();
                }
            }
        }
    }
}
