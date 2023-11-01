namespace POSV2
{
    partial class invoice_product_modal
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
            this.txt_products_sym_barcode = new System.Windows.Forms.TextBox();
            this.txt_products_sym_description = new System.Windows.Forms.TextBox();
            this.lbl_products_barcode = new System.Windows.Forms.Label();
            this.lbl_products_description = new System.Windows.Forms.Label();
            this.lbl_products_price_total = new System.Windows.Forms.Label();
            this.txt_products_sym_price = new System.Windows.Forms.TextBox();
            this.btn_update_product = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.mnuS1 = new System.Windows.Forms.MenuStrip();
            this.lbl_edit_sym_product_id = new System.Windows.Forms.Label();
            this.txt_products_sym_price_before_tax = new System.Windows.Forms.TextBox();
            this.lbl_products_price = new System.Windows.Forms.Label();
            this.cmb_products_sym_type = new System.Windows.Forms.ComboBox();
            this.lbl_products_sym = new System.Windows.Forms.Label();
            this.lbl_products_tax_code = new System.Windows.Forms.Label();
            this.lbl_products_tax_iva = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_products_price_tax = new System.Windows.Forms.Label();
            this.lbl_products_tax = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_cabys_order_cat = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_code_cabys = new System.Windows.Forms.TextBox();
            this.cmb_cabys = new System.Windows.Forms.ComboBox();
            this.txt_search_cabys = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_products_sym_barcode
            // 
            this.txt_products_sym_barcode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_products_sym_barcode.Location = new System.Drawing.Point(12, 45);
            this.txt_products_sym_barcode.Name = "txt_products_sym_barcode";
            this.txt_products_sym_barcode.ReadOnly = true;
            this.txt_products_sym_barcode.Size = new System.Drawing.Size(197, 22);
            this.txt_products_sym_barcode.TabIndex = 103;
            this.txt_products_sym_barcode.Text = "1234567890123456";
            // 
            // txt_products_sym_description
            // 
            this.txt_products_sym_description.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_products_sym_description.Location = new System.Drawing.Point(12, 85);
            this.txt_products_sym_description.Name = "txt_products_sym_description";
            this.txt_products_sym_description.Size = new System.Drawing.Size(393, 22);
            this.txt_products_sym_description.TabIndex = 105;
            // 
            // lbl_products_barcode
            // 
            this.lbl_products_barcode.Location = new System.Drawing.Point(12, 30);
            this.lbl_products_barcode.Name = "lbl_products_barcode";
            this.lbl_products_barcode.Size = new System.Drawing.Size(197, 12);
            this.lbl_products_barcode.TabIndex = 107;
            this.lbl_products_barcode.Text = "Barcode";
            // 
            // lbl_products_description
            // 
            this.lbl_products_description.Location = new System.Drawing.Point(9, 67);
            this.lbl_products_description.Name = "lbl_products_description";
            this.lbl_products_description.Size = new System.Drawing.Size(400, 15);
            this.lbl_products_description.TabIndex = 108;
            this.lbl_products_description.Text = "Description";
            // 
            // lbl_products_price_total
            // 
            this.lbl_products_price_total.Location = new System.Drawing.Point(600, 234);
            this.lbl_products_price_total.Name = "lbl_products_price_total";
            this.lbl_products_price_total.Size = new System.Drawing.Size(197, 16);
            this.lbl_products_price_total.TabIndex = 109;
            this.lbl_products_price_total.Text = "Price ";
            // 
            // txt_products_sym_price
            // 
            this.txt_products_sym_price.BackColor = System.Drawing.Color.White;
            this.txt_products_sym_price.Enabled = false;
            this.txt_products_sym_price.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_products_sym_price.ForeColor = System.Drawing.Color.Black;
            this.txt_products_sym_price.Location = new System.Drawing.Point(600, 253);
            this.txt_products_sym_price.Name = "txt_products_sym_price";
            this.txt_products_sym_price.ShortcutsEnabled = false;
            this.txt_products_sym_price.Size = new System.Drawing.Size(393, 35);
            this.txt_products_sym_price.TabIndex = 136;
            this.txt_products_sym_price.Text = "999,999,999.12345";
            this.txt_products_sym_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_products_sym_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_products_sym_price_KeyPress);
            this.txt_products_sym_price.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_products_sym_price_KeyUp);
            // 
            // btn_update_product
            // 
            this.btn_update_product.Enabled = false;
            this.btn_update_product.Location = new System.Drawing.Point(600, 354);
            this.btn_update_product.Name = "btn_update_product";
            this.btn_update_product.Size = new System.Drawing.Size(191, 40);
            this.btn_update_product.TabIndex = 140;
            this.btn_update_product.Text = "Aceptar";
            this.btn_update_product.UseVisualStyleBackColor = true;
            this.btn_update_product.Click += new System.EventHandler(this.btn_update_product_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(802, 354);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(191, 40);
            this.btn_cancel.TabIndex = 141;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // mnuS1
            // 
            this.mnuS1.Location = new System.Drawing.Point(0, 0);
            this.mnuS1.Name = "mnuS1";
            this.mnuS1.Size = new System.Drawing.Size(1006, 24);
            this.mnuS1.TabIndex = 144;
            this.mnuS1.Text = "menuStrip1";
            // 
            // lbl_edit_sym_product_id
            // 
            this.lbl_edit_sym_product_id.AutoSize = true;
            this.lbl_edit_sym_product_id.Location = new System.Drawing.Point(215, 54);
            this.lbl_edit_sym_product_id.Name = "lbl_edit_sym_product_id";
            this.lbl_edit_sym_product_id.Size = new System.Drawing.Size(13, 13);
            this.lbl_edit_sym_product_id.TabIndex = 146;
            this.lbl_edit_sym_product_id.Text = "0";
            // 
            // txt_products_sym_price_before_tax
            // 
            this.txt_products_sym_price_before_tax.BackColor = System.Drawing.SystemColors.Control;
            this.txt_products_sym_price_before_tax.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_products_sym_price_before_tax.ForeColor = System.Drawing.Color.Black;
            this.txt_products_sym_price_before_tax.Location = new System.Drawing.Point(603, 313);
            this.txt_products_sym_price_before_tax.Name = "txt_products_sym_price_before_tax";
            this.txt_products_sym_price_before_tax.ReadOnly = true;
            this.txt_products_sym_price_before_tax.ShortcutsEnabled = false;
            this.txt_products_sym_price_before_tax.Size = new System.Drawing.Size(390, 35);
            this.txt_products_sym_price_before_tax.TabIndex = 147;
            this.txt_products_sym_price_before_tax.Text = "999,999,999.12345";
            this.txt_products_sym_price_before_tax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_products_price
            // 
            this.lbl_products_price.Location = new System.Drawing.Point(600, 294);
            this.lbl_products_price.Name = "lbl_products_price";
            this.lbl_products_price.Size = new System.Drawing.Size(197, 16);
            this.lbl_products_price.TabIndex = 148;
            this.lbl_products_price.Text = "Price ";
            // 
            // cmb_products_sym_type
            // 
            this.cmb_products_sym_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_products_sym_type.DropDownWidth = 200;
            this.cmb_products_sym_type.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_products_sym_type.FormattingEnabled = true;
            this.cmb_products_sym_type.Items.AddRange(new object[] {
            "012345678901234567890"});
            this.cmb_products_sym_type.Location = new System.Drawing.Point(415, 85);
            this.cmb_products_sym_type.Name = "cmb_products_sym_type";
            this.cmb_products_sym_type.Size = new System.Drawing.Size(197, 21);
            this.cmb_products_sym_type.TabIndex = 149;
            this.cmb_products_sym_type.SelectedIndexChanged += new System.EventHandler(this.cmb_products_sym_type_SelectedIndexChanged);
            // 
            // lbl_products_sym
            // 
            this.lbl_products_sym.Location = new System.Drawing.Point(415, 70);
            this.lbl_products_sym.Name = "lbl_products_sym";
            this.lbl_products_sym.Size = new System.Drawing.Size(158, 12);
            this.lbl_products_sym.TabIndex = 150;
            this.lbl_products_sym.Text = "Product Type SYM";
            // 
            // lbl_products_tax_code
            // 
            this.lbl_products_tax_code.Location = new System.Drawing.Point(616, 97);
            this.lbl_products_tax_code.Name = "lbl_products_tax_code";
            this.lbl_products_tax_code.Size = new System.Drawing.Size(53, 12);
            this.lbl_products_tax_code.TabIndex = 154;
            this.lbl_products_tax_code.Text = ".";
            // 
            // lbl_products_tax_iva
            // 
            this.lbl_products_tax_iva.Location = new System.Drawing.Point(675, 97);
            this.lbl_products_tax_iva.Name = "lbl_products_tax_iva";
            this.lbl_products_tax_iva.Size = new System.Drawing.Size(63, 12);
            this.lbl_products_tax_iva.TabIndex = 153;
            this.lbl_products_tax_iva.Text = ".";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(616, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 152;
            this.label3.Text = "TaxCode";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(675, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 12);
            this.label5.TabIndex = 151;
            this.label5.Text = "TaxIVA";
            // 
            // lbl_products_price_tax
            // 
            this.lbl_products_price_tax.Location = new System.Drawing.Point(744, 85);
            this.lbl_products_price_tax.Name = "lbl_products_price_tax";
            this.lbl_products_price_tax.Size = new System.Drawing.Size(53, 12);
            this.lbl_products_price_tax.TabIndex = 155;
            this.lbl_products_price_tax.Text = "Tax";
            // 
            // lbl_products_tax
            // 
            this.lbl_products_tax.Location = new System.Drawing.Point(744, 97);
            this.lbl_products_tax.Name = "lbl_products_tax";
            this.lbl_products_tax.Size = new System.Drawing.Size(63, 12);
            this.lbl_products_tax.TabIndex = 156;
            this.lbl_products_tax.Text = ".";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk_cabys_order_cat);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txt_code_cabys);
            this.groupBox2.Controls.Add(this.cmb_cabys);
            this.groupBox2.Controls.Add(this.txt_search_cabys);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(992, 83);
            this.groupBox2.TabIndex = 157;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cabys";
            // 
            // chk_cabys_order_cat
            // 
            this.chk_cabys_order_cat.AutoSize = true;
            this.chk_cabys_order_cat.Location = new System.Drawing.Point(418, 15);
            this.chk_cabys_order_cat.Name = "chk_cabys_order_cat";
            this.chk_cabys_order_cat.Size = new System.Drawing.Size(207, 24);
            this.chk_cabys_order_cat.TabIndex = 117;
            this.chk_cabys_order_cat.Text = "Ordenar por Categoria";
            this.chk_cabys_order_cat.UseVisualStyleBackColor = true;
            this.chk_cabys_order_cat.CheckedChanged += new System.EventHandler(this.chk_cabys_order_cat_CheckedChanged);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(776, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 24);
            this.label14.TabIndex = 116;
            this.label14.Text = "CODIGO CABYS";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(6, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(173, 24);
            this.label13.TabIndex = 115;
            this.label13.Text = "Texto para buscar CABYS";
            // 
            // txt_code_cabys
            // 
            this.txt_code_cabys.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_code_cabys.Location = new System.Drawing.Point(882, 17);
            this.txt_code_cabys.Name = "txt_code_cabys";
            this.txt_code_cabys.Size = new System.Drawing.Size(100, 22);
            this.txt_code_cabys.TabIndex = 114;
            this.txt_code_cabys.Text = "000000000000";
            this.txt_code_cabys.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_code_cabys_KeyUp);
            // 
            // cmb_cabys
            // 
            this.cmb_cabys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_cabys.DropDownWidth = 200;
            this.cmb_cabys.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_cabys.FormattingEnabled = true;
            this.cmb_cabys.Items.AddRange(new object[] {
            "012345678901234567890"});
            this.cmb_cabys.Location = new System.Drawing.Point(6, 46);
            this.cmb_cabys.Name = "cmb_cabys";
            this.cmb_cabys.Size = new System.Drawing.Size(975, 21);
            this.cmb_cabys.TabIndex = 97;
            this.cmb_cabys.SelectedIndexChanged += new System.EventHandler(this.cmb_cabys_SelectedIndexChanged);
            // 
            // txt_search_cabys
            // 
            this.txt_search_cabys.Location = new System.Drawing.Point(185, 14);
            this.txt_search_cabys.Name = "txt_search_cabys";
            this.txt_search_cabys.Size = new System.Drawing.Size(227, 26);
            this.txt_search_cabys.TabIndex = 0;
            this.txt_search_cabys.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_search_cabys_KeyUp);
            // 
            // invoice_product_modal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 403);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbl_products_tax);
            this.Controls.Add(this.lbl_products_price_tax);
            this.Controls.Add(this.lbl_products_tax_code);
            this.Controls.Add(this.lbl_products_tax_iva);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_products_sym);
            this.Controls.Add(this.cmb_products_sym_type);
            this.Controls.Add(this.lbl_products_price);
            this.Controls.Add(this.txt_products_sym_price_before_tax);
            this.Controls.Add(this.lbl_edit_sym_product_id);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_update_product);
            this.Controls.Add(this.txt_products_sym_price);
            this.Controls.Add(this.txt_products_sym_barcode);
            this.Controls.Add(this.lbl_products_barcode);
            this.Controls.Add(this.lbl_products_description);
            this.Controls.Add(this.lbl_products_price_total);
            this.Controls.Add(this.mnuS1);
            this.Controls.Add(this.txt_products_sym_description);
            this.MainMenuStrip = this.mnuS1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "invoice_product_modal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.Shown += new System.EventHandler(this.invoice_product_modal_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_products_sym_barcode;
        private System.Windows.Forms.TextBox txt_products_sym_description;
        private System.Windows.Forms.Label lbl_products_barcode;
        private System.Windows.Forms.Label lbl_products_description;
        private System.Windows.Forms.Label lbl_products_price_total;
        private System.Windows.Forms.TextBox txt_products_sym_price;
        private System.Windows.Forms.Button btn_update_product;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.MenuStrip mnuS1;
        private System.Windows.Forms.Label lbl_edit_sym_product_id;
        private System.Windows.Forms.TextBox txt_products_sym_price_before_tax;
        private System.Windows.Forms.Label lbl_products_price;
        private System.Windows.Forms.ComboBox cmb_products_sym_type;
        private System.Windows.Forms.Label lbl_products_sym;
        private System.Windows.Forms.Label lbl_products_tax_code;
        private System.Windows.Forms.Label lbl_products_tax_iva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_products_price_tax;
        private System.Windows.Forms.Label lbl_products_tax;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk_cabys_order_cat;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_code_cabys;
        private System.Windows.Forms.ComboBox cmb_cabys;
        private System.Windows.Forms.TextBox txt_search_cabys;
    }
}