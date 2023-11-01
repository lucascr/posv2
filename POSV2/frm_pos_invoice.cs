using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace POSV2
{
    public partial class frm_pos_invoice : Form
    {
        private SYMPOS_API_clientes _symposapi_clientes;
        private SYMPOS_API_Fe _SYMFE;

        static DataTable g_dt_doc_type;
        string precioInput = "";
        static VarCompany my_company;

        private BackgroundWorker bg = new BackgroundWorker();
        private bool bg_state = false;
        bool global_invoice_descuento = false;
        private int bg_state_count = 0;
        private bool bg_ping_state = false;

        private bool invoice_saldos = false;

        private bool invoice_exoneracion = false;
        bool save_error = true;
        
        //public lv_names lvinvoiceDetail;
        //Dictionary<string, int[]> lvinvoiceDetail = new Dictionary<string, int[]>();
        lv_names lvId = new lv_names();

        

        public frm_pos_invoice()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.frm_pos_invoice : ");
            my_company=DB.CheckCompanyPOS();
            
            InitializeComponent();
            //DB.CreateloadLanguage(mnuS1, this);
            DB.loadCmbIdType(ref cmb_invoice_clients_id_type, 1);
            if (DB.checkConfig("invoice_descuento"))
            {
                global_invoice_descuento = true;
            }
                cleanLvInvoice();
            cleanLinea();
            LoadCmbDocumentType();
            LoadCmbCurrency();
            LoadCmbSaleType();

            LoadCmbActEconomica();

            //calcInovice();
            cleanTotals();

            txt_cal_pagacon.Text = "0.00";
            txt_cal_vuelto.Text = "0.00";

            cleanCliente();

            lbl_invoice_line_cabys_desc.Text = "";
            txt_invoice_line_cabys_code.Text = "";

            if (my_company.company_inventario == "9"){ //Millenium

                //VarMilleniumProductos VarLineasMillenium = new VarMilleniumProductos();
            }

            //developerTest();
        }
        private void developerTest() {
            txt_invoice_line_barcode.Text = "00001";
            SearchBarcode();
            txt_invoice_line_qty.Text = "1";
            AddSymLine();
            txt_invoice_line_barcode.Text = "00001";
            SearchBarcode();
            txt_invoice_line_qty.Text = "5";
            AddSymLine();

            txt_invoice_line_barcode.Text = "00002";
            SearchBarcode();
            txt_invoice_line_qty.Text = "1";
            AddSymLine();
            txt_invoice_line_barcode.Text = "00002";
            SearchBarcode();
            txt_invoice_line_qty.Text = "5";
            AddSymLine();
        }
        private void txt_invoice_client_phone_number_TextChanged(object sender, EventArgs e)
        {
            //max 20 only numbers
        }
        private void LoadCmbCurrency()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.LoadCmbCurrency : ");

            DB.loadCmbCur(ref cmb_invoice_cur, 4);
            cmb_invoice_cur.SelectedIndex = 0;

        }
        private void LoadCmbActEconomica()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.LoadCmbActEconomica : ");

            DB.loadCmbActividadEconomica(ref cmb_invoice_act_eco);
            if (cmb_invoice_act_eco.Items.Count < 1) {
                MessageBox.Show("Ocurrio un error , es requerida la actividad economica, por favor informar al encargado del sistema.");

                cmb_invoice_act_eco.Items.Add(new cbi("N/D", "0"));
                
                //this.Close();
            }
            cmb_invoice_act_eco.SelectedIndex = 0;
            //cmb_invoice_act_eco.SelectedIndex = 0;

        }
        private void LoadCmbSaleType()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.LoadCmbSaleType : ");


            string sql_load_invoice_sale_type_mysql = "select * from invoice_condicion_venta where active=1 order by orden asc";

            cmb_invoice_sale_type.Items.Clear();
            DataTable tDt = DB.q(sql_load_invoice_sale_type_mysql, "", "");
            g_dt_doc_type = tDt;
            foreach (DataRow r in tDt.Rows)
            {
                cmb_invoice_sale_type.Items.Add(new cbi(r["condicionVenta"].ToString(), r["codigo"].ToString()));
                cmb_invoice_sale_type.SelectedIndex = 0;

            }
        }
        private void LoadCmbDocumentType()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.LoadCmbDocumentType : ");


            string sql_load_invoice_document_type_mysql = "select * from invoice_documento_referencia where active=1  order by orden asc";

            cmb_invoice_document_type.Items.Clear();
            DataTable tDt = DB.q(sql_load_invoice_document_type_mysql, "", "");
            g_dt_doc_type = tDt;
            foreach (DataRow r in tDt.Rows)
            {
                if (r["pos"].ToString() == "1") {
                    cmb_invoice_document_type.Items.Add(new cbi(r["documento"].ToString(), r["codigo"].ToString()));
                    cmb_invoice_document_type.SelectedIndex = 0;
                }

            }
        }
        public void LoadCmbAction()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.LoadCmbAction : ");


            cmb_btn_action.Items.Clear();
            cmb_btn_action.Items.Add(new cbi(DB.get_language("cmb_action_select"), ""));
            cmb_btn_action.SelectedIndex = 0;
            cmb_btn_action.Items.Add(new cbi(DB.get_language("cmb_action_invoice_line_add"), "1"));
            if (lbl_edit_invoice_line.Text.Length > 0)
            {
                cmb_btn_action.Items.Add(new cbi(DB.get_language("cmb_action_invoice_line_edit"), "2"));
            }
            cmb_btn_action.Items.Add(new cbi(DB.get_language("cmb_action_invoice_line_clean"), "3"));
            cmb_btn_action.Items.Add(new cbi(DB.get_language("cmb_action_invoice_line_invoice"), "4"));

        }
        private void cleanPagacon() {

            btn_efectivo.Enabled = true;
            btn_cred.Enabled = true;

            txt_cal_pagacon.Text = "0.00";
            txt_cal_vuelto.Text = "0.00";
        }
        private void cleanLinea() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.cleanLinea : ");

            txt_invoice_line_id_producto.Text = "";
            txt_invoice_line_sym_code_type.Text = "";
            txt_invoice_line_barcode.Text = "";

            txt_invoice_line_description.Text = "";

            txt_invoice_line_qty.Text = "";

            txt_invoice_line_price.Text = "";
            txt_invoice_line_price_tax.Text = "";
            txt_invoice_line_price_total.Text = "";

            txt_invoice_line_tax_code.Text = "";
            txt_invoice_line_tax_code_iva.Text = "";

            txt_invoice_line_tax.Text = "";

            txt_invoice_line_description.ReadOnly = false;
            txt_invoice_line_description.BackColor = Color.White;

            txt_invoice_line_price.ReadOnly = true;

            txt_invoice_line_sym.Text = "";
            txt_invoice_line_sym_unit.Text = "";

            txt_invoice_line_cur.Text = "";

            lbl_edit_invoice_line.Text = "";

            txt_invoice_line_price_descuento_monto.Text = "";
            txt_invoice_line_price_descuento_razon.Text = "";

            LoadCmbAction();
        }
        public void cleanLvInvoice()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.cleanInvoice : ");
            DB.debugLV(lv_invoice_detail);
            //Load Users
            //lv_invoice_detail.Items.Clear();
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Remover", new EventHandler(RemoveLine));
            //cm.MenuItems.Add("Editar", new EventHandler(EditLine));
            cm.MenuItems.Add("Descuento", new EventHandler(DescLine));
            lv_invoice_detail.ContextMenu = cm;

            lv_invoice_detail.Columns.Clear(); 
            lv_invoice_detail.Columns.Add("id", 0); //00                      
            lvId["id"] = lv_invoice_detail.Columns.Count-1;

            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_num"), 30); //1
            lvId["lv_invoice_detail_num"] = lv_invoice_detail.Columns.Count - 1;
            
            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_sym"), 65); //2
            lvId["lv_invoice_detail_sym"] = lv_invoice_detail.Columns.Count - 1;

            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_sym_unit"), 0); //3
            lvId["lv_invoice_detail_sym_unit"] = lv_invoice_detail.Columns.Count - 1;

            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_tax_code"), 0); //4 
            lvId["lv_invoice_detail_tax_code"] = lv_invoice_detail.Columns.Count - 1;

            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_tax"), 0); //5
            lvId["lv_invoice_detail_tax"] = lv_invoice_detail.Columns.Count - 1;

            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_id_product"), 0); //6
            lvId["lv_invoice_detail_id_product"] = lv_invoice_detail.Columns.Count - 1;

            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_code_type"), 0); //7
            lvId["lv_invoice_detail_code_type"] = lv_invoice_detail.Columns.Count - 1;

            lv_invoice_detail.Columns.Add(DB.get_language("lbl_products_barcode"), 110); //8
            lvId["lbl_products_barcode"] = lv_invoice_detail.Columns.Count - 1;


            lv_invoice_detail.Columns.Add(DB.get_language("lbl_products_description"), 360); //9
            lvId["lbl_products_description"] = lv_invoice_detail.Columns.Count - 1;

            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_qty"), 45); //10
            lvId["lv_invoice_detail_qty"] = lv_invoice_detail.Columns.Count - 1;


            lv_invoice_detail.Columns.Add(DB.get_language("lbl_products_sym_cur"), 38); //11
            lvId["lbl_products_sym_cur"] = lv_invoice_detail.Columns.Count - 1;

            lv_invoice_detail.Columns.Add(DB.get_language("lbl_products_price"), 85, HorizontalAlignment.Right); //12
            lvId["lbl_products_price"] = lv_invoice_detail.Columns.Count - 1;

            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_price_MontoTotal"), 0); //13 
            lvId["lv_invoice_detail_price_MontoTotal"] = lv_invoice_detail.Columns.Count - 1;

            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_price_Descuento"), 0); //14
            lvId["lv_invoice_detail_price_Descuento"] = lv_invoice_detail.Columns.Count - 1;

            if (global_invoice_descuento)
            {
                lv_invoice_detail.Columns[lvId["lv_invoice_detail_price_Descuento"]].Width = 70;
            }
            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_price_Descuento_razon"), 0); //15
            lvId["lv_invoice_detail_price_Descuento_razon"] = lv_invoice_detail.Columns.Count - 1;
            
            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_price_SubTotal"), 0); //16
            lvId["lv_invoice_detail_price_SubTotal"] = lv_invoice_detail.Columns.Count - 1;

            lv_invoice_detail.Columns.Add(DB.get_language("lbl_products_price_tax"), 55, HorizontalAlignment.Right); //17
            lvId["lbl_products_price_tax"] = lv_invoice_detail.Columns.Count - 1;

            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_tax_code_iva"), 0); //18
            lvId["lv_invoice_detail_tax_code_iva"] = lv_invoice_detail.Columns.Count - 1;


            //lv_products_sym_serach_results.Columns.Add(DB.get_language("lbl_products_price_with_tax"), 60);
            lv_invoice_detail.Columns.Add(DB.get_language("lbl_products_price_total"), 95, HorizontalAlignment.Right); //19 MontoTotalLinea
            lvId["lbl_products_price_total"] = lv_invoice_detail.Columns.Count - 1;



            lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_cabys"), 0); //18
            lvId["lv_invoice_detail_cabys"] = lv_invoice_detail.Columns.Count - 1;

            /*
                if (my_company.company_inventario == "9"){ //Millenium
                    lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_millenium_precio1"), 0); //17
                    lvId["lv_invoice_detail_millenium_precio1"] = lv_invoice_detail.Columns.Count - 1;
                    lv_invoice_detail.Columns.Add(DB.get_language("lv_invoice_detail_millenium_precio2"), 0); //18 
                    lvId["lv_invoice_detail_millenium_precio2"] = lv_invoice_detail.Columns.Count - 1;
                }
                */
        }
        private void CalcLine() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.CalcLine : ");
            if (txt_invoice_line_price.Text.Length > 0) {
                decimal valueDec = decimal.Parse(txt_invoice_line_price.Text.ToString());
                if (txt_invoice_line_qty.Text.Length > 0) {
                    


                    decimal qty = decimal.Parse(txt_invoice_line_qty.Text.ToString());
                    if (txt_invoice_line_price_tax.Text == "0")
                    {
                        //txt_products_sym_price_tax.Text = "0";
                        txt_invoice_line_price_total.Text = (qty * valueDec).ToString(DB.ND5);
                        txt_invoice_line_price_subtotal.Text = (qty * valueDec).ToString(DB.ND5);

                    }
                    else
                    {
                        if (txt_invoice_line_tax.Text.Length > 0) {

                            /*
                            decimal v_sym_tax_monto = decimal.Parse(txt_invoice_line_tax.Text);
                            decimal v_tax_porcent = (v_sym_tax_monto / 100);
                            first.cld(v_tax_porcent);
                            decimal v_sym_prod_tax = ((qty * valueDec) * v_tax_porcent);

                            decimal v_sym_prod_neto_sin_impuesto = ((qty * valueDec) / (1+v_tax_porcent));
                            decimal v_sym_prod_impuesto = (qty * valueDec)-v_sym_prod_neto_sin_impuesto; 
                            first.cld(v_sym_prod_tax);

                            //txt_invoice_line_price_tax.Text = v_sym_prod_tax.ToString(DB.ND5);
                            //txt_invoice_line_price_subtotal.Text = (qty * valueDec).ToString(DB.ND5);
                            //txt_invoice_line_price_total.Text = ((qty * valueDec) + v_sym_prod_tax).ToString(DB.ND5);

                            txt_invoice_line_price_tax.Text = v_sym_prod_impuesto.ToString(DB.ND5);
                            txt_invoice_line_price_subtotal.Text = v_sym_prod_neto_sin_impuesto.ToString(DB.ND5);
                            txt_invoice_line_price_total.Text = (v_sym_prod_neto_sin_impuesto + v_sym_prod_impuesto).ToString(DB.ND5);
                            */
                            decimal v_sym_tax_monto = decimal.Parse(txt_invoice_line_tax.Text); //Impuesto a Cobrar
                            decimal v_tax_porcent = (v_sym_tax_monto / 100);
                            first.cld(v_tax_porcent);
                            decimal v_sym_prod_tax = ((qty * valueDec) * v_tax_porcent);

                            txt_invoice_line_price_tax.Text = v_sym_prod_tax.ToString(DB.ND5);
                            txt_invoice_line_price_subtotal.Text = (qty * valueDec).ToString(DB.ND5);
                            txt_invoice_line_price_total.Text = ((qty * valueDec) + v_sym_prod_tax).ToString(DB.ND5);

                        }
                    }
                }
            }
        }
        private void cleanTotals() {

            txt_TotalServExentos.Text = "0.00";
            txt_TotalServGravados.Text = "0.00";

            txt_TotalMercanciasExentas.Text = "0.00";
            txt_TotalMercanciasGravadas.Text = "0.00";

            txt_TotalExento.Text = "0.00";
            txt_TotalGravado.Text = "0.00";

            txt_TotalVenta.Text = "0.00";

            txt_TotalVentaNeta.Text = "0.00";
            txt_TotalImpuesto.Text = "0.00";

            txt_TotalComprobante.Text = "0.00";

            txt_TotalDescuentos.Text = "0.00";

            txt_invoice_totals_subtotal.Text = "0.00";
            txt_invoice_totals_tax.Text = "0.00";
            txt_invoice_totals_total.Text = "0.00";


            //txt_cal_pagacon.Text = "0.00";
            //txt_cal_vuelto.Text = "0.00";

        }
        private void cleanCliente() {
            lbl_id_client.Text = "0";
            txt_invoice_client_identification.Text = "";
            txt_invoice_client_phone_number.Text = "";
            txt_invoice_client_name.Text = "";
            txt_invoice_client_email.Text = "";

            txt_invoice_cliente_saldo.Text = "0.00";
        }
        private void calcInvoice()
        {
            decimal linea_Tax = 0, linea_TotalServGravados = 0, linea_TotalServExentos = 0, linea_TotalMercanciasGravadas = 0, linea_TotalMercanciasExentas = 0, linea_SubTotal = 0, linea_MontoTotal = 0, linea_TotalDescuentos = 0, linea_total = 0;
            decimal TotalServGravados = 0, TotalServExentos = 0, TotalMercanciasGravadas = 0, TotalMercanciasExentas = 0;
            decimal TotalGravado = 0, TotalExento = 0, TotalVenta = 0, TotalDescuentos = 0, TotalVentaNeta = 0, TotalImpuesto = 0, TotalComprobante = 0;
            cleanTotals();
            int lineas = 1;
            foreach (ListViewItem item in lv_invoice_detail.Items)
            {
                linea_Tax = 0;
                linea_TotalServGravados = 0;
                linea_TotalServExentos = 0;
                linea_TotalMercanciasGravadas = 0;
                linea_TotalMercanciasExentas = 0;
                linea_TotalDescuentos = 0;
                
                linea_total = 0;

                item.SubItems[1].Text = lineas.ToString();
                lineas++;
                if (item.SubItems[2].Text.ToString() == "")
                {
                    //descripcion no calcula

                } else {

                    if (item.SubItems[lvId["lv_invoice_detail_price_Descuento"]].Text.ToString().Length > 0)
                    {
                        linea_TotalDescuentos = decimal.Parse(item.SubItems[lvId["lv_invoice_detail_price_Descuento"]].Text.ToString());
                        if (linea_TotalDescuentos > 0)
                        {
                            TotalDescuentos += linea_TotalDescuentos;                            
                        }
                    }
                    if (item.SubItems[3].Text.ToString() == "Sp" || item.SubItems[3].Text.ToString() == "Cm" ) { //lv_invoice_detail_sym_unit
                        //Servicios
                        if (item.SubItems[4].Text.ToString() == "00") { //lv_invoice_detail_tax
                            //Exento
                            linea_TotalServExentos = decimal.Parse(item.SubItems[lvId["lbl_products_price"]].Text.ToString()) * decimal.Parse(item.SubItems[lvId["lv_invoice_detail_qty"]].Text.ToString());
                            TotalServExentos += (linea_TotalServExentos- linea_TotalDescuentos);
                        } else {
                            //Con IV
                            linea_TotalServGravados = decimal.Parse(item.SubItems[lvId["lbl_products_price"]].Text.ToString()) * decimal.Parse(item.SubItems[lvId["lv_invoice_detail_qty"]].Text.ToString());                            

                            if (linea_TotalServGravados > 0){

                                linea_Tax = ((linea_TotalServGravados - linea_TotalDescuentos) * (1 + (decimal.Parse(item.SubItems[lvId["lv_invoice_detail_tax"]].Text.ToString()) / 100))) - (linea_TotalServGravados - linea_TotalDescuentos);
                                linea_Tax = System.Math.Round(linea_Tax, 5, MidpointRounding.AwayFromZero);

                                TotalImpuesto += linea_Tax; ;
                                TotalServGravados += linea_TotalServGravados;
                            }
                        }
                    } else {
                        //Gravado
                        if (item.SubItems[4].Text.ToString() == "00"){ //lv_invoice_detail_tax
                            //Exento
                            linea_TotalMercanciasExentas = decimal.Parse(item.SubItems[lvId["lbl_products_price"]].Text.ToString()) * decimal.Parse(item.SubItems[lvId["lv_invoice_detail_qty"]].Text.ToString());

                            TotalMercanciasExentas += (linea_TotalMercanciasExentas - linea_TotalDescuentos);
                        }else{

                            //Con IV
                            linea_TotalMercanciasGravadas = decimal.Parse(item.SubItems[lvId["lbl_products_price"]].Text.ToString()) * decimal.Parse(item.SubItems[lvId["lv_invoice_detail_qty"]].Text.ToString());                            

                            if (linea_TotalMercanciasGravadas > 0) { 
                                //linea_Tax = linea_TotalMercanciasGravadas * (1+(decimal.Parse(item.SubItems[4].Text.ToString()) / 100));
                                linea_Tax = ((linea_TotalMercanciasGravadas - linea_TotalDescuentos) * (1 + (decimal.Parse(item.SubItems[lvId["lv_invoice_detail_tax"]].Text.ToString()) / 100))) - (linea_TotalMercanciasGravadas- linea_TotalDescuentos);
                                linea_Tax= System.Math.Round(linea_Tax, 5, MidpointRounding.AwayFromZero);

                                TotalImpuesto += linea_Tax;
                                TotalMercanciasGravadas += linea_TotalMercanciasGravadas;
                            }
                        }
                    }

                    item.SubItems[lvId["lbl_products_price_tax"]].Text = linea_Tax.ToString();

                    linea_SubTotal = ((decimal.Parse(item.SubItems[lvId["lbl_products_price"]].Text.ToString()) * decimal.Parse(item.SubItems[lvId["lv_invoice_detail_qty"]].Text.ToString())) - linea_TotalDescuentos);
                    item.SubItems[lvId["lv_invoice_detail_price_SubTotal"]].Text = linea_SubTotal.ToString();

                    item.SubItems[lvId["lbl_products_price_total"]].Text = (linea_SubTotal + linea_Tax).ToString();
                }

                txt_TotalServExentos.Text = TotalServExentos.ToString();
                txt_TotalServGravados.Text = TotalServGravados.ToString();

                txt_TotalMercanciasExentas.Text = TotalMercanciasExentas.ToString();
                txt_TotalMercanciasGravadas.Text = TotalMercanciasGravadas.ToString();

                txt_TotalDescuentos.Text = TotalDescuentos.ToString();
                
                //decimal.Round( , 5);

                /*
                TotalExento = (TotalServExentos + TotalMercanciasExentas);
                TotalGravado = (TotalServGravados + TotalMercanciasGravadas);

                TotalVenta = TotalExento + TotalGravado;
                TotalDescuentos = 0;

                //txt_TotalVenta.Text = decimal.Round(decimal.Parse(TotalVenta.ToString() ), DB.RD5 );
                txt_TotalVenta.Text = TotalVenta.ToString();

                TotalVentaNeta = TotalVenta - TotalDescuentos;
                TotalComprobante = TotalVentaNeta + TotalImpuesto;

                txt_TotalExento.Text = TotalExento.ToString();
                txt_TotalGravado.Text = TotalGravado.ToString();

                txt_TotalVentaNeta.Text = TotalVentaNeta.ToString();
                txt_TotalImpuesto.Text = TotalImpuesto.ToString();
                txt_TotalComprobante.Text = TotalComprobante.ToString();
                */
                /*
                TotalExento = decimal.Round((TotalServExentos + TotalMercanciasExentas),  DB.RD5);
                TotalGravado = decimal.Round((TotalServGravados + TotalMercanciasGravadas),  DB.RD5);

                TotalVenta = decimal.Round(TotalExento + TotalGravado,  DB.RD5);
                TotalDescuentos = 0;

                //txt_TotalVenta.Text = decimal.Round(decimal.Parse(TotalVenta.ToString() ), DB.RD5 );
                txt_TotalVenta.Text = TotalVenta.ToString(DB.ND5);

                TotalVentaNeta = decimal.Round(TotalVenta - TotalDescuentos,  DB.RD5);
                TotalComprobante = decimal.Round(TotalVentaNeta + TotalImpuesto,DB.RD5);

                txt_TotalExento.Text = TotalExento.ToString(DB.ND5);
                txt_TotalGravado.Text = TotalGravado.ToString(DB.ND5);

                txt_TotalVentaNeta.Text = TotalVentaNeta.ToString(DB.ND5);
                txt_TotalImpuesto.Text = TotalImpuesto.ToString(DB.ND5);
                txt_TotalComprobante.Text = TotalComprobante.ToString(DB.ND5);
                
                txt_invoice_totals_subtotal.Text = TotalVentaNeta.ToString(DB.ND2);
                txt_invoice_totals_tax.Text = TotalImpuesto.ToString(DB.ND2);
                txt_invoice_totals_total.Text = TotalComprobante.ToString(DB.ND2);
                */

                TotalExento = (TotalServExentos + TotalMercanciasExentas);
                TotalGravado = (TotalServGravados + TotalMercanciasGravadas);

                TotalVenta = (TotalExento + TotalGravado);
                //TotalDescuentos = 0;

                //txt_TotalVenta.Text = decimal.Round(decimal.Parse(TotalVenta.ToString() ), DB.RD5 );
                txt_TotalVenta.Text = TotalVenta.ToString();

                TotalVentaNeta = (TotalVenta - TotalDescuentos);
                TotalComprobante = (TotalVentaNeta + TotalImpuesto);

                txt_TotalExento.Text = TotalExento.ToString();
                txt_TotalGravado.Text = TotalGravado.ToString();

                txt_TotalVentaNeta.Text = TotalVentaNeta.ToString();
                txt_TotalImpuesto.Text = TotalImpuesto.ToString();
                txt_TotalComprobante.Text = TotalComprobante.ToString();

                txt_invoice_totals_subtotal.Text = TotalVentaNeta.ToString(DB.ND2);
                txt_invoice_totals_tax.Text = TotalImpuesto.ToString(DB.ND2);
                txt_invoice_totals_total.Text = TotalComprobante.ToString(DB.ND2);

            }

        }

        public void RemoveLine(object sender, EventArgs e)
        {
            if (lv_invoice_detail.SelectedIndices.Count > 0)
            {
                foreach (ListViewItem item in lv_invoice_detail.Items)
                    if (item.Selected)
                        lv_invoice_detail.Items.Remove(item);                
                //lv_invoice_detail.Items.Remove( );

            }
            calcInvoice();
        }
        public void EditLine(object sender, EventArgs e)
        {
            
        }
        
        
        private void AddSymLine() {
            DB.debugLV(lv_invoice_detail);
            //CheckBarcode, if not , checkdescription
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.AddSymLine : ");
            CalcLine();
            #region Verification
            bool errores = false;
            string allErrors = "";
            if (txt_invoice_line_barcode.Text.Length > 0)
            {
                DB.check_text(ref txt_invoice_line_barcode, "lbl_invoice_barcode", ref errores, ref allErrors, 1, 20);
                DB.check_text(ref txt_invoice_line_description, "lbl_invoice_description", ref errores, ref allErrors, 1, 160);
                DB.check_text(ref txt_invoice_line_qty, "lbl_invoice_qty", ref errores, ref allErrors, 1, 14);
                DB.check_text(ref txt_invoice_line_price, "lbl_invoice_price", ref errores, ref allErrors, 1, 13);

                DB.check_text(ref txt_invoice_line_cabys_code, "lbl_code_cabys", ref errores, ref allErrors, 13, 13);
                
                //DB.check_cmb(ref txt_invoice_description, "lbl_products_sym", ref errores, ref allErrors, 1, 999);
                DB.e(" insert into invoice_bita set invoice_id='0', bita_date=now(), bita_type ='20000001',bita_error='.." + txt_invoice_line_barcode.Text.ToString() + "." + txt_invoice_line_description.Text.ToString() + "." + txt_invoice_line_qty.Text.ToString() + "." + txt_invoice_line_price.Text.ToString() + "' ", "", "");
            }
            else if (txt_invoice_line_description.Enabled == true && txt_invoice_line_description.Text.Length > 0)
            {
                DB.check_text(ref txt_invoice_line_description, "lbl_invoice_description", ref errores, ref allErrors, 1, 160);
                txt_invoice_line_qty.Text = "";
                txt_invoice_line_price.Text = "";
                DB.e(" insert into invoice_bita set invoice_id='0', bita_date=now(), bita_type ='20000001',bita_error='!!"+ txt_invoice_line_description.Text.ToString() + "' ", "", "");
            }
            else {
                errores = true;
            }
            if (txt_invoice_line_sym_unit.Text.Length > 0){
                if (txt_invoice_line_sym.Text.Length > 0){
                    
                }else {
                    errores = true; //Otros
                    allErrors += System.Environment.NewLine + " Error de datos ";
                }
            }else{
                if (txt_invoice_line_sym.Text.Length > 0){
                    errores = true;
                    allErrors += System.Environment.NewLine + " Error de datos ";
                }
                else {
                    //Otros
                }
            }


                lv_product_search.Visible = false;
            #endregion

            #region AddLineProducts
            if (errores)
            {
                if (allErrors.Length > 0) { 
                    MessageBox.Show(DB.get_language("var_err") + " > " + allErrors);
                }
            }
            else
            {
                //string[] row = { r["client_id"].ToString(), r["client_identification_type"].ToString(), r["client_identification"].ToString(), r["client_name"].ToString(), r["client_email"].ToString(), r["client_phone_number"].ToString() };
                //string[] row = {"", (lv_invoice_detail.Items.Count+1).ToString(), txt_invoice_sym.Text.ToString(), txt_invoice_barcode.Text.ToString(), txt_invoice_description.Text.ToString() , txt_invoice_qty.Text.ToString(), txt_invoice_cur.Text.ToString(), txt_invoice_price.Text.ToString(), };

                /*string[] row = { "0" };
                row = row.Concat(new string[] { "2" }).ToArray();
                row = row.Concat(new string[] { "3" }).ToArray();
                row = row.Concat(new string[] { "4" }).ToArray();*/

                string[] row = { "0"}; //0
                DB.ASA(ref row, (lv_invoice_detail.Items.Count + 1).ToString()); //1 lv_invoice_detail_num

                DB.ASA(ref row, txt_invoice_line_sym.Text.ToString()); //2 lv_invoice_detail_sym
                if (txt_invoice_line_sym_unit.Text.Length > 0) {
                    DB.ASA(ref row, txt_invoice_line_sym_unit.Text.ToString()); //3 lv_invoice_detail_sym_unit

                } else {
                    DB.ASA(ref row, "Otros"); //3

                }               
                

                DB.ASA(ref row, txt_invoice_line_tax_code.Text.ToString()); //4 lv_invoice_detail_tax_code

                DB.ASA(ref row, txt_invoice_line_tax.Text.ToString()); //5 lv_invoice_detail_tax

                DB.ASA(ref row, txt_invoice_line_id_producto.Text.ToString()); //6 lv_invoice_detail_id_product
                DB.ASA(ref row, txt_invoice_line_sym_code_type.Text.ToString()); //7 lv_invoice_detail_code_type
                DB.ASA(ref row, txt_invoice_line_barcode.Text.ToString()); //8 lbl_products_barcode

                DB.ASA(ref row, txt_invoice_line_description.Text.ToString()); //9 lbl_products_description

                DB.ASA(ref row, txt_invoice_line_qty.Text.ToString()); //10 lv_invoice_detail_qty
                DB.ASA(ref row, txt_invoice_line_cur.Text.ToString()); //11 lbl_products_sym_cur

                DB.ASA(ref row, txt_invoice_line_price.Text.ToString()); //12 lbl_products_price 
                
                DB.ASA(ref row, txt_invoice_line_price_subtotal.Text.ToString()); //13 lv_invoice_detail_price_MontoTotal

                DB.ASA(ref row, txt_invoice_line_price_descuento_monto.Text.ToString()); //14 Descuentos lv_invoice_detail_price_Descuento
                DB.ASA(ref row, txt_invoice_line_price_descuento_razon.Text.ToString()); //15 Razon Descuentos lv_invoice_detail_price_Descuento_razon

                DB.ASA(ref row, txt_invoice_line_price_subtotal.Text.ToString()); //16 lv_invoice_detail_price_SubTotal

                DB.ASA(ref row, txt_invoice_line_price_tax.Text.ToString()); //17 lbl_products_price_tax

                DB.ASA(ref row, txt_invoice_line_tax_code_iva.Text.ToString()); //18 lv_invoice_detail_tax_code_iva

                DB.ASA(ref row, txt_invoice_line_price_total.Text.ToString()); //19 lbl_products_price_with_tax

                DB.ASA(ref row, txt_invoice_line_cabys_code.Text.ToString()); //20 lv_invoice_detail_cabys

                var lvi = new ListViewItem(row);
                lv_invoice_detail.Items.Add(lvi);
            }

            calcInvoice();
            cleanLinea();
            calculaVuelto();
            #endregion

        }
        private void SearchBarcode()
        {
            if (my_company.company_inventario == "9"){ //Millenium
                SearchBarcodeMillenium();

            }
            else { 
                SearchBarcodeSYMPOS();
            }
        }
        public void cargarDE(string id_invoice)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.cargarDE : ");            
            string sql_load_invoice_detail_mysql = "select * from invoice_detail where invoice_id='" + id_invoice + "'  ";

            DataTable tDt = DB.q(sql_load_invoice_detail_mysql, "", "");
            foreach (DataRow r in tDt.Rows)
            {
                /* row = new string[]{ r["invoice_detail_line"].ToString(), r["invoice_detail_product_id"].ToString(), r["invoice_detail_product_sym"].ToString(),
                         r["invoice_detail_product_sym_unit"].ToString(), r["invoice_detail_product_sym_barcode"].ToString(),
                         r["invoice_detail_product_sym_description"].ToString(), r["invoice_detail_qty"].ToString(), r["invoice_detail_product_price"].ToString(),
                         r["invoice_detail_SubTotal"].ToString(),r["invoice_detail_impuesto_Monto"].ToString() ,r["invoice_detail_MontoTotalLinea"].ToString()  };
                         */
                txt_invoice_line_barcode.Text = r["invoice_detail_product_sym_barcode"].ToString();
                txt_invoice_line_description.Text = r["invoice_detail_product_sym_description"].ToString();
                txt_invoice_line_qty.Text = r["invoice_detail_qty"].ToString();
                txt_invoice_line_price.Text = r["invoice_detail_product_price"].ToString();

                if (txt_invoice_line_barcode.Text.Trim().Length > 0)
                {
                    txt_invoice_line_id_producto.Text = r["invoice_detail_product_id"].ToString();
                    txt_invoice_line_sym_code_type.Text = r["invoice_detail_product_sym_code_type"].ToString();

                    txt_invoice_line_sym.Text = r["invoice_detail_product_sym"].ToString();
                    txt_invoice_line_sym_unit.Text = r["invoice_detail_product_sym_unit"].ToString();


                    txt_invoice_line_cur.Text = r["invoice_detail_product_sym_unit"].ToString();

                    txt_invoice_line_tax_code.Text = r["invoice_detail_product_sym_tax_code"].ToString(); 
                    txt_invoice_line_tax_code_iva.Text = r["invoice_detail_product_sym_tax_code_iva"].ToString();
                    /*
                        txt_descuentos_monto.Text = item.SubItems[lvId["lv_invoice_detail_price_Descuento"]].Text;
                        txt_descuentos_razon.Text = item.SubItems[lvId["lv_invoice_detail_price_Descuento_razon"]].Text;
                        */
                    txt_invoice_line_tax.Text = r["invoice_detail_product_sym_tax"].ToString();


                    CalcLine();
                }
                else {

                }
                    
                
                AddSymLine();
            }
        }
        #region Millenium
        private void calculeLineasMillenium() {
            var MisLIneas = VarMillenium.MilleniumLineasFactura;


            if (txt_invoice_line_id_producto.Text.Length>0) {
                if (btn_cred.Enabled == false)
                { //Credito
                    txt_invoice_line_price.Text = VarMillenium.MilleniumProducto.producto_precio2;
                }
                else
                { //Efectivo
                    txt_invoice_line_price.Text = VarMillenium.MilleniumProducto.producto_precio1;
                }
                CalcLine();
            }

            foreach (ListViewItem item in lv_invoice_detail.Items)
            {

                if (btn_cred.Enabled == false){ //Credito
                    foreach (VarMilleniumProducto linea in MisLIneas){
                        if (linea.producto_codigo == item.SubItems[lvId["lbl_products_barcode"]].Text.ToString()){
                            //item.SubItems[lvId["lbl_products_price"]].Text = "20000";
                            item.SubItems[lvId["lbl_products_price"]].Text = linea.producto_precio2; //12                            
                            item.SubItems[lvId["lv_invoice_detail_price_MontoTotal"]].Text = linea.producto_precio2; //12                            
                            break;
                        }
                    }
                }else{
                    foreach (VarMilleniumProducto linea in MisLIneas){
                        if (linea.producto_codigo == item.SubItems[lvId["lbl_products_barcode"]].Text.ToString()){
                            //item.SubItems[lvId["lbl_products_price"]].Text = "10000";
                            item.SubItems[lvId["lbl_products_price"]].Text = linea.producto_precio1;
                            item.SubItems[lvId["lv_invoice_detail_price_MontoTotal"]].Text = linea.producto_precio1;
                            break;
                        }
                    }
                }
                if (item.SubItems[lvId["lv_invoice_detail_qty"]].Text.Length > 0)
                {
                    decimal v_sym_tax_monto = decimal.Parse(item.SubItems[lvId["lv_invoice_detail_tax"]].Text); //Impuesto a Cobrar //5
                    decimal v_tax_porcent = (v_sym_tax_monto / 100);
                    first.cld(v_tax_porcent);
                    decimal qty = decimal.Parse(item.SubItems[lvId["lv_invoice_detail_qty"]].Text); //10
                    decimal valueDec = decimal.Parse(item.SubItems[lvId["lbl_products_price"]].Text); //12
                    decimal v_sym_prod_tax = ((qty * valueDec) * v_tax_porcent);

                    item.SubItems[lvId["lbl_products_price_tax"]].Text = v_sym_prod_tax.ToString(DB.ND5); //13
                    item.SubItems[lvId["lv_invoice_detail_price_SubTotal"]].Text = (qty * valueDec).ToString(DB.ND5); //15
                    item.SubItems[lvId["lbl_products_price_total"]].Text = ((qty * valueDec) + v_sym_prod_tax).ToString(DB.ND5); //14
                }
            }
        }
        private void SearchBarcodeMillenium() {
            
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.SearchBarcodeMillenium : ");
            first myFirst = first.GetInstance();
            string productStatus = "";
            lbl_invoice_line_barcode_result.Text = "";
            if (txt_invoice_line_barcode.Text.Trim().Length > 0)
            {
                string sqlInventarioBarcode = "select * from pos.productos where codigo= '" + DB.s(txt_invoice_line_barcode.Text.Trim().ToString()) + "'";
                DataTable tDt = DB.q(sqlInventarioBarcode, "", "");
                if (tDt.HasErrors)
                {
                    MessageBox.Show(DB.get_language("var_err"));
                }
                else
                {
                    if (tDt.Rows.Count > 0)
                    {
                        if (tDt.Rows[0]["series"].ToString() == "1")
                        {
                            MessageBox.Show("Producto requiere series y no se puede facturar por este POS");
                        }
                            if (tDt.Rows[0]["estado"].ToString() == "1" && tDt.Rows[0]["series"].ToString() == "0")
                        {
                            /*VarMilleniumProducto LineaDeProducto = new VarMilleniumProducto();

                            LineaDeProducto.producto_codigo = tDt.Rows[0]["codigo"].ToString();

                            VarLineasMillenium.Agregar(LineaDeProducto);
                            */
                    //VarMillenium.MilleniumProducto.limpiarProducto();

                    VarMilleniumProducto MyProducto = new VarMilleniumProducto();

                            txt_invoice_line_id_producto.Text = tDt.Rows[0]["codigo"].ToString();


                            if (tDt.Rows[0]["codigo_cabys"].ToString().Length!=13 )
                            {
                                txt_invoice_line_cabys_code.Text = "";
                                lbl_invoice_line_cabys_desc.Text = "";
                                MessageBox.Show("El item seleccionado no tiene la información de CABYS", "POS");
                                productStatus = "skip";
                            }
                            else { 
                                txt_invoice_line_cabys_code.Text = tDt.Rows[0]["codigo_cabys"].ToString();
                                lbl_invoice_line_cabys_desc.Text = DB.GetCabys(tDt.Rows[0]["codigo_cabys"].ToString());
                            }
                            txt_invoice_line_sym_code_type.Text = "01";

                            if (tDt.Rows[0]["tipo_prod"].ToString() == "1")
                            {

                                txt_invoice_line_sym.Text = "UnidGr13";
                                txt_invoice_line_sym_unit.Text = "Unid";

                                txt_invoice_line_tax_code.Text = "01";
                                txt_invoice_line_tax_code_iva.Text = "08";
                                txt_invoice_line_tax.Text = "13";
                            }
                            else
                            {
                                txt_invoice_line_sym.Text = "SpGr13";
                                txt_invoice_line_sym_unit.Text = "Sp";

                                txt_invoice_line_tax_code.Text = "01";
                                txt_invoice_line_tax_code_iva.Text = "08";
                                txt_invoice_line_tax.Text = "13";
                            }

                            //txt_invoice_line_sym.Text = tDt.Rows[0]["product_sym"].ToString();
                            //txt_invoice_line_sym_unit.Text = tDt.Rows[0]["product_sym_unit"].ToString();

                            if (tDt.Rows[0]["moneda"].ToString() == "$")
                            {
                                txt_invoice_line_cur.Text = "USD";
                            }
                            else
                            {
                                txt_invoice_line_cur.Text = "CRC";
                            }


                            txt_invoice_line_description.Text = tDt.Rows[0]["descripcion"].ToString();



                            MyProducto.LimpiarProducto();
                            MyProducto.producto_codigo = tDt.Rows[0]["codigo"].ToString();
                            MyProducto.producto_descripcion = tDt.Rows[0]["descripcion"].ToString();
                            MyProducto.producto_tipo = tDt.Rows[0]["tipo_prod"].ToString();
                            MyProducto.producto_moneda = tDt.Rows[0]["moneda"].ToString();

                            MyProducto.producto_cabys = tDt.Rows[0]["codigo_cabys"].ToString();

                            decimal my_tax, my_precio1, my_precio2;
                            if (!decimal.TryParse(tDt.Rows[0]["impuesto43"].ToString(), out my_tax))
                            {
                                MessageBox.Show("El item seleccionado no tiene la información de impuesto IVA Impuesto", "POS");
                                productStatus = "skip";
                            }
                            else
                            {
                                MyProducto.producto_impuesto = my_tax.ToString();
                            }

                            if (!decimal.TryParse(tDt.Rows[0]["precio1"].ToString(), out my_precio1))
                            {
                                MessageBox.Show("El item seleccionado no tiene la información de impuesto IVA Precio1", "POS");
                                productStatus = "skip";
                            }
                            else
                            {
                                if (MyProducto.producto_tipo == "1")
                                {
                                    MyProducto.producto_precio1 = decimal.Round((decimal)my_precio1 / (decimal)((my_tax /100)+1), 5).ToString();
                                    //VarMillenium.MilleniumProducto.producto_precio1 = decimal.Round((decimal)((my_tax / 100) + 1), 5).ToString();
                                }
                                else{
                                    MyProducto.producto_precio1 = my_precio1.ToString();
                                }
                            }

                            if (!decimal.TryParse(tDt.Rows[0]["precio2"].ToString(), out my_precio2))
                            {
                                MessageBox.Show("El item seleccionado no tiene la información de impuesto IVA Precio2", "POS");
                                productStatus = "skip";
                            }
                            else
                            {
                                if (MyProducto.producto_tipo == "1")
                                {
                                    MyProducto.producto_precio2 = decimal.Round((decimal)my_precio2 / (decimal)((my_tax / 100) + 1), 5).ToString();
                                }
                                else {
                                    MyProducto.producto_precio2 = my_precio2.ToString();
                                }
                                
                            }

                            
                             //= decimal.Round( / (decimal)my_tax, 5).ToString(); 
                             


                            //VarMillenium.MilleniumProducto.producto_precio1 = tDt.Rows[0]["precio1"].ToString();
                            //VarMillenium.MilleniumProducto.producto_precio2 = tDt.Rows[0]["precio2"].ToString();


                            if (btn_cred.Enabled == false){ //Credito
                                txt_invoice_line_price.Text = MyProducto.producto_precio2;
                            }
                            else{ //Efectivo
                                txt_invoice_line_price.Text = MyProducto.producto_precio1;
                            }
                            
                        


                            //CalcLine();


                            txt_invoice_line_description.ReadOnly = true;
                            txt_invoice_line_description.BackColor = SystemColors.Control;

                            //VarMillenium.MilleniumLineasFactura = new VarMilleniumProducto();



                            //VarMillenium.MilleniumLineasFactura.Add(VarMillenium.MilleniumProducto);

                            //if (VarMillenium.MilleniumLineasFactura == null){
                            //List<VarMillenium> VarMillenium.MilleniumLineasFactura;  // new List<VarMilleniumProductos>();
                            //}
                            VarMillenium.MilleniumLineasFactura.Add(MyProducto);

                            //VarMillenium.MilleniumProducto.LimpiarProducto();

                            //VarMilleniumProductos MPs = new VarMilleniumProductos();
                            //MPs.Agregar(VarMillenium.MilleniumProducto);

                            //VarMillenium.MilleniumLineasFactura = MPs;
                            txt_invoice_line_qty.Focus();
                        }
                        else
                        {
                            lbl_invoice_line_barcode_result.Text = DB.get_language("lbl_error_zero");
                        }
                    }
                    else {
                        lbl_invoice_line_barcode_result.Text = DB.get_language("lbl_error_zero");
                    }
                }
            }else {
                lbl_invoice_line_barcode_result.Text = DB.get_language("lbl_error_zero");
                cleanLinea();
            }
        }
        private void SearchProductMillenium()
        {
            lv_product_search.BringToFront();

            DB.debugLV(lv_product_search);

            lv_product_search.Columns.Clear();
            lv_product_search.Columns.Add("Barcode", 85);
            lv_product_search.Columns.Add("Description", 265);
            lv_product_search.Columns.Add("Precio1", 80);
            lv_product_search.Columns.Add("Precio2", 80);
            lv_product_search.Columns.Add("QTY", 30);
            lv_product_search.Items.Clear();

            if (txt_invoice_line_description.Text.Length > 0)
            {
                string sql_load_products_mysql = "select pos.productos.codigo,pos.productos.series,pos.productos.descripcion,pos.productos.precio1,pos.productos.precio2 , if (ISNULL(pos.productos_bodegas.cantidad),0,pos.productos_bodegas.cantidad) as cantidad from pos.productos  left join pos.productos_bodegas on pos.productos_bodegas.codigo = pos.productos.codigo and pos.productos_bodegas.id_bodega = 1 where pos.productos.series =0 and pos.productos.descripcion like '%" + txt_invoice_line_description.Text + "%'";

                DataTable tDt = DB.q(sql_load_products_mysql, "", "");

                if (tDt.HasErrors)
                {
                    MessageBox.Show(DB.get_language("var_err") + " > " + "-Error loading products");
                }
                else
                {
                    foreach (DataRow r in tDt.Rows)
                    {
                        if (r["series"].ToString() == "1") {
                            MessageBox.Show("Producto requiere series y no se puede facturar por este POS");
                        }
                        else
                        {
                            string[] row = { r["codigo"].ToString(), r["descripcion"].ToString(), r["precio1"].ToString(), r["precio2"].ToString(), r["cantidad"].ToString() };
                            var lvi = new ListViewItem(row);
                            lv_product_search.Items.Add(lvi);
                        }
                        
                    }
                }
            }
        }
        #endregion

        private void SearchBarcodeSYMPOS() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.SearchBarcode : ");
            first myFirst = first.GetInstance();
            string productStatus = "";
            lbl_invoice_line_barcode_result.Text = "";
            if (txt_invoice_line_barcode.Text.Trim().Length > 2)
            {
                string sql_mysql_search_barcode = "select * from products where product_sym_barcode='" + DB.s(txt_invoice_line_barcode.Text.ToString()) + "'"; // or temp_product_8_codigo='" + DB.s(txt_invoice_line_barcode.Text.ToString()) + "' or temp_product_9_codigo_proveedor='" + DB.s(txt_invoice_line_barcode.Text.ToString()) + "'";


                //lbl_invoice_barcode_result.Text = DB.get_language("lbl_invoice_barcode_result");

                DataTable tDt = DB.q(sql_mysql_search_barcode, "", "");
                if (tDt.HasErrors)
                {
                    MessageBox.Show(DB.get_language("var_err"));       
                }
                else
                {
                    if (tDt.Rows.Count == 0){
                        sql_mysql_search_barcode = "select * from products where temp_product_8_codigo='" + DB.s(txt_invoice_line_barcode.Text.ToString()) + "' or temp_product_9_codigo_proveedor='" + DB.s(txt_invoice_line_barcode.Text.ToString()) + "'";
                        tDt = DB.q(sql_mysql_search_barcode, "", "");
                        if (tDt.HasErrors)
                        {
                            MessageBox.Show(DB.get_language("var_err"));
                            return;
                        }
                    }
                    if (tDt.Rows.Count > 1){
                        lv_product_search.Visible = true;
                        lv_product_search.Location = new Point(7, 275);
                        SearchProduct("1");
                    }
                    else if (tDt.Rows.Count == 1)
                    {
                        //Todos
                        //Check Pendiente
                        //Preguntar por datos que faltan

                        if (tDt.Rows[0]["product_sym"].ToString() == "?" || tDt.Rows[0]["product_sym_unit"].ToString() == "?" || tDt.Rows[0]["product_sym_tax_code"].ToString() == "?" || tDt.Rows[0]["product_sym_tax_code"].ToString() == "0.00000" || tDt.Rows[0]["product_codigo_cabys"].ToString()=="")
                        {
                            //Producto existe con info pendiente
                            DialogResult result = MessageBox.Show(DB.get_language("var_edit"), "Config", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                invoice_product_modal frmProductUpdate = new invoice_product_modal();
                                frmProductUpdate.loadProduct(tDt.Rows[0]["product_id"].ToString());
                                frmProductUpdate.ShowDialog();

                                myFirst.activeFrm = this;
                                if (frmProductUpdate.saved)
                                {
                                    productStatus = "reload";
                                }
                            }
                            else if (result == DialogResult.No)
                            {
                                txt_invoice_line_barcode.Focus();
                                //do something else
                            }
                        }else if (tDt.Rows[0]["product_adv_impuesto_codigo"].ToString() == "?") {

                            invoice_product_CanastaBasica frmProductUpdate = new invoice_product_CanastaBasica();
                            //frmProductUpdate.loadProduct(tDt.Rows[0]["product_id"].ToString(), tDt.Rows[0]["product_sym_description"].ToString());
                            frmProductUpdate.id_producto = tDt.Rows[0]["product_id"].ToString();
                            frmProductUpdate.descripcion = tDt.Rows[0]["product_sym_description"].ToString();
                            frmProductUpdate.ShowDialog();

                            myFirst.activeFrm = this;
                            if (frmProductUpdate.saved)
                            {
                                productStatus = "reload";
                            }
                        }
                        else {
                            productStatus = "found";
                        }

                        if (productStatus == "found") {
                            if (tDt.Rows[0]["active"].ToString() == "1"){
                                //Es un Combo ****
                                if (tDt.Rows[0]["product_inventory_type"].ToString()=="2") { //Combo
                                    CargarComboDetails(tDt.Rows[0]["product_sym_barcode"].ToString());
                                    cleanLinea();

                                    return;
                                }
                                

                                if (txt_invoice_line_barcode.Text.ToString()!= tDt.Rows[0]["product_sym_barcode"].ToString()) {
                                    txt_invoice_line_barcode.Text = tDt.Rows[0]["product_sym_barcode"].ToString();
                                }
                                txt_invoice_line_id_producto.Text = tDt.Rows[0]["product_id"].ToString();
                                txt_invoice_line_sym_code_type.Text = tDt.Rows[0]["product_sym_code_type"].ToString();


                                txt_invoice_line_sym.Text = tDt.Rows[0]["product_sym"].ToString();
                                txt_invoice_line_sym_unit.Text = tDt.Rows[0]["product_sym_unit"].ToString();

                                txt_invoice_line_cur.Text = tDt.Rows[0]["product_currency"].ToString();

                                txt_invoice_line_description.Text = tDt.Rows[0]["product_sym_description"].ToString();

                                txt_invoice_line_cabys_code.Text = tDt.Rows[0]["product_codigo_cabys"].ToString();
                                lbl_invoice_line_cabys_desc.Text = DB.GetCabys(tDt.Rows[0]["product_codigo_cabys"].ToString());

                                if (tDt.Rows[0]["product_adv_lock_precio"].ToString() == "2")
                                {

                                    //Pedia monto
                                }
                                else {
                                    txt_invoice_line_price.Text = tDt.Rows[0]["product_price"].ToString();
                                }
                                #region ProductoGenericoPrecio
                                
                                  if (tDt.Rows[0]["product_adv_lock_precio"].ToString() == "2"){ //Pedia monto

                                      invoice_price_modal frmProductUpdate = new invoice_price_modal();
                                      frmProductUpdate.descripcion = tDt.Rows[0]["product_sym_description"].ToString();

                                      decimal my_tax;
                                      if (!decimal.TryParse(tDt.Rows[0]["product_sym_tax"].ToString(), out my_tax))
                                      {
                                          MessageBox.Show("El item seleccionado no tiene la información de impuesto IVA", "POS");
                                          productStatus = "skip";
                                      }  else {
                                          frmProductUpdate.tax = my_tax;
                                      }

                                      frmProductUpdate.ShowDialog(); 

                                      myFirst.activeFrm = this;
                                      if (frmProductUpdate.saved)
                                      {
                                          //TODOs
                                          //Fix tax code and tax in the variable
                                          txt_invoice_line_price.Text = frmProductUpdate.price.ToString();

                                          txt_invoice_line_description.Text = frmProductUpdate.descripcion.ToString().Trim();

                                          bool tax_bruto_base = frmProductUpdate.tax_bruto_base;

                                          if (tDt.Rows[0]["product_sym_tax"].ToString() != "0.00")
                                          {
                                              decimal my_price;
                                              if (!decimal.TryParse(txt_invoice_line_price.Text.ToString(), out my_price))
                                              {
                                                  txt_invoice_line_price.Text = "0";
                                              }
                                              else
                                              {
                                                  if (tax_bruto_base == true)
                                                  {


                                                      txt_invoice_line_price.Text = decimal.Round(my_price / (decimal)(1 + (decimal.Parse(tDt.Rows[0]["product_sym_tax"].ToString()) / 100)) , 5).ToString();
                                                  }
                                                  else {
                                                      //txt_invoice_line_price.Text = decimal.Round(my_price * (decimal)1.13, 5).ToString();
                                                      txt_invoice_line_price.Text = decimal.Round(my_price , 5).ToString();

                                                  }
                                              }
                                          }
                                      }
                                      else
                                      {
                                          productStatus = "skip";
                                          cleanLinea();
                                      }
                                  }
                                  else
                                  {
                                      txt_invoice_line_price.Text = tDt.Rows[0]["product_price"].ToString();
                                  }
                                  
  #endregion
                                //txt_invoice_line_price = precio unitario


                                txt_invoice_line_tax_code.Text = tDt.Rows[0]["product_sym_tax_code"].ToString();
                                txt_invoice_line_tax_code_iva.Text = tDt.Rows[0]["product_sym_tax_code_iva"].ToString();
                                if (txt_invoice_line_tax_code_iva.Text.Length == 0) {
                                    productStatus = "skip";
                                    cleanLinea();
                                    MessageBox.Show("El item seleccionado no tiene la información del IVA", "POS");
                                }
                                txt_invoice_line_tax.Text = tDt.Rows[0]["product_sym_tax"].ToString();

                                //CalcLine();


                                txt_invoice_line_description.ReadOnly = true;
                                txt_invoice_line_description.BackColor = SystemColors.Control;
                                if (productStatus == "found")
                                {
                                    if (chk_lock_invoice_detail_qty.Checked)
                                    {
                                        txt_invoice_line_qty.Text = "1";
                                        CalcLine();
                                        AddSymLine();
                                        txt_invoice_line_barcode.Focus();
                                    }
                                    else
                                    {
                                        txt_invoice_line_qty.Focus();
                                    }
                                }
                            }
                            else {
                                MessageBox.Show("Code : '" + txt_invoice_line_barcode.Text.ToString() + "'  Inactivo ");
                            }
                        }
                        //txt_invoice_description.Text = tDt.Rows[0]["user_initials"].ToString();

                        //   DB.sel_combo(ref cmb_users_state, tDt.Rows[0]["user_active"].ToString());
                        //DB.sel_lv(ref lv_users_access_list, tDt.Rows[0]["user_access_level"].ToString());
                        if (productStatus=="reload")
                        {
                            SearchBarcode();
                        }
                    }else {

                        //Producto no existe
                        DialogResult result = MessageBox.Show(DB.get_language("var_edit"), "Config", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            invoice_product_modal frmProductUpdate = new invoice_product_modal();
                            frmProductUpdate.loadBarcode(DB.s(txt_invoice_line_barcode.Text.ToString() ));
                            frmProductUpdate.ShowDialog();
                            if (frmProductUpdate.saved)
                            {
                                productStatus = "reload";
                                SearchBarcode();
                            }
                        }
                        else if (result == DialogResult.No)
                        {
                            MessageBox.Show("Code : '" + txt_invoice_line_barcode.Text.ToString() + "'  " + DB.get_language("lbl_invoice_barcode_result"));
                            cleanLinea();
                            txt_invoice_line_barcode.Focus();
                            
                            //do something else
                        }

                    }


                }

            }
            else {
                lbl_invoice_line_barcode_result.Text = DB.get_language("lbl_error_zero");
                cleanLinea();
            }

        }

        private void CargarComboDetails(string barcode)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.CargarComboDetails : " + barcode.ToString());

            if (barcode.Length > 0)
            {
                string sql_mysql_search_barcode = "select * from product_combo where product_sym_barcode_parent='" + DB.s(barcode.ToString()) + "'";

                DataTable tDt = DB.q(sql_mysql_search_barcode, "", "");
                if (tDt.HasErrors)
                {
                    MessageBox.Show(DB.get_language("var_err"));
                }
                else
                {
                    chk_lock_invoice_detail_qty.Checked = false;
                    decimal desc_subtotal_original = 0, desc_monto = 0, combo_qty=0;
                    foreach (DataRow r in tDt.Rows)
                    {

                        txt_invoice_line_barcode.Text = r["product_sym_barcode_combo"].ToString();
                        SearchBarcode();
                        txt_invoice_line_qty.Text = r["product_combo_qty"].ToString();
                        desc_subtotal_original = decimal.Parse(txt_invoice_line_price.Text.ToString());

                        combo_qty= decimal.Parse(r["product_combo_qty"].ToString());
                        desc_monto = decimal.Parse(r["product_combo_desc_monto"].ToString());



                        txt_invoice_line_price_descuento_monto.Text = (combo_qty*desc_monto).ToString();
                        txt_invoice_line_price_descuento_razon.Text = "DESCUENTO POR COMBO";
                        //CalcLine();
                        AddSymLine();
                    }
                    chk_lock_invoice_detail_qty.Checked = true;
                }
            }

        }
        private void SearchProductSYMPOS(string super_code)
        {
            lv_product_search.BringToFront();

            DB.debugLV(lv_product_search);

            lv_product_search.Columns.Clear();
            lv_product_search.Columns.Add("Barcode", 100);
            lv_product_search.Columns.Add("Description", 305);
            lv_product_search.Columns.Add("Precio", 95);
            lv_product_search.Columns.Add("QTY", 35);
            lv_product_search.Items.Clear();

            if (txt_invoice_line_description.Text.Length > 0 || super_code.Length > 0) //
            {
                string sql_load_products_mysql = "";

                if (super_code.Length > 0) {
                    sql_load_products_mysql = "select* from products where active =1 and (product_sym_barcode = '" + txt_invoice_line_barcode.Text + "' or temp_product_8_codigo = '" + txt_invoice_line_barcode.Text + "' or temp_product_9_codigo_proveedor = '" + txt_invoice_line_barcode.Text + "')";
                } else {
                    sql_load_products_mysql = "select* from products where active =1 and ( product_sym_description like '%" + txt_invoice_line_description.Text + "%' or product_sym_barcode = '" + txt_invoice_line_description.Text + "' or temp_product_8_codigo = '" + txt_invoice_line_description.Text + "' or temp_product_9_codigo_proveedor = '" + txt_invoice_line_description.Text + "' )";
                }

                DataTable tDt = DB.q(sql_load_products_mysql, "", "");
                decimal PrecioTotal;
                if (tDt.HasErrors)
                {
                    MessageBox.Show(DB.get_language("var_err") + " > " + "-Error loading products");
                }
                else
                {
                    foreach (DataRow r in tDt.Rows)
                    {
                        /*decimal v_sym_tax_monto = decimal.Parse(txt_invoice_line_tax.Text); //Impuesto a Cobrar
                            decimal v_tax_porcent = (v_sym_tax_monto / 100);
                            first.cld(v_tax_porcent);
                            decimal v_sym_prod_tax = ((qty * valueDec) * v_tax_porcent);

                            txt_invoice_line_price_tax.Text = v_sym_prod_tax.ToString(DB.ND5);
                            txt_invoice_line_price_subtotal.Text = (qty * valueDec).ToString(DB.ND5);*/
                        decimal output, decimal_product_price, decimal_product_sym_tax;                        
                        PrecioTotal = 0;

                        if (Decimal.TryParse(r["product_price"].ToString(), out decimal_product_price)) {
                            if (Decimal.TryParse(r["product_sym_tax"].ToString(), out decimal_product_sym_tax))
                            {
                                PrecioTotal = decimal_product_price * (1 + (decimal_product_sym_tax / 100));
                            }
                            else {
                                //MessageBox.Show("Error en Precio Sym Tax");
                            }                  
                        }

                        
                        //PrecioTotal = () *( (decimal.Parse(r["product_sym_tax"].ToString()) / 100) +1) );

                        string[] row = { r["product_sym_barcode"].ToString(), r["product_sym_description"].ToString(), PrecioTotal.ToString(), r["product_sym_stock"].ToString() };
                        var lvi = new ListViewItem(row);
                        lv_product_search.Items.Add(lvi);
                    }
                }
            }
        }
        private void SearchProduct(string supercode) {
            if (my_company.company_inventario == "9")
            { //Millenium
                SearchProductMillenium();

            }
            else
            {
                SearchProductSYMPOS( supercode);
            }
                
        }
        private void cmb_btn_action_SelectedIndexChanged(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.cmb_btn_action_SelectedIndexChanged : ");
            string cmd_selected = ((cbi)cmb_btn_action.SelectedItem).HiddenValue;
            if (cmd_selected != "")
            {
                if (cmd_selected == "1")
                {
                    AddSymLine();
                }
                else if (cmd_selected == "2")
                {
                    //UpdateSymLine();
                }
                else if (cmd_selected == "3")
                {
                    cleanLinea();
                }
                else if (cmd_selected == "4")
                {
                    cleanLvInvoice();
                    lv_invoice_detail.Items.Clear();
                    cleanTotals();
                    cleanLinea();
                    cleanCliente();
                    cleanPagacon();
                }
            }
        }
        private void frm_pos_invoice_Shown(object sender, EventArgs e)
        {
            DB.specialRun = "callback_invoice";
            //txt_invoice_client_identification.Focus();

            pnl_pendientes.Location = new Point(360, 215);
            

            if (first.auto_debug) //----------------------------------------------------------------DEBUG -----------DEBUG -----------DEBUG -----------DEBUG -----------
            {
                /*txt_invoice_line_barcode.Text = "7702133860188";
                SearchBarcode();
                saveInvoice("1");*/
                        /*
                        grpClientes.Visible = true;                
                        ClearLVCliente();
                buscarClienteAPI();
                */
            }

        }
        #region CXC
        private void loadSaldoCliente(string client_id)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.loadSaldoCliente : ");
            txt_invoice_cliente_saldo.Text = "0.00";
            string sql_w = " where invoice_client_id='" + client_id + "' and invoice_ref_Codigo is null  and ( invoice_abono_estado =0 or invoice_abono_estado =1 or invoice_abono_estado =2) and invoice_condicion_venta='02' group by invoice_client_id";
            string sql_load_cliente_mysql = "select sum(invoice_TotalComprobante-invoice_abono_total) as abono_saldo from invoice  ";

            DataTable tDt = DB.q(sql_load_cliente_mysql + sql_w, "", "");
            foreach (DataRow r in tDt.Rows)
            {
                txt_invoice_cliente_saldo.Text = decimal.Parse(r["abono_saldo"].ToString()).ToString(DB.ND2); 
            }
        }
        #endregion

        #region ClientesAPI
        private void buscarClienteAPI()
        {
            //cmb_clients_id_type.Text = "";
            DB.sel_combo(ref cmb_invoice_clients_id_type, "");

            _symposapi_clientes = new SYMPOS_API_clientes();

            _symposapi_clientes.THbuscarCliente(DB.CheckCompanyPOS(), txt_invoice_client_identification.Text, txt_invoice_client_name.Text);
            _symposapi_clientes.ProgressChanged += API_ProgressChanged;
            _symposapi_clientes.bgResultados += API_resultados;
        }
        private void API_resultados(object clis) {
            /*if (typeof(clis) == ) {

            }*/
            //Console.WriteLine( ();
            Console.WriteLine(clis.GetType());
            try
            {
                //                EnumerateLists((IList)clis);
                //Clientes myCli = (Clientes)clis);

                /*                foreach (iter as myCli) {

                                }*/
                string tipo_doc = "";
                foreach (Clientes c in (IList)clis) {
                    tipo_doc = "";
                    if (c.clasificacion == "E") {
                        tipo_doc = "03";
                    }
                    else if (c.clasificacion == "J")
                    {
                        tipo_doc = "02";
                    }
                    else if(c.clasificacion == "N") {
                        tipo_doc = "01";
                    }

                        string[] row = { "", tipo_doc, c.cedula,"", c.nombre, "", "" };
                    
                    var lvi = new ListViewItem(row);
                    this.BeginInvoke(new LineReceivedEvent(LineReceived), lvi);

                 //   lv_client.Items.Add(lvi);
                }
                //pb1.Value = 100;
                //JArray _jarray = (JArray)clis;
                /*
                foreach (var myCli in _jarray)
                {

                }*/

            }
            catch (Exception ex)
            { 

            }
        }
        private delegate void LineReceivedEvent(ListViewItem line);
        private void LineReceived(ListViewItem line)
        {
            lv_client.Items.Add(line);
        }
        private void API_ProgressChanged(int progress)
        {
            pb1.Value= progress;
            if (progress == 10)
            {
                lbl_pb.Text = "Conectando...";
            }
            else if (progress == 20)
            {
                lbl_pb.Text = "Buscando...";
            }
            else if (progress == 40)
            {
                lbl_pb.Text = "Procesando...";
            }
            else if (progress == 100)
            {
                lbl_pb.Text = "Listo.";
            }
        }    
        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            // This function fires on the UI thread so it's safe to edit

            // the UI control directly, no funny business with Control.Invoke :)

            // Update the progressBar with the integer supplied to us from the

            // ReportProgress() function.  

            pb1.Value = e.ProgressPercentage;
        }
        private void btn_search_cloud_api_Click(object sender, EventArgs e)
        {
            //varAPIClientes_RootObject ApiCliRO = api.buscarCliente(my_company, txt_invoice_client_identification.Text.ToString(), txt_invoice_client_name.Text.ToString());
            //api.buscarCliente(my_company, txt_invoice_client_identification.Text.ToString(), txt_invoice_client_name.Text.ToString(), ref lv_client);            
            //api.THbuscarCliente(DB.CheckCompanyPOS(), "11157060", "");
            ClearLVCliente();
            buscarClienteAPI();

        }
        private void chk_invoice_client_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_invoice_client_search_close_Click(object sender, EventArgs e)
        {
            grpClientes.Visible = false;
        }
        private void lv_client_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lv_client.Items.Count > 0 && lv_client.SelectedItems.Count > 0)
            {
                if (lv_client.SelectedItems[0].Text.ToString().Length > 0)
                {
                    loadClient(lv_client.SelectedItems[0].Text.ToString());
                }
                else
                {
                    //txt_invoice_client_type.Text = lv_client.SelectedItems[0].SubItems[1].Text.ToString();
                    DB.sel_combo(ref cmb_invoice_clients_id_type, lv_client.SelectedItems[0].SubItems[1].Text.ToString());
                    txt_invoice_client_identification.Text = lv_client.SelectedItems[0].SubItems[2].Text.ToString();
                    txt_invoice_client_phone_number.Text = "";
                    txt_invoice_client_name.Text = lv_client.SelectedItems[0].SubItems[4].Text.ToString();
                    txt_invoice_client_email.Text = "";
                    //Si tiene credito y su saldo

                    grpClientes.Visible = false;
                }

            }
        }
        private void loadClient(string client_id)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.loadClient : ");

            string sql_w = " where client_id='" + client_id + "'";
            string sql_load_cliente_mysql = "select * from clients ";

            DataTable tDt = DB.q(sql_load_cliente_mysql + sql_w, "", "");
            foreach (DataRow r in tDt.Rows)
            {
                //txt_invoice_client_type.Text = r["client_identification_type"].ToString();
                lbl_id_client.Text = client_id;
                DB.sel_combo(ref cmb_invoice_clients_id_type, r["client_identification_type"].ToString());
                txt_invoice_client_identification.Text = r["client_identification"].ToString().PadLeft(12,'0');
                txt_invoice_client_phone_number.Text = r["client_phone_number"].ToString();
                txt_invoice_client_name.Text = r["client_name"].ToString();
                txt_invoice_client_email.Text = r["client_email"].ToString();

                grpClientes.Visible = false;
            }
            loadSaldoCliente(client_id);
        }
        private void ClearLVCliente()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.ClearLVCliente : ");
            DB.debugLV(lv_client);

            lv_client.Columns.Clear();
            lv_client.Columns.Add(DB.get_language("lbl_clients_id"), 0);
            lv_client.Columns.Add(DB.get_language("lbl_clients_identification_type"), 0);
            lv_client.Columns.Add(DB.get_language("lbl_clients_identification"), 118);
            lv_client.Columns.Add(DB.get_language("lbl_clients_phone_number"), 110);
            lv_client.Columns.Add(DB.get_language("lbl_clients_name"), 253);
            lv_client.Columns.Add(DB.get_language("lbl_clients_email"), 205);

            lv_client.Items.Clear();
        }
        private void buscarCliente(string tipo)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.buscarCliente : ");
            grpClientes.Visible = true;
            grpClientes.Location = new Point(8, 193);
            grpClientes.BringToFront();
            lbl_id_client.Text = "0";
            ClearLVCliente();
            bool cargar = false;
            string sql_w = "";
            int invoice_client_int;

            if (tipo == "1")
            { //id
                lv_client.Visible = true;
                lv_client.BringToFront();
                
                //w = "  where client_id=" + client_id;
                if (txt_invoice_client_identification.Text.Length > 0) {
                    int.TryParse(txt_invoice_client_identification.Text.ToString(), out invoice_client_int);
                    sql_w = "  where (client_identification like '%" + txt_invoice_client_identification.Text.ToString() + "%' and client_identification like '%" + invoice_client_int.ToString() + "%' ) ";
                    cargar = true;
                }
                if (txt_invoice_client_name.Text.Length > 0)
                {
                    sql_w = "  where (client_name like '%" + txt_invoice_client_name.Text.ToString() + "%' or client_commercial_name like '%" + txt_invoice_client_name.Text.ToString() + "%') ";

                    cargar = true;
                }
                


                //sql_w = "  where (client_identification like '%" + txt_invoice_client_identification.Text.ToString() + "%' or client_identification like '%" + invoice_client_int.ToString() + "%' ) and (client_name like '%" + txt_invoice_client_name.Text.ToString() + "%' or client_commercial_name like '%" + txt_invoice_client_name.Text.ToString() + "%' )";
            }

            if (cargar)
            {
                string sql_load_clients_mysql = "select * from clients " + sql_w;

                DataTable tDt = DB.q(sql_load_clients_mysql, "", "");

                if (tDt.HasErrors)
                {
                    MessageBox.Show(DB.get_language("var_err") + " > " + "-Error loading client");
                }
                else
                {
                    foreach (DataRow r in tDt.Rows)
                    {
                        string[] row = { r["client_id"].ToString(), r["client_identification_type"].ToString(), r["client_identification"].ToString(), r["client_phone_number"].ToString(), r["client_name"].ToString(), r["client_email"].ToString() };
                        var lvi = new ListViewItem(row);
                        lv_client.Items.Add(lvi);
                    }
                }
            }
            //Check permiso internet
            //Check internet

            


        }
        private void txt_invoice_client_identification_Leave(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.txt_invoice_client_identification_Leave : ");
            //buscarCliente("1");
        }
        private void txt_invoice_client_identification_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.txt_invoice_client_identification_KeyUp : ");
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_invoice_client_identification.Text.Length > 0) {
                    DB.sel_combo(ref cmb_invoice_clients_id_type, "");
                    buscarCliente("1");
                }
                
            }

        }

        #endregion
        #region InvoiceLine
        private void txt_invoice_barcode_line_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.txt_invoice_barcode_KeyUp : ");
            if (e.KeyCode == Keys.Enter)
            {
                //SearchBarcode();
                //txt_invoice_barcode_line_Leave(sender, e);
                if (txt_invoice_line_barcode.Text.Length > 2) {
                    txt_invoice_line_qty.Focus();
                }                else                {
                    txt_invoice_line_description.Focus();
                    
                }
                
            }
            else {
                txt_invoice_line_description.Text = "";
                txt_invoice_line_qty.Text = "";
                txt_invoice_line_price_total.Text= "";
                txt_invoice_line_price_subtotal.Text = "";
                txt_invoice_line_price_total.Text = "";
            }
        }
        private void txt_invoice_barcode_line_Leave(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.txt_invoice_barcode_Leave : ");
            SearchBarcode();
        }
        private void txt_invoice_line_description_Leave(object sender, EventArgs e)
        {
            if (txt_invoice_line_description.Enabled == true)
            {

            }
        }
        private void txt_invoice_line_description_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.txt_invoice_line_description_KeyUp : ");
            if (e.KeyCode == Keys.Enter)
            {

                if (chk_lock_invoice_detail_search_description.Checked)
                {
                    lv_product_search.Visible = true;
                    lv_product_search.Location = new Point(7, 250);
                    SearchProduct("");
                }else {
                    AddSymLine();
                    txt_invoice_line_barcode.Focus();
                }
                
            }
        }


        private void txt_invoice_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.txt_invoice_qty_KeyPress : ");
            /*
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txt_invoice_line_qty.Text.Length > 0)
            {
                int my_qty;
                if (!int.TryParse(txt_invoice_line_qty.Text.ToString(), out my_qty))
                {
                    txt_invoice_line_qty.Text = "0";
                    e.Handled = true;
                }
                else
                {
                    //CalcLine();
                }
            }
            */
            if (!DB.isNumber(e.KeyChar, txt_invoice_line_qty.Text))
                e.Handled = true;
        }
        private void txt_invoice_qty_Leave(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.txt_invoice_qty_Leave : ");
            if (txt_invoice_line_qty.Text.Length > 0)
            {
                //int my_qty;
                //if (!int.TryParse(txt_invoice_line_qty.Text.ToString(), out my_qty))
                decimal my_qty = 0;
                if (!decimal.TryParse(txt_invoice_line_qty.Text.ToString(), out my_qty))
                {
                    txt_invoice_line_qty.Text = "0";
                }
            }
            CalcLine();
        }
        private void txt_invoice_qty_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.txt_invoice_qty_KeyUp : ");

            decimal qty = 0;
            if (decimal.TryParse(txt_invoice_line_qty.Text.ToString(), out qty))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AddSymLine();
                    txt_invoice_line_barcode.Focus();
                }
                else
                {
                    CalcLine();
                }
            }
            else
            {
                //MessageBox.Show("Debe ingresar un número");
            }
            
        }
        #endregion

        private void cmb_invoice_cur_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_invoice_cur.Text = ((cbi)cmb_invoice_cur.SelectedItem).HiddenValue;
        }
        private void cmb_invoice_sale_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((cbi)cmb_invoice_sale_type.SelectedItem).HiddenValue == "02") {
                txt_invoice_credit_days.Text = "";
                txt_invoice_credit_days.Enabled = true;
            } else {
                txt_invoice_credit_days.Text = "0";
                txt_invoice_credit_days.Enabled = false;
            }
        }
        private void txt_invoice_credit_days_KeyPress(object sender, KeyPressEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.txt_invoice_credit_days_KeyPress : ");
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txt_invoice_credit_days.Text.Length > 0)
            {
                int my_qty;
                if (!int.TryParse(txt_invoice_credit_days.Text.ToString(), out my_qty))
                {
                    txt_invoice_credit_days.Text = "0";
                    e.Handled = true;
                }
                else
                {
                }
            }
        }
        private void txt_invoice_credit_days_Leave(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.txt_invoice_credit_days_Leave : ");
            if (txt_invoice_credit_days.Text.Length > 0)
            {
                int my_qty;
                if (!int.TryParse(txt_invoice_credit_days.Text.ToString(), out my_qty))
                {
                    txt_invoice_credit_days.Text = "0";
                }
            }
        }
        private void frm_pos_invoice_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.frm_pos_invoice_KeyUp: ");
            if (e.KeyCode >= Keys.F1 && e.KeyCode <= Keys.F24)
            {
                if (e.KeyCode == Keys.F2) {
                    txt_invoice_line_barcode.Focus();
                }
            }
        }
        private void frm_pos_invoice_Load(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.frm_pos_invoice_Load: ");

            if (my_company.id_company == "")
            {
                MessageBox.Show("No active company");
                this.Close();
            }
            else {
                txt_company_identification.Text = my_company.company_identification;
                txt_company_name.Text = my_company.company_name;

                first myFirst = first.GetInstance();
                
                string suc = myFirst.getKey("pos_sucursal");
                string ter = myFirst.getKey("pos_terminal");
                txt_company_ter.Text = my_company.cloud_api_type + ":" + suc + "-" + ter;

                test_internet();
            }
            txt_invoice_line_barcode.Focus();
        }
            
        #region internetTest
        private void PP_RunCompleted(bool  complete)
        {
            bg_ping_state = false;
            try
            {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : "+ complete);
                if (complete) {
                    first.ping_error = false;
                    pb_internet.Image = il_internet.Images[0];
                    sendPendingsV2_master();
                } else {
                    pb_internet.Image = il_internet.Images[3];
                }
            }
            catch
            {
            }
        }
        private void test_internet()
        {
            lbl_computer_name.Text = Environment.MachineName.ToString();

            if (bg_ping_state) {
                return;
            }
             bg_ping_state = true;
            first.ping_error = true;
            try{
                pb_internet.Image = il_internet.Images[1];
                SYMPOS_internet _li = new SYMPOS_internet();
                _li.th_do_ping();
                _li.RunCompleted += PP_RunCompleted;
            }
            catch {

            }
            
        }
        private void pb_internet_Click(object sender, EventArgs e)
        {
            test_internet();
        }
        #endregion

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sql = "select * from x_m_facturasn where num_factura='" + textBox1.Text.ToString() + "'";
                string sqld = "select * from x_m_facturasn_detalle where num_factura='" + textBox1.Text.ToString() + "'";

                DataTable tDt = DB.q(sql, "", "");

                foreach (DataRow r in tDt.Rows)
                {
                    textBox2.Text = r["subtotal"].ToString() + "\r\n" + textBox2.Text;
                    textBox2.Text = r["impuesto"].ToString() + "\r\n" + textBox2.Text;
                    textBox2.Text = r["total"].ToString() + "\r\n" + textBox2.Text;
                }

                DataTable tDtd = DB.q(sqld, "", "");

                foreach (DataRow r in tDtd.Rows)
                {
                    textBox2.Text = r["codigo"].ToString() + " - " + r["cantidad"].ToString() + " - " + r["precioU"].ToString() + " - " + r["precioO"].ToString() + " - " + r["totalO"].ToString() + " - " + "\r\n" + textBox2.Text; ;
                    if (r["codigo"].ToString() == "") {
                        txt_invoice_line_description.Text = r["descripcion"].ToString();
                    } else {
                        txt_invoice_line_barcode.Text = r["codigo"].ToString();
                        SearchBarcode();
                        txt_invoice_line_qty.Text = r["cantidad"].ToString();
                        if (txt_invoice_line_sym_unit.Text.ToString() == "Sp") {

                        }
                        txt_invoice_line_price.Text = r["precioU"].ToString();
                    }
                    CalcLine();
                    AddSymLine();
                }
            }
        }
        private void saveInvoiceV3(string tipoPS)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.saveInvoice v3 : " + tipoPS.ToString());

            btn_invoice_save_print.Enabled = false;
            btn_invoice_save_email.Enabled = false;


            grpFe.Visible = true;
            grpFe.BringToFront();
            lv_fe_report.Columns.Clear();
            lv_fe_report.Columns.Add("Resultado", 200);
            lv_fe_report.Items.Clear();
            pb_fe.Value = 10;

            int lineasDetalle = 0;
            string allErrors = "";
            string invoice_medio_pago = "01";

            bool imprime_ready = false;
            #region Verification
            bool continuar = true;

            decimal v_sym_total = decimal.Parse(txt_invoice_totals_total.Text);
            VarCompany my_client = new VarCompany();

            if (v_sym_total < 1)
            {
                continuar = false;
                allErrors += System.Environment.NewLine + DB.get_language("var_data_error");
            }

            if (btn_cred.Enabled == false)
            {
                invoice_medio_pago = "02";
            }
            bool check_client;

            if (((cbi)cmb_invoice_document_type.SelectedItem).HiddenValue.ToString() == "04") //Tiquete 
            {
                check_client = false; //No requiere cliente
            }
            else {
                check_client = true; //Factura Electronica requiere cliente
            }
            
            if (tipoPS == "1" || tipoPS == "2")
            {
                //save and print
                if (!check_client)
                {
                    //NO HAY CLIENTE ?
                    //continuar = false;
                    //allErrors += System.Environment.NewLine + DB.get_language("err_client");
                    if (lbl_id_client.Text.Length > 0 && lbl_id_client.Text.ToString() != "0" )
                    {
                        my_client.id_company = lbl_id_client.Text.ToString();
                        if(cmb_invoice_clients_id_type.SelectedItem != null){
                        my_client.company_type = ((cbi)cmb_invoice_clients_id_type.SelectedItem).HiddenValue;
                            
                        my_client.company_identification = txt_invoice_client_identification.Text.ToString();
                        }
                        my_client.company_name = txt_invoice_client_name.Text.ToString();
                        my_client.company_phone = txt_invoice_client_phone_number.Text.ToString();
                        my_client.company_email = txt_invoice_client_email.Text.ToString();
                    }
                        
                }
                else
                {
                    if (txt_invoice_client_identification.Text.Length > 0)
                    {
                        if (txt_invoice_client_identification.Text.Length < 9)
                        {
                            continuar = false;
                            allErrors += System.Environment.NewLine + DB.get_language("err_client") + " Cédula"; ;
                        }

                        if (cmb_invoice_clients_id_type.SelectedItem != null && cmb_invoice_clients_id_type.SelectedIndex > -1)
                        {
                            //sql_save_clients_mysql += " ,client_identification_type = '" + ((cbi)cmb_clients_id_type.SelectedItem).HiddenValue + "'";
                            //if (cmb_invoice_clients_id_type.Text.Length < 1)                            
                        }
                        else
                        {
                            continuar = false;
                            allErrors += System.Environment.NewLine + DB.get_language("err_client") + " Tipo identificación";
                        }

                        if (txt_invoice_client_email.Text.Length < 5)
                        {
                            continuar = false;
                            allErrors += System.Environment.NewLine + DB.get_language("err_client") + " Email";
                        }
                        else
                        {
                            RegexUtilities util = new RegexUtilities();
                            if (!util.IsValidEmail(txt_invoice_client_email.Text.ToString()))
                            {
                                continuar = false;
                                allErrors += System.Environment.NewLine + DB.get_language("err_client") + " Email";
                            }
                        }

                        if (txt_invoice_client_phone_number.Text.Length < 8 || txt_invoice_client_phone_number.Text.Length > 8)
                        {
                            //continuar = false;
                            //allErrors += System.Environment.NewLine + DB.get_language("err_client") + " Teléfono";
                        }

                        if (continuar)
                        {
                            my_client.id_company = lbl_id_client.Text.ToString();
                            my_client.company_type = ((cbi)cmb_invoice_clients_id_type.SelectedItem).HiddenValue;
                            my_client.company_identification = txt_invoice_client_identification.Text.ToString();
                            my_client.company_name = txt_invoice_client_name.Text.ToString();
                            my_client.company_phone = txt_invoice_client_phone_number.Text.ToString();
                            my_client.company_email = txt_invoice_client_email.Text.ToString();
                        }
                    }
                    else
                    {
                        continuar = false;
                        allErrors += System.Environment.NewLine + DB.get_language("err_client");
                    }
                }
                //}else if (tipoPS == "2"){
                //Save Hide Email

            }
            else if (tipoPS == "3")
            {
                //Save Special

            }


            #region CheckCredito
            if (((cbi)cmb_invoice_sale_type.SelectedItem).HiddenValue.ToString() == "02" || ((cbi)cmb_invoice_sale_type.SelectedItem).HiddenValue.ToString() == "04" )
            {
                /*if (!check_client)
                {
                    //error
                    continuar = false;
                    allErrors += System.Environment.NewLine + DB.get_language("err_client") + " " + DB.get_language("err_credit");
                }
                else
                {*/
                    if (lbl_id_client.Text== "0") {
                        continuar = false;


                       /* if (MessageBox.Show("Para poder continuar se requiere que el cliente se encuentre salvado, desea salvador en la tabla de clientes?", "POS", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                         
                        }
                        else
                        {
                            continuar = true;
                        }
                        */
                            allErrors += System.Environment.NewLine + DB.get_language("lbl_invoice_client_id") + " " + DB.get_language("err_credit");   


                    }
                    if (txt_invoice_credit_days.Text.Length > 0)
                    {
                        int my_credit_days;
                        if (!int.TryParse(txt_invoice_credit_days.Text.ToString(), out my_credit_days))
                        {
                            continuar = false;
                            allErrors += System.Environment.NewLine + DB.get_language("lbl_invoice_credit_days") + " " + DB.get_language("err_credit");
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        continuar = false;
                        allErrors += System.Environment.NewLine + DB.get_language("lbl_invoice_credit_days") + " " + DB.get_language("err_credit");
                    }
                //}
            }
            #endregion

            #endregion

            pb_fe.Value = 20;

            #region SaveInvoice
            if (continuar)
            {
                check_client = true;
                btn_invoice_save_print.Enabled = false;
                btn_invoice_save_email.Enabled = false;

                Application.DoEvents();
                lv_fe_report.Items.Add("Salvando Factura");
                //more than 1 line
                if (lv_invoice_detail.Items.Count > 0)
                {
                    //ok
                    //crear factura

                    //insert into invoice set invoice_uuid = UUID();
                    //insert into de_prod_0123456789_te set ref_if = select LAST_INSERT_ID();
                    //crear consecutivo
                    string invoice_id = "";
                    bool errorLocalInvoice = false;
                    SYMPOS_local_fe newFe = new POSV2.SYMPOS_local_fe();
                    SYMPOSprint newFePrint = new POSV2.SYMPOSprint();

                    
                        string sql_check_last_error_invoices = "";

                        if (!first.auto_debug)
                        {
                            sql_check_last_error_invoices = "select count(*) as cuenta from invoice where invoice_api_type=1 and invoice_local_state > 4 and (invoice_hacienda_ind_estado = ''  or invoice_hacienda_ind_estado is null) and(invoice_hacienda_lastdate < SUBTIME(now(), '1:00:00')  or invoice_hacienda_lastdate is null) limit 1";
                        }
                        else
                        {
                            sql_check_last_error_invoices = "select count(*) as cuenta from invoice where invoice_local_state > 4 and (invoice_hacienda_ind_estado = ''  or invoice_hacienda_ind_estado is null) and(invoice_hacienda_lastdate < SUBTIME(now(), '0:00:30')  or invoice_hacienda_lastdate is null) limit 1";
                        }

                        DataTable tDt = DB.q(sql_check_last_error_invoices, "", "");
                        int cuenta_pendientes = 0;
                        foreach (DataRow r in tDt.Rows)
                        {
                            lbl_invoice_pending.Text = "Facturas Pendientes : " + r["cuenta"].ToString();

                            try
                            {
                                cuenta_pendientes = Int32.Parse(r["cuenta"].ToString());
                                if (cuenta_pendientes > 1000)
                                {
                                    lv_fe_report.Items.Add("Pendientes Maximos...");
                                    MessageBox.Show(DB.get_language("var_err") + " Limite de pendientes máximos permitidos");
                                    DB.e("insert into invoice_bita set invoice_id='0' ,user_id='', bita_date=now(), bita_type='10003002', bita_error='SYMsaveInvoice 02'", "", "");
                                    errorLocalInvoice = true;
                                    return;
                                }
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }
                        //
                        //
                        //check last 100 invoices 

                    if (newFe.SYMsaveInvoice(
                        ((cbi)cmb_invoice_act_eco.SelectedItem).HiddenValue.ToString(),
                        ((cbi)cmb_invoice_document_type.SelectedItem).HiddenValue.ToString(),
                        ((cbi)cmb_invoice_cur.SelectedItem).ToString(),
                        txt_invoice_cur.Text.ToString(),
                        ((cbi)cmb_invoice_sale_type.SelectedItem).HiddenValue.ToString(),
                        txt_invoice_credit_days.Text.ToString(), invoice_medio_pago, check_client
                        ) == 1
                        )
                    {
                        invoice_id = DB.lId;
                        //MessageBox.Show("ID : " + DB.lId);
                        int resSYMID = 0;
                        int resSYMTotalsID = 0;

                        #region SaveInvoiceDetail
                        foreach (ListViewItem item in lv_invoice_detail.Items)
                        {
                            resSYMID = newFe.SYMsaveInvoiceDetail(invoice_id,
                                item.SubItems[lvId["lv_invoice_detail_num"]].Text.ToString(),
                                item.SubItems[lvId["lv_invoice_detail_id_product"]].Text.ToString(),
                                item.SubItems[lvId["lv_invoice_detail_sym"]].Text.ToString(),
                                item.SubItems[lvId["lv_invoice_detail_sym_unit"]].Text.ToString(),
                                item.SubItems[lvId["lv_invoice_detail_code_type"]].Text.ToString(),
                                item.SubItems[lvId["lbl_products_barcode"]].Text.ToString(),
                                item.SubItems[lvId["lv_invoice_detail_tax_code"]].Text.ToString(),
                                item.SubItems[lvId["lv_invoice_detail_tax_code_iva"]].Text.ToString(),
                                item.SubItems[lvId["lv_invoice_detail_tax"]].Text.ToString(),
                                item.SubItems[lvId["lbl_products_description"]].Text.ToString(),
                                item.SubItems[lvId["lv_invoice_detail_qty"]].Text.ToString(),
                                item.SubItems[lvId["lbl_products_price"]].Text.ToString(),
                                item.SubItems[lvId["lv_invoice_detail_price_MontoTotal"]].Text.ToString(),
                                item.SubItems[lvId["lv_invoice_detail_price_Descuento"]].Text.ToString(),
                                item.SubItems[lvId["lv_invoice_detail_price_Descuento_razon"]].Text.ToString(),
                                item.SubItems[lvId["lv_invoice_detail_price_SubTotal"]].Text.ToString(),
                                item.SubItems[lvId["lbl_products_price_tax"]].Text.ToString(),
                                item.SubItems[lvId["lbl_products_price_total"]].Text.ToString(),
                                item.SubItems[lvId["lv_invoice_detail_cabys"]].Text.ToString()
                                );

                            if (resSYMID == 0)
                            {
                                DB.e("insert into invoice_bita set invoice_id='" + invoice_id + "' ,user_id='', bita_date=now(), bita_type='10001001', bita_error='SYMsaveInvoiceDetail 01'", "", "");
                                MessageBox.Show(DB.get_language("var_err") + " SYMsaveInvoiceDetail");
                                errorLocalInvoice = true;
                            }
                            else
                            {
                                lineasDetalle++;
                            }
                        } //ForEach
                        #endregion
                        
                        #region SaveInvoiceDetailVerification
                        if (lineasDetalle == 0)
                        {
                            MessageBox.Show(DB.get_language("var_err") + " SYMsaveInvoiceDetail");
                            DB.e("insert into invoice_bita set invoice_id='" + invoice_id + "' ,user_id='', bita_date=now(), bita_type='10001002', bita_error='SYMsaveInvoiceDetail 02'", "", "");
                            errorLocalInvoice = true;
                        }
                        if (!errorLocalInvoice)
                        {
                            DB.e(" update invoice set invoice_local_state=invoice_local_state+1 where invoice_id='" + invoice_id + "'", "", ""); //1
                        }
                        #endregion

                        #region SaveInvoiceCompany
                        resSYMID = newFe.SYMUpdateInvoiceCompany(invoice_id, my_company);
                        if (resSYMID == 0)
                        {
                            MessageBox.Show(DB.get_language("var_err") + " SYMUpdateInvoiceCompany");
                            errorLocalInvoice = true;
                        }
                        //resSYMID = newFe.SYMUpdateInvoiceCustomer
                        #endregion

                        #region SaveInvoiceClient
                        if (check_client)
                        {
                            resSYMID = newFe.SYMUpdateInvoiceClient(invoice_id, my_client);
                            if (resSYMID == 0)
                            {
                                MessageBox.Show(DB.get_language("var_err") + " SYMUpdateInvoiceClient");
                                errorLocalInvoice = true;
                            }

                        }
                        #endregion

                        #region SaveInvoiceTotals
                        if (!errorLocalInvoice)
                        {
                            resSYMTotalsID = newFe.SYMUpdateInvoiceTotals(invoice_id,
                                txt_TotalServGravados.Text, txt_TotalServExentos.Text,
                                txt_TotalMercanciasGravadas.Text, txt_TotalMercanciasExentas.Text,
                                txt_TotalGravado.Text, txt_TotalExento.Text,
                                txt_TotalVenta.Text, txt_TotalDescuentos.Text,
                                txt_TotalVentaNeta.Text, txt_TotalImpuesto.Text, txt_TotalComprobante.Text
                                );
                        }
                        if (resSYMTotalsID == 0)
                        {
                            MessageBox.Show(DB.get_language("var_err") + " SYMUpdateInvoiceTotals");
                            errorLocalInvoice = true;
                        }
                        #endregion

                        if (!errorLocalInvoice)
                        {
                            //Conseguir Consecutivo del API

                            //Caso de Error Crear Consecutivo local

                            lv_fe_report.Items.Add("Factura Salvada...");
                            Application.DoEvents();
                            errorLocalInvoice = SYMPOS_local_fe.createConsecutivo(invoice_id); //, my_company.company_identification.ToString()
                            if (errorLocalInvoice)
                            {
                                lv_fe_report.Items.Add("Ocurrió un error...");
                                return;

                            }

                            
                            Application.DoEvents();
                            //check if consecutivo is created


                            Application.DoEvents();
                            lv_fe_report.Items.Add("#" + SYMPOS_local_fe.g_clave20);
                            if (tipoPS == "1")
                            {


                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: newFePrint.printpos");
                                    newFePrint.printpos(invoice_id);                                
                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "A: newFePrint.printpos");
                                lv_fe_report.Items.Add("Factura Impresa...");
                            }
                            else
                            {
                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "A: NO-printpos");
                                lv_fe_report.Items.Add("Factura No-imprime...");
                            }
                            Application.DoEvents();
                            decimal dec_qty = 0;
                            if (my_company.company_inventario == "9"){ //Millenium
                                //DesCargar Inventario
                                foreach (ListViewItem item in lv_invoice_detail.Items)
                                {
                                    if (item.SubItems[lvId["lbl_products_barcode"]].Text.Length > 0) {
                                        //item.SubItems[lvId["lv_invoice_detail_qty"]].Text.ToString(),
                                        
                                        DB.e("update pos.productos_bodegas set cantidad = cantidad - " + decimal.Parse(item.SubItems[lvId["lv_invoice_detail_qty"]].Text.ToString()) +  " where codigo ='" + item.SubItems[lvId["lbl_products_barcode"]].Text.ToString() + "' and id_bodega=1","","");
                                        //kardexnew codigo, cantidad, "61", "", Bodega
                                        DB.e("insert into pos.kardexnew set cod_item='" + item.SubItems[lvId["lbl_products_barcode"]].Text.ToString() + "',cantidad='" + decimal.Parse(item.SubItems[lvId["lv_invoice_detail_qty"]].Text.ToString()) + "'," +
                                            "user='" + DB.user_login_id + "',fecha=now(),tipo='61',note='f:"+ SYMPOS_local_fe.g_clave20 + "',modulo='SYMPOSv2'", "","");
                                    }
                                }
                            }else if (my_company.company_inventario == "2"){ //Descarga inventario hasta 0
                                foreach (ListViewItem item in lv_invoice_detail.Items)
                                {
                                    if (item.SubItems[lvId["lbl_products_barcode"]].Text.Length > 0)
                                    {
                                        dec_qty = decimal.Parse(item.SubItems[lvId["lv_invoice_detail_qty"]].Text.ToString());
                                        DB.e(" update products set product_sym_stock= if(product_sym_stock-"+ dec_qty + " >= 0 ,product_sym_stock-"+ dec_qty + ", product_sym_stock=0)  where product_sym_barcode ='" + item.SubItems[lvId["lbl_products_barcode"]].Text.ToString() + "' ", "", "");
                                    }
                                }
                            }
                            else if (my_company.company_inventario == "3"){ //Descarga inventario hasta -0
                                foreach (ListViewItem item in lv_invoice_detail.Items)
                                {
                                    if (item.SubItems[lvId["lbl_products_barcode"]].Text.Length > 0)
                                    {
                                        dec_qty = decimal.Parse(item.SubItems[lvId["lv_invoice_detail_qty"]].Text.ToString());
                                        DB.e(" update products set product_sym_stock=product_sym_stock-" + dec_qty + "  where product_sym_barcode ='" + item.SubItems[lvId["lbl_products_barcode"]].Text.ToString() + "' ", "", "");
                                    }
                                }
                            }

                                if (!first.auto_debug)
                            {
                                lv_invoice_detail.Items.Clear();
                                cleanTotals();
                                cleanLinea();
                                cleanCliente();
                                cleanPagacon();
                            }

                            DB.e("insert into invoice_bita set invoice_id='" + invoice_id + "' ,user_id='', bita_date=now(), bita_type='10003003', bita_error='" + SYMPOS_local_fe.SYMinvoiceUUID(invoice_id) + "'", "", "");
                            //first.cld(DateTime.Now.ToString("h:mm:ss tt") + "En contingencia");
                            
                            pb_fe.Value = 90;
                            pb_fe.Value = pb_fe.Value + 10;

                            txt_invoice_line_barcode.Focus();

                        }
                        else
                        {
                            MessageBox.Show("9x004 " + DB.get_language("var_err") + " SYMsaveInvoice");
                            DB.e("insert into invoice_bita set invoice_id='0' ,user_id='', bita_date=now(), bita_type='10003001', bita_error='SYMsaveInvoice 01'", "", "");
                            errorLocalInvoice = true;
                        } //errorLocalInvoice
                    }
                    else
                    {
                        MessageBox.Show("9x003 " + DB.get_language("var_err") + " SYMsaveInvoice");
                        DB.e("insert into invoice_bita set invoice_id='0' ,user_id='', bita_date=now(), bita_type='10001000', bita_error='SYMsaveInvoice 01'", "", "");
                        errorLocalInvoice = true;
                    } // SYMsaveInvoice

                    //newFe.saveClient(txt_invoice_client_identification, txt_invoice_client_phone_number, txt_invoice_client_name, txt_invoice_client_email);
                    //newFe.createConsecutivo();

                }
                else
                {

                    //Error 
                    MessageBox.Show("9x002 " + DB.get_language("var_err") + System.Environment.NewLine + DB.get_language("err_detail_line"));
                    DB.e("insert into invoice_bita set invoice_id='0' ,user_id='', bita_date=now(), bita_type='10002001', bita_error='Error 02'", "", "");
                } // lv_invoice_detail.Items.Count > 0
            }
            else
            {
                MessageBox.Show("9x001 " + DB.get_language("var_err") + allErrors);
                DB.e("insert into invoice_bita set invoice_id='0' ,user_id='', bita_date=now(), bita_type='10002000', bita_error='Error 01 - " + allErrors.ToString() + "'", "", "");
                txt_invoice_line_barcode.Focus();
            } //continuar
            btn_efectivo.Enabled = true;
            btn_cred.Enabled = true;
            #endregion
        }

        private void btn_invoice_save_email_Click(object sender, EventArgs e)
        {

            saveInvoiceV3("2");


        }
        private void btn_invoice_save_print_Click(object sender, EventArgs e)
        {            
            saveInvoiceV3("1");
        }

        
        private void frm_pos_invoice_MouseClick(object sender, MouseEventArgs e)
        {
            txt_invoice_client_identification.Focus();
        }

        #region BotonesCash
        private void activateBotones(string tipo_botones = "") {

            btn_invoice_save_print.Enabled = true;
            btn_invoice_save_email.Enabled = true;
        }
        private void btn_col1_Click(object sender, EventArgs e)
        {
            txt_cal_pagacon.Text = "1000";
            calculaVuelto("Efectivo");
            activateBotones();
        }
        private void btn_col2_Click(object sender, EventArgs e)
        {
            txt_cal_pagacon.Text = "2000";
            calculaVuelto("Efectivo");
            activateBotones();
        }
        private void btn_col3_Click(object sender, EventArgs e)
        {
            txt_cal_pagacon.Text = "5000";
            calculaVuelto("Efectivo");
            activateBotones();
        }
        private void btn_col4_Click(object sender, EventArgs e)
        {
            txt_cal_pagacon.Text = "10000";
            calculaVuelto("Efectivo");
            activateBotones();
        }
        private void btn_col5_Click(object sender, EventArgs e)
        {
            txt_cal_pagacon.Text = "20000";
            calculaVuelto("Efectivo");
            activateBotones();
        }
        private void btn_col6_Click(object sender, EventArgs e)
        {
            txt_cal_pagacon.Text = "50000";
            calculaVuelto("Efectivo");
            activateBotones();
        }
        private void btn_cred_Click(object sender, EventArgs e)
        {
            calculaVuelto("Credito");
            activateBotones();
        }
        private void btn_efectivo_Click(object sender, EventArgs e)
        {
            calcInvoice();            
            calculaVuelto("EfectivoExacto");
            activateBotones();
        }
        #endregion

        private void calculaVuelto(string tipoPago = "") {

            if (tipoPago == "Credito")
            {
                btn_cred.Enabled = false;
                btn_efectivo.Enabled = true;
            }
            else if (tipoPago == "Efectivo" || tipoPago == "EfectivoExacto")
            {
                btn_cred.Enabled = true;
                btn_efectivo.Enabled = false;
            }
            string my_paga_con = txt_cal_pagacon.Text;
            if (my_company.company_inventario == "9")
            { //Millenium
                calculeLineasMillenium();
            }
            calcInvoice();
            //txt_cal_pagacon.Text = my_paga_con;
            if (txt_cal_pagacon.Text.Length > 0)
            {
                if (tipoPago == "Credito" || tipoPago == "EfectivoExacto")
                {
                    txt_cal_pagacon.Text = txt_invoice_totals_total.Text;
                }
                
                decimal v_sym_total = decimal.Parse(txt_invoice_totals_total.Text);
                decimal v_paga = decimal.Parse(txt_cal_pagacon.Text);
                txt_cal_vuelto.Text = decimal.Round(v_paga - v_sym_total, DB.RD5).ToString();
                
            }
        }
        private void txt_cal_pagacon_KeyPress(object sender, KeyPressEventArgs e)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.txt_cal_pagacon_KeyPress : ");
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txt_cal_pagacon.Text.Length > 0)
            {
                int my_qty;
                if (!int.TryParse(txt_cal_pagacon.Text.ToString(), out my_qty))
                {
                    txt_cal_pagacon.Text = "0";
                    e.Handled = true;
                }
                else
                {
                    //calculaVuelto();
                }
            }
        }
        private void txt_cal_pagacon_KeyUp(object sender, KeyEventArgs e)
        {
            calculaVuelto();
            activateBotones();
        }        
        private void btn_abarrotes_exento_Click(object sender, EventArgs e)
        {


                txt_invoice_line_barcode.Text = "1";
                SearchBarcode();
            
            
                txt_invoice_line_qty.Text = "1";
            
            
        }
        private void btn_abarrotes_gravado_Click(object sender, EventArgs e)
        {


            txt_invoice_line_barcode.Text = "2";
            SearchBarcode();


            txt_invoice_line_qty.Text = "1";
        }   
        private void btn_fe_aceptar_Click(object sender, EventArgs e)
        {
            grpFe.Visible = false;
            txt_invoice_line_barcode.Focus();
        }

        private void lv_fe_report_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lv_fe_report.SelectedItems.Count> 0)
            {
                try
                {
                    txt_lv_fe_report.Text = lv_fe_report.SelectedItems[0].Text.ToString().Split('.')[2];
                }
                catch{
                }
                
            }
            
        }

        private void btn_invoice_client_add_Click(object sender, EventArgs e)
        {

        }

        private void lv_product_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lv_product_search.SelectedItems.Count> 0)
            {
                try
                {
                    txt_invoice_line_barcode.Text = lv_product_search.SelectedItems[0].Text.ToString();
                    
                    lv_product_search.Visible = false;
                    SearchBarcode();
                }
                catch{
                }
                
            }
        }

        private void txt_invoice_client_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DB.sel_combo(ref cmb_invoice_clients_id_type, "");
                buscarCliente("1");
            }
        }
        #region SendPendings
        private int sendPendingsCount() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: sendPendingsV2_master.sendPendingsCount"); 
            string sql_check_last_error_invoices = "";

            if (!first.auto_debug)
            {
                sql_check_last_error_invoices = "select count(*) as cuenta from invoice inner join company on company.company_identification=invoice.invoice_company_identification where company.active=1 and invoice_api_type=1 and invoice_local_state > 4 and invoice_clave is not null and (invoice_hacienda_ind_estado = ''  or invoice_hacienda_ind_estado is null) and(invoice_hacienda_lastdate < SUBTIME(now(), '1:00:00')  or invoice_hacienda_lastdate is null) ";
            }
            else
            {
                sql_check_last_error_invoices = "select count(*) as cuenta from invoice inner join company on company.company_identification=invoice.invoice_company_identification where company.active=1 and                        invoice_local_state > 4 and invoice_clave is not null and (invoice_hacienda_ind_estado = ''  or invoice_hacienda_ind_estado is null) and(invoice_hacienda_lastdate < SUBTIME(now(), '0:05:00')  or invoice_hacienda_lastdate is null) ";
            }

            DataTable tDtCount_pendientes = DB.q(sql_check_last_error_invoices, "", "", true, true);
            int cuenta_pendientes = 0;
            foreach (DataRow r in tDtCount_pendientes.Rows)
            {
                cuenta_pendientes = int.Parse( r["cuenta"].ToString());
                lbl_invoice_pending.Text = "Facturas Pendientes : " + r["cuenta"].ToString();
            }
            return cuenta_pendientes;
        }
        private void sendPendingsV2_master()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: sendPendingsV2_master");
            bg_state_count++;
            if (bg_state_count > 10) {
                bg_state_count = 0;
                bg_state = false;
            }
            if (bg_state) {
                return;
            }
            
            if (first.ping_error)
            {
                test_internet();
                //wait for ping
                int count = 0;
                while (bg_ping_state)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                    count++;
                    if (count == 10)
                    {
                        break;
                    }
                }
            }

            string invoice_id = "";
            string invoice_uuid = "";
            string invoice_api_type = "";

            int count_rows = 0;
            if (sendPendingsCount() ==0) {
                return;
            }

            if (first.ping_error)
            {
                return;
            }

            bg_state = true;
            bg_state_count = 0;
            //string sql_load_invoice_documento_referencia = "select * from invoice where invoice_id = '" + invoice_id + "'";
            string sql_load_invoice_pendings = "";
            if (!first.auto_debug)
            {
                sql_load_invoice_pendings = "select* from invoice inner join company on company.company_identification=invoice.invoice_company_identification where company.active=1 and invoice_api_type=1 and invoice_local_state > 4 and invoice_clave is not null and (invoice_hacienda_ind_estado = ''  or invoice_hacienda_ind_estado is null) and(invoice_hacienda_lastdate < SUBTIME(now(), '1:00:00')  or invoice_hacienda_lastdate is null) order by invoice_id desc limit 1 ";
            }
            else {
                sql_load_invoice_pendings = "select* from invoice inner join company on company.company_identification=invoice.invoice_company_identification where                        company.active=1 and invoice_local_state > 4 and invoice_clave is not null and (invoice_hacienda_ind_estado = ''  or invoice_hacienda_ind_estado is null) and(invoice_hacienda_lastdate < SUBTIME(now(), '0:05:00')  or invoice_hacienda_lastdate is null) order by invoice_id desc limit 1";
            }                

            DataTable tDt = DB.q(sql_load_invoice_pendings, "", "",true,true);
            foreach (DataRow r in tDt.Rows)
            {
                invoice_id = r["invoice_id"].ToString();
                invoice_uuid = r["invoice_uuid"].ToString();
                invoice_api_type = r["invoice_api_type"].ToString();
                count_rows++;
            }
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "count "+ count_rows); 
            if (invoice_uuid == "")
            {
                bg_state = false;
                return;
            }

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Enviando");
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: SYMPOS_API_Fe");
            BackgroundWorker bg = new BackgroundWorker();
            bg.WorkerReportsProgress = true;
            bg.DoWork += new DoWorkEventHandler(sendPendingsV2_thread);
            //bg.ProgressChanged += new ProgressChangedEventHandler(bg_ProgressChanged);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(sendPendingsV2_thread_end);
            object[] parameters = new object[] { invoice_id, invoice_uuid , invoice_api_type };
            try {
                bg.RunWorkerAsync(parameters);

            }
            catch {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: sendPendingsV2_master.RunWorkerAsync catch");
            }
            

        }
        private void sendPendingsV2_thread_end(object sender, RunWorkerCompletedEventArgs e)
        {
            bg_state = false;
        }
        private void sendPendingsV2_thread(object sender, DoWorkEventArgs e)
        {
            object[] parameters = e.Argument as object[];

            sendPendings((string)parameters[0], (string)parameters[1], (string)parameters[2],true);
        }
        private void sendPendings(string invoice_id ,string invoice_uuid,string invoice_api_type,bool th_bg =false) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: invoice.sendPendings");
            string api_resultado = "";
            string remote_state = "";

            if (invoice_uuid == "") {
                bg_state = false;
                return;
            }
            bool api_resultado_repetir = true;
            _SYMFE = new SYMPOS_API_Fe();
            try
            {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: _SYMFE.getStatusApi");
                //MessageBox.Show("Test1");
                api_resultado = _SYMFE.getStatusApi(invoice_uuid, invoice_api_type,false);

                if (api_resultado.Length > 0)
                {
                    if (api_resultado.ToString().Split('|')[2].Length>0)
                    {
                        api_resultado_repetir = false;
                    }
                    if (api_resultado.ToString().Split('|')[1] == "202")
                    {
                        api_resultado_repetir = false;
                    }

                }

                if (api_resultado_repetir) { 
                    //Reenviarlo
                    if (remote_state == "")
                    {

                        _SYMFE.uploadFE(invoice_id, th_bg);
                        DB.e("insert into invoice_bita set invoice_id='" + invoice_id + "' ,user_id='', bita_date=now(), bita_type='10003004', bita_error='" + SYMPOS_local_fe.SYMinvoiceUUID(invoice_id) + "'", "", "", th_bg);
                        api_resultado = _SYMFE.getStatusApi(invoice_uuid, invoice_api_type, false);

                    }
                }
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: _SYMFE.respuesta");
                //lv_fe_report.Items.Add(_SYMFE.respuesta);

                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Enviada");
                //lv_fe_report.Items.Add("Enviada");
            }
            catch
            {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Catch");
                ////MessageBox.Show(DB.get_language("var_err") + " FacturaElectronica");
                //lv_fe_report.Items.Add("Ocurrió un error");
            }

            //pb_fe.Value = 40;

            Application.DoEvents();
            if (_SYMFE.respuesta.ToString().Length > 0)
            {
                if (_SYMFE.respuesta.ToString().Substring(0, 3) == "202")
                {
                    //pb_fe.Value = 90;
                    _SYMFE.s3FE(invoice_id);                    
                    _SYMFE.pendientes(th_bg);
                }
                else
                {

                    ////MessageBox.Show("Ocurrio un error al tratar de enviar la factura al servidor, intente de nuevo");
                    //lv_fe_report.Items.Add("Ocurrio un error...");
                    //pb_fe.Value = 0;
                }
            }



        }
        private void timer_pendings_thread(object sender, DoWorkEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: timer_pendings_thread");
            timer_pendings();
        }
        private void timer_pendings() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: timer_pendings");
            _SYMFE = new SYMPOS_API_Fe();
            _SYMFE.s3FE("");
            _SYMFE.pendientes(true);
            DB.checkVersion();
        }
        private void timer_invoice_pending_Tick(object sender, EventArgs e)
        {

            sendPendingsV2_master();
        }
        #endregion
        private void chk_lock_invoice_detail_search_description_Click(object sender, EventArgs e)
        {
            if (!chk_lock_invoice_detail_search_description.Checked)
            {
                lv_product_search.Visible = false;
            }
        }


        private void timer_invoice_db_Tick(object sender, EventArgs e)
        {

            BackgroundWorker bg = new BackgroundWorker();
            bg.WorkerReportsProgress = true;
            bg.DoWork += new DoWorkEventHandler(timer_pendings_thread);
            try
            {
                bg.RunWorkerAsync();

            }
            catch
            {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "B: timer_invoice_db_Tick. RunWorkerAsync catch");
            }
        }

        private void frm_pos_invoice_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (sendPendingsCount() == 0)
            {
                e.Cancel = false;
            }
            else {
                if (MessageBox.Show("Hay facturas pendientes de enviar al servidor, desea esperar?", "POS", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    
                    
                    e.Cancel = false;
                }
                else
                {
                    //Enviar Todo 
                    string sql_load_invoice_pendings = "";

                    if (!first.auto_debug)
                    {
                        sql_load_invoice_pendings = "select* from invoice where invoice_api_type=1 and invoice_local_state > 4 and invoice_clave is not null and (invoice_hacienda_ind_estado = ''  or invoice_hacienda_ind_estado is null) and(invoice_hacienda_lastdate < SUBTIME(now(), '1:00:00')  or invoice_hacienda_lastdate is null) order by invoice_id desc  ";
                    }
                    else
                    {
                        sql_load_invoice_pendings = "select* from invoice where                        invoice_local_state > 4 and invoice_clave is not null and (invoice_hacienda_ind_estado = ''  or invoice_hacienda_ind_estado is null) and(invoice_hacienda_lastdate < SUBTIME(now(), '0:05:00')  or invoice_hacienda_lastdate is null) order by invoice_id desc ";
                    }
                    DataTable tDt = DB.q(sql_load_invoice_pendings, "", "", true, true);
                    pnl_pendientes.Visible = true;
                    pnl_pendientes.BringToFront();
                    Application.DoEvents();
                    foreach (DataRow r in tDt.Rows)
                    {
                        sendPendings(r["invoice_id"].ToString(), r["invoice_uuid"].ToString(), r["invoice_api_type"].ToString());

                    }
                    e.Cancel = false;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //SYMPOS_API_Fe myfe = new SYMPOS_API_Fe();
            //myfe.sendFE("75"); 1
            
        }

        private void txt_invoice_client_identification_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_invoice_document_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            cleanCliente();
            lbl_sel_tipo_doc.Text = cmb_invoice_document_type.SelectedItem.ToString();
            if (((cbi)cmb_invoice_document_type.SelectedItem).HiddenValue.ToString() =="04")
            {
                /*txt_invoice_client_identification.Enabled = false;
                txt_invoice_client_phone_number.Enabled = false;
                txt_invoice_client_name.Enabled = false;
                txt_invoice_client_email.Enabled = false;
                grpClientes.Visible = false;
                cmb_invoice_clients_id_type.Enabled = false;*/


            }
            else
            {
                txt_invoice_client_identification.Enabled = true;
                txt_invoice_client_phone_number.Enabled = true;
                txt_invoice_client_name.Enabled = true;
                txt_invoice_client_email.Enabled = true;
                cmb_invoice_clients_id_type.Enabled = true;
            }
        }

        #region Exoneracion
        private void btn_exoneracion_show_Click(object sender, EventArgs e)
        {
            cargar_tipo_exoneracion();
            grp_exoneracion.Location = new Point(248, 304);
            grp_exoneracion.Visible = true;

        }
        private void cargar_tipo_exoneracion()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.LoadCmbDocumentType : ");


            string sql_load_invoice_tipo_exoneracion_mysql = "select * from invoice_documento_exoneracion_autorizacion order by codigo asc";


            txt_exoneracion_numero_documento.Text = "";
            txt_exoneracion_nombre_institucion.Text = "";
            txt_exoneracion_fecha_emision.Text = "";
            txt_exoneracion_porcentaje_exoneracion.Text = "";

            cmb_exoneracion_tipo_documento.Items.Clear();
            DataTable tDt = DB.q(sql_load_invoice_tipo_exoneracion_mysql, "", "");
            g_dt_doc_type = tDt;
            foreach (DataRow r in tDt.Rows)
            {
                cmb_exoneracion_tipo_documento.Items.Add(new cbi(r["documento"].ToString(), r["codigo"].ToString()));
                cmb_exoneracion_tipo_documento.SelectedIndex = 0;
            }
        }
        private void btn_exoneracion_save_Click(object sender, EventArgs e)
        {
            grp_exoneracion.Visible = false;
            invoice_exoneracion = true;

            int porcentaje = 0;

            if (!int.TryParse(txt_exoneracion_porcentaje_exoneracion.Text.ToString(), out porcentaje))
            {

            }
            else {
                if (porcentaje >= 1 && porcentaje <= 13) {

                }
            }
            //calculos
        }
        private void btn_exoneraciones_clear_Click(object sender, EventArgs e)
        {
            grp_exoneracion.Visible = false;
            invoice_exoneracion = false;
            //calculos
        }
        #endregion
        private void txt_cal_pagacon_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_cal_pagacon.Text.ToString()== "0.00") {
                txt_cal_pagacon.Text = "";
            }
        }
        #region Descuentos

        private void btn_descuentos_total_aplicar_Click(object sender, EventArgs e)
        {

            decimal desc_tax = 0, desc_subtotal_original = 0, desc_total_con_descuento = 0, combo_porcentaje_descuento = 0;
            decimal combo_monto_unitario_linea = 0, combo_monto_descuento_calculado_unitario=0, combo_monto_descuento_calculado=0;


            foreach (ListViewItem item in lv_invoice_detail.Items)
            {
                item.SubItems[lvId["lv_invoice_detail_price_Descuento"]].Text = "";
                item.SubItems[lvId["lv_invoice_detail_price_Descuento_razon"]].Text = "";
            }
            cleanTotals();
            calcInvoice();

            decimal.TryParse(lbl_descuentos_total_original.Text.ToString(), out desc_subtotal_original);
            decimal.TryParse(txt_descuentos_total_precio_final.Text.ToString(), out desc_total_con_descuento);
            decimal.TryParse(txt_invoice_totals_tax.Text.ToString(), out desc_tax);

            if (desc_total_con_descuento > 0)
            {
                combo_porcentaje_descuento = ( desc_total_con_descuento/ (desc_subtotal_original + desc_tax));
            }
            else
            {
                combo_porcentaje_descuento = 0;
            }

            if (combo_porcentaje_descuento > 0)
            {
                foreach (ListViewItem item in lv_invoice_detail.Items)
                    {
                        //combo_monto_unitario_linea = decimal.Parse(item.SubItems[lvId["lv_desc_precio_unitario"]].Text.ToString());

                        combo_monto_unitario_linea = (decimal.Parse(item.SubItems[lvId["lbl_products_price"]].Text.ToString()) * decimal.Parse(item.SubItems[lvId["lv_invoice_detail_qty"]].Text.ToString()));
                    
                        combo_monto_descuento_calculado_unitario = (combo_monto_unitario_linea * combo_porcentaje_descuento);
                        combo_monto_descuento_calculado = combo_monto_unitario_linea - combo_monto_descuento_calculado_unitario;


                        item.SubItems[lvId["lv_invoice_detail_price_Descuento"]].Text = combo_monto_descuento_calculado.ToString(DB.ND2);
                        item.SubItems[lvId["lv_invoice_detail_price_Descuento_razon"]].Text = "DESCUENTO GLOBAL";

                    
                        

                        
                    }
                
                calcInvoice();
                grp_descuento_total.Visible = false;


            }
            else
            {

            }

        }
        private void btn_descuentos_total_cerrar_Click(object sender, EventArgs e)
        {
            grp_descuento_total.Visible = false;
        }
        private void TotalDescuento_Click(object sender, EventArgs e)
        {

            grp_descuento_total.Location = new Point(248, 304);
            grp_descuento_total.Visible = true;
            btn_descuentos_total_aplicar.Enabled = true;

            lbl_descuentos_total_original.Text=txt_TotalVenta.Text;
            txt_descuentos_total_precio_final.Text = txt_invoice_totals_total.Text;
            //Conseguir monto sin descuentos 

        }

        public void DescLine(object sender, EventArgs e)
        {
            if (lv_invoice_detail.SelectedIndices.Count > 0)
            {
                foreach (ListViewItem item in lv_invoice_detail.Items)
                    if (item.Selected)
                    {
                        lv_invoice_detail.Enabled = false;
                        grp_descuento.Location= new Point( 248, 304);

                        grp_descuento.Visible = true;
                        lbl_descuento_producto_descripcion.Text = item.SubItems[lvId["lbl_products_description"]].Text.ToString();
                        //lbl_descuentos_precio_original.Text = item.SubItems[lvId["lbl_products_price"]].Text.ToString();
                        lbl_descuentos_precio_original.Text = (decimal.Parse(item.SubItems[lvId["lbl_products_price"]].Text.ToString()) * decimal.Parse(item.SubItems[lvId["lv_invoice_detail_qty"]].Text.ToString())).ToString(DB.ND2);

                        lbl_descuentos_precio_iva.Text = decimal.Parse(item.SubItems[lvId["lv_invoice_detail_tax"]].Text.ToString()).ToString(DB.ND2);

                        txt_descuentos_monto.Text = "";
                        txt_descuentos_porcentaje.Text = "";
                        txt_descuentos_razon.Text = "";

                        txt_descuentos_monto.Text = item.SubItems[lvId["lv_invoice_detail_price_Descuento"]].Text;
                        txt_descuentos_razon.Text = item.SubItems[lvId["lv_invoice_detail_price_Descuento_razon"]].Text;

                        decimal monto_descuento = 0;
                         decimal.TryParse(txt_descuentos_monto.Text, out monto_descuento);

                        txt_descuentos_precio_final.Text =  ((decimal.Parse(lbl_descuentos_precio_original.Text) - monto_descuento) * (1 + (decimal.Parse(lbl_descuentos_precio_iva.Text) / 100))).ToString(DB.ND2);

                        calcInvoice();
                    }

            }
        }
        private void btn_descuentos_cerrar_Click(object sender, EventArgs e)
        {
            lv_invoice_detail.Enabled = true;
            grp_descuento.Visible = false;
        }
        
        //Calculos
        private void txt_descuentos_porcentaje_KeyUp(object sender, KeyEventArgs e)
        {
            btn_descuentos_aplicar.Enabled = true;
            try
            {
                decimal f_original = decimal.Parse(lbl_descuentos_precio_original.Text.ToString());
                decimal v_sym_descuento_porcentaje = decimal.Parse(txt_descuentos_porcentaje.Text);
                if (v_sym_descuento_porcentaje > 100 || v_sym_descuento_porcentaje < 0) {
                    txt_descuentos_monto.Text = "ERROR";
                    return;
                }
                decimal v_sym_descuento_monto = (f_original * (v_sym_descuento_porcentaje / 100));
                txt_descuentos_monto.Text = v_sym_descuento_monto.ToString(DB.ND2);
                lbl_descuentos_precio_final.Text = (f_original- v_sym_descuento_monto).ToString(DB.ND2);

                txt_descuentos_precio_final.Text = ((f_original - v_sym_descuento_monto) * (1 + (decimal.Parse(lbl_descuentos_precio_iva.Text) / 100))).ToString(DB.ND2);
            }
            catch
            {
                txt_descuentos_monto.Text = "ERROR";
                lbl_descuentos_precio_final.Text = "ERROR";
                btn_descuentos_aplicar.Enabled = false;
            }

        }
        private void txt_descuentos_monto_KeyUp(object sender, KeyEventArgs e)
        {
            btn_descuentos_aplicar.Enabled = true;
            try
            {
                txt_descuentos_porcentaje.Text = "";
                decimal f_original = decimal.Parse(lbl_descuentos_precio_original.Text.ToString());                
                decimal v_sym_descuento_monto = decimal.Parse(txt_descuentos_monto.Text.ToString());
                //Error si el monto es mayor al original
                if ((f_original - v_sym_descuento_monto) <=0)
                {
                    txt_descuentos_monto.Text = "ERROR";
                    return;
                }
                lbl_descuentos_precio_final.Text = (f_original - v_sym_descuento_monto).ToString(DB.ND2);

                
                txt_descuentos_precio_final.Text= ( (f_original - v_sym_descuento_monto) * (1 + (decimal.Parse(lbl_descuentos_precio_iva.Text) / 100))).ToString(DB.ND2);
            }
            catch
            {
                lbl_descuentos_precio_final.Text = "ERROR";
                btn_descuentos_aplicar.Enabled = false;
            }
        }
        private void txt_descuentos_precio_final_KeyUp(object sender, KeyEventArgs e)
        {
            btn_descuentos_aplicar.Enabled = true;

            try
            {
                txt_descuentos_porcentaje.Text = "";
                txt_descuentos_monto.Text = "";

                decimal f_original = decimal.Parse(lbl_descuentos_precio_original.Text.ToString());

                decimal v_sym_descuento_final_subtotal= (decimal.Parse(txt_descuentos_precio_final.Text.ToString()  ) / (1 + (decimal.Parse(lbl_descuentos_precio_iva.Text) / 100)) ); //Quitarle IVA

                txt_descuentos_monto.Text= (f_original-v_sym_descuento_final_subtotal).ToString(DB.ND2);

                decimal v_sym_descuento_monto = decimal.Parse(txt_descuentos_monto.Text.ToString());
                lbl_descuentos_precio_final.Text = (f_original - v_sym_descuento_monto).ToString(DB.ND2);

            }
            catch
            {
                lbl_descuentos_precio_final.Text = "ERROR";
                btn_descuentos_aplicar.Enabled = false;
            }
        }

        private void btn_descuentos_aplicar_Click(object sender, EventArgs e)
        {
            try
            {
                txt_descuentos_porcentaje.Text = "";
                decimal f_monto_descuento= decimal.Parse(txt_descuentos_monto.Text.ToString());
                if (f_monto_descuento > 0 ){
                    if (txt_descuentos_razon.Text.Length > 0){
                        foreach (ListViewItem item in lv_invoice_detail.Items)
                            if (item.Selected)
                            {
                                item.SubItems[lvId["lv_invoice_detail_price_Descuento"]].Text = txt_descuentos_monto.Text.ToString();
                                item.SubItems[lvId["lv_invoice_detail_price_Descuento_razon"]].Text = txt_descuentos_razon.Text.ToString();
                                lv_invoice_detail.Enabled = true;
                                grp_descuento.Visible = false;
                                btn_descuentos_aplicar.Enabled = false;

                                calcInvoice();
                            }
                    }
                    else
                    {
                        MessageBox.Show("Faltan datos para el descuento");
                    }
                }else {
                    //MessageBox.Show("Faltan datos para el descuento");
                    foreach (ListViewItem item in lv_invoice_detail.Items)
                        if (item.Selected)
                        {
                            item.SubItems[lvId["lv_invoice_detail_price_Descuento"]].Text = "";
                            item.SubItems[lvId["lv_invoice_detail_price_Descuento_razon"]].Text = "";

                            lv_invoice_detail.Enabled = true;

                            grp_descuento.Visible = false;
                            btn_descuentos_aplicar.Enabled = false;

                            calcInvoice();
                        }
                }
            }
            catch
            {
                lbl_descuentos_precio_final.Text = "ERROR";
                btn_descuentos_aplicar.Enabled = false;
            }
        }
        #endregion

        private void btn_abarrotes_canastabasica_Click(object sender, EventArgs e)
        {


            txt_invoice_line_barcode.Text = "3";
            SearchBarcode();


            txt_invoice_line_qty.Text = "1";
        }

        
    }
}

