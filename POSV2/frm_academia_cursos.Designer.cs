namespace POSV2
{
    partial class frm_academia_cursos
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
            this.lv_products_sym_search_results = new System.Windows.Forms.ListView();
            this.grp_products = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.invoice_pos__r_dt1 = new System.Windows.Forms.DateTimePicker();
            this.invoice_pos__r_dt2 = new System.Windows.Forms.DateTimePicker();
            this.btn_academia_cursos_save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_products_sym_price_cost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_products_sym_price = new System.Windows.Forms.TextBox();
            this.txt_products_sym_qty = new System.Windows.Forms.TextBox();
            this.lbl_edit_sym_product_id = new System.Windows.Forms.Label();
            this.txt_products_sym_price_total_curso = new System.Windows.Forms.TextBox();
            this.txt_products_sym_barcode = new System.Windows.Forms.TextBox();
            this.txt_products_sym_description = new System.Windows.Forms.TextBox();
            this.lbl_invoice_line_qty = new System.Windows.Forms.Label();
            this.grp_products.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_products_sym_search_results
            // 
            this.lv_products_sym_search_results.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_products_sym_search_results.FullRowSelect = true;
            this.lv_products_sym_search_results.GridLines = true;
            this.lv_products_sym_search_results.HideSelection = false;
            this.lv_products_sym_search_results.Location = new System.Drawing.Point(12, 169);
            this.lv_products_sym_search_results.Name = "lv_products_sym_search_results";
            this.lv_products_sym_search_results.Size = new System.Drawing.Size(984, 441);
            this.lv_products_sym_search_results.TabIndex = 1;
            this.lv_products_sym_search_results.UseCompatibleStateImageBehavior = false;
            this.lv_products_sym_search_results.View = System.Windows.Forms.View.Details;
            this.lv_products_sym_search_results.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_products_sym_search_results_MouseDoubleClick);
            // 
            // grp_products
            // 
            this.grp_products.Controls.Add(this.label4);
            this.grp_products.Controls.Add(this.label5);
            this.grp_products.Controls.Add(this.invoice_pos__r_dt1);
            this.grp_products.Controls.Add(this.invoice_pos__r_dt2);
            this.grp_products.Controls.Add(this.btn_academia_cursos_save);
            this.grp_products.Controls.Add(this.label3);
            this.grp_products.Controls.Add(this.label2);
            this.grp_products.Controls.Add(this.txt_products_sym_price_cost);
            this.grp_products.Controls.Add(this.label1);
            this.grp_products.Controls.Add(this.txt_products_sym_price);
            this.grp_products.Controls.Add(this.txt_products_sym_qty);
            this.grp_products.Controls.Add(this.lbl_edit_sym_product_id);
            this.grp_products.Controls.Add(this.txt_products_sym_price_total_curso);
            this.grp_products.Controls.Add(this.txt_products_sym_barcode);
            this.grp_products.Controls.Add(this.txt_products_sym_description);
            this.grp_products.Controls.Add(this.lbl_invoice_line_qty);
            this.grp_products.Location = new System.Drawing.Point(12, 23);
            this.grp_products.Name = "grp_products";
            this.grp_products.Size = new System.Drawing.Size(994, 111);
            this.grp_products.TabIndex = 68;
            this.grp_products.TabStop = false;
            this.grp_products.Text = "Cursos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(759, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 104;
            this.label4.Text = "Hasta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(551, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 103;
            this.label5.Text = "Desde";
            // 
            // invoice_pos__r_dt1
            // 
            this.invoice_pos__r_dt1.Location = new System.Drawing.Point(551, 75);
            this.invoice_pos__r_dt1.Name = "invoice_pos__r_dt1";
            this.invoice_pos__r_dt1.Size = new System.Drawing.Size(200, 20);
            this.invoice_pos__r_dt1.TabIndex = 101;
            // 
            // invoice_pos__r_dt2
            // 
            this.invoice_pos__r_dt2.Location = new System.Drawing.Point(759, 75);
            this.invoice_pos__r_dt2.Name = "invoice_pos__r_dt2";
            this.invoice_pos__r_dt2.Size = new System.Drawing.Size(200, 20);
            this.invoice_pos__r_dt2.TabIndex = 102;
            // 
            // btn_academia_cursos_save
            // 
            this.btn_academia_cursos_save.Enabled = false;
            this.btn_academia_cursos_save.Location = new System.Drawing.Point(894, 30);
            this.btn_academia_cursos_save.Name = "btn_academia_cursos_save";
            this.btn_academia_cursos_save.Size = new System.Drawing.Size(75, 23);
            this.btn_academia_cursos_save.TabIndex = 100;
            this.btn_academia_cursos_save.Text = "Salvar";
            this.btn_academia_cursos_save.UseVisualStyleBackColor = true;
            this.btn_academia_cursos_save.Click += new System.EventHandler(this.btn_academia_cursos_save_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label3.Location = new System.Drawing.Point(323, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 14);
            this.label3.TabIndex = 99;
            this.label3.Text = "Total de Curso";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label2.Location = new System.Drawing.Point(435, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 14);
            this.label2.TabIndex = 98;
            this.label2.Text = "Costo de Lección";
            // 
            // txt_products_sym_price_cost
            // 
            this.txt_products_sym_price_cost.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_products_sym_price_cost.Location = new System.Drawing.Point(435, 74);
            this.txt_products_sym_price_cost.Name = "txt_products_sym_price_cost";
            this.txt_products_sym_price_cost.ShortcutsEnabled = false;
            this.txt_products_sym_price_cost.Size = new System.Drawing.Size(108, 22);
            this.txt_products_sym_price_cost.TabIndex = 97;
            this.txt_products_sym_price_cost.Text = "999,999,999.12345";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.Location = new System.Drawing.Point(211, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 96;
            this.label1.Text = "Precio de Lección";
            // 
            // txt_products_sym_price
            // 
            this.txt_products_sym_price.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_products_sym_price.Location = new System.Drawing.Point(211, 74);
            this.txt_products_sym_price.Name = "txt_products_sym_price";
            this.txt_products_sym_price.ShortcutsEnabled = false;
            this.txt_products_sym_price.Size = new System.Drawing.Size(104, 22);
            this.txt_products_sym_price.TabIndex = 3;
            this.txt_products_sym_price.Text = "999,999,999.12345";
            this.txt_products_sym_price.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_products_sym_price_KeyUp);
            // 
            // txt_products_sym_qty
            // 
            this.txt_products_sym_qty.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_products_sym_qty.Location = new System.Drawing.Point(6, 74);
            this.txt_products_sym_qty.Name = "txt_products_sym_qty";
            this.txt_products_sym_qty.Size = new System.Drawing.Size(197, 22);
            this.txt_products_sym_qty.TabIndex = 94;
            this.txt_products_sym_qty.Text = "99999";
            this.txt_products_sym_qty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_products_sym_qty_KeyUp);
            // 
            // lbl_edit_sym_product_id
            // 
            this.lbl_edit_sym_product_id.Location = new System.Drawing.Point(6, 16);
            this.lbl_edit_sym_product_id.Name = "lbl_edit_sym_product_id";
            this.lbl_edit_sym_product_id.Size = new System.Drawing.Size(93, 13);
            this.lbl_edit_sym_product_id.TabIndex = 74;
            this.lbl_edit_sym_product_id.Text = "0";
            this.lbl_edit_sym_product_id.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_products_sym_price_total_curso
            // 
            this.txt_products_sym_price_total_curso.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_products_sym_price_total_curso.Location = new System.Drawing.Point(323, 74);
            this.txt_products_sym_price_total_curso.Name = "txt_products_sym_price_total_curso";
            this.txt_products_sym_price_total_curso.ReadOnly = true;
            this.txt_products_sym_price_total_curso.ShortcutsEnabled = false;
            this.txt_products_sym_price_total_curso.Size = new System.Drawing.Size(104, 22);
            this.txt_products_sym_price_total_curso.TabIndex = 70;
            this.txt_products_sym_price_total_curso.Text = "99,999,999.12345";
            // 
            // txt_products_sym_barcode
            // 
            this.txt_products_sym_barcode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_products_sym_barcode.Location = new System.Drawing.Point(6, 32);
            this.txt_products_sym_barcode.Name = "txt_products_sym_barcode";
            this.txt_products_sym_barcode.Size = new System.Drawing.Size(197, 22);
            this.txt_products_sym_barcode.TabIndex = 0;
            this.txt_products_sym_barcode.Text = "1234567890123456";
            // 
            // txt_products_sym_description
            // 
            this.txt_products_sym_description.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_products_sym_description.Location = new System.Drawing.Point(209, 32);
            this.txt_products_sym_description.Name = "txt_products_sym_description";
            this.txt_products_sym_description.Size = new System.Drawing.Size(598, 22);
            this.txt_products_sym_description.TabIndex = 2;
            // 
            // lbl_invoice_line_qty
            // 
            this.lbl_invoice_line_qty.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_line_qty.Location = new System.Drawing.Point(6, 57);
            this.lbl_invoice_line_qty.Name = "lbl_invoice_line_qty";
            this.lbl_invoice_line_qty.Size = new System.Drawing.Size(107, 14);
            this.lbl_invoice_line_qty.TabIndex = 95;
            this.lbl_invoice_line_qty.Text = "Total de Lecciones";
            // 
            // frm_academia_cursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.grp_products);
            this.Controls.Add(this.lv_products_sym_search_results);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "frm_academia_cursos";
            this.Text = "Academia Cursos";
            this.grp_products.ResumeLayout(false);
            this.grp_products.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_products_sym_search_results;
        private System.Windows.Forms.GroupBox grp_products;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_products_sym_price_cost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_products_sym_price;
        private System.Windows.Forms.TextBox txt_products_sym_qty;
        private System.Windows.Forms.Label lbl_edit_sym_product_id;
        private System.Windows.Forms.TextBox txt_products_sym_price_total_curso;
        private System.Windows.Forms.TextBox txt_products_sym_barcode;
        private System.Windows.Forms.TextBox txt_products_sym_description;
        private System.Windows.Forms.Label lbl_invoice_line_qty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_academia_cursos_save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker invoice_pos__r_dt1;
        private System.Windows.Forms.DateTimePicker invoice_pos__r_dt2;
    }
}