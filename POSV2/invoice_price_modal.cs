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
    public partial class invoice_price_modal : Form
    {
        public bool saved = false;
        public string price = "";
        public string descripcion= "";
        public decimal tax =0;        
        public bool tax_bruto_base;
        public invoice_price_modal()
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_price_modal. : ");
            InitializeComponent();
            DB.specialRun = "callback_invoice_price_modal"; 
            DB.CreateloadLanguage(mnuS1, this);
        }
        private void invoice_payment_modal_Load(object sender, EventArgs e)
        {
            lbl_description.Text = descripcion;
        }
        private void btn_cancel_Click(object sender, EventArgs e){
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_price_modal.btn_cancel_Click : ");
            DB.specialRun = "callback_invoice";
            this.Close();
        }



        private void btn_update_product_base_Click(object sender, EventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_price_modal.btn_update_product_base_Click : ");
            if (txt_products_sym_price.Text.Length > 0)
            {
                DB.specialRun = "callback_invoice";
                saved = true;
                price = txt_products_sym_price.Text;
                descripcion = lbl_description.Text + " " + txt_products_sym_description.Text;
                tax_bruto_base = false;
                this.Close();
            }
        }
        private void btn_update_product_Click(object sender, EventArgs e){
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_price_modal.btn_update_product_Click : ");
            if (txt_products_sym_price.Text.Length > 0) {            
                DB.specialRun = "callback_invoice";
                saved = true;
                price = txt_products_sym_price.Text ;
                descripcion = lbl_description.Text + " " + txt_products_sym_description.Text;
                tax_bruto_base = true;
                this.Close();
            }
        }
        private void txt_products_sym_price_KeyPress(object sender, KeyPressEventArgs e){
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_price_modal.txt_products_sym_price_KeyPress : ");
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.'){
                e.Handled = true;
            }
            if (txt_products_sym_price.Text.Length > 0){
                decimal my_qty;
                if (!decimal.TryParse(txt_products_sym_price.Text.ToString(), out my_qty))
                {
                    txt_products_sym_price.Text = "0";
                    e.Handled = true;
                }
                else
                {
                    btn_update_product.Enabled = true;
                    btn_update_product_base.Enabled = true;
                    //CalcLine();
                }
            }
        }

        private void txt_products_sym_price_KeyUp(object sender, KeyEventArgs e)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run invoice_price_modal.txt_products_sym_price_KeyUp : ");
            if (e.KeyCode == Keys.Enter)
            {
                btn_update_product_Click(sender,e);
            }
            else
            {
                if (txt_products_sym_price.Text.Length > 0)
                {
                    decimal my_qty;
                    if (!decimal.TryParse(txt_products_sym_price.Text.ToString(), out my_qty))
                    {
                        txt_products_sym_price.Text = "0";
                    }
                    else
                    {


                        
                        
                        btn_update_product.Text = "Precio NETO \n\r" + decimal.Round(my_qty / (decimal)((tax/100)+1), 5).ToString(); 
                        btn_update_product_base.Text = "Precio BASE \n\r" + decimal.Round(my_qty * (decimal)((tax / 100) + 1), 5).ToString();
                    }
                }

            }
        }

    }
}
