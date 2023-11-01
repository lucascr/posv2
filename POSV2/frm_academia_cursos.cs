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
    public partial class frm_academia_cursos : Form
    {
        public frm_academia_cursos()
        {
            InitializeComponent();
            CargarCursos();
            limpiarTxt();
        }
        private void limpiarTxt() {
            txt_products_sym_qty.Text = "";
            txt_products_sym_price.Text = "";
            txt_products_sym_price_total_curso.Text = "";
            txt_products_sym_price_cost.Text = "";
            txt_products_sym_barcode.Text = "";
            txt_products_sym_description.Text = "";
            lbl_edit_sym_product_id.Text = "";

            invoice_pos__r_dt1.Value.ToShortDateString();
            invoice_pos__r_dt2.Value.ToShortDateString();
        }
        private void CargarCursos() {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run Academia.CargarCursos : ");
            DB.debugLV(lv_products_sym_search_results);

            lv_products_sym_search_results.Items.Clear();
            lv_products_sym_search_results.Columns.Clear();
            lv_products_sym_search_results.Columns.Add("Id", 24);
            lv_products_sym_search_results.Columns.Add("Codigo", 150);
            lv_products_sym_search_results.Columns.Add("Descripcion", 240);
            lv_products_sym_search_results.Columns.Add("Qty", 0);
            lv_products_sym_search_results.Columns.Add("Price.", 0);

            lv_products_sym_search_results.Columns.Add("Profesor", 93);

            lv_products_sym_search_results.Columns.Add("Cantidad", 77);
            lv_products_sym_search_results.Columns.Add("Leccion.", 74);
            lv_products_sym_search_results.Columns.Add("Total", 83);

            lv_products_sym_search_results.Columns.Add("Inicio", 90);
            lv_products_sym_search_results.Columns.Add("Fin", 90);
            lv_products_sym_search_results.Columns.Add("Fin", 90);
            lv_products_sym_search_results.Columns.Add("Fin", 90);
            lv_products_sym_search_results.Columns.Add("Fin", 90);

            string sql_load_products_academia_mysql = @"select product_id, product_sym_barcode, product_sym_description, FORMAT(product_price, 5) as product_price,
            product_sym_tax,ROUND(if (product_sym_tax_code = '00',0,(product_price * (product_sym_tax / 100))),5) as product_price_tax,
            FORMAT(ROUND(if (product_sym_tax_code = '00',product_price,(product_price * (1 + (product_sym_tax / 100)))),5),5) as product_price_tax_total,product_sym_stock,academia_cursos.*,
            if(isnull(academia_cursos_lecciones_total),'', FORMAT(ROUND(academia_cursos_lecciones_total*academia_cursos_leccion_precio,5),0) ) as precio_final_total_lecciones,
            FORMAT(ROUND(academia_cursos_leccion_precio,5),0) as format_academia_cursos_leccion_precio,
            date_format(academia_cursos_fecha_inicio,'%Y-%m-%d') as fecha_inicio,date_format(academia_cursos_fecha_fin,'%Y-%m-%d') as fecha_fin
            from products left join academia_cursos using (product_id) where products.active = 1 ";

            string activodesactivo = "";

            DataTable tDt = DB.q(sql_load_products_academia_mysql  , "", "");
            foreach (DataRow r in tDt.Rows)
            {
                if (r["academia_cursos_id"].ToString() == "") {
                    activodesactivo = "* Pendiente *";
                } else {
                    activodesactivo = "";
                } 

                string[] row = { r["product_id"].ToString(),
                    r["product_sym_barcode"].ToString(),
                    r["product_sym_description"].ToString(), //2
                    r["product_sym_stock"].ToString(), //3
                    r["product_price_tax_total"].ToString(), //4

                    r["academia_cursos_leccion_costo"].ToString() + activodesactivo, //5

                    r["academia_cursos_lecciones_total"].ToString(),    //6
                    r["format_academia_cursos_leccion_precio"].ToString(), //7
                    
                    r["precio_final_total_lecciones"].ToString(), //7 8                  

                           
                    
                    r["fecha_inicio"].ToString(),
                    r["fecha_fin"].ToString()
                    };
                //string formatForMySql = dateValue.ToString("yyyy-MM-dd HH:mm");

                var lvi = new ListViewItem(row);
                lv_products_sym_search_results.Items.Add(lvi);
            }
        }

        private void lv_products_sym_search_results_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //searchProductId(lv_products_sym_search_results.SelectedItems[0].Text.ToString());
            btn_academia_cursos_save.Enabled = true;
            limpiarTxt();

            lbl_edit_sym_product_id.Text = lv_products_sym_search_results.SelectedItems[0].Text.ToString();
            txt_products_sym_barcode.Text = lv_products_sym_search_results.SelectedItems[0].SubItems[1].Text.ToString();
            txt_products_sym_description.Text = lv_products_sym_search_results.SelectedItems[0].SubItems[2].Text.ToString();

            if (lv_products_sym_search_results.SelectedItems[0].SubItems[6].Text.ToString() == "")
            {
                txt_products_sym_price_cost.Text = "";

                txt_products_sym_qty.Text = lv_products_sym_search_results.SelectedItems[0].SubItems[3].Text.ToString();
                decimal valueDec;
                if (!decimal.TryParse(lv_products_sym_search_results.SelectedItems[0].SubItems[4].Text.ToString(), out valueDec))
                {
                    valueDec = 0;
                }

                txt_products_sym_price.Text = valueDec.ToString(DB.ND2);
                curso_calc_total();
            }            else { 
                txt_products_sym_price_cost.Text = lv_products_sym_search_results.SelectedItems[0].SubItems[5].Text.ToString();

                txt_products_sym_qty.Text = lv_products_sym_search_results.SelectedItems[0].SubItems[6].Text.ToString();

                txt_products_sym_price.Text = lv_products_sym_search_results.SelectedItems[0].SubItems[7].Text.ToString();
                txt_products_sym_price_total_curso.Text = lv_products_sym_search_results.SelectedItems[0].SubItems[8].Text.ToString();
            }
            

            invoice_pos__r_dt1.Text  = lv_products_sym_search_results.SelectedItems[0].SubItems[9].Text.ToString();
            invoice_pos__r_dt2.Text = lv_products_sym_search_results.SelectedItems[0].SubItems[10].Text.ToString();



        }


        private void btn_academia_cursos_save_Click(object sender, EventArgs e)
        {

            try
            {
                //CargarCursos();
                string cod_product = lbl_edit_sym_product_id.Text.ToString();
                

                string sql_update = "academia_cursos_lecciones_total='" + decimal.Parse(txt_products_sym_qty.Text.ToString()).ToString() + "', " +
                    " academia_cursos_leccion_precio='" + decimal.Parse(txt_products_sym_price.Text.ToString()).ToString() + "'," +
                    " academia_cursos_leccion_costo='" + txt_products_sym_price_cost.Text.ToString() + "'," +
                    " academia_cursos_fecha_inicio='" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + "'," +
                    " academia_cursos_fecha_fin='" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + "'";


                string sql_update_cursos = "insert into academia_cursos " +
                    "set product_id=" + cod_product + "," + sql_update + " on duplicate key update " + sql_update;
                Console.WriteLine(sql_update_cursos);

                
                try
                {
                    DB.q(sql_update_cursos, "", "");
                }
                catch
                {
                    MessageBox.Show(DB.get_language("var_err") + " 9x1001 SaveCurso");
                }

                MessageBox.Show("Se actualizó correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error");
            }
            CargarCursos();
            limpiarTxt();

        }
        private void curso_calc_total(){
            txt_products_sym_price_total_curso.Text = "0";
            try
            {
                decimal v_sym_curso_price = decimal.Parse(txt_products_sym_qty.Text.ToString()) * decimal.Parse(txt_products_sym_price.Text.ToString());
                txt_products_sym_price_total_curso.Text = v_sym_curso_price.ToString(DB.ND2);
            }
            catch (Exception e)
            {

            }
            

        }
        private void txt_products_sym_price_KeyUp(object sender, KeyEventArgs e)
        {
            curso_calc_total();
        }

        private void txt_products_sym_qty_KeyUp(object sender, KeyEventArgs e)
        {
            curso_calc_total();
        }
    }
}
