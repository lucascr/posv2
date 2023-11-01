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
    public partial class invoice_product_CanastaBasica : Form
    {
        public bool saved = false;
        public bool exento = true;
        public string descripcion = "";
        public string id_producto = "";

        public invoice_product_CanastaBasica()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_canastabasica. : ");
            InitializeComponent();
            DB.specialRun = "callback_invoice_canastabasica";
        }

        private void invoice_product_CanastaBasica_Load(object sender, EventArgs e)
        {
            lbl_description.Text = descripcion;
            lbl_edit_sym_product_id.Text = id_producto;

        }
        
        private void btn_update_product_exento_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_price_modal.btn_update_product_exento_Click : ");
            string sql_save_products_mysql = "";
            string sql_w = "";
            sql_save_products_mysql = "update products set product_ud=now() ";
            sql_w = " where product_id='" + lbl_edit_sym_product_id.Text.ToString() + "'";

            sql_save_products_mysql += " ,product_sym = 'UnidEx'";
            sql_save_products_mysql += " ,product_sym_tax_code = '00'";
            sql_save_products_mysql += " ,product_sym_tax_code_iva = '01'";
            sql_save_products_mysql += " ,product_sym_tax = '0'";
            sql_save_products_mysql += " ,product_adv_impuesto_codigo = ''";            

            DB.e(sql_save_products_mysql + sql_w, "", "");
            if (DB.conectado)
            {
                MessageBox.Show(DB.get_language("var_ok"));
                DB.specialRun = "callback_invoice";
                saved = true;
                exento = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(DB.get_language("var_err"));
            }
        }

        private void btn_update_product_canastabasica_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_price_modal.btn_update_product_canastabasica_Click : ");
            string sql_save_products_mysql = "";
            string sql_w = "";
            sql_save_products_mysql = "update products set product_ud=now() ";
            sql_w = " where product_id='" + lbl_edit_sym_product_id.Text.ToString() + "'";

            sql_save_products_mysql += " ,product_sym = 'UnidCB'";
            sql_save_products_mysql += " ,product_sym_tax_code = '01'";
            sql_save_products_mysql += " ,product_sym_tax_code_iva = '02'";
            sql_save_products_mysql += " ,product_sym_tax = '1'";
            sql_save_products_mysql += " ,product_adv_impuesto_codigo = ''";
            DB.e(sql_save_products_mysql + sql_w, "", "");
            if (DB.conectado)
            {
                MessageBox.Show(DB.get_language("var_ok"));
                DB.specialRun = "callback_invoice";
                saved = true;
                exento = false;
                this.Close();
            }
            else
            {
                MessageBox.Show(DB.get_language("var_err"));
            }
        }
    }
}
