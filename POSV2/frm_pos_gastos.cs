using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace POSV2
{
    public partial class frm_pos_gastos : Form
    {
        string xmlfileContent = "";
        private int activo_lucas = 0;
        List<string[]> xml_detail = new List<string[]>();

        static DataTable g_dt_doc_type;
        private SYMPOS_API_Fe _SYMFE;
        static VarCompany my_company;

        lv_names lvId = new lv_names();

        public frm_pos_gastos()
        {
            InitializeComponent();

            my_company = DB.CheckCompanyPOS();
            LoadCmbDocumentTypeFEC();
            LoadCmbCurrencyFEC();
            LoadCmbSaleTypeFEC();
            LoadCmbMedioPagoTypeFEC();
            DB.loadCmbIdType(ref cmb_invoice_clients_id_type, 2);
            DB.LoadProvince(ref cmb_clients_province, ref cmb_clients_canton, ref cmb_clients_district, 2);

            DB.loadAdvCmbUnit(ref cmb_adv_unit, 1, 2);
        }
        #region FEC
        #region CombosFec
        private void LoadCmbDocumentTypeFEC()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.LoadCmbDocumentType : ");


            string sql_load_invoice_document_type_mysql = "select * from invoice_documento_referencia where active=1  order by orden asc";

            cmb_invoice_document_type.Items.Clear();
            DataTable tDt = DB.q(sql_load_invoice_document_type_mysql, "", "");
            g_dt_doc_type = tDt;
            foreach (DataRow r in tDt.Rows)
            {
                if (r["pos"].ToString() == "2")
                {
                    cmb_invoice_document_type.Items.Add(new cbi(r["documento"].ToString(), r["codigo"].ToString()));
                    cmb_invoice_document_type.SelectedIndex = 0;
                }

            }


        }
        private void LoadCmbCurrencyFEC()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.LoadCmbCurrency : ");

            DB.loadCmbCur(ref cmb_invoice_cur, 4);
            cmb_invoice_cur.SelectedIndex = 0;

        }
        private void LoadCmbSaleTypeFEC()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.LoadCmbSaleType : ");


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
        private void LoadCmbMedioPagoTypeFEC()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.LoadCmbMedioPagoType : ");


            string sql_load_invoice_mediopago_type_mysql = "select * from invoice_medio_pago where active=1 order by orden asc";

            cmb_invoice_medio_pago_type.Items.Clear();
            DataTable tDt = DB.q(sql_load_invoice_mediopago_type_mysql, "", "");
            g_dt_doc_type = tDt;
            foreach (DataRow r in tDt.Rows)
            {
                cmb_invoice_medio_pago_type.Items.Add(new cbi(r["medioPago"].ToString(), r["codigo"].ToString()));
                cmb_invoice_medio_pago_type.SelectedIndex = 0;

            }
        }       

        private void cmb_clients_province_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_clients_province.SelectedItem != null)
            {
                lbl_id_province.Text = ((cbi)cmb_clients_province.SelectedItem).HiddenValue;
            }
        }

        private void cmb_clients_canton_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_clients_canton.SelectedItem != null)
            {
                lbl_id_canton.Text = ((cbc)cmb_clients_canton.SelectedItem).hv_save;
            }
        }

        private void cmb_clients_district_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_clients_district.SelectedItem != null)
            {
                lbl_id_distric.Text = ((cbi)cmb_clients_district.SelectedItem).HiddenValue;
            }
        }
        #endregion
        #region FunctionsFEC
        private void CleanFEC()
        {
            txt_invoice_client_name.Text = "";
            DB.sel_combo(ref cmb_invoice_clients_id_type, "");
            cmb_invoice_act_eco.Items.Clear();
            btn_save_fec.Enabled = false;
            cleanLineaFEC();
        }
        private void cleanLineaFEC()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gatos.cleanLineaFEC : ");

            txt_invoice_line_description.Text = "";

            txt_invoice_line_qty.Text = "";

            txt_invoice_line_price.Text = "";
            txt_invoice_line_price_tax.Text = "0";
            txt_invoice_line_price_total.Text = "0";

            txt_invoice_line_tax_code.Text = "";
            txt_invoice_line_tax_code_iva.Text = "";

            txt_invoice_line_tax.Text = "";

            txt_invoice_line_description.ReadOnly = false;
            txt_invoice_line_description.BackColor = Color.White;

            txt_invoice_line_price.ReadOnly = false;


        }
        private void buscarActividadEconomica()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.buscarActividadEconomica : ");
            CleanFEC();
            int count_ae = 0;
            //API GET

            _SYMFE = new SYMPOS_API_Fe();
            string jsonAPIAE = _SYMFE.getActividadEconomicaApi(txt_invoice_client_identification.Text.ToString());
            Console.WriteLine(jsonAPIAE);
            //var response = JsonConvert.DeserializeObject(jsonAPIAE);
            JObject AEObj = JObject.Parse(jsonAPIAE);
            if ((string)AEObj["code"] == "404")
            {
                MessageBox.Show("Error 404 , Cedula no existe, por favor verifique e intente de nuevo");
            }
            else
            {
                //Todo OK
                //Verifica Regimen Simplificado
                //if ((JArray)AEObj["regimen"]["codigo"]=="2") {

                var arr_regimen = (JObject)AEObj["regimen"];
                var arr_situacion = (JObject)AEObj["situacion"];
                if (arr_regimen["codigo"].ToString() == "1")
                {
                    //Tradicional Error
                    MessageBox.Show("Proveedor se encuentra en régimen Tradicional , " +
                        " \n\r " + AEObj["nombre"].ToString() +
                        " \n\r Situacion " +
                        " \n\r Inscrito : " + arr_situacion["estado"].ToString() + " " +
                        " \n\r Moroso : " + arr_situacion["moroso"].ToString()  + " " +
                        " \n\r Omiso " + arr_situacion["omiso"].ToString() + "" +
                        " \n\r , Solicitar Factura Electrónica ");
                    //return;
                }
                else if (arr_regimen["codigo"].ToString() == "2")
                {
                    //Simplificado
                }
                else
                {
                    //Desconocido
                    MessageBox.Show("Proveedor se encuentra en régimen Desconocido, contactar Administrador de Sistema : "+ arr_regimen["codigo"].ToString());
                    return;
                }
                //Console.WriteLine();
                //}
                //AEObj["regimen"]
                //Console.WriteLine((string));

                if (AEObj["actividades"].GetType().ToString() == "Newtonsoft.Json.Linq.JArray")
                {
                    JArray arr_ae = (JArray)AEObj["actividades"];

                    foreach (var ae in arr_ae)
                    {
                        if ((string)ae["estado"] == "A")
                        {
                            count_ae++;
                            cmb_invoice_act_eco.Items.Add(new cbi((string)ae["descripcion"], (string)ae["codigo"]));
                        }
                    }
                }

                txt_invoice_client_name.Text = (string)AEObj["nombre"];
                DB.sel_combo(ref cmb_invoice_clients_id_type, (string)AEObj["tipoIdentificacion"]);
                if (count_ae > 0)
                {
                    btn_save_fec.Enabled = true;
                }


            }
            //Console.WriteLine(response);
        }
        public void RemoveLine(object sender, EventArgs e)
        {
            if (lv_fec_detail.SelectedIndices.Count > 0)
            {
                foreach (ListViewItem item in lv_fec_detail.Items)
                    if (item.Selected)
                        lv_fec_detail.Items.Remove(item);
                //lv_invoice_detail.Items.Remove( );

            }
            calcInvoiceFEC();
        }
        private void CleanLVFEC() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.CleanLVFEC : " );
            CleanFEC();
            DB.debugLV(lv_fec_detail);

            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Remover", new EventHandler(RemoveLine));
            lv_fec_detail.ContextMenu = cm;

            lv_fec_detail.Items.Clear();
            lv_fec_detail.Columns.Clear();

            lv_fec_detail.Columns.Add(DB.get_language("lv_invoice_detail_num"), 28);
            lvId["lv_invoice_detail_num"] = lv_fec_detail.Columns.Count - 1;

            lv_fec_detail.Columns.Add(DB.get_language("lbl_products_barcode"), 0);
            lvId["lbl_products_barcode"] = lv_fec_detail.Columns.Count - 1;

            lv_fec_detail.Columns.Add(DB.get_language("lbl_products_description"), 230); //Detalle
            lvId["lbl_products_description"] = lv_fec_detail.Columns.Count - 1;

            lv_fec_detail.Columns.Add(DB.get_language("lbl_invoice_line_qty"), 53);
            lvId["lbl_invoice_line_qty"] = lv_fec_detail.Columns.Count - 1;

            lv_fec_detail.Columns.Add(DB.get_language("lbl_products_sym"), 41); //Unidad de Medida
            lvId["lbl_products_sym"] = lv_fec_detail.Columns.Count - 1;

            lv_fec_detail.Columns.Add("Precio ", 75, HorizontalAlignment.Right); //Precio Unitario
            lvId["Precio"] = lv_fec_detail.Columns.Count - 1;

            lv_fec_detail.Columns.Add(DB.get_language("lbl_products_price_tax"), 60, HorizontalAlignment.Right); //Exento
            lvId["lbl_products_price_tax"] = lv_fec_detail.Columns.Count - 1;

            lv_fec_detail.Columns.Add(DB.get_language("lbl_products_price_total"), 84, HorizontalAlignment.Right);
            lvId["lbl_products_price_total"] = lv_fec_detail.Columns.Count - 1;

            lv_fec_detail.Columns.Add(DB.get_language("lbl_tax_code"), 0); //Exento
            lvId["lbl_tax_code"] = lv_fec_detail.Columns.Count - 1;

            lv_fec_detail.Columns.Add(DB.get_language("lbl_tax_code_iva"), 0); //Exento
            lvId["lbl_tax_code_iva"] = lv_fec_detail.Columns.Count - 1;

            lv_fec_detail.Columns.Add(DB.get_language("lbl_tax_tarifa"), 0);
            lvId["lbl_tax_tarifa"] = lv_fec_detail.Columns.Count - 1;

            lv_fec_detail.Columns.Add(DB.get_language("lbl_tax_monto"), 0);
            lvId["lbl_tax_monto"] = lv_fec_detail.Columns.Count - 1;


            lv_fec_detail.Columns.Add(DB.get_language("lbl_products_codigo_proveedor"), 0);
            lvId["lbl_products_codigo_proveedor"] = lv_fec_detail.Columns.Count - 1;

            lv_fec_detail.Columns.Add(DB.get_language("lbl_products_codigo_proveedor_barcode"), 0);
            lvId["lbl_products_codigo_proveedor_barcode"] = lv_fec_detail.Columns.Count - 1;
        }
        private void calcInvoiceFEC() {
            decimal linea_Tax = 0, linea_TotalServGravados = 0, linea_TotalServExentos = 0, linea_TotalMercanciasGravadas = 0, linea_TotalMercanciasExentas = 0, linea_SubTotal = 0, linea_MontoTotal = 0, linea_TotalDescuentos = 0, linea_total = 0;
            decimal TotalServGravados = 0, TotalServExentos = 0, TotalMercanciasGravadas = 0, TotalMercanciasExentas = 0;
            decimal TotalGravado = 0, TotalExento = 0, TotalVenta = 0, TotalDescuentos = 0, TotalVentaNeta = 0, TotalImpuesto = 0, TotalComprobante = 0;
            limpiarALL();

            int lineas = 1;
            foreach (ListViewItem item in lv_fec_detail.Items)
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

            }
        }
        private void CalcLineFEC()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.CalcLine : ");
            if (txt_invoice_line_price.Text.Length > 0 && txt_invoice_line_qty.Text.Length > 0)
            {

                decimal valueDec = decimal.Parse(txt_invoice_line_price.Text.ToString());
                decimal qtyDec = decimal.Parse(txt_invoice_line_qty.Text.ToString());

                txt_invoice_line_price_total.Text = (qtyDec * valueDec).ToString(DB.ND5);
                txt_invoice_line_price_tax.Text = "0";
                txt_invoice_line_price_subtotal.Text = (qtyDec * valueDec).ToString(DB.ND5);
            }
        }
        private void AddSymLineFEC()
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.AddSymLineFEC : ");
            CalcLineFEC();

            #region Verification
            bool errores = false;
            string allErrors = "";
            if (txt_invoice_line_description.Enabled == true && txt_invoice_line_description.Text.Length > 0)
            {
                DB.check_text(ref txt_invoice_line_description, "lbl_invoice_description", ref errores, ref allErrors, 1, 160);                
            }
            else
            {
                allErrors += System.Environment.NewLine + " Error de Descripcion ";
                errores = true;
            }

            if (txt_invoice_line_price.Text.Length < 1)
            {
                allErrors += System.Environment.NewLine + " Error de Precio ";
                errores = true;
            }

            if (txt_invoice_line_qty.Text.Length < 1)
            {
                allErrors += System.Environment.NewLine + " Error de Cantidad ";
                errores = true;
            }

            if (cmb_adv_unit.SelectedIndex<0)
            {
                allErrors += System.Environment.NewLine + " Error de Unidad de medida";
                errores = true;
            }
            #endregion

            if (errores)
            {
                if (allErrors.Length > 0)
                {
                    MessageBox.Show(DB.get_language("var_err") + " > " + allErrors);
                }
            }else{

                string[] row = {  }; //0

                DB.ASA(ref row, (lv_fec_detail.Items.Count + 1).ToString()); //1

                
                DB.ASA(ref row, ""); //2

                DB.ASA(ref row, txt_invoice_line_description.Text.ToString()); //3 Desc

                DB.ASA(ref row, txt_invoice_line_qty.Text.ToString()); //4 QTY
                DB.ASA(ref row, ((cbi)cmb_adv_unit.SelectedItem).HiddenValue.ToString()); //5 Tipo

                DB.ASA(ref row, txt_invoice_line_price.Text.ToString()); //6 Unitario Price


                DB.ASA(ref row, "0"); //7 TAX

                DB.ASA(ref row, txt_invoice_line_price_total.Text.ToString()); //8 Price Total

                DB.ASA(ref row, ""); //9 tax code
                DB.ASA(ref row, ""); //10 tax code iva
                DB.ASA(ref row, ""); //11 tax iva tarifa
                DB.ASA(ref row, ""); //12 tax monto

                DB.ASA(ref row, ""); //13 codigo proveedor
                DB.ASA(ref row, ""); //14 codigo proveedor barcode


                var lvi = new ListViewItem(row);
                lv_fec_detail.Items.Add(lvi);

                calcInvoiceFEC();
                cleanLineaFEC();
            }
        }
        private void txt_invoice_line_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.txt_invoice_qty_KeyPress : ");
            if (!DB.isNumber(e.KeyChar, txt_invoice_line_qty.Text))
                e.Handled = true;
        }
        private void txt_invoice_line_qty_KeyUp(object sender, KeyEventArgs e)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.txt_invoice_qty_KeyUp : ");

            decimal qty = 0;
            if (decimal.TryParse(txt_invoice_line_qty.Text.ToString(), out qty))
            {
                CalcLineFEC();
            }
            else
            {
                //MessageBox.Show("Debe ingresar un número");
            }
        }
        private void txt_invoice_line_qty_Leave(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.txt_invoice_qty_Leave : ");
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
            CalcLineFEC();
        }
        private void txt_invoice_line_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.txt_invoice_line_price_KeyPress : ");
            if (!DB.isNumber(e.KeyChar, txt_invoice_line_qty.Text))
                e.Handled = true;
        }
        private void txt_invoice_line_price_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.txt_invoice_line_price_KeyUp : ");

            decimal qty = 0;
            if (decimal.TryParse(txt_invoice_line_price.Text.ToString(), out qty))
            {
                CalcLineFEC();
            }
            else
            {
                //MessageBox.Show("Debe ingresar un número");
            }
        }
        private void txt_invoice_line_price_Leave(object sender, EventArgs e)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.txt_invoice_line_price_Leave : ");
            if (txt_invoice_line_price.Text.Length > 0)
            {
                //int my_qty;
                //if (!int.TryParse(txt_invoice_line_qty.Text.ToString(), out my_qty))
                decimal my_qty = 0;
                if (!decimal.TryParse(txt_invoice_line_price.Text.ToString(), out my_qty))
                {
                    txt_invoice_line_qty.Text = "0";
                }
            }
            CalcLineFEC();
        }
        #endregion
        private void btn_save_fec_Click(object sender, EventArgs e)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.saveFEC : " + cmb_invoice_document_type.ToString());

            MessageBox.Show("Modulo inactivo");
            return;
            grpFe.Visible = true;
            grpFe.BringToFront();
            lv_fe_report.Columns.Clear();
            lv_fe_report.Columns.Add("Resultado", 200);
            lv_fe_report.Items.Clear();
            pb_fe.Value = 10;

            #region Verification
            //Pendiente

            string allErrors = "";
            bool continuar = true;

            decimal v_sym_total = decimal.Parse(txt_TotalComprobante.Text);
            VarCompany my_client = new VarCompany();

            if (v_sym_total < 1)
            {
                //continuar = false;
                allErrors += System.Environment.NewLine + DB.get_language("var_data_error");
            }


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

                if (cmb_clients_province.SelectedIndex < 1)
                {
                    continuar = false;
                    allErrors += System.Environment.NewLine + DB.get_language("err_client") + " Provincia";
                }
                if (cmb_clients_canton.SelectedIndex < 0)
                {
                    continuar = false;
                    allErrors += System.Environment.NewLine + DB.get_language("err_client") + " Canton";
                }
                if (cmb_clients_district.SelectedIndex <0)
                {
                    continuar = false;
                    allErrors += System.Environment.NewLine + DB.get_language("err_client") + " Distrito";
                }
                if (cmb_invoice_act_eco.SelectedIndex < 0)
                {
                    continuar = false;
                    allErrors += System.Environment.NewLine + DB.get_language("err_client") + " Actividad Economica ";
                }
                /*
                if (txt_invoice_client_phone_number.Text.Length < 8 || txt_invoice_client_phone_number.Text.Length > 8)
                {
                    //continuar = false;
                    //allErrors += System.Environment.NewLine + DB.get_language("err_client") + " Teléfono";
                }
                */
                if (continuar)
                {
                    my_client.id_company = lbl_id_client.Text.ToString();
                    my_client.company_type = ((cbi)cmb_invoice_clients_id_type.SelectedItem).HiddenValue;
                    my_client.company_identification = txt_invoice_client_identification.Text.ToString();
                    my_client.company_name = txt_invoice_client_name.Text.ToString();
                    my_client.company_phone = "";
                    my_client.company_email = txt_invoice_client_email.Text.ToString();
                    my_client.company_actividad_economica = ((cbi)cmb_invoice_act_eco.SelectedItem).HiddenValue.ToString();

                    my_client.company_addr_province= ((cbi)cmb_clients_province.SelectedItem).HiddenValue.ToString();
                    my_client.company_addr_canton= ((cbc)cmb_clients_canton.SelectedItem).hv_save.ToString();
                    my_client.company_addr_district= ((cbi)cmb_clients_district.SelectedItem).HiddenValue.ToString();
                }
            }
            else
            {
                continuar = false;
                allErrors += System.Environment.NewLine + DB.get_language("err_client");
            }
            #endregion

            int lineasDetalle = 0;

            string invoice_id = "";
            bool errorLocalInvoice = false;
            SYMPOS_local_fe newFe = new POSV2.SYMPOS_local_fe();
            SYMPOSprint newFePrint = new POSV2.SYMPOSprint();


            pb_fe.Value = 20;
            if (continuar)
            {
                lv_fe_report.Items.Add("Salvando FEC");
                /*
        public int SYMsaveInvoice(string cmb_invoice_actividad_economica,
            string cmb_invoice_document_type,
            string cmb_invoice_cur,string txt_invoice_cur,
            string cmb_invoice_sale_type,string txt_invoice_credit_days,string txt_invoice_medio_pago,bool chk_invoice_client)*/
                bool check_client = true;

                if (newFe.SYMsaveInvoice(
                    ((cbi)cmb_invoice_act_eco.SelectedItem).HiddenValue.ToString(),
                    ((cbi)cmb_invoice_document_type.SelectedItem).HiddenValue.ToString(),
                    ((cbi)cmb_invoice_cur.SelectedItem).ToString(),
                    txt_invoice_cur.Text.ToString(),
                    ((cbi)cmb_invoice_sale_type.SelectedItem).HiddenValue.ToString(),
                    txt_invoice_credit_days.Text.ToString(), ((cbi)cmb_invoice_medio_pago_type.SelectedItem).HiddenValue.ToString(), check_client
                    ) == 1
                    )
                {
                    //Generar CLAVE
                    invoice_id = DB.lId;

                    int resSYMID = 0; //Detalle
                    int resSYMTotalsID = 0; //Totales

                    #region SaveInvoiceCompany FEC Client
                    //my_company = DB.CheckCompanyPOS();
                    resSYMID = newFe.SYMUpdateInvoiceCompany(invoice_id, my_company);
                    if (resSYMID == 0)
                    {
                        MessageBox.Show(DB.get_language("var_err") + " SYMUpdateInvoiceCompany");
                        errorLocalInvoice = true;
                    }
                    //resSYMID = newFe.SYMUpdateInvoiceCustomer
                    #endregion

                    #region SaveInvoiceClient FEC Proveedor
                    resSYMID = newFe.SYMUpdateInvoiceClient(invoice_id, my_client);
                    if (resSYMID == 0)
                    {
                        MessageBox.Show(DB.get_language("var_err") + " SYMUpdateInvoiceClient");
                        errorLocalInvoice = true;
                    }
                    #endregion

                    //Salvar Detalle

                    #region SaveInvoiceDetail
                    foreach (ListViewItem item in lv_fec_detail.Items)
                    {
                        resSYMID = newFe.SYMsaveInvoiceDetail(invoice_id,
                            item.SubItems[lvId["lv_invoice_detail_num"]].Text.ToString(),
                            "", //lv_invoice_detail_id_product
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
                            ""
                            );


                        lvId["lbl_products_barcode"] = lv_fec_detail.Columns.Count - 1;

                        lvId["lbl_products_description"] = lv_fec_detail.Columns.Count - 1;

                        lvId["lbl_invoice_line_qty"] = lv_fec_detail.Columns.Count - 1;

                        lvId["lbl_products_sym"] = lv_fec_detail.Columns.Count - 1;

                        lvId["Precio"] = lv_fec_detail.Columns.Count - 1;

                        lvId["lbl_products_price_tax"] = lv_fec_detail.Columns.Count - 1;

                        lvId["lbl_products_price_total"] = lv_fec_detail.Columns.Count - 1;

                        lvId["lbl_tax_code"] = lv_fec_detail.Columns.Count - 1;

                        lvId["lbl_tax_code_iva"] = lv_fec_detail.Columns.Count - 1;

                        lvId["lbl_tax_tarifa"] = lv_fec_detail.Columns.Count - 1;

                        lvId["lbl_tax_monto"] = lv_fec_detail.Columns.Count - 1;

                        lvId["lbl_products_codigo_proveedor"] = lv_fec_detail.Columns.Count - 1;

                        lvId["lbl_products_codigo_proveedor_barcode"] = lv_fec_detail.Columns.Count - 1;

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

                }
                else
                {
                    MessageBox.Show("9x803 " + DB.get_language("var_err") + " SYMsaveInvoiceFEC");
                    DB.e("insert into invoice_bita set invoice_id='0' ,user_id='', bita_date=now(), bita_type='80001000', bita_error='SYMsaveInvoiceFEC 01'", "", "");
                    errorLocalInvoice = true;
                } // SYMsaveInvoice

                    
                
            }
            else
            {
                MessageBox.Show(DB.get_language("var_err") + allErrors);

            }
        }

        private void txt_invoice_client_identification_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.txt_invoice_client_identification_KeyUp : ");
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_invoice_client_identification.Text.Length > 0)
                {
                    DB.sel_combo(ref cmb_invoice_clients_id_type, "");
                    buscarActividadEconomica();
                }

            }else {
                CleanFEC();
            }
        }

        private void btn_add_linea_fec_Click(object sender, EventArgs e)
        {
            AddSymLineFEC();
        }
        #endregion
        private void verificarClave(string clave_verificar, string receptor_tipo, string receptor_id, ref bool continuar) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.verificarClave : ");

            txt_status_clave.Text = "";
            bool receptor_existe = false;
            bool receptor_existe_id = false;
            bool receptor_existe_tipo = false;

            if (receptor_id.Length == 9) {
                receptor_id = "000" + receptor_id;
            }else if (receptor_id.Length == 10) {
                receptor_id = "00" + receptor_id;
            }else if (receptor_id.Length == 11) {
                receptor_id = "0" + receptor_id;
            }else{
            }
            string receptor_verify = "select company_type,company_identification from company where active =1";

            DataTable tDtreceptor_verify = DB.q(receptor_verify, "", "");            
            foreach (DataRow r in tDtreceptor_verify.Rows)
            {
                if (r["company_identification"].ToString() == receptor_id) {
                    receptor_existe_id = true;
                }
                if (r["company_type"].ToString() == receptor_tipo)
                {
                    receptor_existe_tipo = true;
                }                
            }
            if (!receptor_existe_tipo) {
                MessageBox.Show("Hay un problem con el tipo de receptor (Física, Jurídica, Dimex ) en el documento cargado");
                txt_status_clave.Text = txt_status_clave.Text + "Error en ( Tipo de Receptor )";
            }
            if (!receptor_existe_id)
            { 
                MessageBox.Show("Hay un problem con el ID (cédula) de receptor en el documento cargado");
                txt_status_clave.Text = txt_status_clave.Text + "\r\n Error en ID (cédula) de receptor";
            }

            if (receptor_existe_tipo && receptor_existe_id)
            {
                receptor_existe = true;
            }else {
                txt_status_clave.Text = txt_status_clave.Text + "\r\n Documento no se puede utilizar como gasto  ";
                txt_exp_emisor_clave.Text = "err_gasto_001";
            }

            SYMPOS_API_Fe _SYMFE = new SYMPOS_API_Fe();
            string respuestaAPI = _SYMFE.getRespuestasClaveApi(clave_verificar.ToString(), "1").ToString();
            if (respuestaAPI != "aceptado"){

                txt_status_clave.Text = txt_status_clave.Text + "\r\n Documento no se puede utilizar, no se encuentra en HACIENDA ( " + respuestaAPI  +" )";
                txt_exp_emisor_clave.Text = "err_gasto_001";

                receptor_existe = true;
            }
            
            string strTipoDoc = "";
            if (clave_verificar.Length > 0 && receptor_existe)
            {
                string sql_mysql_search_ref_clave = "select * from invoice where invoice_ref_Numero='" + DB.s(clave_verificar.ToString()) + "'";
                
                DataTable tDt = DB.q(sql_mysql_search_ref_clave, "", "");
                if (tDt.HasErrors)
                {
                    continuar = false;
                    MessageBox.Show(DB.get_language("var_err"));
                }
                else
                {
                    if (tDt.Rows.Count > 0)
                    {
                        continuar = false;
                        if (tDt.Rows[0]["invoice_tipo_doc"].ToString() == "05")
                        {
                            strTipoDoc = "Aceptado";
                        }
                        else if (tDt.Rows[0]["invoice_tipo_doc"].ToString() == "06")
                        {
                            strTipoDoc = "Aceptado - Parcialmente";
                        }
                        else if (tDt.Rows[0]["invoice_tipo_doc"].ToString() == "07")
                        {
                            strTipoDoc = " Rechazado";
                        }
                        txt_status_clave.Text = "Gasto ya se encuentra aplicado ( " + strTipoDoc + " ) ";
                        if (activo_lucas == 1) {
                            btn_gastos_aceptar_gasto.Enabled = true;
                            btn_gastos_aceptar_compra.Enabled = true;
                            btn_gastos_aceptar_parcial.Enabled = true;
                            btn_gastos_aceptar_rechazar.Enabled = true;
                            continuar = true;
                        }

                    }
                    else {
                        continuar = true;
                        btn_gastos_aceptar_gasto.Enabled = true;
                        btn_gastos_aceptar_compra.Enabled = true;
                        btn_gastos_aceptar_parcial.Enabled = true;
                        btn_gastos_aceptar_rechazar.Enabled = true;

                    }
                }
            }
        }
        private void limpiarALL() {

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

            txt_exp_emisor_clave.Text = "";
            txt_exp_emisor_onsecutivo.Text = "";

            txt_exp_emisor_email.Text = "";
            txt_exp_emisor_fecha_emision.Text = "";
            txt_exp_emisor_identification.Text = "";
            txt_exp_emisor_name.Text = "";

            txt_exp_emisor_tipo.Text = "";

            txt_exp_emisor_tipo_doc.Text = "";

            txt_exp_emisor_tipo_doc_code.Text = "";

            txt_exp_receptor_email.Text = "";
            txt_exp_receptor_identification.Text = "";
            txt_exp_receptor_name.Text = "";
            txt_exp_receptor_tipo.Text = "";
            txt_lv_fe_report.Clear();

            txt_status_clave.Text = "";

            txt_Currency.Text = "";
            txt_Tipocambio.Text = "";

            txt_medio_pago.Text = "";
            txt_condicion_venta.Text = "";
            txt_plazo_credito.Text = "";

            txt_detalle_mensaje.Text = "";

        }
        private void clearLV() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.LoadProductSym : ");
            DB.debugLV(lv_gastos);
            //Load Users
            lv_gastos.Items.Clear();
            lv_gastos.Columns.Clear();

            lv_gastos.Columns.Add(DB.get_language("lv_invoice_detail_num"), 28);
            lv_gastos.Columns.Add(DB.get_language("lbl_products_sym"), 41);
            lv_gastos.Columns.Add(DB.get_language("lbl_products_barcode"), 97);
            lv_gastos.Columns.Add(DB.get_language("lbl_invoice_line_qty"), 53);
            lv_gastos.Columns.Add(DB.get_language("lbl_products_description"), 230);
            lv_gastos.Columns.Add(DB.get_language("lbl_products_price"), 75, HorizontalAlignment.Right);
            lv_gastos.Columns.Add(DB.get_language("lbl_products_price_tax"), 60, HorizontalAlignment.Right);
            lv_gastos.Columns.Add(DB.get_language("lbl_products_price_total"), 84, HorizontalAlignment.Right);
            lv_gastos.Columns.Add(DB.get_language("lbl_tax_code"), 26);
            lv_gastos.Columns.Add(DB.get_language("lbl_tax_code_iva"), 31);
            lv_gastos.Columns.Add(DB.get_language("lbl_tax_tarifa"), 41);
            lv_gastos.Columns.Add(DB.get_language("lbl_tax_monto"), 84);
            lv_gastos.Columns.Add(DB.get_language("lbl_products_codigo_proveedor"), 112);
            lv_gastos.Columns.Add(DB.get_language("lbl_products_codigo_proveedor_barcode"), 112);





            xml_detail.Clear();
        }
        private void cargarXML(string filename) {
            clearLV();
            bool var_cargar_detalle = false;
            //var eEmisor="";
            pb1.Value = 3;
            //Send to server
            /*
            try
            {
                _symposbk = new SYMPOS_db_backup();
                _symposbk.th_do_backup();
                _symposbk.ProgressChanged += BK_ProgressChanged;
            }
            catch
            {
            }
            */

                try
                {
                


                var xml = XDocument.Load(@filename);
                xmlfileContent = File.ReadAllText(@filename);

                pb1.Value = 4;
                #region XMLNode
                foreach (var node in xml.Descendants())
                {
                    Application.DoEvents();

                    if (node is XElement)
                    {
                        //MessageBox.Show(node.Value);
                        //Console.WriteLine("--------------------------------");
                        //Console.WriteLine(node.Value);
                        //Console.WriteLine(node.Name);
                        //Console.WriteLine(node.Name.LocalName );
                        //Console.WriteLine(node.Parent.Name );
                        if (node.Name.LocalName == "MensajeHacienda")
                        {
                            MessageBox.Show("El documento cargado es inválido " + node.Name.LocalName);
                            break;
                        }
                        else if (node.Name.LocalName == "FacturaElectronica" || node.Name.LocalName == "TiqueteElectronico" || node.Name.LocalName == "NotaCreditoElectronica" || node.Name.LocalName == "NotaDebitoElectronica")
                        {
                            if (node.Name.LocalName == "FacturaElectronica")
                            {
                                txt_exp_emisor_tipo_doc_code.Text = "01";
                            }
                            else if (node.Name.LocalName == "TiqueteElectronico")
                            {
                                txt_exp_emisor_tipo_doc_code.Text = "04";
                                MessageBox.Show("El documento cargado es inválido " + node.Name.LocalName);
                                break;
                            }
                            else if (node.Name.LocalName == "NotaCreditoElectronica")
                            {
                                txt_exp_emisor_tipo_doc_code.Text = "03";
                                MessageBox.Show("El documento cargado es inválido " + node.Name.LocalName);
                                break;
                            }
                            else if (node.Name.LocalName == "NotaDebitoElectronica")
                            {
                                txt_exp_emisor_tipo_doc_code.Text = "02";
                                MessageBox.Show("El documento cargado es inválido " + node.Name.LocalName);
                                break;
                            }

                            var_cargar_detalle = true;
                            txt_exp_emisor_tipo_doc.Text = node.Name.LocalName.ToString();
                            pb1.Value = 5;

                        }
                        else if (node.Name.LocalName == "Clave")
                        {
                            txt_exp_emisor_clave.Text = node.Value.ToString();
                        }
                        else if (node.Name.LocalName == "TipoCambio")
                        {
                            txt_Tipocambio.Text = node.Value.ToString();
                        }
                        else if (node.Name.LocalName == "CodigoMoneda")
                        {
                            txt_Currency.Text = node.Value.ToString();
                        }
                        else if (node.Name.LocalName == "NumeroConsecutivo")
                        {
                            txt_exp_emisor_onsecutivo.Text = node.Value.ToString();
                        }
                        else if (node.Name.LocalName == "FechaEmision")
                        {
                            txt_exp_emisor_fecha_emision.Text = node.Value.ToString();
                        }
                        else if (node.Name.LocalName == "CondicionVenta")
                        {
                            txt_condicion_venta.Text = node.Value.ToString();
                        }
                        else if (node.Name.LocalName == "PlazoCredito")
                        {
                            txt_plazo_credito.Text = node.Value.ToString();
                        }
                        else if (node.Name.LocalName == "MedioPago")
                        {
                            txt_medio_pago.Text = node.Value.ToString();
                        }
                        else if (node.Name.LocalName == "Emisor")
                        {
                            #region Emisor
                            pb1.Value = 6;
                            //Dim node1Element As XElement = xDoc.Descendants("infoTributaria").FirstOrDefault()
                            XElement nodeEmisor = xml.Descendants(node.Name).FirstOrDefault();
                            //XElement accountingSupplierParty = xml.Root.Descendants().Where(k => k.Name.LocalName == "Emisor").First();
                            foreach (XElement k in nodeEmisor.Descendants())
                            {
                                switch (k.Name.LocalName)
                                {
                                    case "Nombre":
                                        txt_exp_emisor_name.Text = k.Value;
                                        break;
                                    case "Numero":
                                        txt_exp_emisor_identification.Text = k.Value;
                                        break;
                                    case "Tipo":
                                        txt_exp_emisor_tipo.Text = k.Value;
                                        break;
                                    case "CorreoElectronico":
                                        txt_exp_emisor_email.Text = k.Value;
                                        break;
                                }
                            }
                            #endregion
                        }
                        else if (node.Name.LocalName == "Receptor")
                        {
                            #region Receptor
                            pb1.Value = 7;
                            XElement nodeReceptor = xml.Descendants(node.Name).FirstOrDefault();
                            //XElement accountingSupplierParty = xml.Root.Descendants().Where(k => k.Name.LocalName == "Emisor").First();
                            foreach (XElement k in nodeReceptor.Descendants())
                            {
                                switch (k.Name.LocalName)
                                {
                                    case "Nombre":
                                        txt_exp_receptor_name.Text = k.Value;
                                        break;
                                    case "Numero":
                                        txt_exp_receptor_identification.Text = k.Value;
                                        break;
                                    case "Tipo":
                                        txt_exp_receptor_tipo.Text = k.Value;
                                        break;
                                    case "CorreoElectronico":
                                        txt_exp_receptor_email.Text = k.Value;
                                        break;
                                }
                            }
                            #endregion
                        }
                        else if (node.Name.LocalName == "DetalleServicio")
                        {
                            #region DetalleGasto
                            var selLineaDetalle = (from c in xml.Descendants().Where(k => k.Name.LocalName == "LineaDetalle")
                                                   select c).ToList();

                            foreach (XElement ldnode in selLineaDetalle)
                            {
                                string Cabys="",numeroLinea = "", Cantidad = "", CodigoProducto = "", CodigoImpuesto = "", UnidadMedida = "", Detalle = "", PrecioUnitario = "", MontoTotal = "", SubTotal = "", Tarifa = "", Monto = "", MontoTotalLinea = "", TaxCodigo = "", TaxCodigoIva = "", TaxTarifa = "", TaxMonto = "", MontoDescuento = "", CodigoProveedor= "", LastTipo= "" , SuperBarcode= "";

                                foreach (XElement ldk in ldnode.Descendants())
                                {
                                    switch (ldk.Name.LocalName)
                                    {
                                        case "NumeroLinea":
                                            numeroLinea = ldk.Value;
                                            break;
                                        case "Cantidad":
                                            Cantidad = ldk.Value;
                                            break;
                                        case "UnidadMedida":
                                            UnidadMedida = ldk.Value;
                                            break;
                                        case "Detalle":
                                            Detalle = ldk.Value;
                                            break;
                                        case "PrecioUnitario":
                                            PrecioUnitario = ldk.Value;
                                            break;
                                        case "MontoTotal":
                                            MontoTotal = ldk.Value;
                                            break;
                                        case "MontoDescuento":
                                            MontoDescuento = ldk.Value;
                                            break;
                                        case "SubTotal":
                                            SubTotal = ldk.Value;
                                            break;
                                        case "Tarifa":
                                            Tarifa = ldk.Value;
                                            if (ldk.Parent.Name.LocalName == "Impuesto")
                                            {
                                                TaxTarifa = ldk.Value;
                                            }
                                            break;
                                        case "Monto":
                                            Monto = ldk.Value;
                                            if (ldk.Parent.Name.LocalName == "Impuesto")
                                            {
                                                TaxMonto = ldk.Value;
                                            }
                                            break;
                                        case "CodigoTarifa":
                                            TaxCodigoIva = ldk.Value;
                                            break;
                                        case "Tipo":
                                            if (ldk.Parent.Name.LocalName == "CodigoComercial")
                                            {
                                                LastTipo= ldk.Value;
                                            }
                                            else if (ldk.Parent.Name.LocalName == "Impuesto")
                                            {

                                            }
                                            else
                                            {
                                                Console.WriteLine("Otro TIPO " + ldk.Parent.Name.LocalName);
                                            }
                                            break;
                                        case "Codigo":
                                            if (ldk.Parent.Name.LocalName == "Codigo")
                                            {
                                                //if()
                                                //Console.WriteLine(ldk.Parent.FirstNode.ToString());
                                                /*if (LastTipo == "03") {
                                                    SuperBarcode= ldk.Value; 
                                                }
                                                CodigoProducto = ldk.Value;
                                                */

                                            }
                                            else if (ldk.Parent.Name.LocalName == "CodigoComercial")
                                            {
                                                if (LastTipo == "03")
                                                {
                                                    SuperBarcode = ldk.Value;
                                                }else if(LastTipo == "04"){
                                                    CodigoProveedor= ldk.Value;
                                                }

                                                CodigoProducto = ldk.Value;
                                            }
                                            else if (ldk.Parent.Name.LocalName == "Impuesto")
                                            {
                                                CodigoImpuesto = ldk.Value;
                                                TaxCodigo = ldk.Value;
                                            }
                                            else if (ldk.Parent.Name.LocalName == "Impuesto2")
                                            {

                                            }
                                            else if (ldk.Parent.Name.LocalName == "LineaDetalle")
                                            {
                                                Cabys= ldk.Value;
                                            }
                                            else {
                                                Console.WriteLine("Error en Parent de Codigo " + ldk.Parent.Name.LocalName);
                                            }
                                            //Monto = ldk.Value;
                                            break;
                                        case "MontoTotalLinea":
                                            MontoTotalLinea = ldk.Value;
                                            break;
                                    }
                                }

                                string[] row = { numeroLinea, UnidadMedida, SuperBarcode, Cantidad, Detalle, PrecioUnitario, Monto, MontoTotalLinea , TaxCodigo, TaxCodigoIva, TaxTarifa, TaxMonto, CodigoProveedor, Cabys }; //Se despliega

                                string[] rowDet = { numeroLinea, UnidadMedida, SuperBarcode, Cantidad, Detalle, PrecioUnitario, MontoTotal, MontoDescuento, SubTotal, Monto, MontoTotalLinea, TaxCodigo, TaxCodigoIva, TaxTarifa, TaxMonto, CodigoProveedor, Cabys };  //Se Usa internamente

                                xml_detail.Add(rowDet);
                                var lvi = new ListViewItem(row);
                                lv_gastos.Items.Add(lvi);
                            }
                            #endregion
                        }
                        else if (node.Name.LocalName == "ResumenFactura")
                        {

                            var selResumenFactura = (from c in xml.Descendants().Where(k => k.Name.LocalName == "ResumenFactura")
                                                     select c).ToList();
                            #region ResumenFactura
                            foreach (XElement ldnode in selResumenFactura)
                            {
                                foreach (XElement ldk in ldnode.Descendants())
                                {
                                    switch (ldk.Name.LocalName)
                                    {
                                        case "TotalServGravados":
                                            txt_TotalServGravados.Text = ldk.Value;
                                            break;
                                        case "TotalServExentos":
                                            txt_TotalServExentos.Text = ldk.Value;
                                            break;
                                        case "TotalMercanciasGravadas":
                                            txt_TotalMercanciasGravadas.Text = ldk.Value;
                                            break;
                                        case "TotalMercanciasExentas":
                                            txt_TotalMercanciasExentas.Text = ldk.Value;
                                            break;
                                        case "TotalGravado":
                                            txt_TotalGravado.Text = ldk.Value;
                                            break;
                                        case "TotalExento":
                                            txt_TotalExento.Text = ldk.Value;
                                            break;
                                        case "TotalVenta":
                                            txt_TotalVenta.Text = ldk.Value;
                                            break;
                                        case "TotalDescuentos":
                                            txt_TotalDescuentos.Text = ldk.Value;
                                            break;
                                        case "TotalVentaNeta":
                                            txt_TotalVentaNeta.Text = ldk.Value;
                                            break;
                                        case "TotalImpuesto":
                                            txt_TotalImpuesto.Text = ldk.Value;
                                            break;
                                        case "TotalComprobante":
                                            txt_TotalComprobante.Text = ldk.Value;
                                            break;
                                    }
                                }
                            }
                            #endregion
                        }

                    }
                    else {
                        MessageBox.Show("Hay error" + node.NodeType.ToString());
                    }
                }
                #endregion
                if (!var_cargar_detalle) {
                    MessageBox.Show("El documento cargado es inválido");
                    txt_exp_emisor_clave.Text = "err_detalles_001";
                }
                else {
                    bool continuar = true;

                    verificarClave(txt_exp_emisor_clave.Text.Trim().ToString(), txt_exp_receptor_tipo.Text, txt_exp_receptor_identification.Text, ref continuar);
                }
                pb1.Value = 100;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error " + ex.Message.ToString());
            }
        }
        private void btn_load_xml_Click(object sender, EventArgs e)
        {

            limpiarALL();

            pb1.Value = 1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Buscar XML Facturas";
            openFileDialog1.DefaultExt = "xml";
            openFileDialog1.Filter = "txt files (*.xml)|*.xml";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)

            {
                pb1.Value = 2;
                cargarXML(openFileDialog1.FileName);

                string errores = "";
                VarCompany my_company = DB.CheckCompanyPOS();
                string myToken = my_company.cloud_api_token;
                string myserver = my_company.cloud_api_type.ToString() == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;

                try
                {
                    using (System.Net.WebClient client = new System.Net.WebClient())
                    {

                        client.Headers.Add("Content-Type", "binary/octet-stream");
                        string filePath = @openFileDialog1.FileName.ToString();
                        first.cld("GZ " + filePath.ToString());
                        var serverPath = new Uri(@myserver + "/backupxml.php?token=" + myToken + "&newname=" + txt_exp_emisor_clave.Text.ToString());
                        first.cld("SP " + serverPath.ToString());
                        byte[] bret = client.UploadFile(serverPath, filePath);
                        string result = Encoding.UTF8.GetString(bret);                        
                    }

                }
                catch (Exception err)
                {
                    //MessageBox.Show(err.Message);
                    errores += err.Message.ToString();
                }

            }





        }
        private void salvarLocal(string tipo_doc,string gasto_compra)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run gastos.salvarLocal : " + tipo_doc.ToString());

            #region Verification
            string allErrors = "";
            bool continuar = false;
            
            verificarClave(txt_exp_emisor_clave.Text.Trim().ToString(), txt_exp_receptor_tipo.Text, txt_exp_receptor_identification.Text, ref continuar);
            if (txt_status_clave.Text.ToString().Length>2) {
                MessageBox.Show(txt_status_clave.Text.ToString());
                continuar = false;
            }

            if (txt_detalle_mensaje.Text.ToString().Length>160) {
                MessageBox.Show("Detalle del mensaje debe ser menor a 160 caracteres");
                continuar = false;
            }

            if(tipo_doc=="06" || tipo_doc == "07") { 
                if (txt_detalle_mensaje.Text.ToString().Length < 5)
                {
                    MessageBox.Show("Debe ingresar un detalle de mensaje");
                    continuar = false;
                }
            }

            #endregion
            grpFe.Visible = true;
            grpFe.BringToFront();
            lv_fe_report.Columns.Clear();
            lv_fe_report.Columns.Add("Resultado", 200);
            lv_fe_report.Items.Clear();
            pb_fe.Value = 10;

            
            VarCompany my_client = new VarCompany();
            SYMPOS_API_Fe _SYMFE;
            //TOdos
            //Check Clave no exista en referencais antes
            if (activo_lucas == 1)
            {
                continuar = true;
            }
                pb_fe.Value = 20;
            #region SaveMR
            if (continuar)
            {
                lv_fe_report.Items.Add("Salvando Factura");
                if (lv_gastos.Items.Count > 0)
                {
                    string invoice_id = "";
                    bool errorLocalInvoice = false;
                    SYMPOS_local_fe newFe = new POSV2.SYMPOS_local_fe();
                    if (newFe.SYMsaveMR(tipo_doc, DB.CheckCompanyPOS(), txt_exp_emisor_tipo.Text.ToString(), txt_exp_emisor_identification.Text.ToString(), txt_exp_emisor_name.Text.ToString(), txt_exp_emisor_email.Text.ToString(),
                    txt_exp_emisor_tipo_doc_code.Text.ToString(), txt_exp_emisor_clave.Text.ToString(), txt_exp_emisor_fecha_emision.Text.ToString(),
                    txt_TotalImpuesto.Text.ToString(), txt_TotalComprobante.Text.ToString(), txt_Currency.Text.ToString(),
                    txt_Tipocambio.Text.ToString(), txt_TotalServGravados.Text.ToString(), txt_TotalServExentos.Text.ToString(),
                    txt_TotalMercanciasGravadas.Text.ToString(), txt_TotalMercanciasExentas.Text.ToString(),
                    txt_TotalGravado.Text.ToString(), txt_TotalExento.Text.ToString(), txt_TotalVenta.Text.ToString(), txt_TotalDescuentos.Text.ToString(),
                    txt_TotalVentaNeta.Text.ToString(), txt_condicion_venta.Text.ToString(), txt_plazo_credito.Text.ToString(), txt_medio_pago.Text.ToString(),  
                    gasto_compra.ToString(), txt_detalle_mensaje.Text.ToString()) == 1)
                    {
                        invoice_id = DB.lId;

                        
                        
                        
                    int resSYMID = 0;
                        int resSYMTotalsID = 0;
                        int lineasDetalle = 0;

                        #region SaveGastosDetail
                        //foreach (String item in xml_detail[])
                        for (int i = 0; i < xml_detail.Count ; i++)

                        {

                            // 7  Monto, MontoTotalLinea, TaxCodigo, TaxCodigoIva, TaxTarifa, TaxMonto };
                            /*
0           1              2                3           4           5
numeroLinea, UnidadMedida, CodigoProducto, Cantidad, Detalle, PrecioUnitario,
    6          7                    8      9       10              11           12          13          14         
    MontoTotal, MontoDescuento, SubTotal, Monto, MontoTotalLinea, TaxCodigo, TaxCodigoIva, TaxTarifa, TaxMonto };

                            /*string invoice_id, string ,
            string id_producto,string product_sym, string product_sym_unit, string product_sym_code_type, string , 
            string product_sym_tax_code,string product_sym_tax_code_iva, string product_sym_tax,  string ,
            string , string , string monto_total, string sub_total, string total_tax,string ) {

                               string id_producto,string product_sym, string product_sym_unit, string product_sym_code_type, string product_sym_barcode, 
            string product_sym_tax_code,string product_sym_tax_code_iva, string product_sym_tax,  string product_sym_description,
            string qty, string product_price, string monto_total, string sub_total, string total_tax,string total_linea, string codigo_proveedor) {

                            string[] rowDet = { 
                            numeroLinea, UnidadMedida, CodigoProducto, Cantidad, Detalle, PrecioUnitario, 
                            MontoTotal, MontoDescuento, SubTotal, Monto, MontoTotalLinea, 
                            TaxCodigo, TaxCodigoIva, TaxTarifa, TaxMonto, CodigoProveedor 

           x*/
                            resSYMID = newFe.SYMsaveGastosDetail(invoice_id, //invoice_id
                                xml_detail[i][0].ToString(), 
                                "", //id_producto
                                "", //product_sym
                                xml_detail[i][1].ToString(), //product_sym_unit
                                "", //product_sym_code_type
                                xml_detail[i][2].ToString(), //CodigoProducto BARCODE
                                xml_detail[i][11].ToString(), //TaxCodigo
                                xml_detail[i][12].ToString(), //TaxCodigoIva
                                xml_detail[i][13].ToString(), // TaxTarifa
                                xml_detail[i][4].ToString(),  //product_sym_description Detalle
                                xml_detail[i][3].ToString(), //qty Cantidad
                                xml_detail[i][5].ToString(), //product_price PrecioUnitario
                                xml_detail[i][6].ToString(), //monto_total MontoTotal
                                xml_detail[i][8].ToString(), //sub_total SubTotal
                                xml_detail[i][14].ToString(), //total_tax TaxMonto
                                xml_detail[i][10].ToString(), //total_linea MontoTotalLinea
                                xml_detail[i][7].ToString(), //MontoDescuento MontoDescuento
                                xml_detail[i][15].ToString(), //CodigoProveedor CodigoProveedor
                                xml_detail[i][16].ToString() //Cabys
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


                        pb_fe.Value = 30;
                        lv_fe_report.Items.Add("Mensaje Salvado...");
                            //Conseguir Consecutivo del API

                            //Caso de Error Crear Consecutivo local

                            //HayInternet
                            lv_fe_report.Items.Add("Enviando");
                            pb_fe.Value = 40;
                            _SYMFE = new SYMPOS_API_Fe();
                            try
                            {
                                _SYMFE.sendMR(invoice_id);
                            }
                            catch {
                                MessageBox.Show(DB.get_language("var_err") + " MensajeReceptor");
                            }
                            
                            pb_fe.Value = 50;

                            lv_fe_report.Items.Add(_SYMFE.respuesta);
                            lv_fe_report.Items.Add("Enviada");
                            if (_SYMFE.respuesta.ToString().Length > 0) {
                                if (_SYMFE.respuesta.ToString().Substring(0, 3) == "202")
                                {
                                    pb_fe.Value = 90;
                                }
                                else {
                                    pb_fe.Value = 0;
                                }
                            }

                            pb_fe.Value = pb_fe.Value + 10;

                            _SYMFE.s3FE(invoice_id);
                            lv_fe_report.Items.Add(_SYMFE.respuesta);
                                MessageBox.Show("Gasto salvado "+ _SYMFE.respuesta);
                    }
                    else{
                        MessageBox.Show(DB.get_language("var_err") + " SYMsaveMR");
                        errorLocalInvoice = true;
                    }

                } else {
                    //Error 
                    MessageBox.Show(DB.get_language("var_err") + System.Environment.NewLine + DB.get_language("err_detail_line"));
                }
            #endregion
            }else {
                MessageBox.Show(DB.get_language("var_err") + allErrors);
                
            }
        }

        private void DisableAll() {

            btn_gastos_aceptar_gasto.Enabled = false;
            btn_gastos_aceptar_compra.Enabled = false;
            btn_gastos_aceptar_parcial.Enabled = false;
            btn_gastos_aceptar_rechazar.Enabled = false;
        }
        private void btn_gastos_aceptar_Click(object sender, EventArgs e)
        {
            DisableAll();
            salvarLocal("05","01");
            
        }
        private void btn_gastos_aceptar_parcial_Click(object sender, EventArgs e)
        {
            DisableAll();
            salvarLocal("06","02");
            
        }
        private void btn_gastos_aceptar_rechazar_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Está seguro que desea rechazar este documento ? ", "Gastos", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                DisableAll();
                salvarLocal("07","00");
            }
            else if (result == DialogResult.No)
            {                
                //do something else
            }

            
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

        private void btn_fe_aceptar_Click(object sender, EventArgs e)
        {

        }

        private void txt_Currency_MouseClick(object sender, MouseEventArgs e)
        {
            if (activo_lucas == 1)
            {
                activo_lucas = 0;
            }
            else
            {
                activo_lucas = 1;
            }
        }

        private void txt_status_clave_Click(object sender, EventArgs e)
        {

        }

        private void txt_status_clave_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            btn_gastos_aceptar_gasto.Enabled = true;
            btn_gastos_aceptar_compra.Enabled = true;
            btn_gastos_aceptar_parcial.Enabled = true;
            btn_gastos_aceptar_rechazar.Enabled = true;
        }

        private void btn_gastos_aceptar_compra_Click(object sender, EventArgs e)
        {
            DisableAll();
            salvarLocal("05", "02");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearLV();
            CleanLVFEC();
            limpiarALL();
        }

    }
}
