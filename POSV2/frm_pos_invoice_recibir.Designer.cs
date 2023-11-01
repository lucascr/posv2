namespace POSV2
{
    partial class frm_pos_invoice_recibir
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mnuS1 = new System.Windows.Forms.MenuStrip();
            this.lv_products_sym_search_results = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // mnuS1
            // 
            this.mnuS1.Location = new System.Drawing.Point(0, 0);
            this.mnuS1.Name = "mnuS1";
            this.mnuS1.Size = new System.Drawing.Size(1008, 24);
            this.mnuS1.TabIndex = 0;
            this.mnuS1.Text = "menuStrip1";
            // 
            // lv_products_sym_search_results
            // 
            this.lv_products_sym_search_results.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_products_sym_search_results.FullRowSelect = true;
            this.lv_products_sym_search_results.GridLines = true;
            this.lv_products_sym_search_results.Location = new System.Drawing.Point(5, 97);
            this.lv_products_sym_search_results.Name = "lv_products_sym_search_results";
            this.lv_products_sym_search_results.Size = new System.Drawing.Size(996, 445);
            this.lv_products_sym_search_results.TabIndex = 1;
            this.lv_products_sym_search_results.UseCompatibleStateImageBehavior = false;
            this.lv_products_sym_search_results.View = System.Windows.Forms.View.Details;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 564);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(210, 564);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 39);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(397, 564);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(168, 39);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 39);
            this.button4.TabIndex = 5;
            this.button4.Text = "Cargar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // frm_pos_invoice_recibir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lv_products_sym_search_results);
            this.Controls.Add(this.mnuS1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mnuS1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_pos_invoice_recibir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibir";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip mnuS1;
        private System.Windows.Forms.ListView lv_products_sym_search_results;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}