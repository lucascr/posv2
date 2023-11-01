namespace POSV2
{
    partial class frm_invoice_asadas
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
            this.grp_invoice_client = new System.Windows.Forms.GroupBox();
            this.txt_clients_search_all = new System.Windows.Forms.TextBox();
            this.btn_asadas_buscar = new System.Windows.Forms.Button();
            this.lv_asadas_clients_search_results = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lv_invoices = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grp_asadas_medidores = new System.Windows.Forms.GroupBox();
            this.lv_asadas_clients_medidores = new System.Windows.Forms.ListView();
            this.btn_asadas_cliente_medidores_add = new System.Windows.Forms.Button();
            this.txt_client_asada_medidor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_clients_asada_tipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_client_asada_lectura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lv_facturas_abonos = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_invoice_cxc_antiguedad_saldos = new System.Windows.Forms.Button();
            this.btn_invoice_cxc_saldos = new System.Windows.Forms.Button();
            this.invoice_wb1 = new System.Windows.Forms.WebBrowser();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grp_invoice_client.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grp_asadas_medidores.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_invoice_client
            // 
            this.grp_invoice_client.Controls.Add(this.txt_clients_search_all);
            this.grp_invoice_client.Controls.Add(this.btn_asadas_buscar);
            this.grp_invoice_client.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grp_invoice_client.Location = new System.Drawing.Point(6, 6);
            this.grp_invoice_client.Name = "grp_invoice_client";
            this.grp_invoice_client.Size = new System.Drawing.Size(974, 49);
            this.grp_invoice_client.TabIndex = 93;
            this.grp_invoice_client.TabStop = false;
            this.grp_invoice_client.Text = "Buscar cliente";
            // 
            // txt_clients_search_all
            // 
            this.txt_clients_search_all.Location = new System.Drawing.Point(6, 21);
            this.txt_clients_search_all.Name = "txt_clients_search_all";
            this.txt_clients_search_all.Size = new System.Drawing.Size(853, 22);
            this.txt_clients_search_all.TabIndex = 77;
            this.txt_clients_search_all.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_clients_search_all_KeyUp);
            // 
            // btn_asadas_buscar
            // 
            this.btn_asadas_buscar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_asadas_buscar.Location = new System.Drawing.Point(864, 21);
            this.btn_asadas_buscar.Name = "btn_asadas_buscar";
            this.btn_asadas_buscar.Size = new System.Drawing.Size(104, 24);
            this.btn_asadas_buscar.TabIndex = 3;
            this.btn_asadas_buscar.Text = "Buscar cliente";
            this.btn_asadas_buscar.UseVisualStyleBackColor = true;
            this.btn_asadas_buscar.Click += new System.EventHandler(this.btn_asadas_buscar_Click);
            // 
            // lv_asadas_clients_search_results
            // 
            this.lv_asadas_clients_search_results.FullRowSelect = true;
            this.lv_asadas_clients_search_results.GridLines = true;
            this.lv_asadas_clients_search_results.HideSelection = false;
            this.lv_asadas_clients_search_results.Location = new System.Drawing.Point(12, 55);
            this.lv_asadas_clients_search_results.Name = "lv_asadas_clients_search_results";
            this.lv_asadas_clients_search_results.Size = new System.Drawing.Size(968, 104);
            this.lv_asadas_clients_search_results.TabIndex = 94;
            this.lv_asadas_clients_search_results.UseCompatibleStateImageBehavior = false;
            this.lv_asadas_clients_search_results.View = System.Windows.Forms.View.Details;
            this.lv_asadas_clients_search_results.SelectedIndexChanged += new System.EventHandler(this.lv_asadas_clients_search_results_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(2, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(994, 665);
            this.tabControl1.TabIndex = 95;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lv_invoices);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(986, 639);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pendientes";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // lv_invoices
            // 
            this.lv_invoices.CheckBoxes = true;
            this.lv_invoices.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_invoices.FullRowSelect = true;
            this.lv_invoices.GridLines = true;
            this.lv_invoices.HideSelection = false;
            this.lv_invoices.Location = new System.Drawing.Point(10, 79);
            this.lv_invoices.MultiSelect = false;
            this.lv_invoices.Name = "lv_invoices";
            this.lv_invoices.Size = new System.Drawing.Size(964, 509);
            this.lv_invoices.TabIndex = 86;
            this.lv_invoices.UseCompatibleStateImageBehavior = false;
            this.lv_invoices.View = System.Windows.Forms.View.Details;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grp_asadas_medidores);
            this.tabPage2.Controls.Add(this.grp_invoice_client);
            this.tabPage2.Controls.Add(this.lv_asadas_clients_search_results);
            this.tabPage2.Controls.Add(this.lv_facturas_abonos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(986, 639);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lecturas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grp_asadas_medidores
            // 
            this.grp_asadas_medidores.Controls.Add(this.lv_asadas_clients_medidores);
            this.grp_asadas_medidores.Controls.Add(this.btn_asadas_cliente_medidores_add);
            this.grp_asadas_medidores.Controls.Add(this.txt_client_asada_medidor);
            this.grp_asadas_medidores.Controls.Add(this.label7);
            this.grp_asadas_medidores.Controls.Add(this.cmb_clients_asada_tipo);
            this.grp_asadas_medidores.Controls.Add(this.label1);
            this.grp_asadas_medidores.Controls.Add(this.txt_client_asada_lectura);
            this.grp_asadas_medidores.Controls.Add(this.label3);
            this.grp_asadas_medidores.Location = new System.Drawing.Point(12, 177);
            this.grp_asadas_medidores.Name = "grp_asadas_medidores";
            this.grp_asadas_medidores.Size = new System.Drawing.Size(390, 181);
            this.grp_asadas_medidores.TabIndex = 95;
            this.grp_asadas_medidores.TabStop = false;
            this.grp_asadas_medidores.Text = "Medidores de Cliente";
            this.grp_asadas_medidores.Visible = false;
            // 
            // lv_asadas_clients_medidores
            // 
            this.lv_asadas_clients_medidores.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_asadas_clients_medidores.FullRowSelect = true;
            this.lv_asadas_clients_medidores.GridLines = true;
            this.lv_asadas_clients_medidores.HideSelection = false;
            this.lv_asadas_clients_medidores.Location = new System.Drawing.Point(6, 59);
            this.lv_asadas_clients_medidores.Name = "lv_asadas_clients_medidores";
            this.lv_asadas_clients_medidores.Size = new System.Drawing.Size(373, 111);
            this.lv_asadas_clients_medidores.TabIndex = 96;
            this.lv_asadas_clients_medidores.UseCompatibleStateImageBehavior = false;
            this.lv_asadas_clients_medidores.View = System.Windows.Forms.View.Details;
            // 
            // btn_asadas_cliente_medidores_add
            // 
            this.btn_asadas_cliente_medidores_add.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_asadas_cliente_medidores_add.Location = new System.Drawing.Point(315, 29);
            this.btn_asadas_cliente_medidores_add.Name = "btn_asadas_cliente_medidores_add";
            this.btn_asadas_cliente_medidores_add.Size = new System.Drawing.Size(64, 24);
            this.btn_asadas_cliente_medidores_add.TabIndex = 78;
            this.btn_asadas_cliente_medidores_add.Text = "Agregar";
            this.btn_asadas_cliente_medidores_add.UseVisualStyleBackColor = true;
            this.btn_asadas_cliente_medidores_add.Click += new System.EventHandler(this.btn_asadas_cliente_medidores_add_Click);
            // 
            // txt_client_asada_medidor
            // 
            this.txt_client_asada_medidor.Location = new System.Drawing.Point(147, 28);
            this.txt_client_asada_medidor.Name = "txt_client_asada_medidor";
            this.txt_client_asada_medidor.Size = new System.Drawing.Size(76, 20);
            this.txt_client_asada_medidor.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(173, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Medidor";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_clients_asada_tipo
            // 
            this.cmb_clients_asada_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_clients_asada_tipo.FormattingEnabled = true;
            this.cmb_clients_asada_tipo.Location = new System.Drawing.Point(6, 29);
            this.cmb_clients_asada_tipo.Name = "cmb_clients_asada_tipo";
            this.cmb_clients_asada_tipo.Size = new System.Drawing.Size(135, 21);
            this.cmb_clients_asada_tipo.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(36, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tipo Pago";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_client_asada_lectura
            // 
            this.txt_client_asada_lectura.Location = new System.Drawing.Point(229, 28);
            this.txt_client_asada_lectura.Name = "txt_client_asada_lectura";
            this.txt_client_asada_lectura.Size = new System.Drawing.Size(80, 20);
            this.txt_client_asada_lectura.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(229, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Lectura inicial";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lv_facturas_abonos
            // 
            this.lv_facturas_abonos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_facturas_abonos.FullRowSelect = true;
            this.lv_facturas_abonos.GridLines = true;
            this.lv_facturas_abonos.HideSelection = false;
            this.lv_facturas_abonos.Location = new System.Drawing.Point(12, 386);
            this.lv_facturas_abonos.Name = "lv_facturas_abonos";
            this.lv_facturas_abonos.Size = new System.Drawing.Size(968, 160);
            this.lv_facturas_abonos.TabIndex = 93;
            this.lv_facturas_abonos.UseCompatibleStateImageBehavior = false;
            this.lv_facturas_abonos.View = System.Windows.Forms.View.Details;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_invoice_cxc_antiguedad_saldos);
            this.tabPage3.Controls.Add(this.btn_invoice_cxc_saldos);
            this.tabPage3.Controls.Add(this.invoice_wb1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(986, 639);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Reportes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_invoice_cxc_antiguedad_saldos
            // 
            this.btn_invoice_cxc_antiguedad_saldos.Location = new System.Drawing.Point(182, 10);
            this.btn_invoice_cxc_antiguedad_saldos.Name = "btn_invoice_cxc_antiguedad_saldos";
            this.btn_invoice_cxc_antiguedad_saldos.Size = new System.Drawing.Size(163, 39);
            this.btn_invoice_cxc_antiguedad_saldos.TabIndex = 79;
            this.btn_invoice_cxc_antiguedad_saldos.Text = "Reporte de Antiguedad Saldos";
            this.btn_invoice_cxc_antiguedad_saldos.UseVisualStyleBackColor = true;
            // 
            // btn_invoice_cxc_saldos
            // 
            this.btn_invoice_cxc_saldos.Location = new System.Drawing.Point(13, 10);
            this.btn_invoice_cxc_saldos.Name = "btn_invoice_cxc_saldos";
            this.btn_invoice_cxc_saldos.Size = new System.Drawing.Size(163, 39);
            this.btn_invoice_cxc_saldos.TabIndex = 78;
            this.btn_invoice_cxc_saldos.Text = "Reporte de Saldos";
            this.btn_invoice_cxc_saldos.UseVisualStyleBackColor = true;
            // 
            // invoice_wb1
            // 
            this.invoice_wb1.Location = new System.Drawing.Point(13, 55);
            this.invoice_wb1.MinimumSize = new System.Drawing.Size(20, 20);
            this.invoice_wb1.Name = "invoice_wb1";
            this.invoice_wb1.Size = new System.Drawing.Size(955, 570);
            this.invoice_wb1.TabIndex = 72;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(986, 639);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Importador";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frm_invoice_asadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_invoice_asadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asadas";
            this.grp_invoice_client.ResumeLayout(false);
            this.grp_invoice_client.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.grp_asadas_medidores.ResumeLayout(false);
            this.grp_asadas_medidores.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grp_invoice_client;
        private System.Windows.Forms.TextBox txt_clients_search_all;
        private System.Windows.Forms.Button btn_asadas_buscar;
        private System.Windows.Forms.ListView lv_asadas_clients_search_results;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lv_invoices;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lv_facturas_abonos;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox grp_asadas_medidores;
        private System.Windows.Forms.TextBox txt_client_asada_medidor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_clients_asada_tipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_client_asada_lectura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_asadas_cliente_medidores_add;
        private System.Windows.Forms.ListView lv_asadas_clients_medidores;
        private System.Windows.Forms.Button btn_invoice_cxc_antiguedad_saldos;
        private System.Windows.Forms.Button btn_invoice_cxc_saldos;
        private System.Windows.Forms.WebBrowser invoice_wb1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}