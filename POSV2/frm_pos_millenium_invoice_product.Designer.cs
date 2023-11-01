namespace POSV2
{
    partial class frm_pos_millenium_invoice_product
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_edit_sym_product_id = new System.Windows.Forms.Label();
            this.txt_products_sym_barcode = new System.Windows.Forms.TextBox();
            this.lbl_products_barcode = new System.Windows.Forms.Label();
            this.lbl_products_description = new System.Windows.Forms.Label();
            this.txt_products_sym_description = new System.Windows.Forms.TextBox();
            this.txt_products_sym_price = new System.Windows.Forms.TextBox();
            this.lbl_products_price_total = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_edit_sym_product_id
            // 
            this.lbl_edit_sym_product_id.AutoSize = true;
            this.lbl_edit_sym_product_id.Location = new System.Drawing.Point(215, 33);
            this.lbl_edit_sym_product_id.Name = "lbl_edit_sym_product_id";
            this.lbl_edit_sym_product_id.Size = new System.Drawing.Size(13, 13);
            this.lbl_edit_sym_product_id.TabIndex = 151;
            this.lbl_edit_sym_product_id.Text = "0";
            // 
            // txt_products_sym_barcode
            // 
            this.txt_products_sym_barcode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_products_sym_barcode.Location = new System.Drawing.Point(12, 24);
            this.txt_products_sym_barcode.Name = "txt_products_sym_barcode";
            this.txt_products_sym_barcode.ReadOnly = true;
            this.txt_products_sym_barcode.Size = new System.Drawing.Size(197, 22);
            this.txt_products_sym_barcode.TabIndex = 147;
            this.txt_products_sym_barcode.Text = "1234567890123456";
            // 
            // lbl_products_barcode
            // 
            this.lbl_products_barcode.Location = new System.Drawing.Point(12, 9);
            this.lbl_products_barcode.Name = "lbl_products_barcode";
            this.lbl_products_barcode.Size = new System.Drawing.Size(197, 12);
            this.lbl_products_barcode.TabIndex = 149;
            this.lbl_products_barcode.Text = "Barcode";
            // 
            // lbl_products_description
            // 
            this.lbl_products_description.Location = new System.Drawing.Point(9, 46);
            this.lbl_products_description.Name = "lbl_products_description";
            this.lbl_products_description.Size = new System.Drawing.Size(400, 15);
            this.lbl_products_description.TabIndex = 150;
            this.lbl_products_description.Text = "Description";
            // 
            // txt_products_sym_description
            // 
            this.txt_products_sym_description.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_products_sym_description.Location = new System.Drawing.Point(12, 64);
            this.txt_products_sym_description.Name = "txt_products_sym_description";
            this.txt_products_sym_description.Size = new System.Drawing.Size(393, 22);
            this.txt_products_sym_description.TabIndex = 148;
            // 
            // txt_products_sym_price
            // 
            this.txt_products_sym_price.BackColor = System.Drawing.Color.White;
            this.txt_products_sym_price.Enabled = false;
            this.txt_products_sym_price.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_products_sym_price.ForeColor = System.Drawing.Color.Black;
            this.txt_products_sym_price.Location = new System.Drawing.Point(12, 161);
            this.txt_products_sym_price.Name = "txt_products_sym_price";
            this.txt_products_sym_price.ShortcutsEnabled = false;
            this.txt_products_sym_price.Size = new System.Drawing.Size(393, 35);
            this.txt_products_sym_price.TabIndex = 153;
            this.txt_products_sym_price.Text = "999,999,999.12345";
            this.txt_products_sym_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_products_price_total
            // 
            this.lbl_products_price_total.Location = new System.Drawing.Point(12, 142);
            this.lbl_products_price_total.Name = "lbl_products_price_total";
            this.lbl_products_price_total.Size = new System.Drawing.Size(197, 16);
            this.lbl_products_price_total.TabIndex = 152;
            this.lbl_products_price_total.Text = "Price ";
            // 
            // frm_pos_millenium_invoice_product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 300);
            this.ControlBox = false;
            this.Controls.Add(this.txt_products_sym_price);
            this.Controls.Add(this.lbl_products_price_total);
            this.Controls.Add(this.lbl_edit_sym_product_id);
            this.Controls.Add(this.txt_products_sym_barcode);
            this.Controls.Add(this.lbl_products_barcode);
            this.Controls.Add(this.lbl_products_description);
            this.Controls.Add(this.txt_products_sym_description);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_pos_millenium_invoice_product";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_pos_millenium_invoice_product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_edit_sym_product_id;
        private System.Windows.Forms.TextBox txt_products_sym_barcode;
        private System.Windows.Forms.Label lbl_products_barcode;
        private System.Windows.Forms.Label lbl_products_description;
        private System.Windows.Forms.TextBox txt_products_sym_description;
        private System.Windows.Forms.TextBox txt_products_sym_price;
        private System.Windows.Forms.Label lbl_products_price_total;
    }
}