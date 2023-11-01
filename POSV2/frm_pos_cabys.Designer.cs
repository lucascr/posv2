namespace POSV2
{
    partial class frm_pos_cabys
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
            this.btn_update_cabys = new System.Windows.Forms.Button();
            this.btn_update_excel = new System.Windows.Forms.Button();
            this.cmb_xls_sku = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_xls_descripcion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_xls_cabys = new System.Windows.Forms.ComboBox();
            this.btn_read_excel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1_label1 = new System.Windows.Forms.Label();
            this.lbl_progressBar1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_xls_sheet = new System.Windows.Forms.Label();
            this.lbl_xls_path = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_cabys_60k_do = new System.Windows.Forms.Button();
            this.btn_load_60k = new System.Windows.Forms.Button();
            this.btn_actualizar_cabys = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_xls_codigobarras = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_update_sku = new System.Windows.Forms.Button();
            this.btn_download = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.cmb_xls_telefono = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_xls_cedula = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_xls_num_medidor = new System.Windows.Forms.ComboBox();
            this.btn_asada_subir_excel = new System.Windows.Forms.Button();
            this.cmb_xls_primera_lectura = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_xls_nombre = new System.Windows.Forms.ComboBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_xls_apellido = new System.Windows.Forms.ComboBox();
            this.btn_import_excel = new System.Windows.Forms.Button();
            this.cmb_xls_asada_tipo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.cmb_xls_asada_lectura_medidor = new System.Windows.Forms.ComboBox();
            this.btn_asada_subir_lectura_excel = new System.Windows.Forms.Button();
            this.cmb_xls_asada_lectura_lectura = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cmb_xls_asada_lectura_nombre = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cmb_xls_asada_lectura_apellido = new System.Windows.Forms.ComboBox();
            this.btn_import_excel_lecturas = new System.Windows.Forms.Button();
            this.cmb_xls_asada_lectura_periodo = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_update_cabys
            // 
            this.btn_update_cabys.Location = new System.Drawing.Point(22, 22);
            this.btn_update_cabys.Name = "btn_update_cabys";
            this.btn_update_cabys.Size = new System.Drawing.Size(172, 25);
            this.btn_update_cabys.TabIndex = 0;
            this.btn_update_cabys.Text = "Actualizar MASTER CABYS ";
            this.btn_update_cabys.UseVisualStyleBackColor = true;
            this.btn_update_cabys.Click += new System.EventHandler(this.btn_update_cabys_Click);
            // 
            // btn_update_excel
            // 
            this.btn_update_excel.Enabled = false;
            this.btn_update_excel.Location = new System.Drawing.Point(358, 154);
            this.btn_update_excel.Name = "btn_update_excel";
            this.btn_update_excel.Size = new System.Drawing.Size(172, 25);
            this.btn_update_excel.TabIndex = 1;
            this.btn_update_excel.Text = "Subir EXCEL";
            this.btn_update_excel.UseVisualStyleBackColor = true;
            this.btn_update_excel.Click += new System.EventHandler(this.btn_update_excel_Click);
            // 
            // cmb_xls_sku
            // 
            this.cmb_xls_sku.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_sku.FormattingEnabled = true;
            this.cmb_xls_sku.Location = new System.Drawing.Point(161, 128);
            this.cmb_xls_sku.Name = "cmb_xls_sku";
            this.cmb_xls_sku.Size = new System.Drawing.Size(369, 21);
            this.cmb_xls_sku.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 31);
            this.label3.TabIndex = 88;
            this.label3.Text = "Codigo Proveedor (SKU) (Opcional)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(18, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 19);
            this.label2.TabIndex = 86;
            this.label2.Text = "Codigo Cabys ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_xls_descripcion
            // 
            this.cmb_xls_descripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_descripcion.FormattingEnabled = true;
            this.cmb_xls_descripcion.Location = new System.Drawing.Point(161, 101);
            this.cmb_xls_descripcion.Name = "cmb_xls_descripcion";
            this.cmb_xls_descripcion.Size = new System.Drawing.Size(369, 21);
            this.cmb_xls_descripcion.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 19);
            this.label1.TabIndex = 84;
            this.label1.Text = "Descripcion (Opcional)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_xls_cabys
            // 
            this.cmb_xls_cabys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_cabys.FormattingEnabled = true;
            this.cmb_xls_cabys.Location = new System.Drawing.Point(161, 74);
            this.cmb_xls_cabys.Name = "cmb_xls_cabys";
            this.cmb_xls_cabys.Size = new System.Drawing.Size(369, 21);
            this.cmb_xls_cabys.TabIndex = 85;
            // 
            // btn_read_excel
            // 
            this.btn_read_excel.Location = new System.Drawing.Point(358, 16);
            this.btn_read_excel.Name = "btn_read_excel";
            this.btn_read_excel.Size = new System.Drawing.Size(172, 25);
            this.btn_read_excel.TabIndex = 89;
            this.btn_read_excel.Text = "Leer EXCEL";
            this.btn_read_excel.UseVisualStyleBackColor = true;
            this.btn_read_excel.Click += new System.EventHandler(this.btn_read_excel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1_label1
            // 
            this.progressBar1_label1.Location = new System.Drawing.Point(226, 216);
            this.progressBar1_label1.Name = "progressBar1_label1";
            this.progressBar1_label1.Size = new System.Drawing.Size(132, 19);
            this.progressBar1_label1.TabIndex = 92;
            this.progressBar1_label1.Text = "Importar";
            this.progressBar1_label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_progressBar1
            // 
            this.lbl_progressBar1.AutoSize = true;
            this.lbl_progressBar1.Location = new System.Drawing.Point(364, 216);
            this.lbl_progressBar1.Name = "lbl_progressBar1";
            this.lbl_progressBar1.Size = new System.Drawing.Size(13, 13);
            this.lbl_progressBar1.TabIndex = 91;
            this.lbl_progressBar1.Text = "0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(163, 216);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(369, 23);
            this.progressBar1.TabIndex = 90;
            // 
            // lbl_xls_sheet
            // 
            this.lbl_xls_sheet.BackColor = System.Drawing.Color.White;
            this.lbl_xls_sheet.Location = new System.Drawing.Point(3, 271);
            this.lbl_xls_sheet.Name = "lbl_xls_sheet";
            this.lbl_xls_sheet.Size = new System.Drawing.Size(760, 19);
            this.lbl_xls_sheet.TabIndex = 145;
            this.lbl_xls_sheet.Text = ".";
            this.lbl_xls_sheet.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_xls_path
            // 
            this.lbl_xls_path.BackColor = System.Drawing.Color.White;
            this.lbl_xls_path.Location = new System.Drawing.Point(6, 252);
            this.lbl_xls_path.Name = "lbl_xls_path";
            this.lbl_xls_path.Size = new System.Drawing.Size(757, 19);
            this.lbl_xls_path.TabIndex = 144;
            this.lbl_xls_path.Text = ".";
            this.lbl_xls_path.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1118, 549);
            this.tabControl1.TabIndex = 146;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_cabys_60k_do);
            this.tabPage1.Controls.Add(this.btn_load_60k);
            this.tabPage1.Controls.Add(this.btn_actualizar_cabys);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cmb_xls_codigobarras);
            this.tabPage1.Controls.Add(this.btn_read_excel);
            this.tabPage1.Controls.Add(this.lbl_xls_sheet);
            this.tabPage1.Controls.Add(this.btn_update_excel);
            this.tabPage1.Controls.Add(this.lbl_xls_path);
            this.tabPage1.Controls.Add(this.cmb_xls_cabys);
            this.tabPage1.Controls.Add(this.progressBar1_label1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lbl_progressBar1);
            this.tabPage1.Controls.Add(this.cmb_xls_descripcion);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cmb_xls_sku);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1110, 523);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cargar EXCEL Proveedores";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_cabys_60k_do
            // 
            this.btn_cabys_60k_do.Location = new System.Drawing.Point(329, 293);
            this.btn_cabys_60k_do.Name = "btn_cabys_60k_do";
            this.btn_cabys_60k_do.Size = new System.Drawing.Size(242, 25);
            this.btn_cabys_60k_do.TabIndex = 150;
            this.btn_cabys_60k_do.Text = "Do 50K Proceso 2";
            this.btn_cabys_60k_do.UseVisualStyleBackColor = true;
            this.btn_cabys_60k_do.Click += new System.EventHandler(this.btn_cabys_60k_do_Click);
            // 
            // btn_load_60k
            // 
            this.btn_load_60k.Location = new System.Drawing.Point(81, 293);
            this.btn_load_60k.Name = "btn_load_60k";
            this.btn_load_60k.Size = new System.Drawing.Size(242, 25);
            this.btn_load_60k.TabIndex = 149;
            this.btn_load_60k.Text = "CABYS 60K Download Proceso 1 ";
            this.btn_load_60k.UseVisualStyleBackColor = true;
            this.btn_load_60k.Click += new System.EventHandler(this.btn_load_60k_Click);
            // 
            // btn_actualizar_cabys
            // 
            this.btn_actualizar_cabys.Enabled = false;
            this.btn_actualizar_cabys.Location = new System.Drawing.Point(358, 185);
            this.btn_actualizar_cabys.Name = "btn_actualizar_cabys";
            this.btn_actualizar_cabys.Size = new System.Drawing.Size(172, 25);
            this.btn_actualizar_cabys.TabIndex = 148;
            this.btn_actualizar_cabys.Text = "Actualizar CABYS";
            this.btn_actualizar_cabys.UseVisualStyleBackColor = true;
            this.btn_actualizar_cabys.Click += new System.EventHandler(this.btn_actualizar_cabys_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(18, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 19);
            this.label4.TabIndex = 147;
            this.label4.Text = "Codigo Barra";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_xls_codigobarras
            // 
            this.cmb_xls_codigobarras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_codigobarras.FormattingEnabled = true;
            this.cmb_xls_codigobarras.Location = new System.Drawing.Point(161, 47);
            this.cmb_xls_codigobarras.Name = "cmb_xls_codigobarras";
            this.cmb_xls_codigobarras.Size = new System.Drawing.Size(369, 21);
            this.cmb_xls_codigobarras.TabIndex = 146;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_update_sku);
            this.tabPage2.Controls.Add(this.btn_download);
            this.tabPage2.Controls.Add(this.btn_update_cabys);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1110, 523);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Descargar CABYS Master";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_update_sku
            // 
            this.btn_update_sku.Location = new System.Drawing.Point(22, 108);
            this.btn_update_sku.Name = "btn_update_sku";
            this.btn_update_sku.Size = new System.Drawing.Size(172, 25);
            this.btn_update_sku.TabIndex = 2;
            this.btn_update_sku.Text = "Actualizar SKU";
            this.btn_update_sku.UseVisualStyleBackColor = true;
            this.btn_update_sku.Click += new System.EventHandler(this.btn_update_sku_Click);
            // 
            // btn_download
            // 
            this.btn_download.Location = new System.Drawing.Point(22, 77);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(172, 25);
            this.btn_download.TabIndex = 1;
            this.btn_download.Text = "Descargar SKU";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1110, 523);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ASADA";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmb_xls_telefono);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmb_xls_cedula);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmb_xls_num_medidor);
            this.panel1.Controls.Add(this.btn_asada_subir_excel);
            this.panel1.Controls.Add(this.cmb_xls_primera_lectura);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmb_xls_nombre);
            this.panel1.Controls.Add(this.progressBar2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cmb_xls_apellido);
            this.panel1.Controls.Add(this.btn_import_excel);
            this.panel1.Controls.Add(this.cmb_xls_asada_tipo);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(14, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 419);
            this.panel1.TabIndex = 85;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 21);
            this.label10.TabIndex = 163;
            this.label10.Text = "Telefono";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_xls_telefono
            // 
            this.cmb_xls_telefono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_telefono.FormattingEnabled = true;
            this.cmb_xls_telefono.Location = new System.Drawing.Point(146, 218);
            this.cmb_xls_telefono.Name = "cmb_xls_telefono";
            this.cmb_xls_telefono.Size = new System.Drawing.Size(367, 21);
            this.cmb_xls_telefono.TabIndex = 162;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(1, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 21);
            this.label9.TabIndex = 161;
            this.label9.Text = "Cedula";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_xls_cedula
            // 
            this.cmb_xls_cedula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_cedula.FormattingEnabled = true;
            this.cmb_xls_cedula.Location = new System.Drawing.Point(146, 191);
            this.cmb_xls_cedula.Name = "cmb_xls_cedula";
            this.cmb_xls_cedula.Size = new System.Drawing.Size(367, 21);
            this.cmb_xls_cedula.TabIndex = 160;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 19);
            this.label5.TabIndex = 159;
            this.label5.Text = "Numero de Medidor";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_xls_num_medidor
            // 
            this.cmb_xls_num_medidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_num_medidor.FormattingEnabled = true;
            this.cmb_xls_num_medidor.Location = new System.Drawing.Point(146, 83);
            this.cmb_xls_num_medidor.Name = "cmb_xls_num_medidor";
            this.cmb_xls_num_medidor.Size = new System.Drawing.Size(367, 21);
            this.cmb_xls_num_medidor.TabIndex = 158;
            // 
            // btn_asada_subir_excel
            // 
            this.btn_asada_subir_excel.Enabled = false;
            this.btn_asada_subir_excel.Location = new System.Drawing.Point(341, 256);
            this.btn_asada_subir_excel.Name = "btn_asada_subir_excel";
            this.btn_asada_subir_excel.Size = new System.Drawing.Size(172, 25);
            this.btn_asada_subir_excel.TabIndex = 148;
            this.btn_asada_subir_excel.Text = "Subir EXCEL";
            this.btn_asada_subir_excel.UseVisualStyleBackColor = true;
            this.btn_asada_subir_excel.Click += new System.EventHandler(this.btn_asada_subir_excel_Click);
            // 
            // cmb_xls_primera_lectura
            // 
            this.cmb_xls_primera_lectura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_primera_lectura.FormattingEnabled = true;
            this.cmb_xls_primera_lectura.Location = new System.Drawing.Point(146, 110);
            this.cmb_xls_primera_lectura.Name = "cmb_xls_primera_lectura";
            this.cmb_xls_primera_lectura.Size = new System.Drawing.Size(367, 21);
            this.cmb_xls_primera_lectura.TabIndex = 151;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(209, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 19);
            this.label6.TabIndex = 157;
            this.label6.Text = "Importar";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(1, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 19);
            this.label7.TabIndex = 150;
            this.label7.Text = "Nombre";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(347, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 156;
            this.label8.Text = "0";
            // 
            // cmb_xls_nombre
            // 
            this.cmb_xls_nombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_nombre.FormattingEnabled = true;
            this.cmb_xls_nombre.Location = new System.Drawing.Point(146, 137);
            this.cmb_xls_nombre.Name = "cmb_xls_nombre";
            this.cmb_xls_nombre.Size = new System.Drawing.Size(367, 21);
            this.cmb_xls_nombre.TabIndex = 149;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(146, 318);
            this.progressBar2.Maximum = 1000;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(369, 23);
            this.progressBar2.TabIndex = 155;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(1, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 19);
            this.label11.TabIndex = 152;
            this.label11.Text = "Primera Lectura";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(1, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 31);
            this.label12.TabIndex = 154;
            this.label12.Text = "Apellido";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_xls_apellido
            // 
            this.cmb_xls_apellido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_apellido.FormattingEnabled = true;
            this.cmb_xls_apellido.Location = new System.Drawing.Point(146, 164);
            this.cmb_xls_apellido.Name = "cmb_xls_apellido";
            this.cmb_xls_apellido.Size = new System.Drawing.Size(367, 21);
            this.cmb_xls_apellido.TabIndex = 153;
            // 
            // btn_import_excel
            // 
            this.btn_import_excel.Location = new System.Drawing.Point(350, 11);
            this.btn_import_excel.Name = "btn_import_excel";
            this.btn_import_excel.Size = new System.Drawing.Size(163, 39);
            this.btn_import_excel.TabIndex = 80;
            this.btn_import_excel.Text = "Importar Excel";
            this.btn_import_excel.UseVisualStyleBackColor = true;
            this.btn_import_excel.Click += new System.EventHandler(this.btn_import_excel_Click);
            // 
            // cmb_xls_asada_tipo
            // 
            this.cmb_xls_asada_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_asada_tipo.FormattingEnabled = true;
            this.cmb_xls_asada_tipo.Location = new System.Drawing.Point(146, 56);
            this.cmb_xls_asada_tipo.Name = "cmb_xls_asada_tipo";
            this.cmb_xls_asada_tipo.Size = new System.Drawing.Size(367, 21);
            this.cmb_xls_asada_tipo.TabIndex = 82;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(25, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 14);
            this.label13.TabIndex = 81;
            this.label13.Text = "Tipo Pago";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.cmb_xls_asada_lectura_medidor);
            this.panel2.Controls.Add(this.btn_asada_subir_lectura_excel);
            this.panel2.Controls.Add(this.cmb_xls_asada_lectura_lectura);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.cmb_xls_asada_lectura_nombre);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.cmb_xls_asada_lectura_apellido);
            this.panel2.Controls.Add(this.btn_import_excel_lecturas);
            this.panel2.Controls.Add(this.cmb_xls_asada_lectura_periodo);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Location = new System.Drawing.Point(552, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 419);
            this.panel2.TabIndex = 164;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(27, 83);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 19);
            this.label16.TabIndex = 159;
            this.label16.Text = "Numero de Medidor";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_xls_asada_lectura_medidor
            // 
            this.cmb_xls_asada_lectura_medidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_asada_lectura_medidor.FormattingEnabled = true;
            this.cmb_xls_asada_lectura_medidor.Location = new System.Drawing.Point(144, 83);
            this.cmb_xls_asada_lectura_medidor.Name = "cmb_xls_asada_lectura_medidor";
            this.cmb_xls_asada_lectura_medidor.Size = new System.Drawing.Size(367, 21);
            this.cmb_xls_asada_lectura_medidor.TabIndex = 158;
            // 
            // btn_asada_subir_lectura_excel
            // 
            this.btn_asada_subir_lectura_excel.Enabled = false;
            this.btn_asada_subir_lectura_excel.Location = new System.Drawing.Point(339, 256);
            this.btn_asada_subir_lectura_excel.Name = "btn_asada_subir_lectura_excel";
            this.btn_asada_subir_lectura_excel.Size = new System.Drawing.Size(172, 25);
            this.btn_asada_subir_lectura_excel.TabIndex = 148;
            this.btn_asada_subir_lectura_excel.Text = "Subir EXCEL";
            this.btn_asada_subir_lectura_excel.UseVisualStyleBackColor = true;
            this.btn_asada_subir_lectura_excel.Click += new System.EventHandler(this.btn_asada_subir_lectura_excel_Click);
            // 
            // cmb_xls_asada_lectura_lectura
            // 
            this.cmb_xls_asada_lectura_lectura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_asada_lectura_lectura.FormattingEnabled = true;
            this.cmb_xls_asada_lectura_lectura.Location = new System.Drawing.Point(144, 110);
            this.cmb_xls_asada_lectura_lectura.Name = "cmb_xls_asada_lectura_lectura";
            this.cmb_xls_asada_lectura_lectura.Size = new System.Drawing.Size(367, 21);
            this.cmb_xls_asada_lectura_lectura.TabIndex = 151;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(27, 137);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 19);
            this.label18.TabIndex = 150;
            this.label18.Text = "Nombre";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_xls_asada_lectura_nombre
            // 
            this.cmb_xls_asada_lectura_nombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_asada_lectura_nombre.FormattingEnabled = true;
            this.cmb_xls_asada_lectura_nombre.Location = new System.Drawing.Point(144, 137);
            this.cmb_xls_asada_lectura_nombre.Name = "cmb_xls_asada_lectura_nombre";
            this.cmb_xls_asada_lectura_nombre.Size = new System.Drawing.Size(367, 21);
            this.cmb_xls_asada_lectura_nombre.TabIndex = 149;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(27, 110);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(107, 19);
            this.label20.TabIndex = 152;
            this.label20.Text = "Lectura Periodo";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(27, 164);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(107, 31);
            this.label21.TabIndex = 154;
            this.label21.Text = "Apellido";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_xls_asada_lectura_apellido
            // 
            this.cmb_xls_asada_lectura_apellido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_asada_lectura_apellido.FormattingEnabled = true;
            this.cmb_xls_asada_lectura_apellido.Location = new System.Drawing.Point(144, 164);
            this.cmb_xls_asada_lectura_apellido.Name = "cmb_xls_asada_lectura_apellido";
            this.cmb_xls_asada_lectura_apellido.Size = new System.Drawing.Size(367, 21);
            this.cmb_xls_asada_lectura_apellido.TabIndex = 153;
            // 
            // btn_import_excel_lecturas
            // 
            this.btn_import_excel_lecturas.Location = new System.Drawing.Point(348, 11);
            this.btn_import_excel_lecturas.Name = "btn_import_excel_lecturas";
            this.btn_import_excel_lecturas.Size = new System.Drawing.Size(163, 39);
            this.btn_import_excel_lecturas.TabIndex = 80;
            this.btn_import_excel_lecturas.Text = "Importar Excel Lecturas";
            this.btn_import_excel_lecturas.UseVisualStyleBackColor = true;
            this.btn_import_excel_lecturas.Click += new System.EventHandler(this.btn_import_excel_lecturas_Click);
            // 
            // cmb_xls_asada_lectura_periodo
            // 
            this.cmb_xls_asada_lectura_periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xls_asada_lectura_periodo.FormattingEnabled = true;
            this.cmb_xls_asada_lectura_periodo.Location = new System.Drawing.Point(144, 56);
            this.cmb_xls_asada_lectura_periodo.Name = "cmb_xls_asada_lectura_periodo";
            this.cmb_xls_asada_lectura_periodo.Size = new System.Drawing.Size(367, 21);
            this.cmb_xls_asada_lectura_periodo.TabIndex = 82;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(49, 58);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 14);
            this.label22.TabIndex = 81;
            this.label22.Text = "Periodo Facturacion";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frm_pos_cabys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 564);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_pos_cabys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CABYS";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_update_cabys;
        private System.Windows.Forms.Button btn_update_excel;
        private System.Windows.Forms.ComboBox cmb_xls_sku;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_xls_descripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_xls_cabys;
        private System.Windows.Forms.Button btn_read_excel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label progressBar1_label1;
        private System.Windows.Forms.Label lbl_progressBar1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_xls_sheet;
        private System.Windows.Forms.Label lbl_xls_path;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_update_sku;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_xls_codigobarras;
        private System.Windows.Forms.Button btn_actualizar_cabys;
        private System.Windows.Forms.Button btn_cabys_60k_do;
        private System.Windows.Forms.Button btn_load_60k;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmb_xls_telefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_xls_cedula;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_xls_num_medidor;
        private System.Windows.Forms.Button btn_asada_subir_excel;
        private System.Windows.Forms.ComboBox cmb_xls_primera_lectura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_xls_nombre;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_xls_apellido;
        private System.Windows.Forms.Button btn_import_excel;
        private System.Windows.Forms.ComboBox cmb_xls_asada_tipo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmb_xls_asada_lectura_medidor;
        private System.Windows.Forms.Button btn_asada_subir_lectura_excel;
        private System.Windows.Forms.ComboBox cmb_xls_asada_lectura_lectura;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmb_xls_asada_lectura_nombre;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmb_xls_asada_lectura_apellido;
        private System.Windows.Forms.Button btn_import_excel_lecturas;
        private System.Windows.Forms.ComboBox cmb_xls_asada_lectura_periodo;
        private System.Windows.Forms.Label label22;
    }
}