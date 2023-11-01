namespace POSV2
{
    partial class invoice_product_CanastaBasica
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
            this.lbl_description = new System.Windows.Forms.Label();
            this.btn_update_product_canastabasica = new System.Windows.Forms.Button();
            this.btn_update_product_exento = new System.Windows.Forms.Button();
            this.lbl_edit_sym_product_id = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_description
            // 
            this.lbl_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_description.Location = new System.Drawing.Point(2, 9);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(470, 37);
            this.lbl_description.TabIndex = 147;
            this.lbl_description.Text = "Abarrotes";
            this.lbl_description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_update_product_canastabasica
            // 
            this.btn_update_product_canastabasica.Location = new System.Drawing.Point(251, 77);
            this.btn_update_product_canastabasica.Name = "btn_update_product_canastabasica";
            this.btn_update_product_canastabasica.Size = new System.Drawing.Size(141, 56);
            this.btn_update_product_canastabasica.TabIndex = 150;
            this.btn_update_product_canastabasica.Text = "Canasta Basica";
            this.btn_update_product_canastabasica.UseVisualStyleBackColor = true;
            this.btn_update_product_canastabasica.Click += new System.EventHandler(this.btn_update_product_canastabasica_Click);
            // 
            // btn_update_product_exento
            // 
            this.btn_update_product_exento.Location = new System.Drawing.Point(89, 77);
            this.btn_update_product_exento.Name = "btn_update_product_exento";
            this.btn_update_product_exento.Size = new System.Drawing.Size(141, 56);
            this.btn_update_product_exento.TabIndex = 149;
            this.btn_update_product_exento.Text = "Producto EXENTO";
            this.btn_update_product_exento.UseVisualStyleBackColor = true;
            this.btn_update_product_exento.Click += new System.EventHandler(this.btn_update_product_exento_Click);
            // 
            // lbl_edit_sym_product_id
            // 
            this.lbl_edit_sym_product_id.AutoSize = true;
            this.lbl_edit_sym_product_id.Location = new System.Drawing.Point(5, 116);
            this.lbl_edit_sym_product_id.Name = "lbl_edit_sym_product_id";
            this.lbl_edit_sym_product_id.Size = new System.Drawing.Size(13, 13);
            this.lbl_edit_sym_product_id.TabIndex = 151;
            this.lbl_edit_sym_product_id.Text = "0";
            // 
            // invoice_product_CanastaBasica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 138);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_edit_sym_product_id);
            this.Controls.Add(this.btn_update_product_canastabasica);
            this.Controls.Add(this.btn_update_product_exento);
            this.Controls.Add(this.lbl_description);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "invoice_product_CanastaBasica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "invoice_product_CanastaBasica";
            this.Load += new System.EventHandler(this.invoice_product_CanastaBasica_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.Button btn_update_product_canastabasica;
        private System.Windows.Forms.Button btn_update_product_exento;
        private System.Windows.Forms.Label lbl_edit_sym_product_id;
    }
}