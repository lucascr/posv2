namespace POSV2
{
    partial class frm_pos_invoice_maintenance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed;otherwise, false.</param>
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
            this.mnuS1 = new System.Windows.Forms.MenuStrip();
            this.txt_invoice_man_num = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_invoice_man_print = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btn_download_xml = new System.Windows.Forms.Button();
            this.btn_download_respuesta = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chk_sel_all = new System.Windows.Forms.CheckBox();
            this.txt_invoice_line_price_total = new System.Windows.Forms.TextBox();
            this.pb1 = new System.Windows.Forms.ProgressBar();
            this.lv_invoices_detail = new System.Windows.Forms.ListView();
            this.lv_invoices = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_respuesta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.invoice_pos__r_dt1 = new System.Windows.Forms.DateTimePicker();
            this.invoice_pos__r_dt2 = new System.Windows.Forms.DateTimePicker();
            this.chk_dates = new System.Windows.Forms.CheckBox();
            this.btn_download_respuesta_api = new System.Windows.Forms.Button();
            this.btn_anular = new System.Windows.Forms.Button();
            this.btn_download_comprobantes_api = new System.Windows.Forms.Button();
            this.chk_list_tipo_doc = new System.Windows.Forms.CheckedListBox();
            this.cmb_invoice_sale_type = new System.Windows.Forms.ComboBox();
            this.chk_sales_type = new System.Windows.Forms.CheckBox();
            this.txt_invoice_email = new System.Windows.Forms.TextBox();
            this.btn_invoice_sendemail_copy = new System.Windows.Forms.Button();
            this.lbl_invoice_client_email = new System.Windows.Forms.Label();
            this.chk_sales_currency = new System.Windows.Forms.CheckBox();
            this.cmb_invoice_sale_currency = new System.Windows.Forms.ComboBox();
            this.chk_anular = new System.Windows.Forms.CheckBox();
            this.btn_load_factura = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuS1
            // 
            this.mnuS1.Location = new System.Drawing.Point(0, 0);
            this.mnuS1.Name = "mnuS1";
            this.mnuS1.Size = new System.Drawing.Size(1008, 24);
            this.mnuS1.TabIndex = 65;
            this.mnuS1.Text = "menuStrip1";
            // 
            // txt_invoice_man_num
            // 
            this.txt_invoice_man_num.Location = new System.Drawing.Point(12, 26);
            this.txt_invoice_man_num.Name = "txt_invoice_man_num";
            this.txt_invoice_man_num.Size = new System.Drawing.Size(610, 20);
            this.txt_invoice_man_num.TabIndex = 66;
            this.txt_invoice_man_num.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_invoice_man_num_KeyUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(628, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 20);
            this.button1.TabIndex = 67;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_invoice_man_print
            // 
            this.btn_invoice_man_print.Location = new System.Drawing.Point(901, 26);
            this.btn_invoice_man_print.Name = "btn_invoice_man_print";
            this.btn_invoice_man_print.Size = new System.Drawing.Size(91, 20);
            this.btn_invoice_man_print.TabIndex = 69;
            this.btn_invoice_man_print.Text = "Re-imprimir";
            this.btn_invoice_man_print.UseVisualStyleBackColor = true;
            this.btn_invoice_man_print.Click += new System.EventHandler(this.btn_invoice_man_print_Click);
            // 
            // btn_download_xml
            // 
            this.btn_download_xml.Location = new System.Drawing.Point(9, 658);
            this.btn_download_xml.Name = "btn_download_xml";
            this.btn_download_xml.Size = new System.Drawing.Size(91, 20);
            this.btn_download_xml.TabIndex = 70;
            this.btn_download_xml.Text = "XML";
            this.btn_download_xml.UseVisualStyleBackColor = true;
            this.btn_download_xml.Click += new System.EventHandler(this.btn_download_xml_Click);
            // 
            // btn_download_respuesta
            // 
            this.btn_download_respuesta.Location = new System.Drawing.Point(103, 658);
            this.btn_download_respuesta.Name = "btn_download_respuesta";
            this.btn_download_respuesta.Size = new System.Drawing.Size(91, 20);
            this.btn_download_respuesta.TabIndex = 71;
            this.btn_download_respuesta.Text = "Respuesta XML";
            this.btn_download_respuesta.UseVisualStyleBackColor = true;
            this.btn_download_respuesta.Click += new System.EventHandler(this.btn_download_respuesta_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(808, 26);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(90, 20);
            this.btn_refresh.TabIndex = 72;
            this.btn_refresh.Text = "Refrescar";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 133);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 522);
            this.tabControl1.TabIndex = 75;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chk_sel_all);
            this.tabPage1.Controls.Add(this.txt_invoice_line_price_total);
            this.tabPage1.Controls.Add(this.pb1);
            this.tabPage1.Controls.Add(this.lv_invoices_detail);
            this.tabPage1.Controls.Add(this.lv_invoices);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 496);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Facturas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chk_sel_all
            // 
            this.chk_sel_all.AutoSize = true;
            this.chk_sel_all.Location = new System.Drawing.Point(8, 305);
            this.chk_sel_all.Name = "chk_sel_all";
            this.chk_sel_all.Size = new System.Drawing.Size(106, 17);
            this.chk_sel_all.TabIndex = 89;
            this.chk_sel_all.Text = "Seleccionar todo";
            this.chk_sel_all.UseVisualStyleBackColor = true;
            this.chk_sel_all.Click += new System.EventHandler(this.chk_sel_all_Click);
            // 
            // txt_invoice_line_price_total
            // 
            this.txt_invoice_line_price_total.BackColor = System.Drawing.SystemColors.Control;
            this.txt_invoice_line_price_total.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_price_total.Location = new System.Drawing.Point(908, 301);
            this.txt_invoice_line_price_total.Name = "txt_invoice_line_price_total";
            this.txt_invoice_line_price_total.ReadOnly = true;
            this.txt_invoice_line_price_total.Size = new System.Drawing.Size(85, 22);
            this.txt_invoice_line_price_total.TabIndex = 72;
            this.txt_invoice_line_price_total.Text = "999,999,999.12";
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(8, 478);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(983, 13);
            this.pb1.TabIndex = 71;
            // 
            // lv_invoices_detail
            // 
            this.lv_invoices_detail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_invoices_detail.FullRowSelect = true;
            this.lv_invoices_detail.GridLines = true;
            this.lv_invoices_detail.HideSelection = false;
            this.lv_invoices_detail.Location = new System.Drawing.Point(8, 329);
            this.lv_invoices_detail.Name = "lv_invoices_detail";
            this.lv_invoices_detail.Size = new System.Drawing.Size(990, 145);
            this.lv_invoices_detail.TabIndex = 70;
            this.lv_invoices_detail.UseCompatibleStateImageBehavior = false;
            this.lv_invoices_detail.View = System.Windows.Forms.View.Details;
            // 
            // lv_invoices
            // 
            this.lv_invoices.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_invoices.FullRowSelect = true;
            this.lv_invoices.GridLines = true;
            this.lv_invoices.HideSelection = false;
            this.lv_invoices.Location = new System.Drawing.Point(6, 6);
            this.lv_invoices.Name = "lv_invoices";
            this.lv_invoices.Size = new System.Drawing.Size(987, 293);
            this.lv_invoices.TabIndex = 69;
            this.lv_invoices.UseCompatibleStateImageBehavior = false;
            this.lv_invoices.View = System.Windows.Forms.View.Details;
            this.lv_invoices.SelectedIndexChanged += new System.EventHandler(this.lv_invoices_SelectedIndexChanged);
            this.lv_invoices.DoubleClick += new System.EventHandler(this.lv_invoices_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_respuesta);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1000, 496);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "XML";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_respuesta
            // 
            this.txt_respuesta.Location = new System.Drawing.Point(8, 9);
            this.txt_respuesta.Multiline = true;
            this.txt_respuesta.Name = "txt_respuesta";
            this.txt_respuesta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_respuesta.Size = new System.Drawing.Size(986, 483);
            this.txt_respuesta.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Desde";
            // 
            // invoice_pos__r_dt1
            // 
            this.invoice_pos__r_dt1.Location = new System.Drawing.Point(73, 53);
            this.invoice_pos__r_dt1.Name = "invoice_pos__r_dt1";
            this.invoice_pos__r_dt1.Size = new System.Drawing.Size(200, 20);
            this.invoice_pos__r_dt1.TabIndex = 76;
            // 
            // invoice_pos__r_dt2
            // 
            this.invoice_pos__r_dt2.Location = new System.Drawing.Point(314, 53);
            this.invoice_pos__r_dt2.Name = "invoice_pos__r_dt2";
            this.invoice_pos__r_dt2.Size = new System.Drawing.Size(200, 20);
            this.invoice_pos__r_dt2.TabIndex = 77;
            // 
            // chk_dates
            // 
            this.chk_dates.AutoSize = true;
            this.chk_dates.Location = new System.Drawing.Point(11, 55);
            this.chk_dates.Name = "chk_dates";
            this.chk_dates.Size = new System.Drawing.Size(15, 14);
            this.chk_dates.TabIndex = 82;
            this.chk_dates.UseVisualStyleBackColor = true;
            // 
            // btn_download_respuesta_api
            // 
            this.btn_download_respuesta_api.Location = new System.Drawing.Point(295, 658);
            this.btn_download_respuesta_api.Name = "btn_download_respuesta_api";
            this.btn_download_respuesta_api.Size = new System.Drawing.Size(91, 20);
            this.btn_download_respuesta_api.TabIndex = 83;
            this.btn_download_respuesta_api.Text = "Respuesta API";
            this.btn_download_respuesta_api.UseVisualStyleBackColor = true;
            this.btn_download_respuesta_api.Click += new System.EventHandler(this.btn_download_respuesta_api_Click);
            // 
            // btn_anular
            // 
            this.btn_anular.Enabled = false;
            this.btn_anular.Location = new System.Drawing.Point(819, 658);
            this.btn_anular.Name = "btn_anular";
            this.btn_anular.Size = new System.Drawing.Size(169, 20);
            this.btn_anular.TabIndex = 84;
            this.btn_anular.Text = "Anular";
            this.btn_anular.UseVisualStyleBackColor = true;
            this.btn_anular.Click += new System.EventHandler(this.btn_anular_Click);
            // 
            // btn_download_comprobantes_api
            // 
            this.btn_download_comprobantes_api.Location = new System.Drawing.Point(201, 658);
            this.btn_download_comprobantes_api.Name = "btn_download_comprobantes_api";
            this.btn_download_comprobantes_api.Size = new System.Drawing.Size(91, 20);
            this.btn_download_comprobantes_api.TabIndex = 85;
            this.btn_download_comprobantes_api.Text = "Comprobantes API";
            this.btn_download_comprobantes_api.UseVisualStyleBackColor = true;
            this.btn_download_comprobantes_api.Click += new System.EventHandler(this.btn_download_comprobantes_api_Click);
            // 
            // chk_list_tipo_doc
            // 
            this.chk_list_tipo_doc.CheckOnClick = true;
            this.chk_list_tipo_doc.ColumnWidth = 175;
            this.chk_list_tipo_doc.FormattingEnabled = true;
            this.chk_list_tipo_doc.Items.AddRange(new object[] {
            "cosa1 larga 123456789",
            "cosa1 larga 123456789",
            "cosa1 larga 123456789",
            "cosa1 larga 123456789",
            "cosa1 larga 123456789",
            "cosa1 larga 123456789"});
            this.chk_list_tipo_doc.Location = new System.Drawing.Point(4, 97);
            this.chk_list_tipo_doc.MultiColumn = true;
            this.chk_list_tipo_doc.Name = "chk_list_tipo_doc";
            this.chk_list_tipo_doc.Size = new System.Drawing.Size(714, 34);
            this.chk_list_tipo_doc.TabIndex = 86;
            // 
            // cmb_invoice_sale_type
            // 
            this.cmb_invoice_sale_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_invoice_sale_type.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmb_invoice_sale_type.FormattingEnabled = true;
            this.cmb_invoice_sale_type.Location = new System.Drawing.Point(563, 52);
            this.cmb_invoice_sale_type.Name = "cmb_invoice_sale_type";
            this.cmb_invoice_sale_type.Size = new System.Drawing.Size(155, 21);
            this.cmb_invoice_sale_type.TabIndex = 87;
            // 
            // chk_sales_type
            // 
            this.chk_sales_type.AutoSize = true;
            this.chk_sales_type.Location = new System.Drawing.Point(542, 52);
            this.chk_sales_type.Name = "chk_sales_type";
            this.chk_sales_type.Size = new System.Drawing.Size(15, 14);
            this.chk_sales_type.TabIndex = 88;
            this.chk_sales_type.UseVisualStyleBackColor = true;
            // 
            // txt_invoice_email
            // 
            this.txt_invoice_email.Location = new System.Drawing.Point(808, 66);
            this.txt_invoice_email.Name = "txt_invoice_email";
            this.txt_invoice_email.Size = new System.Drawing.Size(184, 20);
            this.txt_invoice_email.TabIndex = 90;
            // 
            // btn_invoice_sendemail_copy
            // 
            this.btn_invoice_sendemail_copy.Location = new System.Drawing.Point(808, 92);
            this.btn_invoice_sendemail_copy.Name = "btn_invoice_sendemail_copy";
            this.btn_invoice_sendemail_copy.Size = new System.Drawing.Size(184, 23);
            this.btn_invoice_sendemail_copy.TabIndex = 91;
            this.btn_invoice_sendemail_copy.Text = "Enviar Copia";
            this.btn_invoice_sendemail_copy.UseVisualStyleBackColor = true;
            this.btn_invoice_sendemail_copy.Click += new System.EventHandler(this.btn_invoice_sendemail_copy_Click);
            // 
            // lbl_invoice_client_email
            // 
            this.lbl_invoice_client_email.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_client_email.Location = new System.Drawing.Point(805, 49);
            this.lbl_invoice_client_email.Name = "lbl_invoice_client_email";
            this.lbl_invoice_client_email.Size = new System.Drawing.Size(167, 14);
            this.lbl_invoice_client_email.TabIndex = 92;
            this.lbl_invoice_client_email.Text = "Email";
            // 
            // chk_sales_currency
            // 
            this.chk_sales_currency.AutoSize = true;
            this.chk_sales_currency.Location = new System.Drawing.Point(542, 77);
            this.chk_sales_currency.Name = "chk_sales_currency";
            this.chk_sales_currency.Size = new System.Drawing.Size(15, 14);
            this.chk_sales_currency.TabIndex = 94;
            this.chk_sales_currency.UseVisualStyleBackColor = true;
            // 
            // cmb_invoice_sale_currency
            // 
            this.cmb_invoice_sale_currency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_invoice_sale_currency.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmb_invoice_sale_currency.FormattingEnabled = true;
            this.cmb_invoice_sale_currency.Location = new System.Drawing.Point(563, 77);
            this.cmb_invoice_sale_currency.Name = "cmb_invoice_sale_currency";
            this.cmb_invoice_sale_currency.Size = new System.Drawing.Size(155, 21);
            this.cmb_invoice_sale_currency.TabIndex = 93;
            // 
            // chk_anular
            // 
            this.chk_anular.AutoSize = true;
            this.chk_anular.Location = new System.Drawing.Point(989, 662);
            this.chk_anular.Name = "chk_anular";
            this.chk_anular.Size = new System.Drawing.Size(15, 14);
            this.chk_anular.TabIndex = 95;
            this.chk_anular.UseVisualStyleBackColor = true;
            this.chk_anular.CheckedChanged += new System.EventHandler(this.chk_anular_CheckedChanged);
            // 
            // btn_load_factura
            // 
            this.btn_load_factura.Location = new System.Drawing.Point(808, 121);
            this.btn_load_factura.Name = "btn_load_factura";
            this.btn_load_factura.Size = new System.Drawing.Size(184, 28);
            this.btn_load_factura.TabIndex = 97;
            this.btn_load_factura.Text = "Abrir Factura";
            this.btn_load_factura.UseVisualStyleBackColor = true;
            this.btn_load_factura.Click += new System.EventHandler(this.btn_load_factura_Click);
            // 
            // frm_pos_invoice_maintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 679);
            this.Controls.Add(this.btn_load_factura);
            this.Controls.Add(this.chk_anular);
            this.Controls.Add(this.chk_sales_currency);
            this.Controls.Add(this.cmb_invoice_sale_currency);
            this.Controls.Add(this.lbl_invoice_client_email);
            this.Controls.Add(this.btn_invoice_sendemail_copy);
            this.Controls.Add(this.txt_invoice_email);
            this.Controls.Add(this.chk_sales_type);
            this.Controls.Add(this.cmb_invoice_sale_type);
            this.Controls.Add(this.chk_list_tipo_doc);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_download_comprobantes_api);
            this.Controls.Add(this.btn_anular);
            this.Controls.Add(this.btn_download_respuesta_api);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.invoice_pos__r_dt1);
            this.Controls.Add(this.invoice_pos__r_dt2);
            this.Controls.Add(this.chk_dates);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_download_respuesta);
            this.Controls.Add(this.btn_download_xml);
            this.Controls.Add(this.btn_invoice_man_print);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_invoice_man_num);
            this.Controls.Add(this.mnuS1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mnuS1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_pos_invoice_maintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maintenance";
            this.Load += new System.EventHandler(this.frm_pos_invoice_maintenance_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuS1;
        private System.Windows.Forms.TextBox txt_invoice_man_num;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_invoice_man_print;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btn_download_xml;
        private System.Windows.Forms.Button btn_download_respuesta;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lv_invoices_detail;
        private System.Windows.Forms.ListView lv_invoices;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_respuesta;
        private System.Windows.Forms.ProgressBar pb1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker invoice_pos__r_dt1;
        private System.Windows.Forms.DateTimePicker invoice_pos__r_dt2;
        private System.Windows.Forms.CheckBox chk_dates;
        private System.Windows.Forms.Button btn_download_respuesta_api;
        private System.Windows.Forms.Button btn_anular;
        private System.Windows.Forms.Button btn_download_comprobantes_api;
        private System.Windows.Forms.CheckedListBox chk_list_tipo_doc;
        private System.Windows.Forms.ComboBox cmb_invoice_sale_type;
        private System.Windows.Forms.CheckBox chk_sales_type;
        private System.Windows.Forms.TextBox txt_invoice_line_price_total;
        private System.Windows.Forms.CheckBox chk_sel_all;
        private System.Windows.Forms.TextBox txt_invoice_email;
        private System.Windows.Forms.Button btn_invoice_sendemail_copy;
        private System.Windows.Forms.Label lbl_invoice_client_email;
        private System.Windows.Forms.CheckBox chk_sales_currency;
        private System.Windows.Forms.ComboBox cmb_invoice_sale_currency;
        private System.Windows.Forms.CheckBox chk_anular;
        private System.Windows.Forms.Button btn_load_factura;
    }
}