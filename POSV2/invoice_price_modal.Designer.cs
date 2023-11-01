namespace POSV2
{
    partial class invoice_price_modal
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_update_product = new System.Windows.Forms.Button();
            this.txt_products_sym_price = new System.Windows.Forms.TextBox();
            this.lbl_products_price_total = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.mnuS1 = new System.Windows.Forms.MenuStrip();
            this.btn_update_product_base = new System.Windows.Forms.Button();
            this.txt_products_sym_description = new System.Windows.Forms.TextBox();
            this.lbl_products_description = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(336, 182);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(137, 40);
            this.btn_cancel.TabIndex = 145;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_update_product
            // 
            this.btn_update_product.Enabled = false;
            this.btn_update_product.Location = new System.Drawing.Point(12, 182);
            this.btn_update_product.Name = "btn_update_product";
            this.btn_update_product.Size = new System.Drawing.Size(141, 56);
            this.btn_update_product.TabIndex = 144;
            this.btn_update_product.Text = "Precio NETO";
            this.btn_update_product.UseVisualStyleBackColor = true;
            this.btn_update_product.Click += new System.EventHandler(this.btn_update_product_Click);
            // 
            // txt_products_sym_price
            // 
            this.txt_products_sym_price.BackColor = System.Drawing.Color.White;
            this.txt_products_sym_price.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_products_sym_price.ForeColor = System.Drawing.Color.Black;
            this.txt_products_sym_price.Location = new System.Drawing.Point(9, 141);
            this.txt_products_sym_price.Name = "txt_products_sym_price";
            this.txt_products_sym_price.ShortcutsEnabled = false;
            this.txt_products_sym_price.Size = new System.Drawing.Size(464, 35);
            this.txt_products_sym_price.TabIndex = 143;
            this.txt_products_sym_price.Text = "0";
            this.txt_products_sym_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_products_sym_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_products_sym_price_KeyPress);
            this.txt_products_sym_price.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_products_sym_price_KeyUp);
            // 
            // lbl_products_price_total
            // 
            this.lbl_products_price_total.Location = new System.Drawing.Point(9, 122);
            this.lbl_products_price_total.Name = "lbl_products_price_total";
            this.lbl_products_price_total.Size = new System.Drawing.Size(197, 16);
            this.lbl_products_price_total.TabIndex = 142;
            this.lbl_products_price_total.Text = "Price ";
            // 
            // lbl_description
            // 
            this.lbl_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_description.Location = new System.Drawing.Point(6, 27);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(470, 37);
            this.lbl_description.TabIndex = 146;
            this.lbl_description.Text = "Abarrotes";
            this.lbl_description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mnuS1
            // 
            this.mnuS1.Location = new System.Drawing.Point(0, 0);
            this.mnuS1.Name = "mnuS1";
            this.mnuS1.Size = new System.Drawing.Size(488, 24);
            this.mnuS1.TabIndex = 147;
            this.mnuS1.Text = "menuStrip1";
            // 
            // btn_update_product_base
            // 
            this.btn_update_product_base.Enabled = false;
            this.btn_update_product_base.Location = new System.Drawing.Point(174, 182);
            this.btn_update_product_base.Name = "btn_update_product_base";
            this.btn_update_product_base.Size = new System.Drawing.Size(141, 56);
            this.btn_update_product_base.TabIndex = 148;
            this.btn_update_product_base.Text = "Precio BASE";
            this.btn_update_product_base.UseVisualStyleBackColor = true;
            this.btn_update_product_base.Click += new System.EventHandler(this.btn_update_product_base_Click);
            // 
            // txt_products_sym_description
            // 
            this.txt_products_sym_description.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.txt_products_sym_description.Location = new System.Drawing.Point(9, 84);
            this.txt_products_sym_description.Name = "txt_products_sym_description";
            this.txt_products_sym_description.Size = new System.Drawing.Size(464, 35);
            this.txt_products_sym_description.TabIndex = 149;
            // 
            // lbl_products_description
            // 
            this.lbl_products_description.Location = new System.Drawing.Point(12, 64);
            this.lbl_products_description.Name = "lbl_products_description";
            this.lbl_products_description.Size = new System.Drawing.Size(171, 16);
            this.lbl_products_description.TabIndex = 150;
            this.lbl_products_description.Text = "lbl_products_description";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(209, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 16);
            this.label1.TabIndex = 151;
            this.label1.Text = "Adicional";
            // 
            // invoice_price_modal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 244);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_products_description);
            this.Controls.Add(this.txt_products_sym_description);
            this.Controls.Add(this.btn_update_product_base);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_update_product);
            this.Controls.Add(this.txt_products_sym_price);
            this.Controls.Add(this.lbl_products_price_total);
            this.Controls.Add(this.mnuS1);
            this.MainMenuStrip = this.mnuS1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "invoice_price_modal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "invoice_payment_modal";
            this.Load += new System.EventHandler(this.invoice_payment_modal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_update_product;
        private System.Windows.Forms.TextBox txt_products_sym_price;
        private System.Windows.Forms.Label lbl_products_price_total;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.MenuStrip mnuS1;
        private System.Windows.Forms.Button btn_update_product_base;
        private System.Windows.Forms.TextBox txt_products_sym_description;
        private System.Windows.Forms.Label lbl_products_description;
        private System.Windows.Forms.Label label1;
    }
}