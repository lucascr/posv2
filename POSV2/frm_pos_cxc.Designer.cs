namespace POSV2
{
    partial class frm_pos_cxc
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
            this.btn_cxc_agregar_abono = new System.Windows.Forms.Button();
            this.lv_invoices = new System.Windows.Forms.ListView();
            this.txt_invoice_cxc_total = new System.Windows.Forms.TextBox();
            this.chk_sel_all = new System.Windows.Forms.CheckBox();
            this.grp_invoice_client = new System.Windows.Forms.GroupBox();
            this.txt_clients_search_all = new System.Windows.Forms.TextBox();
            this.btn_cxc_buscar = new System.Windows.Forms.Button();
            this.lv_clients_search_results = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbl_invoice_check_total = new System.Windows.Forms.TextBox();
            this.lbl_cal_pagacon = new System.Windows.Forms.Label();
            this.txt_cal_abono = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_abono_print = new System.Windows.Forms.Button();
            this.lv_abonos = new System.Windows.Forms.ListView();
            this.lv_facturas_abonos = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.invoice_wb1 = new System.Windows.Forms.WebBrowser();
            this.btn_invoice_cxc_saldos = new System.Windows.Forms.Button();
            this.btn_invoice_cxc_antiguedad_saldos = new System.Windows.Forms.Button();
            this.grp_invoice_client.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_cxc_agregar_abono
            // 
            this.btn_cxc_agregar_abono.Enabled = false;
            this.btn_cxc_agregar_abono.Location = new System.Drawing.Point(792, 425);
            this.btn_cxc_agregar_abono.Name = "btn_cxc_agregar_abono";
            this.btn_cxc_agregar_abono.Size = new System.Drawing.Size(185, 35);
            this.btn_cxc_agregar_abono.TabIndex = 85;
            this.btn_cxc_agregar_abono.Text = "Agregar Abono";
            this.btn_cxc_agregar_abono.UseVisualStyleBackColor = true;
            this.btn_cxc_agregar_abono.Click += new System.EventHandler(this.btn_cxc_agregar_abono_Click);
            // 
            // lv_invoices
            // 
            this.lv_invoices.CheckBoxes = true;
            this.lv_invoices.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_invoices.FullRowSelect = true;
            this.lv_invoices.GridLines = true;
            this.lv_invoices.Location = new System.Drawing.Point(3, 6);
            this.lv_invoices.MultiSelect = false;
            this.lv_invoices.Name = "lv_invoices";
            this.lv_invoices.Size = new System.Drawing.Size(974, 385);
            this.lv_invoices.TabIndex = 86;
            this.lv_invoices.UseCompatibleStateImageBehavior = false;
            this.lv_invoices.View = System.Windows.Forms.View.Details;
            this.lv_invoices.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lv_invoices_ItemCheck);
            this.lv_invoices.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_invoices_ItemChecked);
            this.lv_invoices.SelectedIndexChanged += new System.EventHandler(this.lv_invoices_SelectedIndexChanged);
            // 
            // txt_invoice_cxc_total
            // 
            this.txt_invoice_cxc_total.BackColor = System.Drawing.SystemColors.Control;
            this.txt_invoice_cxc_total.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_cxc_total.Location = new System.Drawing.Point(792, 397);
            this.txt_invoice_cxc_total.Name = "txt_invoice_cxc_total";
            this.txt_invoice_cxc_total.ReadOnly = true;
            this.txt_invoice_cxc_total.Size = new System.Drawing.Size(185, 22);
            this.txt_invoice_cxc_total.TabIndex = 87;
            this.txt_invoice_cxc_total.Text = "999,999,999.12";
            // 
            // chk_sel_all
            // 
            this.chk_sel_all.AutoSize = true;
            this.chk_sel_all.Location = new System.Drawing.Point(3, 397);
            this.chk_sel_all.Name = "chk_sel_all";
            this.chk_sel_all.Size = new System.Drawing.Size(106, 17);
            this.chk_sel_all.TabIndex = 90;
            this.chk_sel_all.Text = "Seleccionar todo";
            this.chk_sel_all.UseVisualStyleBackColor = true;
            this.chk_sel_all.Click += new System.EventHandler(this.chk_sel_all_Click);
            // 
            // grp_invoice_client
            // 
            this.grp_invoice_client.Controls.Add(this.txt_clients_search_all);
            this.grp_invoice_client.Controls.Add(this.btn_cxc_buscar);
            this.grp_invoice_client.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grp_invoice_client.Location = new System.Drawing.Point(12, 12);
            this.grp_invoice_client.Name = "grp_invoice_client";
            this.grp_invoice_client.Size = new System.Drawing.Size(984, 49);
            this.grp_invoice_client.TabIndex = 91;
            this.grp_invoice_client.TabStop = false;
            this.grp_invoice_client.Text = "Buscar cliente";
            // 
            // txt_clients_search_all
            // 
            this.txt_clients_search_all.Location = new System.Drawing.Point(6, 21);
            this.txt_clients_search_all.Name = "txt_clients_search_all";
            this.txt_clients_search_all.Size = new System.Drawing.Size(862, 22);
            this.txt_clients_search_all.TabIndex = 77;
            this.txt_clients_search_all.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_clients_search_all_KeyUp);
            // 
            // btn_cxc_buscar
            // 
            this.btn_cxc_buscar.Enabled = false;
            this.btn_cxc_buscar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_cxc_buscar.Location = new System.Drawing.Point(874, 21);
            this.btn_cxc_buscar.Name = "btn_cxc_buscar";
            this.btn_cxc_buscar.Size = new System.Drawing.Size(104, 24);
            this.btn_cxc_buscar.TabIndex = 3;
            this.btn_cxc_buscar.Text = "Buscar cliente";
            this.btn_cxc_buscar.UseVisualStyleBackColor = true;
            this.btn_cxc_buscar.Click += new System.EventHandler(this.btn_cxc_buscar_Click);
            // 
            // lv_clients_search_results
            // 
            this.lv_clients_search_results.FullRowSelect = true;
            this.lv_clients_search_results.GridLines = true;
            this.lv_clients_search_results.Location = new System.Drawing.Point(12, 67);
            this.lv_clients_search_results.Name = "lv_clients_search_results";
            this.lv_clients_search_results.Size = new System.Drawing.Size(978, 104);
            this.lv_clients_search_results.TabIndex = 92;
            this.lv_clients_search_results.UseCompatibleStateImageBehavior = false;
            this.lv_clients_search_results.View = System.Windows.Forms.View.Details;
            this.lv_clients_search_results.SelectedIndexChanged += new System.EventHandler(this.lv_clients_search_results_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 177);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(994, 492);
            this.tabControl1.TabIndex = 65;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbl_invoice_check_total);
            this.tabPage1.Controls.Add(this.lbl_cal_pagacon);
            this.tabPage1.Controls.Add(this.txt_cal_abono);
            this.tabPage1.Controls.Add(this.lv_invoices);
            this.tabPage1.Controls.Add(this.txt_invoice_cxc_total);
            this.tabPage1.Controls.Add(this.btn_cxc_agregar_abono);
            this.tabPage1.Controls.Add(this.chk_sel_all);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(986, 466);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Facturas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbl_invoice_check_total
            // 
            this.lbl_invoice_check_total.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_invoice_check_total.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_check_total.Location = new System.Drawing.Point(3, 441);
            this.lbl_invoice_check_total.Name = "lbl_invoice_check_total";
            this.lbl_invoice_check_total.ReadOnly = true;
            this.lbl_invoice_check_total.Size = new System.Drawing.Size(34, 22);
            this.lbl_invoice_check_total.TabIndex = 141;
            this.lbl_invoice_check_total.Text = "0";
            // 
            // lbl_cal_pagacon
            // 
            this.lbl_cal_pagacon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cal_pagacon.Location = new System.Drawing.Point(398, 425);
            this.lbl_cal_pagacon.Name = "lbl_cal_pagacon";
            this.lbl_cal_pagacon.Size = new System.Drawing.Size(191, 35);
            this.lbl_cal_pagacon.TabIndex = 140;
            this.lbl_cal_pagacon.Text = "Abono";
            this.lbl_cal_pagacon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_cal_abono
            // 
            this.txt_cal_abono.BackColor = System.Drawing.Color.White;
            this.txt_cal_abono.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cal_abono.ForeColor = System.Drawing.Color.Black;
            this.txt_cal_abono.Location = new System.Drawing.Point(595, 425);
            this.txt_cal_abono.Name = "txt_cal_abono";
            this.txt_cal_abono.ShortcutsEnabled = false;
            this.txt_cal_abono.Size = new System.Drawing.Size(191, 35);
            this.txt_cal_abono.TabIndex = 139;
            this.txt_cal_abono.Text = "999,999,999.12345";
            this.txt_cal_abono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_cal_abono.TextChanged += new System.EventHandler(this.txt_cal_abono_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_abono_print);
            this.tabPage2.Controls.Add(this.lv_abonos);
            this.tabPage2.Controls.Add(this.lv_facturas_abonos);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(986, 466);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Abonos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_abono_print
            // 
            this.btn_abono_print.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_abono_print.Location = new System.Drawing.Point(818, 9);
            this.btn_abono_print.Name = "btn_abono_print";
            this.btn_abono_print.Size = new System.Drawing.Size(159, 24);
            this.btn_abono_print.TabIndex = 96;
            this.btn_abono_print.Text = "Imprimir abono";
            this.btn_abono_print.UseVisualStyleBackColor = true;
            this.btn_abono_print.Click += new System.EventHandler(this.btn_abono_print_Click);
            // 
            // lv_abonos
            // 
            this.lv_abonos.CheckBoxes = true;
            this.lv_abonos.FullRowSelect = true;
            this.lv_abonos.GridLines = true;
            this.lv_abonos.Location = new System.Drawing.Point(3, 39);
            this.lv_abonos.Name = "lv_abonos";
            this.lv_abonos.Size = new System.Drawing.Size(974, 214);
            this.lv_abonos.TabIndex = 95;
            this.lv_abonos.UseCompatibleStateImageBehavior = false;
            this.lv_abonos.View = System.Windows.Forms.View.Details;
            this.lv_abonos.SelectedIndexChanged += new System.EventHandler(this.lv_abonos_SelectedIndexChanged);
            // 
            // lv_facturas_abonos
            // 
            this.lv_facturas_abonos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_facturas_abonos.FullRowSelect = true;
            this.lv_facturas_abonos.GridLines = true;
            this.lv_facturas_abonos.Location = new System.Drawing.Point(6, 259);
            this.lv_facturas_abonos.Name = "lv_facturas_abonos";
            this.lv_facturas_abonos.Size = new System.Drawing.Size(974, 160);
            this.lv_facturas_abonos.TabIndex = 93;
            this.lv_facturas_abonos.UseCompatibleStateImageBehavior = false;
            this.lv_facturas_abonos.View = System.Windows.Forms.View.Details;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.textBox1.Location = new System.Drawing.Point(864, 432);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(85, 22);
            this.textBox1.TabIndex = 94;
            this.textBox1.Text = "999,999,999.12";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_invoice_cxc_antiguedad_saldos);
            this.tabPage3.Controls.Add(this.btn_invoice_cxc_saldos);
            this.tabPage3.Controls.Add(this.invoice_wb1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(986, 466);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Reportes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // invoice_wb1
            // 
            this.invoice_wb1.Location = new System.Drawing.Point(3, 55);
            this.invoice_wb1.MinimumSize = new System.Drawing.Size(20, 20);
            this.invoice_wb1.Name = "invoice_wb1";
            this.invoice_wb1.Size = new System.Drawing.Size(971, 408);
            this.invoice_wb1.TabIndex = 72;
            // 
            // btn_invoice_cxc_saldos
            // 
            this.btn_invoice_cxc_saldos.Location = new System.Drawing.Point(13, 10);
            this.btn_invoice_cxc_saldos.Name = "btn_invoice_cxc_saldos";
            this.btn_invoice_cxc_saldos.Size = new System.Drawing.Size(163, 39);
            this.btn_invoice_cxc_saldos.TabIndex = 78;
            this.btn_invoice_cxc_saldos.Text = "Reporte de Saldos";
            this.btn_invoice_cxc_saldos.UseVisualStyleBackColor = true;
            this.btn_invoice_cxc_saldos.Click += new System.EventHandler(this.btn_invoice_cxc_saldos_Click);
            // 
            // btn_invoice_cxc_antiguedad_saldos
            // 
            this.btn_invoice_cxc_antiguedad_saldos.Location = new System.Drawing.Point(182, 10);
            this.btn_invoice_cxc_antiguedad_saldos.Name = "btn_invoice_cxc_antiguedad_saldos";
            this.btn_invoice_cxc_antiguedad_saldos.Size = new System.Drawing.Size(163, 39);
            this.btn_invoice_cxc_antiguedad_saldos.TabIndex = 79;
            this.btn_invoice_cxc_antiguedad_saldos.Text = "Reporte de Antiguedad Saldos";
            this.btn_invoice_cxc_antiguedad_saldos.UseVisualStyleBackColor = true;
            this.btn_invoice_cxc_antiguedad_saldos.Click += new System.EventHandler(this.btn_invoice_cxc_antiguedad_saldos_Click);
            // 
            // frm_pos_cxc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grp_invoice_client);
            this.Controls.Add(this.lv_clients_search_results);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_pos_cxc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas X Pagar";
            this.Load += new System.EventHandler(this.frm_pos_cxc_Load);
            this.grp_invoice_client.ResumeLayout(false);
            this.grp_invoice_client.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_cxc_agregar_abono;
        private System.Windows.Forms.ListView lv_invoices;
        private System.Windows.Forms.TextBox txt_invoice_cxc_total;
        private System.Windows.Forms.CheckBox chk_sel_all;
        private System.Windows.Forms.GroupBox grp_invoice_client;
        private System.Windows.Forms.Button btn_cxc_buscar;
        private System.Windows.Forms.ListView lv_clients_search_results;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lv_abonos;
        private System.Windows.Forms.ListView lv_facturas_abonos;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txt_clients_search_all;
        private System.Windows.Forms.Label lbl_cal_pagacon;
        private System.Windows.Forms.TextBox txt_cal_abono;
        private System.Windows.Forms.TextBox lbl_invoice_check_total;
        private System.Windows.Forms.Button btn_abono_print;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.WebBrowser invoice_wb1;
        private System.Windows.Forms.Button btn_invoice_cxc_saldos;
        private System.Windows.Forms.Button btn_invoice_cxc_antiguedad_saldos;
    }
}