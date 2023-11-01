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
    public partial class invoice_product_modal : Form
    {
        public bool saved = false;
        bool loadReady = false;
        public invoice_product_modal()
        {            
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_product_modal. : ");
            InitializeComponent();
            DB.specialRun = "callback_invoice_product_modal";
            DB.CreateloadLanguage(mnuS1, this);

            DB.loadCmbProdSym(ref cmb_products_sym_type, 2);
            cmb_products_sym_type.SelectedIndex = 0;
            txt_code_cabys.Text = "";
            loadReady = true;
        }
        public void loadBarcode(string loadBarcode)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_product_modal.loadBarcode : ");
            txt_products_sym_barcode.Text = loadBarcode.ToString();
            lbl_edit_sym_product_id.Text = "";
            cleanPModal();
        }
        public void loadProduct(string product_id)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_product_modal.loadProduct : ");

            cleanPModal();
            string sql_mysql_search_barcode = "select * from products where product_id='" + product_id + "'";


            //lbl_invoice_barcode_result.Text = DB.get_language("lbl_invoice_barcode_result");

            DataTable tDt = DB.q(sql_mysql_search_barcode, "", "");
            if (tDt.HasErrors)
            {
                MessageBox.Show(DB.get_language("var_err"));
            }
            else
            {
                if (tDt.Rows.Count > 0)
                {
                    txt_products_sym_barcode.Text = tDt.Rows[0]["product_sym_barcode"].ToString();
                    txt_products_sym_description.Text = tDt.Rows[0]["product_sym_description"].ToString();
                    lbl_edit_sym_product_id.Text = tDt.Rows[0]["product_id"].ToString();

                    if (tDt.Rows[0]["product_sym_tax_code"].ToString()!="" && tDt.Rows[0]["product_sym_tax_code_iva"].ToString() != "" ) {

                        foreach (var cbi in cmb_products_sym_type.Items)
                        {
                            if (((csym)cbi).h_sym_tax_code.ToString() == tDt.Rows[0]["product_sym_tax_code"].ToString()
                                && ((csym)cbi).h_sym_tax_code_iva.ToString() == tDt.Rows[0]["product_sym_tax_code_iva"].ToString()
                                ){
                                cmb_products_sym_type.SelectedItem = cbi;
                                ActivateAll();
                                break;
                            }

                        }
                    }
                    decimal decimal_product_price, PrecioTotal;
                    if (tDt.Rows[0]["product_price"].ToString() != "0.00000" )
                    {
                        //txt_products_sym_price_before_tax.Text = tDt.Rows[0]["product_price"].ToString();
                        
                        if (Decimal.TryParse(tDt.Rows[0]["product_price"].ToString(), out decimal_product_price))
                        {
                            PrecioTotal = 0;

                            PrecioTotal = decimal.Round(decimal_product_price * (decimal)(1 + (decimal.Parse(lbl_products_tax.Text) / 100)), 5);

                            txt_products_sym_price.Text = PrecioTotal.ToString();
                            calcFinal();
                        }
                        

                    }
                        //product_price = '" + txt_products_sym_price_before_tax.Text.ToString()

                    }
            }
            
        }
        private void cleanPModal() {
            /*
            DB.loadCmbSubCat(ref cmb_products_sym_sub_cat, 2);
            cmb_products_sym_sub_cat.SelectedIndex = 0;

            DB.loadCmbCur(ref cmb_products_sym_cur);
            cmb_products_sym_cur.SelectedIndex = 0;

            DB.loadCmbProdSym(ref cmb_products_sym_type, 2);
            cmb_products_sym_type.SelectedIndex = 0;
            
            txt_products_sym_qty.Text = "0";
            */
            txt_products_sym_price.Text = "";
            txt_products_sym_price_before_tax.Text = "";            
        }
        private void invoice_product_modal_Shown(object sender, EventArgs e)
        {
            // DB.specialRun = "callback_invoice_product_modal";
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DB.specialRun = "callback_invoice";
            this.Close();
        }
        private void saveProductSYM() {

            #region Verification

            bool errores = false;
            string allErrors = "";
            

            DB.check_cmb(ref cmb_products_sym_type, "lbl_products_sym", ref errores, ref allErrors, 1, 999, "2");

            DB.check_text(ref txt_products_sym_description, "lbl_products_description", ref errores, ref allErrors, 1, 160);

            DB.check_text(ref txt_products_sym_price, "lbl_products_price_total", ref errores, ref allErrors, 1, 80);
            DB.check_text(ref txt_products_sym_price_before_tax, "lbl_products_price", ref errores, ref allErrors, 1, 80);

            DB.check_text(ref txt_code_cabys, "lbl_code_cabys", ref errores, ref allErrors, 13, 13);

            string crud = "";
            
            string h_sym_tax_code = "";
            string h_sym_tax_monto = "";
            string h_sym_tax_code_iva = "";
            string cmb_products_sym_sub_cat = "";

            if (lbl_edit_sym_product_id.Text.Length > 0) {
                crud = "2";
            } else {
                crud = "1";
            }
            /*if (btn_abarrotes_exento.Enabled == false) {
                cmb_products_sym_type = "UnidEx";
                h_sym_tax_code = "00";
                h_sym_tax_monto = "0"; 
                cmb_products_sym_sub_cat = "1";
            } else if (btn_abarrotes_grabado.Enabled == false){
                cmb_products_sym_type = "UnidGr13";
                h_sym_tax_code = "01";
                h_sym_tax_monto = "13";
                cmb_products_sym_sub_cat = "2";
            }
            else if (btn_abarrotes_licores.Enabled == false) {
                cmb_products_sym_type = "UnidEx";
                h_sym_tax_code = "00";
                h_sym_tax_monto = "0";
                cmb_products_sym_sub_cat = "3";
            }*/
            h_sym_tax_code= lbl_products_tax_code.Text.ToString();
            h_sym_tax_code_iva = lbl_products_tax_iva.Text.ToString();
            h_sym_tax_monto = lbl_products_tax.Text.ToString();
            cmb_products_sym_sub_cat = "1";

            #endregion

            #region Products
            if (errores){
                MessageBox.Show(DB.get_language("var_err") + " > " + allErrors);
            }else{

                string sql_save_products_mysql = "";
                string sql_w = "";

                if (crud == "1")
                {
                    sql_save_products_mysql = "insert into products set product_cd=now() ";
                    sql_w = " ";
                }
                else
                {
                    sql_save_products_mysql = "update products set product_ud=now() ";
                    sql_w = " where product_id='" + lbl_edit_sym_product_id.Text.ToString() + "'";
                }
                sql_save_products_mysql += " ,product_sym = '" + ((csym)cmb_products_sym_type.SelectedItem).h_sym.ToString() + "'";
                sql_save_products_mysql += " ,product_inventory_type = '1'";

                sql_save_products_mysql += " ,product_sym_stock = '0'";

                sql_save_products_mysql += " ,product_sym_barcode = '" + DB.s(txt_products_sym_barcode.Text.ToString()) + "'";
                sql_save_products_mysql += " ,product_sym_description = '" + DB.s(txt_products_sym_description.Text.ToString() )+ "'";


                sql_save_products_mysql += " ,product_sym_tax_code = '" + h_sym_tax_code + "'";
                sql_save_products_mysql += " ,product_sym_tax_code_iva = '" + h_sym_tax_code_iva + "'";                
                sql_save_products_mysql += " ,product_sym_tax = '" + h_sym_tax_monto + "'";
                /*
                if (btn_abarrotes_exento.Enabled == false){
                    sql_save_products_mysql += " ,product_sym = 'UnidEx'";
                }else{
                    sql_save_products_mysql += " ,product_sym = 'UnidGr13'";
                }
                */

                sql_save_products_mysql += " ,product_sym_unit = 'Unid'";
                sql_save_products_mysql += " ,product_sym_code_type = '01'";

                sql_save_products_mysql += " ,product_currency = 'CRC'";
                sql_save_products_mysql += " ,product_sub_category_id = '1'";

                sql_save_products_mysql += " ,product_price = '" + txt_products_sym_price_before_tax.Text.ToString() + "'";

                sql_save_products_mysql += " ,product_codigo_cabys = '" + txt_code_cabys.Text.ToString() + "'";

                DB.e(sql_save_products_mysql + sql_w, "", "");
                if (DB.conectado)
                {
                    MessageBox.Show(DB.get_language("var_ok"));
                    saved = true;
                    DB.specialRun = "callback_invoice";
                    this.Close();

                }
                else
                {
                    MessageBox.Show(DB.get_language("var_err"));
                }
            }
            #endregion
        }
        private void btn_update_product_Click(object sender, EventArgs e)
        {
            saveProductSYM();
        }
        private void ActivateAll() {
            /*btn_abarrotes_exento.Enabled = true;
            btn_abarrotes_grabado.Enabled = true;
            btn_abarrotes_licores.Enabled = true;*/
            btn_update_product.Enabled = true;
            txt_products_sym_price.Enabled = true;
        }
        /*private void btn_abarrotes_exento_Click(object sender, EventArgs e)
        {
            ActivateAll();
            btn_abarrotes_exento.Enabled = false;
            txt_products_sym_price.Focus();
        }
        private void btn_abarrotes_grabado_Click(object sender, EventArgs e)
        {
            ActivateAll();
            btn_abarrotes_grabado.Enabled = false;
            txt_products_sym_price.Focus();
        }
        private void btn_abarrotes_licores_Click(object sender, EventArgs e)
        {
            ActivateAll();
            btn_abarrotes_licores.Enabled = false;
            txt_products_sym_price.Focus();
        }*/
        private void txt_products_sym_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.txt_invoice_qty_KeyPress : ");
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txt_products_sym_price.Text.Length > 0)
            {
                int my_qty;
                if (!int.TryParse(txt_products_sym_price.Text.ToString(), out my_qty))
                {
                    txt_products_sym_price.Text = "0";
                    e.Handled = true;
                }
                else
                {
                    //CalcLine();
                }
            }
        }
        private void calcFinal() {


            if (txt_products_sym_price.Text.Length > 0)
            {
                decimal my_price;
                decimal my_price_final;
                if (!decimal.TryParse(txt_products_sym_price.Text.ToString(), out my_price))
                {
                    txt_products_sym_price.Text = "0";
                }
                else
                {
                    
                        my_price_final = decimal.Round(my_price / (decimal)(1 + (decimal.Parse(lbl_products_tax.Text)/100) ), 5);
                    txt_products_sym_price_before_tax.Text = my_price_final.ToString();
                    /* if (btn_abarrotes_exento.Enabled == false)
                     {
                         //my_price_final = decimal.Round(my_price / (decimal)1.13, 5);
                         txt_products_sym_price_before_tax.Text = my_price.ToString();
                     }
                     else if (btn_abarrotes_grabado.Enabled == false)
                     {
                         my_price_final = decimal.Round(my_price / (decimal)1.13, 5);
                         txt_products_sym_price_before_tax.Text = my_price_final.ToString();
                     }
                     else if (btn_abarrotes_licores.Enabled == false)
                     { //EXENTOS
                         //my_price_final = decimal.Round(my_price / (decimal)1.13, 5);
                         txt_products_sym_price_before_tax.Text = my_price.ToString();
                     }
                     */
                }
            }
        }
        private void txt_products_sym_price_KeyUp(object sender, KeyEventArgs e)
        {
            calcFinal();
        }

        private void cmb_products_sym_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_products_tax_code.Text = ((csym)cmb_products_sym_type.SelectedItem).h_sym_tax_code.ToString();
            lbl_products_tax_iva.Text = ((csym)cmb_products_sym_type.SelectedItem).h_sym_tax_code_iva.ToString();
            lbl_products_tax.Text = ((csym)cmb_products_sym_type.SelectedItem).h_sym_tax_monto.ToString();
            ActivateAll();
            if (loadReady) { calcFinal(); }
                
        }

        #region CABYS

        private void txt_search_cabys_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.txt_products_search_CABYS : ");
            if (e.KeyCode == Keys.Enter)
            {
                txt_code_cabys.Text = "";
                SearchCabys("");
            }
        }
        private void SearchCabys(string code_cabys)
        {
            if (txt_search_cabys.Text.Length > 2 || code_cabys.Length == 13)
            {
                cmb_cabys.Items.Clear();
                string sql_mysql_search_cabys = "";
                string sql_mysql_search_order = "";
                if (chk_cabys_order_cat.Checked == true) { sql_mysql_search_order = " order by f17 "; } else { sql_mysql_search_order = " order by f18 "; }

                if (code_cabys != "")
                {
                    sql_mysql_search_cabys = "select f17,f18 from cabys where f17 = '" + DB.s(txt_code_cabys.Text.ToString()) + "' " + sql_mysql_search_order;
                }
                else { sql_mysql_search_cabys = "select f17,f18 from cabys where lcase(f18) like lcase('%" + DB.s(txt_search_cabys.Text.ToString().Replace(" ", "%")) + "%') " + sql_mysql_search_order; }

                DataTable tDt = DB.q(sql_mysql_search_cabys, "", "");
                if (tDt.HasErrors)
                {
                    MessageBox.Show(DB.get_language("var_err"));
                }
                else
                {
                    if (tDt.Rows.Count > 0)
                    {
                        if (tDt.Rows.Count != 1)
                        {
                            cmb_cabys.Items.Add(new cbi("--Seleccione una opcion--", ""));
                            cmb_cabys.SelectedIndex = 0;
                        }
                        foreach (DataRow r in tDt.Rows)
                        {
                            cmb_cabys.Items.Add(new cbi(r["f18"].ToString(), r["f17"].ToString()));
                            if (tDt.Rows.Count == 1) { cmb_cabys.SelectedIndex = 0; }
                        }
                    }
                    else
                    {
                        cmb_cabys.Items.Add(new cbi("--NO HAY RESULTADOS--", ""));
                        cmb_cabys.SelectedIndex = 0;
                    }

                }
            }
        }

        private void cmb_cabys_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_code_cabys.Text = ((cbi)cmb_cabys.SelectedItem).HiddenValue.ToString();
            }
            catch { }
        }

        private void txt_code_cabys_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.txt_products_search_CABYS : ");
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_code_cabys.Text.Length != 13)
                {
                    MessageBox.Show("El codigo CABYS Debe de ser de 13 digitos");
                }
                else
                {
                    txt_search_cabys.Text = "";
                    SearchCabys(txt_code_cabys.Text.ToString());
                }

            }
        }

        private void chk_cabys_order_cat_CheckedChanged(object sender, EventArgs e)
        {

            txt_code_cabys.Text = "";
            SearchCabys("");
        }

        #endregion
    }
}
