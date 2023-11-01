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
    public partial class frm_pos_products : Form
    {
        string TxtPriceActivo;
        bool products_stores = false;
        bool products_minmax = false;
        string sql_products_stores = "";

        lv_names lvId = new lv_names();

        public frm_pos_products()
        {
            InitializeComponent();
        }

        private void frm_pos_products_Load(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.frm_pos_products_Load : ");
            DB.CreateloadLanguage(mnuS1, this);
            clearTxtProductSym();
            LoadProductSymTypeSearch();
            if (DB.checkConfig("products_minmax"))
            {
                products_minmax = true;
                panel_minmaxstock.Visible = true;
                txt_products_sym_stock_min.Text = "";
                txt_products_sym_stock_max.Text = "";
                txt_products_sym_stock_falta.Text = "";
            }
            else {
                panel_minmaxstock.Visible = false;
            }

            LoadProductSym("1");
            TxtPriceActivo = "";

            cmb_cabys.Items.Clear();
            txt_code_cabys.Text = "";

            if (DB.checkConfig("products_stores"))
            {
                products_stores = true;
                panel_ps.Visible = true;
                panel_ps.BringToFront();
                load_products_stores("", "");
            }
            else {
                panel_ps.Visible = false;
            }

            cleanTXTCombo();
            cleanLVCombo();
        }
        private void load_products_stores(string product_barcode, string product_iva) {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.load_products_stores : ");

            lbl_products_ps_iva.Text = product_iva;

            DB.debugLV(lv_ps_stores);

            lv_ps_stores.Items.Clear();
            lv_ps_stores.Columns.Clear();
            lv_ps_stores.Columns.Add("Id", 0);
            lv_ps_stores.Columns.Add("store_code", 0);
            lv_ps_stores.Columns.Add("Store", 81);
            lv_ps_stores.Columns.Add("Util", 30);
            lv_ps_stores.Columns.Add("Costo", 75);
            lv_ps_stores.Columns.Add("Precio", 75);

            //lv_ps_stores.Width = lv_ps_stores.Width - 10;
            string sql_load_ps_mysql = "";
            if (product_barcode.Length > 0)
            {
                sql_load_ps_mysql = @"select * from company_store
                left join products_store on products_store.ps_store_code = company_store.store_code and product_sym_barcode = '" + product_barcode + "'";
                lbl_products_ps_product_barcode.Text = product_barcode;

            }
            else {
                sql_load_ps_mysql = "select *,'00' as ps_product_utilidad,'9,999,999.99' as ps_product_price,'9,999,999.00' as ps_product_cost  from company_store order by store_code";
                lbl_products_ps_product_barcode.Text = "";
            }


            DataTable tDt = DB.q(sql_load_ps_mysql, "", "");
            //TODOs
            //user_access_level
            sql_products_stores = "";
            foreach (DataRow r in tDt.Rows)
            {
                string[] row = {
                    r["company_store_id"].ToString(),
                    r["store_code"].ToString(),
                    r["store_name"].ToString(),
                    r["ps_product_utilidad"].ToString(),
                    r["ps_product_cost"].ToString(),
                    r["ps_product_price"].ToString()
                };
                //lbl_products_ps_iva.Text = r["product_sym_tax"].ToString();
                var lvi = new ListViewItem(row);
                lv_ps_stores.Items.Add(lvi);

                sql_products_stores += ",round(max(if(ps_store_code='" + r["store_code"].ToString() + "',ps_product_price,'')),0) as '" + r["store_code"].ToString() + "'";

            }
        }

        public void LoadProductSymStores(string tipo = "0")
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.LoadProductSym : ");
            DB.debugLV(lv_ps_products);
            //Load Users
            lv_ps_products.Items.Clear();
            lv_ps_products.Columns.Clear();
            lv_ps_products.Columns.Add("Id", 0);
            lv_ps_products.Columns.Add(DB.get_language("lbl_products_sym"), 0);

            lv_ps_products.Columns.Add(DB.get_language("lbl_products_inventory"), 35);
            lv_ps_products.Columns.Add(DB.get_language("lbl_products_barcode"), 45);
            lv_ps_products.Columns.Add(DB.get_language("lbl_products_description"), 205);

            lv_ps_products.Columns.Add(DB.get_language("lbl_products_sym_cur"), 0);
            lv_ps_products.Columns.Add(DB.get_language("lbl_products_price"), 48, HorizontalAlignment.Right);
            lv_ps_products.Columns.Add(DB.get_language("lbl_products_price_tax"), 27, HorizontalAlignment.Right);
            //lv_products_sym_serach_results.Columns.Add(DB.get_language("lbl_products_price_with_tax"), 60);
            lv_ps_products.Columns.Add(DB.get_language("lbl_products_price_total"), 50, HorizontalAlignment.Right);

            lv_ps_products.Columns.Add("Estado", 38, HorizontalAlignment.Right);

            lv_ps_products.Columns.Add("Nombre Costo", 0, HorizontalAlignment.Right);
            lv_ps_products.Columns.Add("Costo", 50, HorizontalAlignment.Right);

            if (products_minmax) {
                lv_ps_products.Columns.Add("Min", 38, HorizontalAlignment.Right);
                lv_ps_products.Columns.Add("Max", 38, HorizontalAlignment.Right);
                lv_ps_products.Columns.Add("Falta", 38, HorizontalAlignment.Right);
            }

            foreach (ListViewItem item in lv_ps_stores.Items)
            {
                lv_ps_products.Columns.Add(item.SubItems[2].Text, 50, HorizontalAlignment.Right);
            }


            string sql_w = " where ";
            string sql_a = "";
            string sql_s = "";
            string sql_o = "";
            /*            string sql_load_products_mysql = "select active,product_id,product_sym,product_inventory_type,if(product_inventory_type=0,'',product_sym_stock) as product_sym_stock,product_sym_barcode,product_sym_description,product_currency,FORMAT(product_price,0) as product_price, FORMAT(product_sym_tax,0) as product_sym_tax, " +
                        " ROUND(if (product_sym_tax_code = '00',0,(product_price * (product_sym_tax / 100))),0) as product_price_tax,  " +
                        " FORMAT(ROUND(if (product_sym_tax_code = '00',product_price,(product_price * (1 + (product_sym_tax / 100)))),0),0) as product_price_tax_total  " +
                        " from products where product_sym !='0' ";*/
            string sql_minmaxstock_inner = "";
            string sql_minmaxstock_sel = "";
            if (products_minmax)
            {
                sql_minmaxstock_sel = " ,stock.stock_min,stock.stock_max, if (products.product_sym_stock > stock_max,0,stock_max -if (products.product_sym_stock < 0,0,products.product_sym_stock)) as stock_falta ";
                sql_minmaxstock_inner = " left JOIN stock ON stock.barcode =products.product_sym_barcode";
            }
            string sql_load_products_mysql = @"select active,
product_id,product_sym,
product_inventory_type,
if(product_inventory_type=0,'',product_sym_stock) as product_sym_stock,
product_sym_barcode,
product_sym_description,
product_currency,
    FORMAT(product_price,0) as product_price, 
    FORMAT(product_sym_tax,0) as product_sym_tax, 
    ROUND(if (product_sym_tax_code = '00',0,(product_price * (product_sym_tax / 100))),0) as product_price_tax,  
    FORMAT(ROUND(if (product_sym_tax_code = '00',product_price,(product_price * (1 + (product_sym_tax / 100)))),0),0) as product_price_tax_total,
products_costos.costo as costo_price,
products_costos.nombre as costo_name
" + sql_products_stores + @"
" + sql_minmaxstock_sel + @"
from products
left join products_costos on products_costos.codbarras=product_sym_barcode
left join products_store using(product_sym_barcode)
" + sql_minmaxstock_inner + @"
where product_sym !='0'";

            if (((csym)cmb_products_sym_type_search.SelectedItem).h_sym.ToString() != "0")
            {
                sql_s = " and product_sym like  '%" + ((csym)cmb_products_sym_type_search.SelectedItem).h_sym.ToString() + "'";
            }

            if (txt_products_search_all.Text.Length > 0)
            {
                string search_txt = DB.s(txt_products_search_all.Text.ToString() + "%");
                sql_s += " and ( product_sym like '" + search_txt + "' or product_sym_barcode like '%" + search_txt + "' or product_sym_description like '%" + search_txt + "' )";
            }
            else
            {
                sql_s += " and active=1 order by if (product_ud>product_cd,product_ud,product_cd) desc  limit 50";
            }

            DataTable tDt = DB.q(sql_load_products_mysql + sql_s + " group by products.product_sym_barcode ", "", "");
            //TODOs
            //user_access_level

            foreach (DataRow r in tDt.Rows)
            {
                string activodesactivo = "";
                if (r["active"].ToString() == "1") { activodesactivo = "Activo"; } else { activodesactivo = "Eliminado"; }

                string[] row = { r["product_id"].ToString(), r["product_sym"].ToString(), r["product_sym_stock"].ToString(), r["product_sym_barcode"].ToString(),
                    r["product_sym_description"].ToString(),
                    r["product_currency"].ToString(),
                    r["product_price"].ToString(), //Sin IVA
                    r["product_sym_tax"].ToString(), //% IVA
                    r["product_price_tax_total"].ToString(), //Con IVA
                    activodesactivo,
                    r["costo_name"].ToString(), //Costo name
                    r["costo_price"].ToString() //Costo Price                    
                };
                if (products_minmax)
                {
                    string[] row2 = {
                        r["stock_min"].ToString(), //Min
                        r["stock_max"].ToString(), //Max
                        r["stock_falta"].ToString() //Faltante
                    };
                    row2.CopyTo(row, 0);
                }
                var lvi = new ListViewItem(row);

                var ps_stores = new List<string>();

                foreach (ListViewItem item in lv_ps_stores.Items)
                {
                    ps_stores.Add(r[item.SubItems[1].Text].ToString());
                    lvi.SubItems.Add(r[item.SubItems[1].Text].ToString());
                }



                lv_ps_products.Items.Add(lvi);
            }
        }

        private void lv_ps_products_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarPStxt();
            if (lv_ps_products.Items.Count > 0 && lv_ps_products.SelectedItems.Count == 1)
            {
                if (lv_ps_products.SelectedItems[0].SubItems[3].Text.Length > 0) {
                    load_products_stores(
                    lv_ps_products.SelectedItems[0].SubItems[3].Text.ToString(),
                    lv_ps_products.SelectedItems[0].SubItems[7].Text.ToString()
                    );
                }
            }
        }

        private void lv_ps_stores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_ps_stores.Items.Count > 0 && lv_ps_stores.SelectedItems.Count == 1)
            {
                lbl_products_ps_store_code.Text = lv_ps_stores.SelectedItems[0].SubItems[1].Text.ToString();

                lbl_products_ps_store_name.Text = lv_ps_stores.SelectedItems[0].SubItems[2].Text.ToString();

                txt_products_ps_utilidad.Text = lv_ps_stores.SelectedItems[0].SubItems[3].Text.ToString();
                txt_products_ps_costo.Text = lv_ps_stores.SelectedItems[0].SubItems[4].Text.ToString();

                txt_products_ps_precio.Text = lv_ps_stores.SelectedItems[0].SubItems[5].Text.ToString();


                //txt_products_ps_calculo_utilidad.Text = lv_ps_stores.SelectedItems[0].SubItems[2].Text.ToString();
                txt_products_ps_calculo_iva_utilidad.Text = "";
                CalcularPSCosto();

            }
        }
        private void btn_ps_save_Click(object sender, EventArgs e)
        {

            string sql_save_head = @"insert into products_store set 
            ps_store_code='" + lbl_products_ps_store_code.Text.ToString() + "', product_sym_barcode='" + lbl_products_ps_product_barcode.Text.ToString() + "', ";

            string sql_save_data = " ps_product_price='" + txt_products_ps_precio.Text.ToString() + "', " +
 " ps_product_cost='" + txt_products_ps_costo.Text.ToString() + "', " +
 " ps_product_utilidad='" + txt_products_ps_utilidad.Text.ToString() + "'";
            string sql_save_ps = sql_save_head + sql_save_data + " on duplicate key update " + sql_save_data;

            DB.e(sql_save_ps, "", "");
            if (DB.conectado)
            {
                MessageBox.Show(DB.get_language("var_ok"));
                //LimpiarPStxt();
                load_products_stores(lbl_products_ps_product_barcode.Text.ToString(), lbl_products_ps_iva.Text.ToString());
            }
            else
            {
                MessageBox.Show(DB.get_language("var_err"));
            }
        }

        private void txt_products_ps_utilidad_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularPSCosto();
        }
        private void txt_products_ps_costo_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularPSCosto();
        }

        private void LimpiarPStxt() {

            lbl_products_ps_store_name.Text = "";

            txt_products_ps_utilidad.Text = "";
            txt_products_ps_costo.Text = "";

            txt_products_ps_precio.Text = "";

            txt_products_ps_calculo_cost_iva.Text = "";
            txt_products_ps_calculo_iva_utilidad.Text = "";

        }
        private void CalcularPSCosto() {
            try {
                //decimal.Parse(txt_products_ps_utilidad.Text);
                decimal.Parse(txt_products_ps_costo.Text);

                decimal v_sym_tax_monto = decimal.Parse(lbl_products_ps_iva.Text);
                decimal v_tax_porcent = (v_sym_tax_monto / 100);
                first.cld(v_tax_porcent);

                decimal v_sym_util_monto = decimal.Parse(txt_products_ps_utilidad.Text);
                decimal v_util_porcent = (v_sym_util_monto / 100);

                decimal v_sym_cost_monto = decimal.Parse(txt_products_ps_costo.Text);
                decimal v_sym_prod_tax = v_sym_cost_monto + (v_sym_cost_monto * v_tax_porcent);
                first.cld(v_sym_prod_tax);
                txt_products_ps_calculo_cost_iva.Text = v_sym_prod_tax.ToString(DB.ND2);

                decimal v_sym_prod_tax_util = v_sym_prod_tax + (v_sym_prod_tax * v_util_porcent);
                first.cld(v_sym_prod_tax_util);
                txt_products_ps_calculo_iva_utilidad.Text = v_sym_prod_tax_util.ToString(DB.ND2);

            } catch {
                txt_products_ps_calculo_iva_utilidad.Text = "ERROR";
            }
        }
        private void clearTxtProductSym()
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.clearTxtProduct : ");
            LoadProductCategory();
            LoadProductSymCur();
            LoadProductSymType();

            txt_products_sym_barcode.Text = "";
            txt_products_sym_description.Text = "";

            txt_products_sym_price.Text = "";
            txt_products_sym_price_tax.Text = "";
            txt_products_sym_price_total.Text = "";
            txt_products_sym_inventory_cost.Text = "";

            lbl_edit_sym_product_id.Text = "";


            txt_products_sym_stock_min.Text = "";
            txt_products_sym_stock_max.Text = "";
            txt_products_sym_stock_falta.Text = "";

            loadAdvanced();

            LoadCmbAction();
        }
        private void loadAdvanced() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.loadAdvanced : ");

            DB.loadAdvCmbUnit(ref cmb_adv_unit, 1, 2);
            //DB.loadAdvCmbproducts_code_type(ref cmb_adv_product_code, 1, 2);
            DB.loadAdvCmbproducts_adv_tax(ref cmb_adv_product_tax, 1, 2);
            //DB.loadCmbCur(ref cmb_adv_product_cur, 5, 2);

        }
        private void LoadProductCategory()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.LoadProductCategory : ");


            if (!chk_lock_cmb_sub_category.Checked)
            {
                DB.loadCmbSubCat(ref cmb_products_sym_sub_cat, 2);
                cmb_products_sym_sub_cat.SelectedIndex = 0;
            }
        }
        private void LoadProductSymCur() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.LoadProductSymCur : ");


            if (!chk_lock_cmb_products_sym_cur.Checked)
            {
                DB.loadCmbCur(ref cmb_products_sym_cur);
                cmb_products_sym_cur.SelectedIndex = 0;
            }

        }
        private void LoadProductSymType()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.LoadProductSymType : ");


            if (!chk_lock_cmb_products_sym_type.Checked)
            {
                DB.loadCmbProdSym(ref cmb_products_sym_type, 2);
                cmb_products_sym_type.SelectedIndex = 0;

            }

        }
        private void LoadProductSymTypeSearch()
        {

            DB.loadCmbProdSym(ref cmb_products_sym_type_search, 4);
            cmb_products_sym_type_search.SelectedIndex = 0;

            cmb_products_sym_type_search.Items.Add(
                new csym("Pendientes", "UnidEx", "01", "Unit", "00", "01", "0", "?")
                );
        }
        public void LoadCmbAction() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.LoadCmbAction : ");



            cmb_btn_action.Items.Clear();
            cmb_btn_action.Items.Add(new cbi(DB.get_language("cmb_action_select"), ""));
            cmb_btn_action.SelectedIndex = 0;
            cmb_btn_action.Items.Add(new cbi(DB.get_language("cmb_action_product_add"), "1"));

            if (lbl_edit_sym_product_id.Text.Length > 0) {
                cmb_btn_action.Items.Add(new cbi(DB.get_language("cmb_action_product_edit"), "2"));
            }
            cmb_btn_action.Items.Add(new cbi(DB.get_language("cmb_action_product_clean"), "3"));



            cmb_products_action.Items.Clear();
            cmb_products_action.Items.Add(new cbi(DB.get_language("cmb_action_select"), ""));
            cmb_products_action.Items.Add(new cbi("Activar los Seleccionados", "1"));
            cmb_products_action.Items.Add(new cbi("Desactivar los Seleccionados", "2"));
            cmb_products_action.SelectedIndex = 0;

        }
        public void LoadProductSym(string tipo = "0") {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.LoadProductSym : ");
            DB.debugLV(lv_products_sym_search_results);
            //Load Users
            lv_products_sym_search_results.Items.Clear();
            lv_products_sym_search_results.Columns.Clear();
            lv_products_sym_search_results.Columns.Add("Id", 24);
            lv_products_sym_search_results.Columns.Add(DB.get_language("lbl_products_sym"), 70);
            lv_products_sym_search_results.Columns.Add(DB.get_language("lbl_products_inventory"), 60);
            lv_products_sym_search_results.Columns.Add(DB.get_language("lbl_products_barcode"), 115);
            lv_products_sym_search_results.Columns.Add(DB.get_language("lbl_products_cabys"), 95);
            lv_products_sym_search_results.Columns.Add(DB.get_language("lbl_products_description"), 240);
            lv_products_sym_search_results.Columns.Add(DB.get_language("lbl_products_sym_cur"), 35);
            lv_products_sym_search_results.Columns.Add(DB.get_language("lbl_products_price"), 82, HorizontalAlignment.Right);
            lv_products_sym_search_results.Columns.Add(DB.get_language("lbl_products_price_tax"), 60, HorizontalAlignment.Right);
            //lv_products_sym_serach_results.Columns.Add(DB.get_language("lbl_products_price_with_tax"), 60);
            lv_products_sym_search_results.Columns.Add(DB.get_language("lbl_products_price_total"), 82, HorizontalAlignment.Right);

            lv_products_sym_search_results.Columns.Add("Estado", 45, HorizontalAlignment.Right);

            lv_products_sym_search_results.Columns.Add("PM", 35, HorizontalAlignment.Right);
            if (products_minmax)
            {
                lv_products_sym_search_results.Columns.Add("Min", 33, HorizontalAlignment.Right);
                lv_products_sym_search_results.Columns.Add("Max", 33, HorizontalAlignment.Right);
                lv_products_sym_search_results.Columns.Add("Falta", 38, HorizontalAlignment.Right);
            }

            string sql_w = " where ";
            string sql_a = "";
            string sql_s = "";
            string sql_o = "";


            string sql_minmaxstock_inner = "";
            string sql_minmaxstock_sel = "";
            if (products_minmax)
            {
                sql_minmaxstock_sel = " ,stock.stock_min,stock.stock_max, if (products.product_sym_stock > stock_max,0,stock_max -if (products.product_sym_stock < 0,0,products.product_sym_stock)) as stock_falta ";
                sql_minmaxstock_inner = " left JOIN stock ON stock.barcode =products.product_sym_barcode";
            }

            string sql_load_products_mysql = "select product_codigo_cabys,active,product_id,product_sym,product_inventory_type," +
                "if(product_adv_lock_precio=2,'Y','') as precio_modificable,if(product_inventory_type=0,'',product_sym_stock) as product_sym_stock,product_sym_barcode,product_sym_description,product_currency," +
                "FORMAT(product_price,2) as product_price,product_sym_tax, " +
            " ROUND(if (product_sym_tax_code = '00',0,(product_price * (product_sym_tax / 100))),0) as product_price_tax,  " +
            " FORMAT(ROUND(if (product_sym_tax_code = '00',product_price,(product_price * (1 + (product_sym_tax / 100)))),5),2) as product_price_tax_total  " + sql_minmaxstock_sel +
            " from products " + sql_minmaxstock_inner + "  where product_sym !='0' ";

            if (((csym)cmb_products_sym_type_search.SelectedItem).h_sym.ToString() != "0") {
                sql_s = " and product_sym like  '%" + ((csym)cmb_products_sym_type_search.SelectedItem).h_sym.ToString() + "'";
                if (((csym)cmb_products_sym_type_search.SelectedItem).h_sym_inventory_type.ToString() == "?")
                {
                    sql_s = " and product_adv_impuesto_codigo = '?'";
                }
            }

            if (txt_products_search_all.Text.Length > 0) {
                string search_txt = DB.s(txt_products_search_all.Text.ToString() + "%");
                sql_s += " and ( product_sym like '" + search_txt + "' or product_sym_barcode like '%" + search_txt + "' or product_sym_description like '%" + search_txt + "' )";
            } else {
                sql_s += " and active=1 order by if (product_ud>product_cd,product_ud,product_cd) desc  limit 50";
            }

            DataTable tDt = DB.q(sql_load_products_mysql + sql_s, "", "");
            //TODOs
            //user_access_level

            foreach (DataRow r in tDt.Rows)
            {
                string activodesactivo = "";
                if (r["active"].ToString() == "1") { activodesactivo = "Activo"; } else { activodesactivo = "Eliminado"; }
                string[] row = { r["product_id"].ToString(), r["product_sym"].ToString(), r["product_sym_stock"].ToString(),
                    r["product_sym_barcode"].ToString(), r["product_codigo_cabys"].ToString(), r["product_sym_description"].ToString(),
                    r["product_currency"].ToString(), r["product_price"].ToString(), r["product_sym_tax"].ToString(),
                    r["product_price_tax_total"].ToString(), activodesactivo,r["precio_modificable"].ToString()};

                if (products_minmax)
                {
                    string[] row2 = {
                        r["stock_min"].ToString(), //Min
                        r["stock_max"].ToString(), //Max
                        r["stock_falta"].ToString() //Faltante
                    };
                    //                    row2.CopyTo(row, 3);
                    string[] row3 = row.Concat(row2).ToArray();
                    row = row3;
                }
                var lvi = new ListViewItem(row);
                lv_products_sym_search_results.Items.Add(lvi);
            }
        }
        private void LoadProductSymbyId(string product_id)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.LoadProductSymbyId : ");
            string sql_load_products_mysql = "select * from products where product_id=" + product_id;

            DataTable tDt = DB.q(sql_load_products_mysql, sql_load_products_mysql, sql_load_products_mysql);

            if (tDt.HasErrors)
            {
                MessageBox.Show("-Error loading");
            }
            else
            {
                clearTxtProductSym();

                txt_products_sym_barcode.Text = tDt.Rows[0]["product_sym_barcode"].ToString();
                txt_products_sym_description.Text = tDt.Rows[0]["product_sym_description"].ToString();

                txt_products_sym_price.Text = tDt.Rows[0]["product_price"].ToString();
                txt_products_sym_qty.Text = tDt.Rows[0]["product_sym_stock"].ToString();

                txt_code_cabys.Text = tDt.Rows[0]["product_codigo_cabys"].ToString();

                SearchCabys(txt_code_cabys.Text.ToString());

                DB.sel_combo(ref cmb_products_sym_type, tDt.Rows[0]["product_sym"].ToString(), "2");
                DB.sel_combo(ref cmb_products_sym_cur, tDt.Rows[0]["product_currency"].ToString());

                if (!chk_lock_cmb_sub_category.Checked)
                {
                    DB.sel_combo(ref cmb_products_sym_sub_cat, tDt.Rows[0]["product_sub_category_id"].ToString());
                }
                lbl_edit_sym_product_id.Text = tDt.Rows[0]["product_id"].ToString();
                LoadCmbAction();

                if (tDt.Rows[0]["product_adv_lock_precio"].ToString() == "2") {
                    chk_lock_cmb_adv_price.Checked = true;
                }
                else {
                    chk_lock_cmb_adv_price.Checked = false;
                }
                //txt_products_adv_unidadmedidacomercial.Text = tDt.Rows[0]["product_adv_UnidadMedidaComercial"].ToString();
            }
            if (((csym)cmb_products_sym_type.SelectedItem).h_sym_inventory_type == "2")
            { //COMBO
                CargarComboDetails(txt_products_sym_barcode.Text);

                decimal  desc_subtotal_original = 0, desc_total_con_descuento = 0, desc_combo = 0;
                decimal.TryParse(tDt.Rows[0]["product_price"].ToString(), out desc_subtotal_original);
                decimal.TryParse(tDt.Rows[0]["temp_product_7_descuento"].ToString(), out desc_combo);
                desc_total_con_descuento = desc_subtotal_original - desc_combo;
                txt_products_sym_combo_precio_con_descuento.Text=desc_total_con_descuento.ToString(DB.ND2); 
            }

            if (products_minmax) {

                panel_minmaxstock.Visible = true;
                txt_products_sym_stock_min.Text = "";
                txt_products_sym_stock_max.Text = "";
                txt_products_sym_stock_falta.Text = "";

                string sql_load_products_stock_mysql = "select * from stock where barcode=" + txt_products_sym_barcode.Text;

                DataTable tDt_stocks = DB.q(sql_load_products_stock_mysql, sql_load_products_stock_mysql, sql_load_products_stock_mysql);

                if (tDt_stocks.HasErrors)
                {
                    MessageBox.Show("-Error loading");
                } else {
                    if (tDt_stocks.Rows.Count > 0)
                    {
                        txt_products_sym_stock_min.Text = tDt_stocks.Rows[0]["stock_min"].ToString();
                        txt_products_sym_stock_max.Text = tDt_stocks.Rows[0]["stock_max"].ToString();
                    }
                }
            }
        }
        private void saveProductSym(string crud) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.saveProductSym : " + crud.ToString());
            //Question if sure
            //Type 3 clean
            DB.debugLV(lv_products_sym_search_results);
            if (crud == "3") {
                clearTxtProductSym();
                return;
            }
            #region Verification

            bool errores = false;
            string allErrors = "";

            DB.check_text(ref txt_products_sym_barcode, "lbl_products_barcode", ref errores, ref allErrors, 2, 20);

            DB.check_cmb(ref cmb_products_sym_type, "lbl_products_sym", ref errores, ref allErrors, 1, 999, "2");

            DB.check_text(ref txt_products_sym_description, "lbl_products_description", ref errores, ref allErrors, 1, 160);

            DB.check_text(ref txt_products_sym_price, "lbl_products_price", ref errores, ref allErrors, 1, 80);

            if (((csym)cmb_products_sym_type.SelectedItem).h_sym_inventory_type.ToString() == "2") {
                if (lv_products_combo.Items.Count > 0) {
                    txt_code_cabys.Text = "0000000000000";
                }
                else {
                    errores = true;
                    allErrors = "Error en Items del combo, debe agregar 1 o más códigos";
                }

            }
            else {
                if (txt_code_cabys.Text == "0000000000000") {
                    txt_code_cabys.Text = "";
                }
                DB.check_text(ref txt_code_cabys, "lbl_code_cabys", ref errores, ref allErrors, 13, 13);
            }

            decimal valueDec;
            if (!decimal.TryParse(txt_products_sym_price.Text.ToString(), out valueDec))
            {
                valueDec = 0;
            }

            DB.check_cmb(ref cmb_products_sym_sub_cat, "lbl_products_category", ref errores, ref allErrors, 1, 999, "1");

            if (valueDec <= 0) {

                //if (tDt.Rows[0]["product_adv_lock_precio"].ToString() == "2")
                
                if (chk_lock_cmb_adv_price.Checked)
                {

                }
                else { 
                    errores = true;
                    allErrors += "Error en precio";
                }
            }
            #endregion


            #region Products
            if (errores)
            {
                MessageBox.Show(DB.get_language("var_err") + " > " + allErrors);
                cmb_btn_action.SelectedIndex = 0;
            }
            else
            {


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
                sql_save_products_mysql += " ,product_inventory_type = '" + ((csym)cmb_products_sym_type.SelectedItem).h_sym_inventory_type.ToString() + "'";
                if (((csym)cmb_products_sym_type.SelectedItem).h_sym_inventory_type.ToString() == "0")
                {
                    sql_save_products_mysql += " ,product_sym_stock = '0'";
                }
                else
                {
                    sql_save_products_mysql += " ,product_sym_stock = '" + txt_products_sym_qty.Text.ToString() + "'";
                }
                if (chk_lock_cmb_adv_price.Checked)
                {
                    sql_save_products_mysql += " ,product_adv_lock_precio = '2'"; 
                }
                else
                {
                    sql_save_products_mysql += " ,product_adv_lock_precio = '1'";
                }
                    sql_save_products_mysql += " ,product_adv_impuesto_codigo = ''"; //Canasta Basica


                sql_save_products_mysql += " ,product_sym_barcode = '" + txt_products_sym_barcode.Text.ToString() + "'";
                sql_save_products_mysql += " ,product_sym_description = '" + txt_products_sym_description.Text.ToString() + "'";



                sql_save_products_mysql += " ,product_sym_tax_code = '" + ((csym)cmb_products_sym_type.SelectedItem).h_sym_tax_code.ToString() + "'";
                sql_save_products_mysql += " ,product_sym_tax = '" + ((csym)cmb_products_sym_type.SelectedItem).h_sym_tax_monto.ToString() + "'";

                sql_save_products_mysql += " ,product_sym_tax_code_iva = '" + ((csym)cmb_products_sym_type.SelectedItem).h_sym_tax_code_iva.ToString() + "'";

                sql_save_products_mysql += " ,product_sym_unit = '" + ((csym)cmb_products_sym_type.SelectedItem).h_sym_unit.ToString() + "'";
                sql_save_products_mysql += " ,product_sym_code_type = '" + ((csym)cmb_products_sym_type.SelectedItem).h_sym_code_type.ToString() + "'";

                sql_save_products_mysql += " ,product_currency = '" + ((cbi)cmb_products_sym_cur.SelectedItem).HiddenValue.ToString() + "'";
                sql_save_products_mysql += " ,product_sub_category_id = '" + ((cbi)cmb_products_sym_sub_cat.SelectedItem).HiddenValue.ToString() + "'";

                sql_save_products_mysql += " ,product_price = '" + valueDec.ToString() + "'";

                sql_save_products_mysql += " ,product_codigo_cabys = '" + txt_code_cabys.Text.ToString() + "'";

                if (((csym)cmb_products_sym_type.SelectedItem).h_sym_inventory_type.ToString() == "2")
                {
                    sql_save_products_mysql += " ,temp_product_7_descuento = '" + txt_products_sym_combo_monto_descuento.Text.ToString() + "'";
                    //Falta Porcentaje
                }

                DB.e(sql_save_products_mysql + sql_w, "", "");

                string sql_insert_products_combo_mysql = "";
                if (DB.conectado)
                {
                    if (((csym)cmb_products_sym_type.SelectedItem).h_sym_inventory_type.ToString() == "2")
                    {

                        DB.e("delete from product_combo where product_sym_barcode_parent ='" + txt_products_sym_barcode.Text.ToString() + "'", "", "");
                        decimal combo_porcentaje_descuento = 0, combo_monto_unitario_linea=0,combo_monto_descuento_calculado_unitario=0;
                        foreach (ListViewItem item in lv_products_combo.Items)
                        {

                            sql_insert_products_combo_mysql = "insert into product_combo set product_combo_cd=now() ";
                            sql_insert_products_combo_mysql += " ,product_sym_barcode_parent = '" + txt_products_sym_barcode.Text.ToString() + "'";
                            sql_insert_products_combo_mysql += " ,product_id = '" + item.SubItems[lvId["id"]].Text.ToString() + "'";
                            sql_insert_products_combo_mysql += " ,product_sym_barcode_combo = '" + item.SubItems[lvId["lv_desc_barcode"]].Text.ToString() + "'";
                            sql_insert_products_combo_mysql += " ,product_combo_qty = '" + item.SubItems[lvId["lv_desc_qty"]].Text.ToString() + "'";

                            combo_porcentaje_descuento = decimal.Parse(txt_products_sym_combo_porcentaje_descuento.Text.ToString());                            
                            if (combo_porcentaje_descuento > 0)
                            {
                                combo_monto_unitario_linea = decimal.Parse(item.SubItems[lvId["lv_desc_precio_unitario"]].Text.ToString());
                                combo_monto_descuento_calculado_unitario = (combo_monto_unitario_linea - (combo_monto_unitario_linea / combo_porcentaje_descuento));

                                sql_insert_products_combo_mysql += " ,product_combo_desc_porcentaje = '" + combo_porcentaje_descuento.ToString() + "'";
                                sql_insert_products_combo_mysql += " ,product_combo_desc_monto = '" + combo_monto_descuento_calculado_unitario.ToString() + "'";

                            }
                            else {

                            }
                                DB.e(sql_insert_products_combo_mysql, "", "");

                        }
                    }
                    if (products_minmax)
                    {
                        string sql_product_stock = "insert into stock set barcode = '" + txt_products_sym_barcode.Text.ToString() + "'," +
                            "stock_min= '" + txt_products_sym_stock_min.Text.ToString() + "', stock_max = '" + txt_products_sym_stock_max.Text.ToString() + "' " +
                            "ON DUPLICATE KEY UPDATE stock_min = '" + txt_products_sym_stock_min.Text.ToString() + "', stock_max = '" + txt_products_sym_stock_max.Text.ToString() + "'";
                        DB.e(sql_product_stock, "", "");
                    }

                    MessageBox.Show(DB.get_language("var_ok"));
                    LoadProductSym("2");
                    lbl_edit_sym_product_id.Text = "";
                    clearTxtProductSym();

                }
                else
                {
                    MessageBox.Show(DB.get_language("var_err"));
                }


            }
            #endregion
            /**
             product_sym_id
product_sym_tipo
product_sym_unit_simbolo
product_sym_unit_descripcion
product_sym_tax_code
product_sym_tax
product_sym_impuesto
active
orden
product_sym_unit
product_sym_unit_desc
product_sym_code_type
product_sym_code_type_desc
product_inventory_type

                product_id
product_adv_code_type
product_adv_code
product_adv_unit_simbolo
product_adv_UnidadMedidaComercial
product_adv_impuesto_id
product_adv_impuesto_codigo
product_adv_impuesto_monto
product_inventory_type
product_sym_stock
product_sym_unit_simbolo
product_sym_barcode
product_sym_tax_code
product_sym_tax
products_sym_unit
products_sym_code_type
product_sym_description
product_category
product_currency
product_price
product_cd
product_ud

             **/

        }
        private void products_calc_total(string txt_sending = "1") {
            //If Products ADV ? SYM 
            string textboxValue = "";
            if (txt_sending == "1")
            {
                textboxValue = txt_products_sym_price.Text;
            }
            else {
                textboxValue = txt_products_sym_price_total.Text;
            }
            if (cmb_products_sym_type.SelectedIndex >= 0 && textboxValue.Length > 0 && ((csym)cmb_products_sym_type.SelectedItem).h_sym_tax_monto.Length > 0)
            {


                decimal valueDec = decimal.Parse(textboxValue);

                // Retrieve as integer
                //int valueInt = Int32.Parse(textboxValue);
                //((csym)cmb_products_sym.SelectedItem)).
                //((cbi)pCB.SelectedItem).HiddenValue

                if (((csym)cmb_products_sym_type.SelectedItem).h_sym_tax_monto == "0")
                {
                    txt_products_sym_price_tax.Text = "0";
                    txt_products_sym_price_total.Text = valueDec.ToString(DB.ND5);
                }
                else {

                    if (txt_sending == "1")
                    {
                        decimal v_sym_tax_monto = decimal.Parse(((csym)cmb_products_sym_type.SelectedItem).h_sym_tax_monto);
                        decimal v_tax_porcent = (v_sym_tax_monto / 100);
                        first.cld(v_tax_porcent);
                        decimal v_sym_prod_tax = (valueDec * v_tax_porcent);
                        first.cld(v_sym_prod_tax);

                        txt_products_sym_price_tax.Text = v_sym_prod_tax.ToString(DB.ND5);
                        txt_products_sym_price_total.Text = (valueDec + v_sym_prod_tax).ToString(DB.ND5);
                    }
                    else {
                        decimal v_sym_tax_monto = decimal.Parse(((csym)cmb_products_sym_type.SelectedItem).h_sym_tax_monto);
                        decimal v_tax_porcent = (v_sym_tax_monto / 100) + 1;
                        first.cld(v_tax_porcent);
                        decimal v_sym_prod_sin_tax = (valueDec / v_tax_porcent);
                        first.cld(v_sym_prod_sin_tax);

                        txt_products_sym_price_tax.Text = (valueDec - v_sym_prod_sin_tax).ToString(DB.ND5);

                        txt_products_sym_price.Text = v_sym_prod_sin_tax.ToString(DB.ND5);
                    }
                }

                if (((csym)cmb_products_sym_type.SelectedItem).h_sym_inventory_type == "1" && txt_products_sym_qty.Text.Length > 0)
                {
                    decimal v_sym_inventory_cost = decimal.Parse(txt_products_sym_price_total.Text.ToString()) * decimal.Parse(txt_products_sym_qty.Text.ToString());
                    txt_products_sym_inventory_cost.Text = v_sym_inventory_cost.ToString(DB.ND5);
                } else {
                    txt_products_sym_inventory_cost.Text = "0";
                }
            } else {
                txt_products_sym_price_tax.Text = "0";
                if (txt_sending == "1")
                {
                    txt_products_sym_price_total.Text = "0";
                }
                else
                {
                    txt_products_sym_price.Text = "0";
                }

            }
        }
        private void cmb_products_sym_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_products_tax_code.Text = ((csym)cmb_products_sym_type.SelectedItem).h_sym_tax_code.ToString();
            lbl_products_tax_iva.Text = ((csym)cmb_products_sym_type.SelectedItem).h_sym_tax_code_iva.ToString();

            panel_buscador.Visible = false;
            panel_combo.Visible = false;
            grp_cabys.Visible = true;

            txt_products_sym_qty.Enabled = true;
            txt_products_sym_price_total.Enabled = true;
            txt_products_sym_price.Enabled = true;
            
            if (((csym)cmb_products_sym_type.SelectedItem).h_sym_inventory_type == "1")
            { //Servicios
                if (txt_products_sym_qty.Text == "") {
                    txt_products_sym_qty.Text = "1";
                }
                txt_products_sym_qty.Enabled = true;
                panel_buscador.Visible = true;
            } else if (((csym)cmb_products_sym_type.SelectedItem).h_sym_inventory_type == "2")
            { //COMBO
                lbl_combo_descripcion.Text = txt_products_sym_description.Text;

                txt_products_sym_qty.Text = "1";
                txt_products_sym_qty.Enabled = false;

                txt_products_sym_price_total.Text = "0";
                txt_products_sym_price_total.Enabled = false;

                txt_products_sym_price.Text = "0";
                txt_products_sym_price.Enabled = false;

                panel_combo.Visible = true;
                grp_cabys.Visible = false;
            }
            else
            {
                txt_products_sym_qty.Text = "";
                txt_products_sym_qty.Enabled = false;
                panel_buscador.Visible = true;
            }
            products_calc_total();
        }
        private void cmb_btn_action_SelectedIndexChanged(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.cmb_btn_action_SelectedIndexChanged : ");
            string cmd_selected = ((cbi)cmb_btn_action.SelectedItem).HiddenValue;

            if (cmd_selected != "") {
                if (!chk_lock_cmb_btn_action.Checked && (cmd_selected == "1" | cmd_selected == "2"))
                {
                    string var_lang = "";
                    if (cmd_selected == "1")
                    {
                        var_lang = DB.get_language("var_add");
                    }
                    else if (cmd_selected == "2") {
                        var_lang = DB.get_language("var_update");
                    }

                    DialogResult result = MessageBox.Show(var_lang, "Products", MessageBoxButtons.YesNo);

                    if (result == DialogResult.No)
                    {
                        cmd_selected = "";
                    }
                }

                if (cmd_selected == "1") {
                    saveProductSym(cmd_selected);
                }
                else if (cmd_selected == "2")
                {
                    saveProductSym(cmd_selected);
                }
                else if (cmd_selected == "3")
                {
                    clearTxtProductSym();
                }

            } else {

            }

        }
        private void frm_pos_products_Shown(object sender, EventArgs e)
        {
            DB.specialRun = "callback_products";
        }
        private void lv_products_sym_serach_results_DoubleClick(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.lv_products_sym_serach_results_DoubleClick : ");
            searchProductId(lv_products_sym_search_results.SelectedItems[0].Text.ToString());
        }
        private void searchProductId(string product_id) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.searchProductId : ");
            if (product_id.Length > 0) {
                DialogResult result = MessageBox.Show(DB.get_language("var_edit"), "Products", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    LoadProductSymbyId(product_id);

                }
                else if (result == DialogResult.No)
                {
                    //do something else
                    txt_products_sym_barcode.Text = "";
                    txt_products_sym_barcode.Focus();
                }
            }
        }
        private void txt_products_search_all_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.txt_products_search_all_KeyUp : ");
            if (e.KeyCode == Keys.Enter)
            {

                if (products_stores)
                {
                    LoadProductSymStores("2");
                }
                else { LoadProductSym("2"); }

            }
        }

        private void cmb_adv_product_tax_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_adv_product_code_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lv_products_sym_serach_results_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chk_lock_cmb_products_sym_cur_CheckedChanged(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.chk_lock_cmb_products_sym_cur_CheckedChanged : ");
            if (chk_lock_cmb_products_sym_cur.Checked)
            {
                cmb_products_sym_cur.Enabled = false;
            }
            else {
                cmb_products_sym_cur.Enabled = true;
            }
        }
        private void chk_lock_cmb_products_sym_type_CheckedChanged(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.chk_lock_cmb_products_sym_type_CheckedChanged : ");
            if (chk_lock_cmb_products_sym_type.Checked)
            {
                cmb_products_sym_type.Enabled = false;
            }
            else
            {
                cmb_products_sym_type.Enabled = true;
            }

        }

        private void txt_products_sym_barcode_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.txt_products_sym_barcode_KeyUp : ");
            if (e.KeyCode == Keys.Enter)
            {
                //searchProductId(txt_products_sym_barcode.Text.ToString());
                txt_products_sym_description.Focus();
            }
        }

        private void txt_products_sym_barcode_Leave(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.txt_invoice_barcode_Leave : ");
            //searchProductId(txt_products_sym_barcode.Text.ToString());
            searchBarcode();
        }
        private void searchBarcode() {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.SearchBarcode : ");

            if (txt_products_sym_barcode.Text.Length > 0)
            {
                string sql_mysql_search_barcode = "select * from products where product_sym_barcode='" + DB.s(txt_products_sym_barcode.Text.ToString()) + "'";

                DataTable tDt = DB.q(sql_mysql_search_barcode, "", "");
                if (tDt.HasErrors)
                {
                    MessageBox.Show(DB.get_language("var_err"));
                }
                else
                {
                    if (tDt.Rows.Count > 0)
                    {

                        searchProductId(tDt.Rows[0]["product_id"].ToString());
                    }
                    else {
                        //Limpiar
                        cleanLVCombo();
                    }
                }

            }
            else
            {

            }

        }

        private void txt_products_sym_qty_Leave(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.txt_products_sym_qty_Leave : ");
            if (txt_products_sym_qty.Text.Length > 0)
            {
                int my_qty;
                if (!int.TryParse(txt_products_sym_qty.Text.ToString(), out my_qty))
                {
                    txt_products_sym_qty.Text = "0";
                }
            }
            products_calc_total();
        }
        private void txt_products_sym_qty_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.txt_products_sym_qty_KeyUp : ");
            if (e.KeyCode == Keys.Enter)
            {
                txt_products_sym_price.Focus();
            }
            else
            {
                products_calc_total();
            }
        }
        private void txt_products_sym_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.txt_products_sym_qty_KeyPress : ");
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txt_products_sym_qty.Text.Length > 0)
            {
                int my_qty;
                if (!int.TryParse(txt_products_sym_qty.Text.ToString(), out my_qty))
                {
                    txt_products_sym_qty.Text = "0";
                    e.Handled = true;
                }
                else
                {
                    //CalcLine();
                }
            }
        }

        private void chk_lock_cmb_sub_category_CheckedChanged(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.chk_lock_cmb_sub_category_CheckedChanged : ");
            if (chk_lock_cmb_sub_category.Checked)
            {
                cmb_products_sym_sub_cat.Enabled = false;
            }
            else
            {
                cmb_products_sym_sub_cat.Enabled = true;
            }

        }

        private void txt_products_sym_price_TextChanged(object sender, EventArgs e)
        {

        }

        private void actionList(string newActive)
        {
            if (lv_products_sym_search_results.Items.Count > 0)
            {
                string sql_update_products = "";
                int count_update = 0;
                foreach (ListViewItem Xvi in lv_products_sym_search_results.Items)
                {
                    if (Xvi.Checked)
                    {
                        if (newActive == "1")
                        {
                            sql_update_products = "update products set active=1 where product_id=" + Xvi.SubItems[0].Text.ToString();
                        }
                        else if (newActive == "2")
                        {
                            sql_update_products = "update products set active=0 where product_id=" + Xvi.SubItems[0].Text.ToString();
                        }
                        count_update++;
                        DB.q(sql_update_products, "", "");
                    }

                }
                MessageBox.Show("Se actualizaron " + count_update + " Productos");

                LoadProductSym("2");
            }
        }
        private void cmb_products_action_SelectedIndexChanged(object sender, EventArgs e)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice.cmb_products_action_SelectedIndexChanged : ");
            string cmd_selected = ((cbi)cmb_products_action.SelectedItem).HiddenValue;
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

        //*PRICE*
        private void txt_products_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch((sender as TextBox).Text, @"\.\d\d\d\d\d") && (e.KeyChar != (char)8))
            {
                if ((sender as TextBox).SelectionLength < 1)
                {
                    e.Handled = true;
                }

            }

            //            products_calc_total("1");

        }
        private void txt_products_price_KeyUp(object sender, KeyEventArgs e)
        {
            products_calc_total("1");
        }
        private void txt_products_sym_price_MouseClick(object sender, MouseEventArgs e)
        {
            TxtPriceActivo = "1";
        }

        //*TOTAL*
        private void txt_products_sym_price_total_KeyUp(object sender, KeyEventArgs e)
        {
            products_calc_total("2");
        }

        private void txt_products_sym_price_total_KeyPress(object sender, KeyPressEventArgs e)
        {

            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.txt_products_sym_price_total_KeyPress : ");

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch((sender as TextBox).Text, @"\.\d\d\d\d\d") && (e.KeyChar != (char)8))
            {
                if ((sender as TextBox).SelectionLength < 1)
                {
                    e.Handled = true;
                }

            }
            //products_calc_total("2");

        }
        private void txt_products_sym_price_total_MouseClick(object sender, MouseEventArgs e)
        {
            TxtPriceActivo = "2";
        }

        private void lv_ps_products_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.lv_ps_products_MouseDoubleClick : ");
            searchProductId(lv_ps_products.SelectedItems[0].Text.ToString());
        }
        #region CABYS
        //*CABYS*
        private void txt_search_cabys_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.txt_products_search_CABYS : ");
            if (e.KeyCode == Keys.Enter)
            {
                txt_code_cabys.Text = "";
                SearchCabys("");
            }
        }

        private void SearchCabys(string code_cabys) {
            if (txt_search_cabys.Text.Length > 1 || code_cabys.Length > 1) {
                cmb_cabys.Items.Clear();
                string sql_mysql_search_cabys = "";
                string sql_mysql_search_order = "";
                if (chk_cabys_order_cat.Checked == true) { sql_mysql_search_order = " order by f17 "; } else { sql_mysql_search_order = " order by f18 "; }

                if (code_cabys != "") {
                    if (code_cabys.Length == 13)
                    {
                        sql_mysql_search_cabys = "select f17,f18 from cabys where f17 = '" + DB.s(txt_code_cabys.Text.ToString()) + "' " + sql_mysql_search_order;
                    }
                    else { sql_mysql_search_cabys = "select f17,f18 from cabys where f17 like '" + DB.s(txt_code_cabys.Text.ToString()) + "%' " + sql_mysql_search_order; }
                } else { sql_mysql_search_cabys = "select f17,f18 from cabys where lcase(f18) like lcase('%" + DB.s(txt_search_cabys.Text.ToString().Replace(" ", "%")) + "%') " + sql_mysql_search_order; }

                DataTable tDt = DB.q(sql_mysql_search_cabys, "", "");
                if (tDt.HasErrors)
                {
                    MessageBox.Show(DB.get_language("var_err"));
                }
                else
                {
                    if (tDt.Rows.Count > 0)
                    {
                        if (tDt.Rows.Count != 1) {
                            cmb_cabys.Items.Add(new cbi("--Seleccione una opcion--", ""));
                            cmb_cabys.SelectedIndex = 0;
                        }
                        foreach (DataRow r in tDt.Rows)
                        {
                            cmb_cabys.Items.Add(new cbi(r["f18"].ToString(), r["f17"].ToString()));
                            if (tDt.Rows.Count == 1) { cmb_cabys.SelectedIndex = 0; }
                        }
                    }
                    else {
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
                if (txt_code_cabys.Text.Length != 13) {
                    MessageBox.Show("El codigo CABYS Debe de ser de 13 digitos");
                    SearchCabys(txt_code_cabys.Text.ToString());
                } else {
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

        private void btn_update_cabys_Click(object sender, EventArgs e)
        {
            //Actualizar Seleccionados
            bool errores = false;
            string allErrors = "";

            DB.check_text(ref txt_code_cabys, "Codigo de CABYS", ref errores, ref allErrors, 13, 13); //lbl_code_cabys
            if (errores)
            {
                MessageBox.Show(DB.get_language("var_err") + " > " + allErrors);
            }
            else
            {
                DialogResult result = MessageBox.Show("Desea actualizar el CABYS ( " + txt_code_cabys.Text + ") a los productos seleccionados", "Actualizar CABYS a varios productos", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (lv_products_sym_search_results.Items.Count > 0)
                    {
                        string sql_update_products = "", sql_bitacora = "";
                        int count_update = 0;
                        foreach (ListViewItem Xvi in lv_products_sym_search_results.Items)
                        {
                            if (Xvi.Checked)
                            {
                                sql_bitacora = "insert into products_bita  set" +
                                    " bita='" + Xvi.SubItems[4].Text.ToString() + ">" + txt_code_cabys.Text.ToString() + "'," +
                                    " products_id = " + Xvi.SubItems[0].Text.ToString() + ",bita_date=now(),user_id='" + DB.user_login_id + "'";
                                DB.q(sql_bitacora, "", "", false);

                                sql_update_products = "update products set product_codigo_cabys='" + txt_code_cabys.Text.ToString() + "' where product_id=" + Xvi.SubItems[0].Text.ToString();
                                count_update++;
                                DB.q(sql_update_products, "", "");



                            }
                        }
                        MessageBox.Show("Se actualizaron " + count_update + " Productos");

                        LoadProductSym("2");
                    }
                }
            }
        }
        #endregion
        #region COMBO
        private void CargarComboDetails(string barcode)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.CargarComboDetails : " + barcode.ToString());

            cleanLVCombo();

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
                    foreach (DataRow r in tDt.Rows){

                        txt_products_sym_combo_barcode.Text = r["product_sym_barcode_combo"].ToString();
                        searchBarcodeCombo(r["product_sym_barcode_combo"].ToString());
                        txt_products_sym_combo_qty.Text = r["product_combo_qty"].ToString();
                        agregarLineaDetalleCombo();
                    }
                }
            }
        }

        private void cleanLVCombo() {
            DB.debugLV(lv_products_combo);
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Remover", new EventHandler(RemoveLineCombo));
            lv_products_combo.ContextMenu = cm;

            lv_products_combo.Columns.Clear();
            lv_products_combo.Columns.Add("id", 0); //00                      
            lvId["id"] = lv_products_combo.Columns.Count - 1;

            lv_products_combo.Columns.Add("Barcode", 110); //1
            lvId["lv_desc_barcode"] = lv_products_combo.Columns.Count - 1;

            lv_products_combo.Columns.Add("QTY", 45); //2
            lvId["lv_desc_qty"] = lv_products_combo.Columns.Count - 1;

            lv_products_combo.Columns.Add("Descripcion", 360); //3
            lvId["lv_desc_descripcion"] = lv_products_combo.Columns.Count - 1;

            lv_products_combo.Columns.Add("Precio Unitario", 0); //4
            lvId["lv_desc_precio_unitario"] = lv_products_combo.Columns.Count - 1;

            lv_products_combo.Columns.Add("IVA", 0); //5
            lvId["lv_desc_tax"] = lv_products_combo.Columns.Count - 1;

            lv_products_combo.Columns.Add("Precio Subtotal", 0); //6
            lvId["lv_desc_precio_subtotal"] = lv_products_combo.Columns.Count - 1;

            lv_products_combo.Columns.Add("Precio Total", 85, HorizontalAlignment.Right); //7
            lvId["lv_desc_precio_total"] = lv_products_combo.Columns.Count - 1;

            lv_products_combo.Items.Clear();
        }
        private void cleanTXTCombo() {
            txt_products_sym_combo_barcode.Text = "";
            txt_products_sym_combo_qty.Text = "1";
            txt_products_sym_combo_descripcion.Text = "";

            txt_products_sym_combo_precio_con_descuento.Text = "0.00";
        }

        private void txt_products_sym_combo_barcode_KeyUp(object sender, KeyEventArgs e)
        {
            txt_products_sym_combo_descripcion.Text = "";
            lbl_products_sym_combo_product_id.Text = "";
            txt_products_sym_combo_qty.Text = "1";
            btn_products_sym_desc_agregar.Enabled = false;
            if (e.KeyCode == Keys.Enter)
            {
                searchBarcodeCombo(txt_products_sym_combo_barcode.Text.ToString());
                txt_products_sym_combo_qty.Focus();
            }

        }
        private void txt_products_sym_combo_barcode_Leave(object sender, EventArgs e)
        {
            txt_products_sym_combo_descripcion.Text = "";
            lbl_products_sym_combo_product_id.Text = "";
            txt_products_sym_combo_qty.Text = "1";
            btn_products_sym_desc_agregar.Enabled = false;
            searchBarcodeCombo(txt_products_sym_combo_barcode.Text.ToString());
            txt_products_sym_combo_qty.Focus();
        }

        private void searchBarcodeCombo(string barcode)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.searchBarcodeCombo : ");
            if (barcode.Length > 0)
            {
                string sql_mysql_search_barcode = "select * from products where product_sym_barcode='" + DB.s(barcode.ToString()) + "' and active =1";

                DataTable tDt = DB.q(sql_mysql_search_barcode, "", "");
                if (tDt.HasErrors)
                {
                    MessageBox.Show(DB.get_language("var_err"));
                }
                else
                {
                    if (tDt.Rows.Count > 0)
                    {
                        if (tDt.Rows[0]["product_sym"].ToString() == "?" 
                            || tDt.Rows[0]["product_sym_unit"].ToString() == "?" 
                            || tDt.Rows[0]["product_sym_tax_code"].ToString() == "?" 
                            || tDt.Rows[0]["product_sym_tax_code"].ToString() == "0.00000" 
                            || tDt.Rows[0]["product_codigo_cabys"].ToString() == ""
                            || tDt.Rows[0]["product_adv_impuesto_codigo"].ToString() == "?"                            
                            )
                        {
                            MessageBox.Show("El producto seleccionado esta incomlpeto y no se puede usar en COMBO");
                        }
                        else { 
                            //searchProductId(tDt.Rows[0]["product_id"].ToString());
                            txt_products_sym_combo_descripcion.Text = tDt.Rows[0]["product_sym_description"].ToString();
                            lbl_products_sym_combo_product_id.Text = tDt.Rows[0]["product_id"].ToString();
                        
                            btn_products_sym_desc_agregar.Enabled = true;
                        }
                    }
                }

            }
        }
        private void agregarLineaDetalleCombo(){
            decimal desc_qty = 0;
            bool desc_error = false;
            decimal.TryParse(txt_products_sym_combo_qty.Text.ToString(), out desc_qty);
            if (desc_qty > 0) {

            } else {
                desc_error = true;
                MessageBox.Show("Debe ingresar una cantidad");
            }

            if (txt_products_sym_combo_barcode.Text.ToString().Length<1 || txt_products_sym_combo_descripcion.Text.ToString().Length< 1) { 
                desc_error = true;
                MessageBox.Show("Debe ingresar un codigo de barra para agregar al Combo");
            }
            if (!desc_error) {
                string sql_mysql_search_barcode = "select * from products where product_sym_barcode='" + DB.s(txt_products_sym_combo_barcode.Text.ToString()) + "'";

                DataTable tDt = DB.q(sql_mysql_search_barcode, "", "");
                if (tDt.HasErrors)
                {
                    MessageBox.Show(DB.get_language("var_err"));
                }
                else
                {
                    if (tDt.Rows.Count > 0)
                    {
                        string[] row = { tDt.Rows[0]["product_id"].ToString() }; //0
                                                                        //DB.ASA(ref row, tDt.Rows[0]["product_id"].ToString()); //1
                        DB.ASA(ref row, tDt.Rows[0]["product_sym_barcode"].ToString()); //1
                        DB.ASA(ref row, txt_products_sym_combo_qty.Text.ToString()); //2
                        DB.ASA(ref row, tDt.Rows[0]["product_sym_description"].ToString()); //3

                        DB.ASA(ref row, tDt.Rows[0]["product_price"].ToString()); //4
                        DB.ASA(ref row, tDt.Rows[0]["product_sym_tax"].ToString()); //5

                        decimal decimal_product_price, decimal_product_sym_tax;
                        decimal PrecioSubTotal = 0, PrecioTotal = 0;

                        if (Decimal.TryParse(tDt.Rows[0]["product_price"].ToString(), out decimal_product_price))
                        {
                            if (Decimal.TryParse(tDt.Rows[0]["product_sym_tax"].ToString(), out decimal_product_sym_tax))
                            {
                                PrecioSubTotal = decimal_product_price* (1 + (decimal_product_sym_tax / 100));
                                PrecioTotal = PrecioSubTotal* desc_qty;
                                DB.ASA(ref row, PrecioSubTotal.ToString()); //7
                                DB.ASA(ref row, PrecioTotal.ToString(DB.ND2)); //8
                                //
                                
                            }
                            else
                            {
                                //MessageBox.Show("Error en Precio Sym Tax");
                            }
                        }
                        var lvi = new ListViewItem(row);
                        lv_products_combo.Items.Add(lvi);

                        CalcularCombo();
                        CalcularComboDescuento();
                        cleanTXTCombo();
                    }
                }
            }
        }
        private void btn_products_sym_desc_agregar_Click(object sender, EventArgs e)
        {
            agregarLineaDetalleCombo();
        }


        private void txt_products_sym_combo_precio_con_descuento_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularComboDescuento();
        }
        private void CalcularComboDescuento()
        {

            decimal desc_tax = 0, desc_subtotal_original = 0, desc_total_con_descuento = 0, desc_combo= 0, desc_combo_porcentaje=0;
            decimal.TryParse(txt_products_sym_combo_precio_total_original.Text.ToString(),out desc_subtotal_original);
            decimal.TryParse(txt_products_sym_combo_precio_con_descuento.Text.ToString(), out desc_total_con_descuento);

            CalcularCombo();

            if (desc_subtotal_original >= desc_total_con_descuento ) { 
                desc_combo = desc_subtotal_original- desc_total_con_descuento;
                if (desc_total_con_descuento > 0)
                {
                    desc_combo_porcentaje = (desc_subtotal_original / desc_total_con_descuento);
                }
                else {
                    desc_combo = 0;
                    desc_combo_porcentaje = 0;
                }
                

                txt_products_sym_combo_monto_descuento.Text = desc_combo.ToString(DB.ND2);
                txt_products_sym_combo_porcentaje_descuento.Text = desc_combo_porcentaje.ToString();



                //txt_products_sym_price.Text = desc_total_con_descuento.ToString(DB.ND2);


                txt_products_sym_price.Text = desc_subtotal_original.ToString(DB.ND2);
                txt_products_sym_price_total.Text = desc_total_con_descuento.ToString(DB.ND2);
                
            }
        }
        private void CalcularCombo() {
            txt_products_sym_combo_precio_total_original.Text = "";
            //txt_products_sym_combo_precio_con_descuento.Text = "";
            decimal linea_desc_Qty = 0, linea_desc_SubTotal = 0, linea_desc_tax = 0, linea_desc_Total = 0, linea_desc_precio_unitario = 0;
            decimal desc_tax = 0, desc_subtotal = 0, desc_total = 0, desc_precio_unitario = 0;

            foreach (ListViewItem item in lv_products_combo.Items){
                linea_desc_Qty = decimal.Parse(item.SubItems[lvId["lv_desc_qty"]].Text.ToString());
                
                linea_desc_precio_unitario = decimal.Parse(item.SubItems[lvId["lv_desc_precio_unitario"]].Text.ToString());

                linea_desc_SubTotal = decimal.Parse(item.SubItems[lvId["lv_desc_precio_subtotal"]].Text.ToString());
                linea_desc_tax = decimal.Parse(item.SubItems[lvId["lv_desc_tax"]].Text.ToString());
                
                linea_desc_Total = decimal.Parse(item.SubItems[lvId["lv_desc_precio_total"]].Text.ToString());

                desc_precio_unitario += linea_desc_precio_unitario;
                desc_tax += linea_desc_tax;
                desc_subtotal += linea_desc_SubTotal;
                desc_total += linea_desc_Total;
            }
            txt_products_sym_combo_precio_total_original.Text = desc_total.ToString(DB.ND2);
            //txt_products_sym_combo_precio_con_descuento.Text = desc_total.ToString();

            //txt_products_sym_price.Text = desc_precio_unitario.ToString(DB.ND2);
            //txt_products_sym_price_tax.Text= desc_tax.ToString(DB.ND2);
            txt_products_sym_price_tax.Text = "0";
            //txt_products_sym_price.Text = desc_total.ToString(DB.ND2);
            //txt_products_sym_price_total.Text= desc_total.ToString(DB.ND2);
        }
        public void RemoveLineCombo(object sender, EventArgs e)
        {
            if (lv_products_combo.SelectedIndices.Count > 0)
            {
                foreach (ListViewItem item in lv_products_combo.Items)
                    if (item.Selected)
                        lv_products_combo.Items.Remove(item);
            }
            CalcularCombo();
        }
        private void txt_products_sym_description_KeyUp(object sender, KeyEventArgs e)
        {
            lbl_combo_descripcion.Text = txt_products_sym_description.Text;
        }
        #endregion COMBO

        private void txt_products_sym_combo_descripcion_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run products.txt_products_sym_combo_descripcion_KeyUp : ");
            if (e.KeyCode == Keys.Enter)
            {

                    lv_product_search.Visible = true;
                    lv_product_search.Location = new Point(281, 90);
                    SearchProduct("");
            }
        }
        private void SearchProduct(string supercode) {

            lv_product_search.BringToFront();

            DB.debugLV(lv_product_search);

            lv_product_search.Columns.Clear();
            lv_product_search.Columns.Add("Barcode", 100);
            lv_product_search.Columns.Add("Description", 305);
            lv_product_search.Columns.Add("Precio", 95);
            lv_product_search.Columns.Add("QTY", 35);
            lv_product_search.Items.Clear();

            if (txt_products_sym_combo_descripcion.Text.Length > 0 ) //
            {
                string sql_load_products_mysql = "";

                sql_load_products_mysql = "select* from products where active =1 and ( product_sym_description like '%" + txt_products_sym_combo_descripcion.Text + "%' or product_sym_barcode = '" + txt_products_sym_combo_descripcion.Text + "' or temp_product_8_codigo = '" + txt_products_sym_combo_descripcion.Text + "' or temp_product_9_codigo_proveedor = '" + txt_products_sym_combo_descripcion.Text + "' )";

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

                        if (Decimal.TryParse(r["product_price"].ToString(), out decimal_product_price))
                        {
                            if (Decimal.TryParse(r["product_sym_tax"].ToString(), out decimal_product_sym_tax))
                            {
                                PrecioTotal = decimal_product_price * (1 + (decimal_product_sym_tax / 100));
                            }
                            else
                            {
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

        private void lv_product_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_product_search.SelectedItems.Count > 0)
            {
                try
                {
                    txt_products_sym_combo_barcode.Text = lv_product_search.SelectedItems[0].Text.ToString();

                    lv_product_search.Visible = false;

                    txt_products_sym_combo_descripcion.Text = "";
                    lbl_products_sym_combo_product_id.Text = "";
                    txt_products_sym_combo_qty.Text = "1";
                    btn_products_sym_desc_agregar.Enabled = false;
                        searchBarcodeCombo(txt_products_sym_combo_barcode.Text.ToString());
                        txt_products_sym_combo_qty.Focus();
                }
                catch
                {
                }

            }
        }
    }
}
