namespace POSV2
{
    partial class frm_pos_invoice
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_pos_invoice));
            this.lv_invoice_detail = new System.Windows.Forms.ListView();
            this.txt_invoice_line_barcode = new System.Windows.Forms.TextBox();
            this.txt_invoice_line_qty = new System.Windows.Forms.TextBox();
            this.txt_invoice_line_description = new System.Windows.Forms.TextBox();
            this.txt_invoice_line_price = new System.Windows.Forms.TextBox();
            this.lbl_invoice_line_barcode = new System.Windows.Forms.Label();
            this.lbl_invoice_line_description = new System.Windows.Forms.Label();
            this.lbl_invoice_line_qty = new System.Windows.Forms.Label();
            this.lbl_invoice_line_price = new System.Windows.Forms.Label();
            this.lbl_invoice_sale_type = new System.Windows.Forms.Label();
            this.cmb_invoice_sale_type = new System.Windows.Forms.ComboBox();
            this.lbl_invoice_client_phone_number = new System.Windows.Forms.Label();
            this.txt_invoice_client_phone_number = new System.Windows.Forms.TextBox();
            this.lbl_invoice_client_name = new System.Windows.Forms.Label();
            this.txt_invoice_client_name = new System.Windows.Forms.TextBox();
            this.lbl_invoice_client_identification = new System.Windows.Forms.Label();
            this.txt_invoice_client_identification = new System.Windows.Forms.TextBox();
            this.btn_invoice_client_add = new System.Windows.Forms.Button();
            this.lbl_invoice_credit_days = new System.Windows.Forms.Label();
            this.txt_invoice_credit_days = new System.Windows.Forms.TextBox();
            this.lbl_invoice_document_type = new System.Windows.Forms.Label();
            this.grp_invoice_client = new System.Windows.Forms.GroupBox();
            this.btn_exoneracion_show = new System.Windows.Forms.Button();
            this.lbl_id_client = new System.Windows.Forms.Label();
            this.cmb_invoice_clients_id_type = new System.Windows.Forms.ComboBox();
            this.txt_invoice_client_email = new System.Windows.Forms.TextBox();
            this.lbl_invoice_client_email = new System.Windows.Forms.Label();
            this.lbl_invoice_cur = new System.Windows.Forms.Label();
            this.cmb_invoice_cur = new System.Windows.Forms.ComboBox();
            this.lbl_invoice_exchange = new System.Windows.Forms.Label();
            this.txt_invoice_cur = new System.Windows.Forms.TextBox();
            this.txt_invoice_line_price_total = new System.Windows.Forms.TextBox();
            this.lbl_invoice_line_total = new System.Windows.Forms.Label();
            this.mnuS1 = new System.Windows.Forms.MenuStrip();
            this.lbl_invoice_line_tax = new System.Windows.Forms.Label();
            this.cmb_invoice_document_type = new System.Windows.Forms.ComboBox();
            this.lbl_invoice_line_barcode_result = new System.Windows.Forms.Label();
            this.txt_invoice_line_price_tax = new System.Windows.Forms.TextBox();
            this.txt_invoice_line_sym = new System.Windows.Forms.Label();
            this.txt_invoice_line_cur = new System.Windows.Forms.Label();
            this.txt_invoice_line_tax = new System.Windows.Forms.Label();
            this.cmb_btn_action = new System.Windows.Forms.ComboBox();
            this.lbl_edit_invoice_line = new System.Windows.Forms.Label();
            this.grp_invoice_header = new System.Windows.Forms.GroupBox();
            this.cmb_invoice_act_eco = new System.Windows.Forms.ComboBox();
            this.lbl_invoice_cod_act_eco = new System.Windows.Forms.Label();
            this.txt_invoice_line_sym_unit = new System.Windows.Forms.Label();
            this.lbl_invoice_subtotal = new System.Windows.Forms.Label();
            this.lbl_invoice_total_tax = new System.Windows.Forms.Label();
            this.lbl_invoice_total = new System.Windows.Forms.Label();
            this.txt_invoice_totals_subtotal = new System.Windows.Forms.TextBox();
            this.txt_invoice_totals_tax = new System.Windows.Forms.TextBox();
            this.txt_invoice_totals_total = new System.Windows.Forms.TextBox();
            this.grp_fe_calculos = new System.Windows.Forms.GroupBox();
            this.lbl_computer_name = new System.Windows.Forms.Label();
            this.txt_TotalComprobante = new System.Windows.Forms.TextBox();
            this.txt_TotalImpuesto = new System.Windows.Forms.TextBox();
            this.txt_TotalVentaNeta = new System.Windows.Forms.TextBox();
            this.txt_TotalDescuentos = new System.Windows.Forms.TextBox();
            this.txt_TotalVenta = new System.Windows.Forms.TextBox();
            this.txt_TotalExento = new System.Windows.Forms.TextBox();
            this.txt_TotalGravado = new System.Windows.Forms.TextBox();
            this.txt_TotalMercanciasExentas = new System.Windows.Forms.TextBox();
            this.txt_TotalMercanciasGravadas = new System.Windows.Forms.TextBox();
            this.txt_TotalServExentos = new System.Windows.Forms.TextBox();
            this.txt_TotalServGravados = new System.Windows.Forms.TextBox();
            this.lbl_TotalServGravados = new System.Windows.Forms.Label();
            this.lbl_TotalComprobante = new System.Windows.Forms.Label();
            this.lbl_TotalServExentos = new System.Windows.Forms.Label();
            this.lbl_TotalImpuesto = new System.Windows.Forms.Label();
            this.lbl_TotalMercanciasGravadas = new System.Windows.Forms.Label();
            this.lbl_TotalVentaNeta = new System.Windows.Forms.Label();
            this.lbl_TotalMercanciasExentas = new System.Windows.Forms.Label();
            this.lbl_TotalDescuentos = new System.Windows.Forms.Label();
            this.lbl_TotalGravado = new System.Windows.Forms.Label();
            this.lbl_TotalVenta = new System.Windows.Forms.Label();
            this.lbl_TotalExento = new System.Windows.Forms.Label();
            this.btn_invoice_save_email = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txt_invoice_line_id_producto = new System.Windows.Forms.Label();
            this.txt_invoice_line_tax_code = new System.Windows.Forms.Label();
            this.txt_invoice_line_sym_code_type = new System.Windows.Forms.Label();
            this.txt_invoice_line_price_subtotal = new System.Windows.Forms.TextBox();
            this.txt_cal_pagacon = new System.Windows.Forms.TextBox();
            this.txt_cal_vuelto = new System.Windows.Forms.TextBox();
            this.lbl_cal_vuelto = new System.Windows.Forms.Label();
            this.lbl_cal_pagacon = new System.Windows.Forms.Label();
            this.btn_col1 = new System.Windows.Forms.Button();
            this.btn_col2 = new System.Windows.Forms.Button();
            this.btn_col3 = new System.Windows.Forms.Button();
            this.btn_col4 = new System.Windows.Forms.Button();
            this.btn_col5 = new System.Windows.Forms.Button();
            this.btn_col6 = new System.Windows.Forms.Button();
            this.grp_efectivo = new System.Windows.Forms.GroupBox();
            this.btn_efectivo = new System.Windows.Forms.Button();
            this.btn_cred = new System.Windows.Forms.Button();
            this.grp_exoneracion = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_exoneraciones_clear = new System.Windows.Forms.Button();
            this.lbl_exoneracion_porcentaje_exoneracion = new System.Windows.Forms.Label();
            this.btn_exoneracion_save = new System.Windows.Forms.Button();
            this.lbl_exoneracion_fecha_emision = new System.Windows.Forms.Label();
            this.txt_exoneracion_porcentaje_exoneracion = new System.Windows.Forms.TextBox();
            this.lbl_exoneracion_nombre_institucion = new System.Windows.Forms.Label();
            this.txt_exoneracion_nombre_institucion = new System.Windows.Forms.TextBox();
            this.txt_exoneracion_fecha_emision = new System.Windows.Forms.TextBox();
            this.lbl_exoneracion_numero_documento = new System.Windows.Forms.Label();
            this.txt_exoneracion_numero_documento = new System.Windows.Forms.TextBox();
            this.cmb_exoneracion_tipo_documento = new System.Windows.Forms.ComboBox();
            this.lbl_exoneracion_tipo_documento = new System.Windows.Forms.Label();
            this.pb_internet = new System.Windows.Forms.PictureBox();
            this.lv_client = new System.Windows.Forms.ListView();
            this.chk_lock_invoice_detail_qty = new System.Windows.Forms.CheckBox();
            this.btn_abarrotes_exento = new System.Windows.Forms.Button();
            this.txt_company_name = new System.Windows.Forms.TextBox();
            this.txt_company_identification = new System.Windows.Forms.TextBox();
            this.grpClientes = new System.Windows.Forms.GroupBox();
            this.btn_invoice_client_search_close = new System.Windows.Forms.Button();
            this.pb1 = new System.Windows.Forms.ProgressBar();
            this.btn_search_cloud_api = new System.Windows.Forms.Button();
            this.lbl_pb = new System.Windows.Forms.Label();
            this.grpFe = new System.Windows.Forms.GroupBox();
            this.txt_lv_fe_report = new System.Windows.Forms.TextBox();
            this.btn_fe_aceptar = new System.Windows.Forms.Button();
            this.lv_fe_report = new System.Windows.Forms.ListView();
            this.pb_fe = new System.Windows.Forms.ProgressBar();
            this.txt_company_id = new System.Windows.Forms.TextBox();
            this.btn_abarrotes_gravado = new System.Windows.Forms.Button();
            this.txt_company_ter = new System.Windows.Forms.TextBox();
            this.lv_product_search = new System.Windows.Forms.ListView();
            this.chk_lock_invoice_detail_search_description = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_invoice_save_print = new System.Windows.Forms.Button();
            this.il_internet = new System.Windows.Forms.ImageList(this.components);
            this.lbl_invoice_pending = new System.Windows.Forms.Label();
            this.timer_invoice_pending = new System.Windows.Forms.Timer(this.components);
            this.timer_invoice_db = new System.Windows.Forms.Timer(this.components);
            this.pnl_pendientes = new System.Windows.Forms.Panel();
            this.lbl_enviando = new System.Windows.Forms.Label();
            this.txt_invoice_cliente_saldo = new System.Windows.Forms.TextBox();
            this.lbl_invoice_cliente_saldo = new System.Windows.Forms.Label();
            this.txt_invoice_line_tax_code_iva = new System.Windows.Forms.Label();
            this.lbl_sel_tipo_doc = new System.Windows.Forms.Label();
            this.grp_descuento = new System.Windows.Forms.GroupBox();
            this.lbl_descuentos_precio_iva = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_descuentos_precio_final = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_descuentos_precio_original = new System.Windows.Forms.Label();
            this.lbl_descuento_producto_descripcion = new System.Windows.Forms.Label();
            this.btn_descuentos_cerrar = new System.Windows.Forms.Button();
            this.lbl_descuentos_precio_final = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_descuentos_aplicar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_descuentos_monto = new System.Windows.Forms.TextBox();
            this.txt_descuentos_razon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_descuentos_porcentaje = new System.Windows.Forms.TextBox();
            this.btn_abarrotes_canastabasica = new System.Windows.Forms.Button();
            this.lbl_invoice_line_cabys_desc = new System.Windows.Forms.Label();
            this.txt_invoice_line_cabys_code = new System.Windows.Forms.TextBox();
            this.txt_invoice_line_price_descuento_monto = new System.Windows.Forms.TextBox();
            this.txt_invoice_line_price_descuento_razon = new System.Windows.Forms.TextBox();
            this.TotalDescuento = new System.Windows.Forms.PictureBox();
            this.grp_descuento_total = new System.Windows.Forms.GroupBox();
            this.lbl_descuentos_total_original = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_descuentos_total_precio_final = new System.Windows.Forms.TextBox();
            this.btn_descuentos_total_cerrar = new System.Windows.Forms.Button();
            this.btn_descuentos_total_aplicar = new System.Windows.Forms.Button();
            this.grp_invoice_client.SuspendLayout();
            this.grp_invoice_header.SuspendLayout();
            this.grp_fe_calculos.SuspendLayout();
            this.grp_efectivo.SuspendLayout();
            this.grp_exoneracion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_internet)).BeginInit();
            this.grpClientes.SuspendLayout();
            this.grpFe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_pendientes.SuspendLayout();
            this.grp_descuento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDescuento)).BeginInit();
            this.grp_descuento_total.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_invoice_detail
            // 
            this.lv_invoice_detail.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lv_invoice_detail.FullRowSelect = true;
            this.lv_invoice_detail.GridLines = true;
            this.lv_invoice_detail.HideSelection = false;
            this.lv_invoice_detail.Location = new System.Drawing.Point(6, 294);
            this.lv_invoice_detail.Name = "lv_invoice_detail";
            this.lv_invoice_detail.Size = new System.Drawing.Size(960, 211);
            this.lv_invoice_detail.TabIndex = 7;
            this.lv_invoice_detail.UseCompatibleStateImageBehavior = false;
            this.lv_invoice_detail.View = System.Windows.Forms.View.Details;
            // 
            // txt_invoice_line_barcode
            // 
            this.txt_invoice_line_barcode.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_barcode.Location = new System.Drawing.Point(7, 226);
            this.txt_invoice_line_barcode.Name = "txt_invoice_line_barcode";
            this.txt_invoice_line_barcode.Size = new System.Drawing.Size(105, 22);
            this.txt_invoice_line_barcode.TabIndex = 0;
            this.txt_invoice_line_barcode.Text = "1234567890123456";
            this.txt_invoice_line_barcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_invoice_barcode_line_KeyUp);
            this.txt_invoice_line_barcode.Leave += new System.EventHandler(this.txt_invoice_barcode_line_Leave);
            // 
            // txt_invoice_line_qty
            // 
            this.txt_invoice_line_qty.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_qty.Location = new System.Drawing.Point(519, 226);
            this.txt_invoice_line_qty.Name = "txt_invoice_line_qty";
            this.txt_invoice_line_qty.Size = new System.Drawing.Size(39, 22);
            this.txt_invoice_line_qty.TabIndex = 2;
            this.txt_invoice_line_qty.Text = "99999";
            this.txt_invoice_line_qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_invoice_qty_KeyPress);
            this.txt_invoice_line_qty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_invoice_qty_KeyUp);
            this.txt_invoice_line_qty.Leave += new System.EventHandler(this.txt_invoice_qty_Leave);
            // 
            // txt_invoice_line_description
            // 
            this.txt_invoice_line_description.BackColor = System.Drawing.SystemColors.Window;
            this.txt_invoice_line_description.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_description.Location = new System.Drawing.Point(115, 226);
            this.txt_invoice_line_description.Name = "txt_invoice_line_description";
            this.txt_invoice_line_description.Size = new System.Drawing.Size(401, 22);
            this.txt_invoice_line_description.TabIndex = 1;
            this.txt_invoice_line_description.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_invoice_line_description_KeyUp);
            this.txt_invoice_line_description.Leave += new System.EventHandler(this.txt_invoice_line_description_Leave);
            // 
            // txt_invoice_line_price
            // 
            this.txt_invoice_line_price.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_price.Location = new System.Drawing.Point(565, 226);
            this.txt_invoice_line_price.Name = "txt_invoice_line_price";
            this.txt_invoice_line_price.ReadOnly = true;
            this.txt_invoice_line_price.Size = new System.Drawing.Size(85, 22);
            this.txt_invoice_line_price.TabIndex = 3;
            this.txt_invoice_line_price.Text = "999,999,999.12";
            // 
            // lbl_invoice_line_barcode
            // 
            this.lbl_invoice_line_barcode.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_line_barcode.Location = new System.Drawing.Point(7, 211);
            this.lbl_invoice_line_barcode.Name = "lbl_invoice_line_barcode";
            this.lbl_invoice_line_barcode.Size = new System.Drawing.Size(108, 14);
            this.lbl_invoice_line_barcode.TabIndex = 43;
            this.lbl_invoice_line_barcode.Text = "Barcode";
            // 
            // lbl_invoice_line_description
            // 
            this.lbl_invoice_line_description.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_line_description.Location = new System.Drawing.Point(158, 210);
            this.lbl_invoice_line_description.Name = "lbl_invoice_line_description";
            this.lbl_invoice_line_description.Size = new System.Drawing.Size(267, 14);
            this.lbl_invoice_line_description.TabIndex = 44;
            this.lbl_invoice_line_description.Text = "Description";
            // 
            // lbl_invoice_line_qty
            // 
            this.lbl_invoice_line_qty.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_line_qty.Location = new System.Drawing.Point(519, 209);
            this.lbl_invoice_line_qty.Name = "lbl_invoice_line_qty";
            this.lbl_invoice_line_qty.Size = new System.Drawing.Size(41, 14);
            this.lbl_invoice_line_qty.TabIndex = 45;
            this.lbl_invoice_line_qty.Text = "QTY";
            // 
            // lbl_invoice_line_price
            // 
            this.lbl_invoice_line_price.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_line_price.Location = new System.Drawing.Point(565, 209);
            this.lbl_invoice_line_price.Name = "lbl_invoice_line_price";
            this.lbl_invoice_line_price.Size = new System.Drawing.Size(85, 14);
            this.lbl_invoice_line_price.TabIndex = 46;
            this.lbl_invoice_line_price.Text = "Price";
            // 
            // lbl_invoice_sale_type
            // 
            this.lbl_invoice_sale_type.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_sale_type.Location = new System.Drawing.Point(508, 19);
            this.lbl_invoice_sale_type.Name = "lbl_invoice_sale_type";
            this.lbl_invoice_sale_type.Size = new System.Drawing.Size(91, 14);
            this.lbl_invoice_sale_type.TabIndex = 55;
            this.lbl_invoice_sale_type.Text = "Sale Type";
            // 
            // cmb_invoice_sale_type
            // 
            this.cmb_invoice_sale_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_invoice_sale_type.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmb_invoice_sale_type.FormattingEnabled = true;
            this.cmb_invoice_sale_type.Location = new System.Drawing.Point(508, 39);
            this.cmb_invoice_sale_type.Name = "cmb_invoice_sale_type";
            this.cmb_invoice_sale_type.Size = new System.Drawing.Size(148, 21);
            this.cmb_invoice_sale_type.TabIndex = 3;
            this.cmb_invoice_sale_type.SelectedIndexChanged += new System.EventHandler(this.cmb_invoice_sale_type_SelectedIndexChanged);
            // 
            // lbl_invoice_client_phone_number
            // 
            this.lbl_invoice_client_phone_number.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_client_phone_number.Location = new System.Drawing.Point(258, 18);
            this.lbl_invoice_client_phone_number.Name = "lbl_invoice_client_phone_number";
            this.lbl_invoice_client_phone_number.Size = new System.Drawing.Size(102, 14);
            this.lbl_invoice_client_phone_number.TabIndex = 57;
            this.lbl_invoice_client_phone_number.Text = "Phone (optional)";
            // 
            // txt_invoice_client_phone_number
            // 
            this.txt_invoice_client_phone_number.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_client_phone_number.Location = new System.Drawing.Point(258, 40);
            this.txt_invoice_client_phone_number.Name = "txt_invoice_client_phone_number";
            this.txt_invoice_client_phone_number.Size = new System.Drawing.Size(107, 22);
            this.txt_invoice_client_phone_number.TabIndex = 162;
            this.txt_invoice_client_phone_number.TextChanged += new System.EventHandler(this.txt_invoice_client_phone_number_TextChanged);
            // 
            // lbl_invoice_client_name
            // 
            this.lbl_invoice_client_name.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_client_name.Location = new System.Drawing.Point(366, 18);
            this.lbl_invoice_client_name.Name = "lbl_invoice_client_name";
            this.lbl_invoice_client_name.Size = new System.Drawing.Size(243, 14);
            this.lbl_invoice_client_name.TabIndex = 59;
            this.lbl_invoice_client_name.Text = "Name";
            // 
            // txt_invoice_client_name
            // 
            this.txt_invoice_client_name.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_client_name.Location = new System.Drawing.Point(366, 40);
            this.txt_invoice_client_name.Name = "txt_invoice_client_name";
            this.txt_invoice_client_name.Size = new System.Drawing.Size(254, 22);
            this.txt_invoice_client_name.TabIndex = 163;
            this.txt_invoice_client_name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_invoice_client_name_KeyUp);
            // 
            // lbl_invoice_client_identification
            // 
            this.lbl_invoice_client_identification.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_client_identification.Location = new System.Drawing.Point(134, 18);
            this.lbl_invoice_client_identification.Name = "lbl_invoice_client_identification";
            this.lbl_invoice_client_identification.Size = new System.Drawing.Size(92, 14);
            this.lbl_invoice_client_identification.TabIndex = 62;
            this.lbl_invoice_client_identification.Text = "Identification";
            // 
            // txt_invoice_client_identification
            // 
            this.txt_invoice_client_identification.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_client_identification.Location = new System.Drawing.Point(134, 40);
            this.txt_invoice_client_identification.Name = "txt_invoice_client_identification";
            this.txt_invoice_client_identification.Size = new System.Drawing.Size(123, 22);
            this.txt_invoice_client_identification.TabIndex = 161;
            this.txt_invoice_client_identification.TextChanged += new System.EventHandler(this.txt_invoice_client_identification_TextChanged);
            this.txt_invoice_client_identification.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_invoice_client_identification_KeyUp);
            this.txt_invoice_client_identification.Leave += new System.EventHandler(this.txt_invoice_client_identification_Leave);
            // 
            // btn_invoice_client_add
            // 
            this.btn_invoice_client_add.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_invoice_client_add.Location = new System.Drawing.Point(843, 40);
            this.btn_invoice_client_add.Name = "btn_invoice_client_add";
            this.btn_invoice_client_add.Size = new System.Drawing.Size(104, 21);
            this.btn_invoice_client_add.TabIndex = 3;
            this.btn_invoice_client_add.Text = "Salvar Cliente";
            this.btn_invoice_client_add.UseVisualStyleBackColor = true;
            this.btn_invoice_client_add.Visible = false;
            this.btn_invoice_client_add.Click += new System.EventHandler(this.btn_invoice_client_add_Click);
            // 
            // lbl_invoice_credit_days
            // 
            this.lbl_invoice_credit_days.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_credit_days.Location = new System.Drawing.Point(660, 19);
            this.lbl_invoice_credit_days.Name = "lbl_invoice_credit_days";
            this.lbl_invoice_credit_days.Size = new System.Drawing.Size(79, 14);
            this.lbl_invoice_credit_days.TabIndex = 65;
            this.lbl_invoice_credit_days.Text = "Días de crédito:";
            // 
            // txt_invoice_credit_days
            // 
            this.txt_invoice_credit_days.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_credit_days.Location = new System.Drawing.Point(661, 39);
            this.txt_invoice_credit_days.Name = "txt_invoice_credit_days";
            this.txt_invoice_credit_days.Size = new System.Drawing.Size(79, 22);
            this.txt_invoice_credit_days.TabIndex = 4;
            this.txt_invoice_credit_days.Text = "0";
            this.txt_invoice_credit_days.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_invoice_credit_days_KeyPress);
            this.txt_invoice_credit_days.Leave += new System.EventHandler(this.txt_invoice_credit_days_Leave);
            // 
            // lbl_invoice_document_type
            // 
            this.lbl_invoice_document_type.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_document_type.Location = new System.Drawing.Point(9, 19);
            this.lbl_invoice_document_type.Name = "lbl_invoice_document_type";
            this.lbl_invoice_document_type.Size = new System.Drawing.Size(79, 14);
            this.lbl_invoice_document_type.TabIndex = 0;
            this.lbl_invoice_document_type.Text = "Tipo documento:";
            // 
            // grp_invoice_client
            // 
            this.grp_invoice_client.Controls.Add(this.btn_exoneracion_show);
            this.grp_invoice_client.Controls.Add(this.lbl_id_client);
            this.grp_invoice_client.Controls.Add(this.cmb_invoice_clients_id_type);
            this.grp_invoice_client.Controls.Add(this.txt_invoice_client_email);
            this.grp_invoice_client.Controls.Add(this.lbl_invoice_client_email);
            this.grp_invoice_client.Controls.Add(this.btn_invoice_client_add);
            this.grp_invoice_client.Controls.Add(this.txt_invoice_client_phone_number);
            this.grp_invoice_client.Controls.Add(this.lbl_invoice_client_phone_number);
            this.grp_invoice_client.Controls.Add(this.txt_invoice_client_name);
            this.grp_invoice_client.Controls.Add(this.lbl_invoice_client_name);
            this.grp_invoice_client.Controls.Add(this.lbl_invoice_client_identification);
            this.grp_invoice_client.Controls.Add(this.txt_invoice_client_identification);
            this.grp_invoice_client.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grp_invoice_client.Location = new System.Drawing.Point(7, 125);
            this.grp_invoice_client.Name = "grp_invoice_client";
            this.grp_invoice_client.Size = new System.Drawing.Size(953, 71);
            this.grp_invoice_client.TabIndex = 68;
            this.grp_invoice_client.TabStop = false;
            this.grp_invoice_client.Text = "Client information (optional)";
            // 
            // btn_exoneracion_show
            // 
            this.btn_exoneracion_show.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_exoneracion_show.Location = new System.Drawing.Point(843, 14);
            this.btn_exoneracion_show.Name = "btn_exoneracion_show";
            this.btn_exoneracion_show.Size = new System.Drawing.Size(104, 21);
            this.btn_exoneracion_show.TabIndex = 165;
            this.btn_exoneracion_show.Text = "Exoneración";
            this.btn_exoneracion_show.UseVisualStyleBackColor = true;
            this.btn_exoneracion_show.Visible = false;
            this.btn_exoneracion_show.Click += new System.EventHandler(this.btn_exoneracion_show_Click);
            // 
            // lbl_id_client
            // 
            this.lbl_id_client.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_id_client.Location = new System.Drawing.Point(7, 22);
            this.lbl_id_client.Name = "lbl_id_client";
            this.lbl_id_client.Size = new System.Drawing.Size(41, 15);
            this.lbl_id_client.TabIndex = 68;
            this.lbl_id_client.Text = "0";
            // 
            // cmb_invoice_clients_id_type
            // 
            this.cmb_invoice_clients_id_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_invoice_clients_id_type.FormattingEnabled = true;
            this.cmb_invoice_clients_id_type.Location = new System.Drawing.Point(6, 40);
            this.cmb_invoice_clients_id_type.Name = "cmb_invoice_clients_id_type";
            this.cmb_invoice_clients_id_type.Size = new System.Drawing.Size(126, 21);
            this.cmb_invoice_clients_id_type.TabIndex = 160;
            // 
            // txt_invoice_client_email
            // 
            this.txt_invoice_client_email.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_client_email.Location = new System.Drawing.Point(621, 40);
            this.txt_invoice_client_email.Name = "txt_invoice_client_email";
            this.txt_invoice_client_email.Size = new System.Drawing.Size(210, 22);
            this.txt_invoice_client_email.TabIndex = 164;
            // 
            // lbl_invoice_client_email
            // 
            this.lbl_invoice_client_email.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_client_email.Location = new System.Drawing.Point(624, 18);
            this.lbl_invoice_client_email.Name = "lbl_invoice_client_email";
            this.lbl_invoice_client_email.Size = new System.Drawing.Size(167, 14);
            this.lbl_invoice_client_email.TabIndex = 64;
            this.lbl_invoice_client_email.Text = "Email";
            // 
            // lbl_invoice_cur
            // 
            this.lbl_invoice_cur.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_cur.Location = new System.Drawing.Point(306, 19);
            this.lbl_invoice_cur.Name = "lbl_invoice_cur";
            this.lbl_invoice_cur.Size = new System.Drawing.Size(60, 14);
            this.lbl_invoice_cur.TabIndex = 70;
            this.lbl_invoice_cur.Text = "Currency:";
            // 
            // cmb_invoice_cur
            // 
            this.cmb_invoice_cur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_invoice_cur.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmb_invoice_cur.FormattingEnabled = true;
            this.cmb_invoice_cur.Location = new System.Drawing.Point(306, 38);
            this.cmb_invoice_cur.Name = "cmb_invoice_cur";
            this.cmb_invoice_cur.Size = new System.Drawing.Size(102, 21);
            this.cmb_invoice_cur.TabIndex = 1;
            this.cmb_invoice_cur.SelectedIndexChanged += new System.EventHandler(this.cmb_invoice_cur_SelectedIndexChanged);
            // 
            // lbl_invoice_exchange
            // 
            this.lbl_invoice_exchange.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_exchange.Location = new System.Drawing.Point(412, 19);
            this.lbl_invoice_exchange.Name = "lbl_invoice_exchange";
            this.lbl_invoice_exchange.Size = new System.Drawing.Size(71, 14);
            this.lbl_invoice_exchange.TabIndex = 72;
            this.lbl_invoice_exchange.Text = "Tipo cambio";
            // 
            // txt_invoice_cur
            // 
            this.txt_invoice_cur.Enabled = false;
            this.txt_invoice_cur.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_cur.Location = new System.Drawing.Point(412, 39);
            this.txt_invoice_cur.Name = "txt_invoice_cur";
            this.txt_invoice_cur.Size = new System.Drawing.Size(92, 22);
            this.txt_invoice_cur.TabIndex = 2;
            this.txt_invoice_cur.Text = "0";
            // 
            // txt_invoice_line_price_total
            // 
            this.txt_invoice_line_price_total.BackColor = System.Drawing.SystemColors.Control;
            this.txt_invoice_line_price_total.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_price_total.Location = new System.Drawing.Point(743, 226);
            this.txt_invoice_line_price_total.Name = "txt_invoice_line_price_total";
            this.txt_invoice_line_price_total.ReadOnly = true;
            this.txt_invoice_line_price_total.Size = new System.Drawing.Size(85, 22);
            this.txt_invoice_line_price_total.TabIndex = 5;
            this.txt_invoice_line_price_total.Text = "999,999,999.12";
            // 
            // lbl_invoice_line_total
            // 
            this.lbl_invoice_line_total.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_line_total.Location = new System.Drawing.Point(743, 209);
            this.lbl_invoice_line_total.Name = "lbl_invoice_line_total";
            this.lbl_invoice_line_total.Size = new System.Drawing.Size(85, 14);
            this.lbl_invoice_line_total.TabIndex = 53;
            this.lbl_invoice_line_total.Text = "Total";
            // 
            // mnuS1
            // 
            this.mnuS1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.mnuS1.Location = new System.Drawing.Point(0, 0);
            this.mnuS1.Name = "mnuS1";
            this.mnuS1.Size = new System.Drawing.Size(1294, 24);
            this.mnuS1.TabIndex = 77;
            this.mnuS1.Text = "menuStrip1";
            // 
            // lbl_invoice_line_tax
            // 
            this.lbl_invoice_line_tax.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_line_tax.Location = new System.Drawing.Point(654, 209);
            this.lbl_invoice_line_tax.Name = "lbl_invoice_line_tax";
            this.lbl_invoice_line_tax.Size = new System.Drawing.Size(85, 14);
            this.lbl_invoice_line_tax.TabIndex = 78;
            this.lbl_invoice_line_tax.Text = "Tax";
            // 
            // cmb_invoice_document_type
            // 
            this.cmb_invoice_document_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_invoice_document_type.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmb_invoice_document_type.FormattingEnabled = true;
            this.cmb_invoice_document_type.Location = new System.Drawing.Point(9, 39);
            this.cmb_invoice_document_type.Name = "cmb_invoice_document_type";
            this.cmb_invoice_document_type.Size = new System.Drawing.Size(164, 21);
            this.cmb_invoice_document_type.TabIndex = 0;
            this.cmb_invoice_document_type.SelectedIndexChanged += new System.EventHandler(this.cmb_invoice_document_type_SelectedIndexChanged);
            // 
            // lbl_invoice_line_barcode_result
            // 
            this.lbl_invoice_line_barcode_result.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_line_barcode_result.Location = new System.Drawing.Point(7, 253);
            this.lbl_invoice_line_barcode_result.Name = "lbl_invoice_line_barcode_result";
            this.lbl_invoice_line_barcode_result.Size = new System.Drawing.Size(108, 14);
            this.lbl_invoice_line_barcode_result.TabIndex = 80;
            // 
            // txt_invoice_line_price_tax
            // 
            this.txt_invoice_line_price_tax.BackColor = System.Drawing.SystemColors.Control;
            this.txt_invoice_line_price_tax.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_price_tax.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_invoice_line_price_tax.Location = new System.Drawing.Point(654, 226);
            this.txt_invoice_line_price_tax.Name = "txt_invoice_line_price_tax";
            this.txt_invoice_line_price_tax.ReadOnly = true;
            this.txt_invoice_line_price_tax.Size = new System.Drawing.Size(85, 22);
            this.txt_invoice_line_price_tax.TabIndex = 4;
            this.txt_invoice_line_price_tax.Text = "999,999,999.12";
            // 
            // txt_invoice_line_sym
            // 
            this.txt_invoice_line_sym.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_sym.Location = new System.Drawing.Point(121, 254);
            this.txt_invoice_line_sym.Name = "txt_invoice_line_sym";
            this.txt_invoice_line_sym.Size = new System.Drawing.Size(97, 13);
            this.txt_invoice_line_sym.TabIndex = 81;
            // 
            // txt_invoice_line_cur
            // 
            this.txt_invoice_line_cur.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_cur.Location = new System.Drawing.Point(744, 251);
            this.txt_invoice_line_cur.Name = "txt_invoice_line_cur";
            this.txt_invoice_line_cur.Size = new System.Drawing.Size(85, 14);
            this.txt_invoice_line_cur.TabIndex = 82;
            // 
            // txt_invoice_line_tax
            // 
            this.txt_invoice_line_tax.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_tax.Location = new System.Drawing.Point(708, 248);
            this.txt_invoice_line_tax.Name = "txt_invoice_line_tax";
            this.txt_invoice_line_tax.Size = new System.Drawing.Size(20, 14);
            this.txt_invoice_line_tax.TabIndex = 83;
            this.txt_invoice_line_tax.Text = "00";
            // 
            // cmb_btn_action
            // 
            this.cmb_btn_action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_btn_action.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_btn_action.FormattingEnabled = true;
            this.cmb_btn_action.Location = new System.Drawing.Point(833, 226);
            this.cmb_btn_action.Name = "cmb_btn_action";
            this.cmb_btn_action.Size = new System.Drawing.Size(133, 21);
            this.cmb_btn_action.TabIndex = 6;
            this.cmb_btn_action.SelectedIndexChanged += new System.EventHandler(this.cmb_btn_action_SelectedIndexChanged);
            // 
            // lbl_edit_invoice_line
            // 
            this.lbl_edit_invoice_line.Location = new System.Drawing.Point(895, 252);
            this.lbl_edit_invoice_line.Name = "lbl_edit_invoice_line";
            this.lbl_edit_invoice_line.Size = new System.Drawing.Size(70, 13);
            this.lbl_edit_invoice_line.TabIndex = 95;
            this.lbl_edit_invoice_line.Text = "0";
            this.lbl_edit_invoice_line.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grp_invoice_header
            // 
            this.grp_invoice_header.Controls.Add(this.cmb_invoice_act_eco);
            this.grp_invoice_header.Controls.Add(this.lbl_invoice_cod_act_eco);
            this.grp_invoice_header.Controls.Add(this.cmb_invoice_document_type);
            this.grp_invoice_header.Controls.Add(this.lbl_invoice_document_type);
            this.grp_invoice_header.Controls.Add(this.cmb_invoice_cur);
            this.grp_invoice_header.Controls.Add(this.lbl_invoice_cur);
            this.grp_invoice_header.Controls.Add(this.txt_invoice_cur);
            this.grp_invoice_header.Controls.Add(this.lbl_invoice_exchange);
            this.grp_invoice_header.Controls.Add(this.lbl_invoice_sale_type);
            this.grp_invoice_header.Controls.Add(this.cmb_invoice_sale_type);
            this.grp_invoice_header.Controls.Add(this.lbl_invoice_credit_days);
            this.grp_invoice_header.Controls.Add(this.txt_invoice_credit_days);
            this.grp_invoice_header.Location = new System.Drawing.Point(5, 48);
            this.grp_invoice_header.Name = "grp_invoice_header";
            this.grp_invoice_header.Size = new System.Drawing.Size(746, 70);
            this.grp_invoice_header.TabIndex = 96;
            this.grp_invoice_header.TabStop = false;
            this.grp_invoice_header.Text = "Invoice header";
            // 
            // cmb_invoice_act_eco
            // 
            this.cmb_invoice_act_eco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_invoice_act_eco.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmb_invoice_act_eco.FormattingEnabled = true;
            this.cmb_invoice_act_eco.Location = new System.Drawing.Point(179, 38);
            this.cmb_invoice_act_eco.Name = "cmb_invoice_act_eco";
            this.cmb_invoice_act_eco.Size = new System.Drawing.Size(121, 21);
            this.cmb_invoice_act_eco.TabIndex = 73;
            // 
            // lbl_invoice_cod_act_eco
            // 
            this.lbl_invoice_cod_act_eco.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_cod_act_eco.Location = new System.Drawing.Point(179, 18);
            this.lbl_invoice_cod_act_eco.Name = "lbl_invoice_cod_act_eco";
            this.lbl_invoice_cod_act_eco.Size = new System.Drawing.Size(60, 14);
            this.lbl_invoice_cod_act_eco.TabIndex = 74;
            this.lbl_invoice_cod_act_eco.Text = "Act. Eco.";
            // 
            // txt_invoice_line_sym_unit
            // 
            this.txt_invoice_line_sym_unit.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_sym_unit.Location = new System.Drawing.Point(412, 254);
            this.txt_invoice_line_sym_unit.Name = "txt_invoice_line_sym_unit";
            this.txt_invoice_line_sym_unit.Size = new System.Drawing.Size(97, 13);
            this.txt_invoice_line_sym_unit.TabIndex = 97;
            // 
            // lbl_invoice_subtotal
            // 
            this.lbl_invoice_subtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_invoice_subtotal.Location = new System.Drawing.Point(639, 522);
            this.lbl_invoice_subtotal.Name = "lbl_invoice_subtotal";
            this.lbl_invoice_subtotal.Size = new System.Drawing.Size(132, 24);
            this.lbl_invoice_subtotal.TabIndex = 110;
            this.lbl_invoice_subtotal.Text = "SubTotal";
            this.lbl_invoice_subtotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_invoice_total_tax
            // 
            this.lbl_invoice_total_tax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_invoice_total_tax.Location = new System.Drawing.Point(639, 574);
            this.lbl_invoice_total_tax.Name = "lbl_invoice_total_tax";
            this.lbl_invoice_total_tax.Size = new System.Drawing.Size(132, 24);
            this.lbl_invoice_total_tax.TabIndex = 111;
            this.lbl_invoice_total_tax.Text = "Impuesto";
            this.lbl_invoice_total_tax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_invoice_total
            // 
            this.lbl_invoice_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_invoice_total.Location = new System.Drawing.Point(639, 626);
            this.lbl_invoice_total.Name = "lbl_invoice_total";
            this.lbl_invoice_total.Size = new System.Drawing.Size(132, 24);
            this.lbl_invoice_total.TabIndex = 112;
            this.lbl_invoice_total.Text = "Total";
            this.lbl_invoice_total.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_invoice_totals_subtotal
            // 
            this.txt_invoice_totals_subtotal.BackColor = System.Drawing.SystemColors.Control;
            this.txt_invoice_totals_subtotal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_invoice_totals_subtotal.ForeColor = System.Drawing.Color.Black;
            this.txt_invoice_totals_subtotal.Location = new System.Drawing.Point(775, 521);
            this.txt_invoice_totals_subtotal.Name = "txt_invoice_totals_subtotal";
            this.txt_invoice_totals_subtotal.ReadOnly = true;
            this.txt_invoice_totals_subtotal.ShortcutsEnabled = false;
            this.txt_invoice_totals_subtotal.Size = new System.Drawing.Size(191, 35);
            this.txt_invoice_totals_subtotal.TabIndex = 113;
            this.txt_invoice_totals_subtotal.Text = "999,999,999.12345";
            this.txt_invoice_totals_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_invoice_totals_tax
            // 
            this.txt_invoice_totals_tax.BackColor = System.Drawing.SystemColors.Control;
            this.txt_invoice_totals_tax.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_invoice_totals_tax.ForeColor = System.Drawing.Color.Black;
            this.txt_invoice_totals_tax.Location = new System.Drawing.Point(775, 573);
            this.txt_invoice_totals_tax.Name = "txt_invoice_totals_tax";
            this.txt_invoice_totals_tax.ReadOnly = true;
            this.txt_invoice_totals_tax.ShortcutsEnabled = false;
            this.txt_invoice_totals_tax.Size = new System.Drawing.Size(191, 35);
            this.txt_invoice_totals_tax.TabIndex = 114;
            this.txt_invoice_totals_tax.Text = "999,999,999.12345";
            this.txt_invoice_totals_tax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_invoice_totals_total
            // 
            this.txt_invoice_totals_total.BackColor = System.Drawing.SystemColors.Control;
            this.txt_invoice_totals_total.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_invoice_totals_total.ForeColor = System.Drawing.Color.Black;
            this.txt_invoice_totals_total.Location = new System.Drawing.Point(775, 625);
            this.txt_invoice_totals_total.Name = "txt_invoice_totals_total";
            this.txt_invoice_totals_total.ReadOnly = true;
            this.txt_invoice_totals_total.ShortcutsEnabled = false;
            this.txt_invoice_totals_total.Size = new System.Drawing.Size(191, 35);
            this.txt_invoice_totals_total.TabIndex = 115;
            this.txt_invoice_totals_total.Text = "999,999,999.12345";
            this.txt_invoice_totals_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grp_fe_calculos
            // 
            this.grp_fe_calculos.Controls.Add(this.txt_TotalComprobante);
            this.grp_fe_calculos.Controls.Add(this.txt_TotalImpuesto);
            this.grp_fe_calculos.Controls.Add(this.txt_TotalVentaNeta);
            this.grp_fe_calculos.Controls.Add(this.txt_TotalDescuentos);
            this.grp_fe_calculos.Controls.Add(this.txt_TotalVenta);
            this.grp_fe_calculos.Controls.Add(this.txt_TotalExento);
            this.grp_fe_calculos.Controls.Add(this.txt_TotalGravado);
            this.grp_fe_calculos.Controls.Add(this.txt_TotalMercanciasExentas);
            this.grp_fe_calculos.Controls.Add(this.txt_TotalMercanciasGravadas);
            this.grp_fe_calculos.Controls.Add(this.txt_TotalServExentos);
            this.grp_fe_calculos.Controls.Add(this.txt_TotalServGravados);
            this.grp_fe_calculos.Controls.Add(this.lbl_TotalServGravados);
            this.grp_fe_calculos.Controls.Add(this.lbl_TotalComprobante);
            this.grp_fe_calculos.Controls.Add(this.lbl_TotalServExentos);
            this.grp_fe_calculos.Controls.Add(this.lbl_TotalImpuesto);
            this.grp_fe_calculos.Controls.Add(this.lbl_TotalMercanciasGravadas);
            this.grp_fe_calculos.Controls.Add(this.lbl_TotalVentaNeta);
            this.grp_fe_calculos.Controls.Add(this.lbl_TotalMercanciasExentas);
            this.grp_fe_calculos.Controls.Add(this.lbl_TotalDescuentos);
            this.grp_fe_calculos.Controls.Add(this.lbl_TotalGravado);
            this.grp_fe_calculos.Controls.Add(this.lbl_TotalVenta);
            this.grp_fe_calculos.Controls.Add(this.lbl_TotalExento);
            this.grp_fe_calculos.Location = new System.Drawing.Point(5, 548);
            this.grp_fe_calculos.Name = "grp_fe_calculos";
            this.grp_fe_calculos.Size = new System.Drawing.Size(633, 125);
            this.grp_fe_calculos.TabIndex = 127;
            this.grp_fe_calculos.TabStop = false;
            this.grp_fe_calculos.Text = "Factura Electrónica";
            // 
            // lbl_computer_name
            // 
            this.lbl_computer_name.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_computer_name.Location = new System.Drawing.Point(447, 672);
            this.lbl_computer_name.Name = "lbl_computer_name";
            this.lbl_computer_name.Size = new System.Drawing.Size(187, 13);
            this.lbl_computer_name.TabIndex = 149;
            // 
            // txt_TotalComprobante
            // 
            this.txt_TotalComprobante.BackColor = System.Drawing.SystemColors.Control;
            this.txt_TotalComprobante.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalComprobante.ForeColor = System.Drawing.Color.Black;
            this.txt_TotalComprobante.Location = new System.Drawing.Point(530, 100);
            this.txt_TotalComprobante.Name = "txt_TotalComprobante";
            this.txt_TotalComprobante.ReadOnly = true;
            this.txt_TotalComprobante.ShortcutsEnabled = false;
            this.txt_TotalComprobante.Size = new System.Drawing.Size(100, 22);
            this.txt_TotalComprobante.TabIndex = 148;
            this.txt_TotalComprobante.Text = "999,999,999.12345";
            // 
            // txt_TotalImpuesto
            // 
            this.txt_TotalImpuesto.BackColor = System.Drawing.SystemColors.Control;
            this.txt_TotalImpuesto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalImpuesto.ForeColor = System.Drawing.Color.Black;
            this.txt_TotalImpuesto.Location = new System.Drawing.Point(530, 75);
            this.txt_TotalImpuesto.Name = "txt_TotalImpuesto";
            this.txt_TotalImpuesto.ReadOnly = true;
            this.txt_TotalImpuesto.ShortcutsEnabled = false;
            this.txt_TotalImpuesto.Size = new System.Drawing.Size(100, 22);
            this.txt_TotalImpuesto.TabIndex = 147;
            this.txt_TotalImpuesto.Text = "999,999,999.12345";
            // 
            // txt_TotalVentaNeta
            // 
            this.txt_TotalVentaNeta.BackColor = System.Drawing.SystemColors.Control;
            this.txt_TotalVentaNeta.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalVentaNeta.ForeColor = System.Drawing.Color.Black;
            this.txt_TotalVentaNeta.Location = new System.Drawing.Point(530, 22);
            this.txt_TotalVentaNeta.Name = "txt_TotalVentaNeta";
            this.txt_TotalVentaNeta.ReadOnly = true;
            this.txt_TotalVentaNeta.ShortcutsEnabled = false;
            this.txt_TotalVentaNeta.Size = new System.Drawing.Size(100, 22);
            this.txt_TotalVentaNeta.TabIndex = 146;
            this.txt_TotalVentaNeta.Text = "999,999,999.12345";
            // 
            // txt_TotalDescuentos
            // 
            this.txt_TotalDescuentos.BackColor = System.Drawing.SystemColors.Control;
            this.txt_TotalDescuentos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalDescuentos.ForeColor = System.Drawing.Color.Black;
            this.txt_TotalDescuentos.Location = new System.Drawing.Point(334, 100);
            this.txt_TotalDescuentos.Name = "txt_TotalDescuentos";
            this.txt_TotalDescuentos.ReadOnly = true;
            this.txt_TotalDescuentos.ShortcutsEnabled = false;
            this.txt_TotalDescuentos.Size = new System.Drawing.Size(100, 22);
            this.txt_TotalDescuentos.TabIndex = 145;
            this.txt_TotalDescuentos.Text = "999,999,999.12345";
            // 
            // txt_TotalVenta
            // 
            this.txt_TotalVenta.BackColor = System.Drawing.SystemColors.Control;
            this.txt_TotalVenta.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalVenta.ForeColor = System.Drawing.Color.Black;
            this.txt_TotalVenta.Location = new System.Drawing.Point(334, 75);
            this.txt_TotalVenta.Name = "txt_TotalVenta";
            this.txt_TotalVenta.ReadOnly = true;
            this.txt_TotalVenta.ShortcutsEnabled = false;
            this.txt_TotalVenta.Size = new System.Drawing.Size(100, 22);
            this.txt_TotalVenta.TabIndex = 144;
            this.txt_TotalVenta.Text = "999,999,999.12345";
            // 
            // txt_TotalExento
            // 
            this.txt_TotalExento.BackColor = System.Drawing.SystemColors.Control;
            this.txt_TotalExento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalExento.ForeColor = System.Drawing.Color.Black;
            this.txt_TotalExento.Location = new System.Drawing.Point(334, 49);
            this.txt_TotalExento.Name = "txt_TotalExento";
            this.txt_TotalExento.ReadOnly = true;
            this.txt_TotalExento.ShortcutsEnabled = false;
            this.txt_TotalExento.Size = new System.Drawing.Size(100, 22);
            this.txt_TotalExento.TabIndex = 143;
            this.txt_TotalExento.Text = "999,999,999.12345";
            // 
            // txt_TotalGravado
            // 
            this.txt_TotalGravado.BackColor = System.Drawing.SystemColors.Control;
            this.txt_TotalGravado.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalGravado.ForeColor = System.Drawing.Color.Black;
            this.txt_TotalGravado.Location = new System.Drawing.Point(334, 22);
            this.txt_TotalGravado.Name = "txt_TotalGravado";
            this.txt_TotalGravado.ReadOnly = true;
            this.txt_TotalGravado.ShortcutsEnabled = false;
            this.txt_TotalGravado.Size = new System.Drawing.Size(100, 22);
            this.txt_TotalGravado.TabIndex = 142;
            this.txt_TotalGravado.Text = "999,999,999.12345";
            // 
            // txt_TotalMercanciasExentas
            // 
            this.txt_TotalMercanciasExentas.BackColor = System.Drawing.SystemColors.Control;
            this.txt_TotalMercanciasExentas.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalMercanciasExentas.ForeColor = System.Drawing.Color.Black;
            this.txt_TotalMercanciasExentas.Location = new System.Drawing.Point(137, 100);
            this.txt_TotalMercanciasExentas.Name = "txt_TotalMercanciasExentas";
            this.txt_TotalMercanciasExentas.ReadOnly = true;
            this.txt_TotalMercanciasExentas.ShortcutsEnabled = false;
            this.txt_TotalMercanciasExentas.Size = new System.Drawing.Size(100, 22);
            this.txt_TotalMercanciasExentas.TabIndex = 141;
            this.txt_TotalMercanciasExentas.Text = "999,999,999.12345";
            // 
            // txt_TotalMercanciasGravadas
            // 
            this.txt_TotalMercanciasGravadas.BackColor = System.Drawing.SystemColors.Control;
            this.txt_TotalMercanciasGravadas.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalMercanciasGravadas.ForeColor = System.Drawing.Color.Black;
            this.txt_TotalMercanciasGravadas.Location = new System.Drawing.Point(137, 75);
            this.txt_TotalMercanciasGravadas.Name = "txt_TotalMercanciasGravadas";
            this.txt_TotalMercanciasGravadas.ReadOnly = true;
            this.txt_TotalMercanciasGravadas.ShortcutsEnabled = false;
            this.txt_TotalMercanciasGravadas.Size = new System.Drawing.Size(100, 22);
            this.txt_TotalMercanciasGravadas.TabIndex = 140;
            this.txt_TotalMercanciasGravadas.Text = "999,999,999.12345";
            // 
            // txt_TotalServExentos
            // 
            this.txt_TotalServExentos.BackColor = System.Drawing.SystemColors.Control;
            this.txt_TotalServExentos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalServExentos.ForeColor = System.Drawing.Color.Black;
            this.txt_TotalServExentos.Location = new System.Drawing.Point(137, 49);
            this.txt_TotalServExentos.Name = "txt_TotalServExentos";
            this.txt_TotalServExentos.ReadOnly = true;
            this.txt_TotalServExentos.ShortcutsEnabled = false;
            this.txt_TotalServExentos.Size = new System.Drawing.Size(100, 22);
            this.txt_TotalServExentos.TabIndex = 139;
            this.txt_TotalServExentos.Text = "999,999,999.12345";
            // 
            // txt_TotalServGravados
            // 
            this.txt_TotalServGravados.BackColor = System.Drawing.SystemColors.Control;
            this.txt_TotalServGravados.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalServGravados.ForeColor = System.Drawing.Color.Black;
            this.txt_TotalServGravados.Location = new System.Drawing.Point(137, 22);
            this.txt_TotalServGravados.Name = "txt_TotalServGravados";
            this.txt_TotalServGravados.ReadOnly = true;
            this.txt_TotalServGravados.ShortcutsEnabled = false;
            this.txt_TotalServGravados.Size = new System.Drawing.Size(100, 22);
            this.txt_TotalServGravados.TabIndex = 138;
            this.txt_TotalServGravados.Text = "999,999,999.12345";
            // 
            // lbl_TotalServGravados
            // 
            this.lbl_TotalServGravados.AutoSize = true;
            this.lbl_TotalServGravados.Location = new System.Drawing.Point(32, 22);
            this.lbl_TotalServGravados.Name = "lbl_TotalServGravados";
            this.lbl_TotalServGravados.Size = new System.Drawing.Size(99, 13);
            this.lbl_TotalServGravados.TabIndex = 127;
            this.lbl_TotalServGravados.Text = "TotalServGravados";
            // 
            // lbl_TotalComprobante
            // 
            this.lbl_TotalComprobante.AutoSize = true;
            this.lbl_TotalComprobante.Location = new System.Drawing.Point(435, 100);
            this.lbl_TotalComprobante.Name = "lbl_TotalComprobante";
            this.lbl_TotalComprobante.Size = new System.Drawing.Size(94, 13);
            this.lbl_TotalComprobante.TabIndex = 137;
            this.lbl_TotalComprobante.Text = "TotalComprobante";
            // 
            // lbl_TotalServExentos
            // 
            this.lbl_TotalServExentos.AutoSize = true;
            this.lbl_TotalServExentos.Location = new System.Drawing.Point(40, 49);
            this.lbl_TotalServExentos.Name = "lbl_TotalServExentos";
            this.lbl_TotalServExentos.Size = new System.Drawing.Size(91, 13);
            this.lbl_TotalServExentos.TabIndex = 128;
            this.lbl_TotalServExentos.Text = "TotalServExentos";
            // 
            // lbl_TotalImpuesto
            // 
            this.lbl_TotalImpuesto.AutoSize = true;
            this.lbl_TotalImpuesto.Location = new System.Drawing.Point(455, 75);
            this.lbl_TotalImpuesto.Name = "lbl_TotalImpuesto";
            this.lbl_TotalImpuesto.Size = new System.Drawing.Size(74, 13);
            this.lbl_TotalImpuesto.TabIndex = 136;
            this.lbl_TotalImpuesto.Text = "TotalImpuesto";
            // 
            // lbl_TotalMercanciasGravadas
            // 
            this.lbl_TotalMercanciasGravadas.AutoSize = true;
            this.lbl_TotalMercanciasGravadas.Location = new System.Drawing.Point(-1, 75);
            this.lbl_TotalMercanciasGravadas.Name = "lbl_TotalMercanciasGravadas";
            this.lbl_TotalMercanciasGravadas.Size = new System.Drawing.Size(132, 13);
            this.lbl_TotalMercanciasGravadas.TabIndex = 129;
            this.lbl_TotalMercanciasGravadas.Text = "TotalMercanciasGravadas";
            // 
            // lbl_TotalVentaNeta
            // 
            this.lbl_TotalVentaNeta.AutoSize = true;
            this.lbl_TotalVentaNeta.Location = new System.Drawing.Point(447, 22);
            this.lbl_TotalVentaNeta.Name = "lbl_TotalVentaNeta";
            this.lbl_TotalVentaNeta.Size = new System.Drawing.Size(82, 13);
            this.lbl_TotalVentaNeta.TabIndex = 135;
            this.lbl_TotalVentaNeta.Text = "TotalVentaNeta";
            // 
            // lbl_TotalMercanciasExentas
            // 
            this.lbl_TotalMercanciasExentas.AutoSize = true;
            this.lbl_TotalMercanciasExentas.Location = new System.Drawing.Point(7, 100);
            this.lbl_TotalMercanciasExentas.Name = "lbl_TotalMercanciasExentas";
            this.lbl_TotalMercanciasExentas.Size = new System.Drawing.Size(124, 13);
            this.lbl_TotalMercanciasExentas.TabIndex = 130;
            this.lbl_TotalMercanciasExentas.Text = "TotalMercanciasExentas";
            // 
            // lbl_TotalDescuentos
            // 
            this.lbl_TotalDescuentos.AutoSize = true;
            this.lbl_TotalDescuentos.Location = new System.Drawing.Point(240, 100);
            this.lbl_TotalDescuentos.Name = "lbl_TotalDescuentos";
            this.lbl_TotalDescuentos.Size = new System.Drawing.Size(88, 13);
            this.lbl_TotalDescuentos.TabIndex = 134;
            this.lbl_TotalDescuentos.Text = "TotalDescuentos";
            // 
            // lbl_TotalGravado
            // 
            this.lbl_TotalGravado.AutoSize = true;
            this.lbl_TotalGravado.Location = new System.Drawing.Point(256, 22);
            this.lbl_TotalGravado.Name = "lbl_TotalGravado";
            this.lbl_TotalGravado.Size = new System.Drawing.Size(72, 13);
            this.lbl_TotalGravado.TabIndex = 131;
            this.lbl_TotalGravado.Text = "TotalGravado";
            // 
            // lbl_TotalVenta
            // 
            this.lbl_TotalVenta.AutoSize = true;
            this.lbl_TotalVenta.Location = new System.Drawing.Point(269, 75);
            this.lbl_TotalVenta.Name = "lbl_TotalVenta";
            this.lbl_TotalVenta.Size = new System.Drawing.Size(59, 13);
            this.lbl_TotalVenta.TabIndex = 133;
            this.lbl_TotalVenta.Text = "TotalVenta";
            // 
            // lbl_TotalExento
            // 
            this.lbl_TotalExento.AutoSize = true;
            this.lbl_TotalExento.Location = new System.Drawing.Point(264, 49);
            this.lbl_TotalExento.Name = "lbl_TotalExento";
            this.lbl_TotalExento.Size = new System.Drawing.Size(64, 13);
            this.lbl_TotalExento.TabIndex = 132;
            this.lbl_TotalExento.Text = "TotalExento";
            // 
            // btn_invoice_save_email
            // 
            this.btn_invoice_save_email.Enabled = false;
            this.btn_invoice_save_email.Location = new System.Drawing.Point(1133, 383);
            this.btn_invoice_save_email.Name = "btn_invoice_save_email";
            this.btn_invoice_save_email.Size = new System.Drawing.Size(130, 49);
            this.btn_invoice_save_email.TabIndex = 8;
            this.btn_invoice_save_email.Text = "Save && Email";
            this.btn_invoice_save_email.UseVisualStyleBackColor = true;
            this.btn_invoice_save_email.Click += new System.EventHandler(this.btn_invoice_save_email_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.textBox1.Location = new System.Drawing.Point(103, 663);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 22);
            this.textBox1.TabIndex = 129;
            this.textBox1.Text = "0";
            this.textBox1.Visible = false;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.textBox2.Location = new System.Drawing.Point(43, 663);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(59, 10);
            this.textBox2.TabIndex = 130;
            this.textBox2.Text = "0";
            this.textBox2.Visible = false;
            // 
            // txt_invoice_line_id_producto
            // 
            this.txt_invoice_line_id_producto.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_id_producto.Location = new System.Drawing.Point(218, 254);
            this.txt_invoice_line_id_producto.Name = "txt_invoice_line_id_producto";
            this.txt_invoice_line_id_producto.Size = new System.Drawing.Size(97, 13);
            this.txt_invoice_line_id_producto.TabIndex = 131;
            // 
            // txt_invoice_line_tax_code
            // 
            this.txt_invoice_line_tax_code.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_tax_code.Location = new System.Drawing.Point(656, 248);
            this.txt_invoice_line_tax_code.Name = "txt_invoice_line_tax_code";
            this.txt_invoice_line_tax_code.Size = new System.Drawing.Size(20, 14);
            this.txt_invoice_line_tax_code.TabIndex = 132;
            this.txt_invoice_line_tax_code.Text = "00";
            // 
            // txt_invoice_line_sym_code_type
            // 
            this.txt_invoice_line_sym_code_type.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_sym_code_type.Location = new System.Drawing.Point(315, 254);
            this.txt_invoice_line_sym_code_type.Name = "txt_invoice_line_sym_code_type";
            this.txt_invoice_line_sym_code_type.Size = new System.Drawing.Size(97, 13);
            this.txt_invoice_line_sym_code_type.TabIndex = 133;
            // 
            // txt_invoice_line_price_subtotal
            // 
            this.txt_invoice_line_price_subtotal.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_price_subtotal.Location = new System.Drawing.Point(565, 245);
            this.txt_invoice_line_price_subtotal.Name = "txt_invoice_line_price_subtotal";
            this.txt_invoice_line_price_subtotal.ReadOnly = true;
            this.txt_invoice_line_price_subtotal.Size = new System.Drawing.Size(85, 22);
            this.txt_invoice_line_price_subtotal.TabIndex = 134;
            this.txt_invoice_line_price_subtotal.Text = "999,999,999.12";
            this.txt_invoice_line_price_subtotal.Visible = false;
            // 
            // txt_cal_pagacon
            // 
            this.txt_cal_pagacon.BackColor = System.Drawing.Color.White;
            this.txt_cal_pagacon.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cal_pagacon.ForeColor = System.Drawing.Color.Black;
            this.txt_cal_pagacon.Location = new System.Drawing.Point(61, 38);
            this.txt_cal_pagacon.Name = "txt_cal_pagacon";
            this.txt_cal_pagacon.ShortcutsEnabled = false;
            this.txt_cal_pagacon.Size = new System.Drawing.Size(191, 35);
            this.txt_cal_pagacon.TabIndex = 135;
            this.txt_cal_pagacon.Text = "999,999,999.12345";
            this.txt_cal_pagacon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_cal_pagacon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_cal_pagacon_MouseClick);
            this.txt_cal_pagacon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cal_pagacon_KeyPress);
            this.txt_cal_pagacon.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_cal_pagacon_KeyUp);
            // 
            // txt_cal_vuelto
            // 
            this.txt_cal_vuelto.BackColor = System.Drawing.SystemColors.Control;
            this.txt_cal_vuelto.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cal_vuelto.ForeColor = System.Drawing.Color.Black;
            this.txt_cal_vuelto.Location = new System.Drawing.Point(61, 105);
            this.txt_cal_vuelto.Name = "txt_cal_vuelto";
            this.txt_cal_vuelto.ReadOnly = true;
            this.txt_cal_vuelto.ShortcutsEnabled = false;
            this.txt_cal_vuelto.Size = new System.Drawing.Size(191, 35);
            this.txt_cal_vuelto.TabIndex = 136;
            this.txt_cal_vuelto.Text = "999,999,999.12345";
            this.txt_cal_vuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_cal_vuelto
            // 
            this.lbl_cal_vuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cal_vuelto.Location = new System.Drawing.Point(61, 78);
            this.lbl_cal_vuelto.Name = "lbl_cal_vuelto";
            this.lbl_cal_vuelto.Size = new System.Drawing.Size(191, 24);
            this.lbl_cal_vuelto.TabIndex = 137;
            this.lbl_cal_vuelto.Text = "Vuelto";
            this.lbl_cal_vuelto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_cal_pagacon
            // 
            this.lbl_cal_pagacon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cal_pagacon.Location = new System.Drawing.Point(61, 11);
            this.lbl_cal_pagacon.Name = "lbl_cal_pagacon";
            this.lbl_cal_pagacon.Size = new System.Drawing.Size(191, 24);
            this.lbl_cal_pagacon.TabIndex = 138;
            this.lbl_cal_pagacon.Text = "Paga con";
            this.lbl_cal_pagacon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_col1
            // 
            this.btn_col1.Location = new System.Drawing.Point(17, 147);
            this.btn_col1.Name = "btn_col1";
            this.btn_col1.Size = new System.Drawing.Size(130, 40);
            this.btn_col1.TabIndex = 139;
            this.btn_col1.Text = "1,000";
            this.btn_col1.UseVisualStyleBackColor = true;
            this.btn_col1.Click += new System.EventHandler(this.btn_col1_Click);
            // 
            // btn_col2
            // 
            this.btn_col2.Location = new System.Drawing.Point(162, 147);
            this.btn_col2.Name = "btn_col2";
            this.btn_col2.Size = new System.Drawing.Size(130, 40);
            this.btn_col2.TabIndex = 140;
            this.btn_col2.Text = "2,000";
            this.btn_col2.UseVisualStyleBackColor = true;
            this.btn_col2.Click += new System.EventHandler(this.btn_col2_Click);
            // 
            // btn_col3
            // 
            this.btn_col3.Location = new System.Drawing.Point(17, 193);
            this.btn_col3.Name = "btn_col3";
            this.btn_col3.Size = new System.Drawing.Size(130, 40);
            this.btn_col3.TabIndex = 141;
            this.btn_col3.Text = "5,000";
            this.btn_col3.UseVisualStyleBackColor = true;
            this.btn_col3.Click += new System.EventHandler(this.btn_col3_Click);
            // 
            // btn_col4
            // 
            this.btn_col4.Location = new System.Drawing.Point(162, 193);
            this.btn_col4.Name = "btn_col4";
            this.btn_col4.Size = new System.Drawing.Size(130, 40);
            this.btn_col4.TabIndex = 142;
            this.btn_col4.Text = "10,000";
            this.btn_col4.UseVisualStyleBackColor = true;
            this.btn_col4.Click += new System.EventHandler(this.btn_col4_Click);
            // 
            // btn_col5
            // 
            this.btn_col5.Location = new System.Drawing.Point(17, 239);
            this.btn_col5.Name = "btn_col5";
            this.btn_col5.Size = new System.Drawing.Size(130, 40);
            this.btn_col5.TabIndex = 143;
            this.btn_col5.Text = "20,000";
            this.btn_col5.UseVisualStyleBackColor = true;
            this.btn_col5.Click += new System.EventHandler(this.btn_col5_Click);
            // 
            // btn_col6
            // 
            this.btn_col6.Location = new System.Drawing.Point(162, 239);
            this.btn_col6.Name = "btn_col6";
            this.btn_col6.Size = new System.Drawing.Size(130, 40);
            this.btn_col6.TabIndex = 144;
            this.btn_col6.Text = "50,000";
            this.btn_col6.UseVisualStyleBackColor = true;
            this.btn_col6.Click += new System.EventHandler(this.btn_col6_Click);
            // 
            // grp_efectivo
            // 
            this.grp_efectivo.BackColor = System.Drawing.Color.White;
            this.grp_efectivo.Controls.Add(this.btn_efectivo);
            this.grp_efectivo.Controls.Add(this.btn_cred);
            this.grp_efectivo.Controls.Add(this.btn_col6);
            this.grp_efectivo.Controls.Add(this.btn_col5);
            this.grp_efectivo.Controls.Add(this.btn_col4);
            this.grp_efectivo.Controls.Add(this.btn_col3);
            this.grp_efectivo.Controls.Add(this.btn_col2);
            this.grp_efectivo.Controls.Add(this.btn_col1);
            this.grp_efectivo.Controls.Add(this.lbl_cal_pagacon);
            this.grp_efectivo.Controls.Add(this.lbl_cal_vuelto);
            this.grp_efectivo.Controls.Add(this.txt_cal_vuelto);
            this.grp_efectivo.Controls.Add(this.txt_cal_pagacon);
            this.grp_efectivo.Location = new System.Drawing.Point(971, 48);
            this.grp_efectivo.Name = "grp_efectivo";
            this.grp_efectivo.Size = new System.Drawing.Size(312, 330);
            this.grp_efectivo.TabIndex = 145;
            this.grp_efectivo.TabStop = false;
            this.grp_efectivo.Text = "Efectivo";
            // 
            // btn_efectivo
            // 
            this.btn_efectivo.Location = new System.Drawing.Point(162, 285);
            this.btn_efectivo.Name = "btn_efectivo";
            this.btn_efectivo.Size = new System.Drawing.Size(130, 40);
            this.btn_efectivo.TabIndex = 146;
            this.btn_efectivo.Text = "Efectivo Exacto";
            this.btn_efectivo.UseVisualStyleBackColor = true;
            this.btn_efectivo.Click += new System.EventHandler(this.btn_efectivo_Click);
            // 
            // btn_cred
            // 
            this.btn_cred.Location = new System.Drawing.Point(17, 285);
            this.btn_cred.Name = "btn_cred";
            this.btn_cred.Size = new System.Drawing.Size(130, 40);
            this.btn_cred.TabIndex = 145;
            this.btn_cred.Text = "Tarjeta credito";
            this.btn_cred.UseVisualStyleBackColor = true;
            this.btn_cred.Click += new System.EventHandler(this.btn_cred_Click);
            // 
            // grp_exoneracion
            // 
            this.grp_exoneracion.Controls.Add(this.label9);
            this.grp_exoneracion.Controls.Add(this.btn_exoneraciones_clear);
            this.grp_exoneracion.Controls.Add(this.lbl_exoneracion_porcentaje_exoneracion);
            this.grp_exoneracion.Controls.Add(this.btn_exoneracion_save);
            this.grp_exoneracion.Controls.Add(this.lbl_exoneracion_fecha_emision);
            this.grp_exoneracion.Controls.Add(this.txt_exoneracion_porcentaje_exoneracion);
            this.grp_exoneracion.Controls.Add(this.lbl_exoneracion_nombre_institucion);
            this.grp_exoneracion.Controls.Add(this.txt_exoneracion_nombre_institucion);
            this.grp_exoneracion.Controls.Add(this.txt_exoneracion_fecha_emision);
            this.grp_exoneracion.Controls.Add(this.lbl_exoneracion_numero_documento);
            this.grp_exoneracion.Controls.Add(this.txt_exoneracion_numero_documento);
            this.grp_exoneracion.Controls.Add(this.cmb_exoneracion_tipo_documento);
            this.grp_exoneracion.Controls.Add(this.lbl_exoneracion_tipo_documento);
            this.grp_exoneracion.Location = new System.Drawing.Point(200, 294);
            this.grp_exoneracion.Name = "grp_exoneracion";
            this.grp_exoneracion.Size = new System.Drawing.Size(587, 197);
            this.grp_exoneracion.TabIndex = 170;
            this.grp_exoneracion.TabStop = false;
            this.grp_exoneracion.Text = "Exoneración";
            this.grp_exoneracion.Visible = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label9.Location = new System.Drawing.Point(208, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(253, 14);
            this.label9.TabIndex = 175;
            this.label9.Text = "Del 1% al 13%, digite solo el número entero";
            // 
            // btn_exoneraciones_clear
            // 
            this.btn_exoneraciones_clear.Enabled = false;
            this.btn_exoneraciones_clear.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_exoneraciones_clear.Location = new System.Drawing.Point(422, 82);
            this.btn_exoneraciones_clear.Name = "btn_exoneraciones_clear";
            this.btn_exoneraciones_clear.Size = new System.Drawing.Size(109, 43);
            this.btn_exoneraciones_clear.TabIndex = 174;
            this.btn_exoneraciones_clear.Text = "Eliminar Exoneración";
            this.btn_exoneraciones_clear.UseVisualStyleBackColor = true;
            this.btn_exoneraciones_clear.Click += new System.EventHandler(this.btn_exoneraciones_clear_Click);
            // 
            // lbl_exoneracion_porcentaje_exoneracion
            // 
            this.lbl_exoneracion_porcentaje_exoneracion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_exoneracion_porcentaje_exoneracion.Location = new System.Drawing.Point(211, 135);
            this.lbl_exoneracion_porcentaje_exoneracion.Name = "lbl_exoneracion_porcentaje_exoneracion";
            this.lbl_exoneracion_porcentaje_exoneracion.Size = new System.Drawing.Size(133, 14);
            this.lbl_exoneracion_porcentaje_exoneracion.TabIndex = 173;
            this.lbl_exoneracion_porcentaje_exoneracion.Text = "PorcentajeExoneracion";
            // 
            // btn_exoneracion_save
            // 
            this.btn_exoneracion_save.Enabled = false;
            this.btn_exoneracion_save.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_exoneracion_save.Location = new System.Drawing.Point(422, 135);
            this.btn_exoneracion_save.Name = "btn_exoneracion_save";
            this.btn_exoneracion_save.Size = new System.Drawing.Size(109, 43);
            this.btn_exoneracion_save.TabIndex = 172;
            this.btn_exoneracion_save.Text = "Salvar Exoneración";
            this.btn_exoneracion_save.UseVisualStyleBackColor = true;
            this.btn_exoneracion_save.Click += new System.EventHandler(this.btn_exoneracion_save_Click);
            // 
            // lbl_exoneracion_fecha_emision
            // 
            this.lbl_exoneracion_fecha_emision.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_exoneracion_fecha_emision.Location = new System.Drawing.Point(18, 135);
            this.lbl_exoneracion_fecha_emision.Name = "lbl_exoneracion_fecha_emision";
            this.lbl_exoneracion_fecha_emision.Size = new System.Drawing.Size(133, 14);
            this.lbl_exoneracion_fecha_emision.TabIndex = 166;
            this.lbl_exoneracion_fecha_emision.Text = "FechaEmision";
            // 
            // txt_exoneracion_porcentaje_exoneracion
            // 
            this.txt_exoneracion_porcentaje_exoneracion.Enabled = false;
            this.txt_exoneracion_porcentaje_exoneracion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_exoneracion_porcentaje_exoneracion.Location = new System.Drawing.Point(211, 156);
            this.txt_exoneracion_porcentaje_exoneracion.Name = "txt_exoneracion_porcentaje_exoneracion";
            this.txt_exoneracion_porcentaje_exoneracion.Size = new System.Drawing.Size(181, 22);
            this.txt_exoneracion_porcentaje_exoneracion.TabIndex = 171;
            // 
            // lbl_exoneracion_nombre_institucion
            // 
            this.lbl_exoneracion_nombre_institucion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_exoneracion_nombre_institucion.Location = new System.Drawing.Point(211, 82);
            this.lbl_exoneracion_nombre_institucion.Name = "lbl_exoneracion_nombre_institucion";
            this.lbl_exoneracion_nombre_institucion.Size = new System.Drawing.Size(133, 14);
            this.lbl_exoneracion_nombre_institucion.TabIndex = 164;
            this.lbl_exoneracion_nombre_institucion.Text = "NombreInstitucion";
            // 
            // txt_exoneracion_nombre_institucion
            // 
            this.txt_exoneracion_nombre_institucion.Enabled = false;
            this.txt_exoneracion_nombre_institucion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_exoneracion_nombre_institucion.Location = new System.Drawing.Point(211, 103);
            this.txt_exoneracion_nombre_institucion.Name = "txt_exoneracion_nombre_institucion";
            this.txt_exoneracion_nombre_institucion.Size = new System.Drawing.Size(181, 22);
            this.txt_exoneracion_nombre_institucion.TabIndex = 165;
            // 
            // txt_exoneracion_fecha_emision
            // 
            this.txt_exoneracion_fecha_emision.Enabled = false;
            this.txt_exoneracion_fecha_emision.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_exoneracion_fecha_emision.Location = new System.Drawing.Point(18, 156);
            this.txt_exoneracion_fecha_emision.Name = "txt_exoneracion_fecha_emision";
            this.txt_exoneracion_fecha_emision.Size = new System.Drawing.Size(181, 22);
            this.txt_exoneracion_fecha_emision.TabIndex = 167;
            // 
            // lbl_exoneracion_numero_documento
            // 
            this.lbl_exoneracion_numero_documento.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_exoneracion_numero_documento.Location = new System.Drawing.Point(18, 82);
            this.lbl_exoneracion_numero_documento.Name = "lbl_exoneracion_numero_documento";
            this.lbl_exoneracion_numero_documento.Size = new System.Drawing.Size(133, 14);
            this.lbl_exoneracion_numero_documento.TabIndex = 162;
            this.lbl_exoneracion_numero_documento.Text = "NumeroDocumento";
            // 
            // txt_exoneracion_numero_documento
            // 
            this.txt_exoneracion_numero_documento.Enabled = false;
            this.txt_exoneracion_numero_documento.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_exoneracion_numero_documento.Location = new System.Drawing.Point(18, 103);
            this.txt_exoneracion_numero_documento.Name = "txt_exoneracion_numero_documento";
            this.txt_exoneracion_numero_documento.Size = new System.Drawing.Size(181, 22);
            this.txt_exoneracion_numero_documento.TabIndex = 163;
            // 
            // cmb_exoneracion_tipo_documento
            // 
            this.cmb_exoneracion_tipo_documento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_exoneracion_tipo_documento.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmb_exoneracion_tipo_documento.FormattingEnabled = true;
            this.cmb_exoneracion_tipo_documento.Location = new System.Drawing.Point(18, 53);
            this.cmb_exoneracion_tipo_documento.Name = "cmb_exoneracion_tipo_documento";
            this.cmb_exoneracion_tipo_documento.Size = new System.Drawing.Size(371, 21);
            this.cmb_exoneracion_tipo_documento.TabIndex = 1;
            // 
            // lbl_exoneracion_tipo_documento
            // 
            this.lbl_exoneracion_tipo_documento.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_exoneracion_tipo_documento.Location = new System.Drawing.Point(18, 32);
            this.lbl_exoneracion_tipo_documento.Name = "lbl_exoneracion_tipo_documento";
            this.lbl_exoneracion_tipo_documento.Size = new System.Drawing.Size(135, 14);
            this.lbl_exoneracion_tipo_documento.TabIndex = 2;
            this.lbl_exoneracion_tipo_documento.Text = "Tipo documento:";
            // 
            // pb_internet
            // 
            this.pb_internet.Image = ((System.Drawing.Image)(resources.GetObject("pb_internet.Image")));
            this.pb_internet.Location = new System.Drawing.Point(1272, 26);
            this.pb_internet.Name = "pb_internet";
            this.pb_internet.Size = new System.Drawing.Size(21, 21);
            this.pb_internet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_internet.TabIndex = 163;
            this.pb_internet.TabStop = false;
            this.pb_internet.Click += new System.EventHandler(this.pb_internet_Click);
            // 
            // lv_client
            // 
            this.lv_client.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lv_client.FullRowSelect = true;
            this.lv_client.GridLines = true;
            this.lv_client.HideSelection = false;
            this.lv_client.Location = new System.Drawing.Point(6, 16);
            this.lv_client.Name = "lv_client";
            this.lv_client.Size = new System.Drawing.Size(751, 223);
            this.lv_client.TabIndex = 146;
            this.lv_client.UseCompatibleStateImageBehavior = false;
            this.lv_client.View = System.Windows.Forms.View.Details;
            this.lv_client.SelectedIndexChanged += new System.EventHandler(this.lv_client_SelectedIndexChanged);
            // 
            // chk_lock_invoice_detail_qty
            // 
            this.chk_lock_invoice_detail_qty.AutoSize = true;
            this.chk_lock_invoice_detail_qty.Checked = true;
            this.chk_lock_invoice_detail_qty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_lock_invoice_detail_qty.Location = new System.Drawing.Point(519, 250);
            this.chk_lock_invoice_detail_qty.Name = "chk_lock_invoice_detail_qty";
            this.chk_lock_invoice_detail_qty.Size = new System.Drawing.Size(36, 17);
            this.chk_lock_invoice_detail_qty.TabIndex = 147;
            this.chk_lock_invoice_detail_qty.Text = "🔒";
            this.chk_lock_invoice_detail_qty.UseVisualStyleBackColor = true;
            // 
            // btn_abarrotes_exento
            // 
            this.btn_abarrotes_exento.Location = new System.Drawing.Point(7, 507);
            this.btn_abarrotes_exento.Name = "btn_abarrotes_exento";
            this.btn_abarrotes_exento.Size = new System.Drawing.Size(104, 40);
            this.btn_abarrotes_exento.TabIndex = 148;
            this.btn_abarrotes_exento.Text = "Abarrotes Exento";
            this.btn_abarrotes_exento.UseMnemonic = false;
            this.btn_abarrotes_exento.UseVisualStyleBackColor = true;
            this.btn_abarrotes_exento.Visible = false;
            this.btn_abarrotes_exento.Click += new System.EventHandler(this.btn_abarrotes_exento_Click);
            // 
            // txt_company_name
            // 
            this.txt_company_name.BackColor = System.Drawing.SystemColors.Control;
            this.txt_company_name.Enabled = false;
            this.txt_company_name.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_company_name.Location = new System.Drawing.Point(200, 26);
            this.txt_company_name.Name = "txt_company_name";
            this.txt_company_name.Size = new System.Drawing.Size(409, 22);
            this.txt_company_name.TabIndex = 66;
            // 
            // txt_company_identification
            // 
            this.txt_company_identification.BackColor = System.Drawing.SystemColors.Control;
            this.txt_company_identification.Enabled = false;
            this.txt_company_identification.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_company_identification.Location = new System.Drawing.Point(13, 26);
            this.txt_company_identification.Name = "txt_company_identification";
            this.txt_company_identification.Size = new System.Drawing.Size(182, 22);
            this.txt_company_identification.TabIndex = 65;
            // 
            // grpClientes
            // 
            this.grpClientes.Controls.Add(this.btn_invoice_client_search_close);
            this.grpClientes.Controls.Add(this.pb1);
            this.grpClientes.Controls.Add(this.btn_search_cloud_api);
            this.grpClientes.Controls.Add(this.lv_client);
            this.grpClientes.Controls.Add(this.lbl_pb);
            this.grpClientes.Location = new System.Drawing.Point(8, 700);
            this.grpClientes.Name = "grpClientes";
            this.grpClientes.Size = new System.Drawing.Size(763, 279);
            this.grpClientes.TabIndex = 149;
            this.grpClientes.TabStop = false;
            this.grpClientes.Text = "Clientes";
            this.grpClientes.Visible = false;
            // 
            // btn_invoice_client_search_close
            // 
            this.btn_invoice_client_search_close.Location = new System.Drawing.Point(692, 258);
            this.btn_invoice_client_search_close.Name = "btn_invoice_client_search_close";
            this.btn_invoice_client_search_close.Size = new System.Drawing.Size(62, 21);
            this.btn_invoice_client_search_close.TabIndex = 150;
            this.btn_invoice_client_search_close.Text = "Cerrar";
            this.btn_invoice_client_search_close.UseVisualStyleBackColor = true;
            this.btn_invoice_client_search_close.Click += new System.EventHandler(this.btn_invoice_client_search_close_Click);
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(95, 240);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(662, 16);
            this.pb1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb1.TabIndex = 148;
            // 
            // btn_search_cloud_api
            // 
            this.btn_search_cloud_api.Location = new System.Drawing.Point(6, 242);
            this.btn_search_cloud_api.Name = "btn_search_cloud_api";
            this.btn_search_cloud_api.Size = new System.Drawing.Size(75, 28);
            this.btn_search_cloud_api.TabIndex = 147;
            this.btn_search_cloud_api.Text = "Internet";
            this.btn_search_cloud_api.UseVisualStyleBackColor = true;
            this.btn_search_cloud_api.Click += new System.EventHandler(this.btn_search_cloud_api_Click);
            // 
            // lbl_pb
            // 
            this.lbl_pb.Location = new System.Drawing.Point(92, 259);
            this.lbl_pb.Name = "lbl_pb";
            this.lbl_pb.Size = new System.Drawing.Size(594, 14);
            this.lbl_pb.TabIndex = 149;
            // 
            // grpFe
            // 
            this.grpFe.Controls.Add(this.txt_lv_fe_report);
            this.grpFe.Controls.Add(this.btn_fe_aceptar);
            this.grpFe.Controls.Add(this.lv_fe_report);
            this.grpFe.Controls.Add(this.pb_fe);
            this.grpFe.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grpFe.Location = new System.Drawing.Point(972, 478);
            this.grpFe.Name = "grpFe";
            this.grpFe.Size = new System.Drawing.Size(308, 207);
            this.grpFe.TabIndex = 150;
            this.grpFe.TabStop = false;
            this.grpFe.Text = "Factura Electronica";
            this.grpFe.Visible = false;
            // 
            // txt_lv_fe_report
            // 
            this.txt_lv_fe_report.Location = new System.Drawing.Point(163, 175);
            this.txt_lv_fe_report.Name = "txt_lv_fe_report";
            this.txt_lv_fe_report.Size = new System.Drawing.Size(139, 20);
            this.txt_lv_fe_report.TabIndex = 153;
            // 
            // btn_fe_aceptar
            // 
            this.btn_fe_aceptar.Location = new System.Drawing.Point(7, 174);
            this.btn_fe_aceptar.Name = "btn_fe_aceptar";
            this.btn_fe_aceptar.Size = new System.Drawing.Size(131, 27);
            this.btn_fe_aceptar.TabIndex = 152;
            this.btn_fe_aceptar.Text = "Aceptar";
            this.btn_fe_aceptar.UseVisualStyleBackColor = true;
            this.btn_fe_aceptar.Visible = false;
            this.btn_fe_aceptar.Click += new System.EventHandler(this.btn_fe_aceptar_Click);
            // 
            // lv_fe_report
            // 
            this.lv_fe_report.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lv_fe_report.FullRowSelect = true;
            this.lv_fe_report.GridLines = true;
            this.lv_fe_report.HideSelection = false;
            this.lv_fe_report.Location = new System.Drawing.Point(7, 17);
            this.lv_fe_report.Name = "lv_fe_report";
            this.lv_fe_report.Size = new System.Drawing.Size(295, 127);
            this.lv_fe_report.TabIndex = 151;
            this.lv_fe_report.UseCompatibleStateImageBehavior = false;
            this.lv_fe_report.View = System.Windows.Forms.View.Details;
            this.lv_fe_report.SelectedIndexChanged += new System.EventHandler(this.lv_fe_report_SelectedIndexChanged);
            // 
            // pb_fe
            // 
            this.pb_fe.Location = new System.Drawing.Point(6, 150);
            this.pb_fe.Name = "pb_fe";
            this.pb_fe.Size = new System.Drawing.Size(296, 19);
            this.pb_fe.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_fe.TabIndex = 150;
            // 
            // txt_company_id
            // 
            this.txt_company_id.BackColor = System.Drawing.SystemColors.Control;
            this.txt_company_id.Enabled = false;
            this.txt_company_id.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_company_id.Location = new System.Drawing.Point(708, 26);
            this.txt_company_id.Name = "txt_company_id";
            this.txt_company_id.Size = new System.Drawing.Size(37, 22);
            this.txt_company_id.TabIndex = 151;
            // 
            // btn_abarrotes_gravado
            // 
            this.btn_abarrotes_gravado.Location = new System.Drawing.Point(114, 507);
            this.btn_abarrotes_gravado.Name = "btn_abarrotes_gravado";
            this.btn_abarrotes_gravado.Size = new System.Drawing.Size(104, 40);
            this.btn_abarrotes_gravado.TabIndex = 152;
            this.btn_abarrotes_gravado.Text = "Abarrotes Gravado";
            this.btn_abarrotes_gravado.UseVisualStyleBackColor = true;
            this.btn_abarrotes_gravado.Visible = false;
            this.btn_abarrotes_gravado.Click += new System.EventHandler(this.btn_abarrotes_gravado_Click);
            // 
            // txt_company_ter
            // 
            this.txt_company_ter.BackColor = System.Drawing.SystemColors.Control;
            this.txt_company_ter.Enabled = false;
            this.txt_company_ter.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_company_ter.Location = new System.Drawing.Point(614, 26);
            this.txt_company_ter.Name = "txt_company_ter";
            this.txt_company_ter.Size = new System.Drawing.Size(89, 22);
            this.txt_company_ter.TabIndex = 153;
            // 
            // lv_product_search
            // 
            this.lv_product_search.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lv_product_search.FullRowSelect = true;
            this.lv_product_search.GridLines = true;
            this.lv_product_search.HideSelection = false;
            this.lv_product_search.Location = new System.Drawing.Point(7, 850);
            this.lv_product_search.Name = "lv_product_search";
            this.lv_product_search.Size = new System.Drawing.Size(551, 223);
            this.lv_product_search.TabIndex = 155;
            this.lv_product_search.UseCompatibleStateImageBehavior = false;
            this.lv_product_search.View = System.Windows.Forms.View.Details;
            this.lv_product_search.SelectedIndexChanged += new System.EventHandler(this.lv_product_search_SelectedIndexChanged);
            // 
            // chk_lock_invoice_detail_search_description
            // 
            this.chk_lock_invoice_detail_search_description.Image = ((System.Drawing.Image)(resources.GetObject("chk_lock_invoice_detail_search_description.Image")));
            this.chk_lock_invoice_detail_search_description.Location = new System.Drawing.Point(115, 206);
            this.chk_lock_invoice_detail_search_description.Name = "chk_lock_invoice_detail_search_description";
            this.chk_lock_invoice_detail_search_description.Size = new System.Drawing.Size(37, 21);
            this.chk_lock_invoice_detail_search_description.TabIndex = 156;
            this.chk_lock_invoice_detail_search_description.Text = ".";
            this.chk_lock_invoice_detail_search_description.UseVisualStyleBackColor = true;
            this.chk_lock_invoice_detail_search_description.Click += new System.EventHandler(this.chk_lock_invoice_detail_search_description_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(763, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 128;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_invoice_save_print
            // 
            this.btn_invoice_save_print.Enabled = false;
            this.btn_invoice_save_print.Image = ((System.Drawing.Image)(resources.GetObject("btn_invoice_save_print.Image")));
            this.btn_invoice_save_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_invoice_save_print.Location = new System.Drawing.Point(988, 383);
            this.btn_invoice_save_print.Name = "btn_invoice_save_print";
            this.btn_invoice_save_print.Size = new System.Drawing.Size(130, 49);
            this.btn_invoice_save_print.TabIndex = 9;
            this.btn_invoice_save_print.Text = "Save && Print";
            this.btn_invoice_save_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_invoice_save_print.UseVisualStyleBackColor = true;
            this.btn_invoice_save_print.Click += new System.EventHandler(this.btn_invoice_save_print_Click);
            // 
            // il_internet
            // 
            this.il_internet.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_internet.ImageStream")));
            this.il_internet.TransparentColor = System.Drawing.Color.Transparent;
            this.il_internet.Images.SetKeyName(0, "green.png");
            this.il_internet.Images.SetKeyName(1, "blue.png");
            this.il_internet.Images.SetKeyName(2, "yellow.png");
            this.il_internet.Images.SetKeyName(3, "red.png");
            // 
            // lbl_invoice_pending
            // 
            this.lbl_invoice_pending.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_invoice_pending.Location = new System.Drawing.Point(1099, 29);
            this.lbl_invoice_pending.Name = "lbl_invoice_pending";
            this.lbl_invoice_pending.Size = new System.Drawing.Size(167, 14);
            this.lbl_invoice_pending.TabIndex = 68;
            // 
            // timer_invoice_pending
            // 
            this.timer_invoice_pending.Enabled = true;
            this.timer_invoice_pending.Interval = 20000;
            this.timer_invoice_pending.Tick += new System.EventHandler(this.timer_invoice_pending_Tick);
            // 
            // timer_invoice_db
            // 
            this.timer_invoice_db.Enabled = true;
            this.timer_invoice_db.Interval = 300000;
            this.timer_invoice_db.Tick += new System.EventHandler(this.timer_invoice_db_Tick);
            // 
            // pnl_pendientes
            // 
            this.pnl_pendientes.Controls.Add(this.lbl_enviando);
            this.pnl_pendientes.Location = new System.Drawing.Point(361, 800);
            this.pnl_pendientes.Name = "pnl_pendientes";
            this.pnl_pendientes.Size = new System.Drawing.Size(606, 289);
            this.pnl_pendientes.TabIndex = 164;
            this.pnl_pendientes.Visible = false;
            // 
            // lbl_enviando
            // 
            this.lbl_enviando.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_enviando.Location = new System.Drawing.Point(166, 92);
            this.lbl_enviando.Name = "lbl_enviando";
            this.lbl_enviando.Size = new System.Drawing.Size(284, 86);
            this.lbl_enviando.TabIndex = 139;
            this.lbl_enviando.Text = "Enviando pendientes, por favor esperar.";
            this.lbl_enviando.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_invoice_cliente_saldo
            // 
            this.txt_invoice_cliente_saldo.BackColor = System.Drawing.SystemColors.Control;
            this.txt_invoice_cliente_saldo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_invoice_cliente_saldo.ForeColor = System.Drawing.Color.Black;
            this.txt_invoice_cliente_saldo.Location = new System.Drawing.Point(477, 514);
            this.txt_invoice_cliente_saldo.Name = "txt_invoice_cliente_saldo";
            this.txt_invoice_cliente_saldo.ReadOnly = true;
            this.txt_invoice_cliente_saldo.ShortcutsEnabled = false;
            this.txt_invoice_cliente_saldo.Size = new System.Drawing.Size(158, 35);
            this.txt_invoice_cliente_saldo.TabIndex = 166;
            this.txt_invoice_cliente_saldo.Text = "999,999,999.12345";
            this.txt_invoice_cliente_saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_invoice_cliente_saldo
            // 
            this.lbl_invoice_cliente_saldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_invoice_cliente_saldo.Location = new System.Drawing.Point(323, 515);
            this.lbl_invoice_cliente_saldo.Name = "lbl_invoice_cliente_saldo";
            this.lbl_invoice_cliente_saldo.Size = new System.Drawing.Size(150, 24);
            this.lbl_invoice_cliente_saldo.TabIndex = 165;
            this.lbl_invoice_cliente_saldo.Text = "Saldo Cliente";
            this.lbl_invoice_cliente_saldo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_invoice_line_tax_code_iva
            // 
            this.txt_invoice_line_tax_code_iva.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_tax_code_iva.Location = new System.Drawing.Point(682, 248);
            this.txt_invoice_line_tax_code_iva.Name = "txt_invoice_line_tax_code_iva";
            this.txt_invoice_line_tax_code_iva.Size = new System.Drawing.Size(20, 14);
            this.txt_invoice_line_tax_code_iva.TabIndex = 167;
            this.txt_invoice_line_tax_code_iva.Text = "00";
            // 
            // lbl_sel_tipo_doc
            // 
            this.lbl_sel_tipo_doc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sel_tipo_doc.Location = new System.Drawing.Point(988, 435);
            this.lbl_sel_tipo_doc.Name = "lbl_sel_tipo_doc";
            this.lbl_sel_tipo_doc.Size = new System.Drawing.Size(278, 24);
            this.lbl_sel_tipo_doc.TabIndex = 168;
            this.lbl_sel_tipo_doc.Text = ".";
            this.lbl_sel_tipo_doc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grp_descuento
            // 
            this.grp_descuento.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grp_descuento.Controls.Add(this.lbl_descuentos_precio_iva);
            this.grp_descuento.Controls.Add(this.label6);
            this.grp_descuento.Controls.Add(this.txt_descuentos_precio_final);
            this.grp_descuento.Controls.Add(this.label5);
            this.grp_descuento.Controls.Add(this.lbl_descuentos_precio_original);
            this.grp_descuento.Controls.Add(this.lbl_descuento_producto_descripcion);
            this.grp_descuento.Controls.Add(this.btn_descuentos_cerrar);
            this.grp_descuento.Controls.Add(this.lbl_descuentos_precio_final);
            this.grp_descuento.Controls.Add(this.label1);
            this.grp_descuento.Controls.Add(this.btn_descuentos_aplicar);
            this.grp_descuento.Controls.Add(this.label2);
            this.grp_descuento.Controls.Add(this.label3);
            this.grp_descuento.Controls.Add(this.txt_descuentos_monto);
            this.grp_descuento.Controls.Add(this.txt_descuentos_razon);
            this.grp_descuento.Controls.Add(this.label4);
            this.grp_descuento.Controls.Add(this.txt_descuentos_porcentaje);
            this.grp_descuento.Location = new System.Drawing.Point(40, 319);
            this.grp_descuento.Margin = new System.Windows.Forms.Padding(10);
            this.grp_descuento.Name = "grp_descuento";
            this.grp_descuento.Size = new System.Drawing.Size(539, 160);
            this.grp_descuento.TabIndex = 175;
            this.grp_descuento.TabStop = false;
            this.grp_descuento.Text = "Descuento";
            this.grp_descuento.Visible = false;
            // 
            // lbl_descuentos_precio_iva
            // 
            this.lbl_descuentos_precio_iva.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_descuentos_precio_iva.Location = new System.Drawing.Point(431, 90);
            this.lbl_descuentos_precio_iva.Name = "lbl_descuentos_precio_iva";
            this.lbl_descuentos_precio_iva.Size = new System.Drawing.Size(92, 14);
            this.lbl_descuentos_precio_iva.TabIndex = 181;
            this.lbl_descuentos_precio_iva.Text = "IVA_decuento";
            this.lbl_descuentos_precio_iva.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label6.Location = new System.Drawing.Point(11, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 14);
            this.label6.TabIndex = 180;
            this.label6.Text = "o Monto Total Con Descuento";
            // 
            // txt_descuentos_precio_final
            // 
            this.txt_descuentos_precio_final.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_descuentos_precio_final.Location = new System.Drawing.Point(184, 81);
            this.txt_descuentos_precio_final.Name = "txt_descuentos_precio_final";
            this.txt_descuentos_precio_final.Size = new System.Drawing.Size(152, 22);
            this.txt_descuentos_precio_final.TabIndex = 179;
            this.txt_descuentos_precio_final.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_descuentos_precio_final_KeyUp);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label5.Location = new System.Drawing.Point(11, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 14);
            this.label5.TabIndex = 178;
            this.label5.Text = "Precio Sub-Total";
            // 
            // lbl_descuentos_precio_original
            // 
            this.lbl_descuentos_precio_original.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_descuentos_precio_original.Location = new System.Drawing.Point(11, 54);
            this.lbl_descuentos_precio_original.Name = "lbl_descuentos_precio_original";
            this.lbl_descuentos_precio_original.Size = new System.Drawing.Size(89, 14);
            this.lbl_descuentos_precio_original.TabIndex = 177;
            this.lbl_descuentos_precio_original.Text = "precio_unitario";
            // 
            // lbl_descuento_producto_descripcion
            // 
            this.lbl_descuento_producto_descripcion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_descuento_producto_descripcion.Location = new System.Drawing.Point(113, 11);
            this.lbl_descuento_producto_descripcion.Name = "lbl_descuento_producto_descripcion";
            this.lbl_descuento_producto_descripcion.Size = new System.Drawing.Size(376, 15);
            this.lbl_descuento_producto_descripcion.TabIndex = 176;
            this.lbl_descuento_producto_descripcion.Text = "descripcion_producto";
            // 
            // btn_descuentos_cerrar
            // 
            this.btn_descuentos_cerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_descuentos_cerrar.Location = new System.Drawing.Point(495, 11);
            this.btn_descuentos_cerrar.Name = "btn_descuentos_cerrar";
            this.btn_descuentos_cerrar.Size = new System.Drawing.Size(31, 29);
            this.btn_descuentos_cerrar.TabIndex = 175;
            this.btn_descuentos_cerrar.Text = "X";
            this.btn_descuentos_cerrar.UseVisualStyleBackColor = true;
            this.btn_descuentos_cerrar.Click += new System.EventHandler(this.btn_descuentos_cerrar_Click);
            // 
            // lbl_descuentos_precio_final
            // 
            this.lbl_descuentos_precio_final.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_descuentos_precio_final.Location = new System.Drawing.Point(278, 54);
            this.lbl_descuentos_precio_final.Name = "lbl_descuentos_precio_final";
            this.lbl_descuentos_precio_final.Size = new System.Drawing.Size(92, 14);
            this.lbl_descuentos_precio_final.TabIndex = 174;
            this.lbl_descuentos_precio_final.Text = "total_descuento";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.Location = new System.Drawing.Point(278, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 14);
            this.label1.TabIndex = 173;
            this.label1.Text = "SubTotal c/ Descuento aplicado";
            // 
            // btn_descuentos_aplicar
            // 
            this.btn_descuentos_aplicar.Enabled = false;
            this.btn_descuentos_aplicar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_descuentos_aplicar.Location = new System.Drawing.Point(417, 112);
            this.btn_descuentos_aplicar.Name = "btn_descuentos_aplicar";
            this.btn_descuentos_aplicar.Size = new System.Drawing.Size(109, 43);
            this.btn_descuentos_aplicar.TabIndex = 172;
            this.btn_descuentos_aplicar.Text = "Salvar Descuento";
            this.btn_descuentos_aplicar.UseVisualStyleBackColor = true;
            this.btn_descuentos_aplicar.Click += new System.EventHandler(this.btn_descuentos_aplicar_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label2.Location = new System.Drawing.Point(11, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 14);
            this.label2.TabIndex = 166;
            this.label2.Text = "Razon Descuento";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label3.Location = new System.Drawing.Point(184, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 164;
            this.label3.Text = "o Monto";
            // 
            // txt_descuentos_monto
            // 
            this.txt_descuentos_monto.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_descuentos_monto.Location = new System.Drawing.Point(184, 49);
            this.txt_descuentos_monto.Name = "txt_descuentos_monto";
            this.txt_descuentos_monto.Size = new System.Drawing.Size(81, 22);
            this.txt_descuentos_monto.TabIndex = 165;
            this.txt_descuentos_monto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_descuentos_monto_KeyUp);
            // 
            // txt_descuentos_razon
            // 
            this.txt_descuentos_razon.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_descuentos_razon.Location = new System.Drawing.Point(14, 131);
            this.txt_descuentos_razon.Name = "txt_descuentos_razon";
            this.txt_descuentos_razon.Size = new System.Drawing.Size(366, 22);
            this.txt_descuentos_razon.TabIndex = 167;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label4.Location = new System.Drawing.Point(113, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 14);
            this.label4.TabIndex = 162;
            this.label4.Text = "Porcentaje";
            // 
            // txt_descuentos_porcentaje
            // 
            this.txt_descuentos_porcentaje.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_descuentos_porcentaje.Location = new System.Drawing.Point(113, 49);
            this.txt_descuentos_porcentaje.Name = "txt_descuentos_porcentaje";
            this.txt_descuentos_porcentaje.Size = new System.Drawing.Size(62, 22);
            this.txt_descuentos_porcentaje.TabIndex = 163;
            this.txt_descuentos_porcentaje.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_descuentos_porcentaje_KeyUp);
            // 
            // btn_abarrotes_canastabasica
            // 
            this.btn_abarrotes_canastabasica.Location = new System.Drawing.Point(221, 506);
            this.btn_abarrotes_canastabasica.Name = "btn_abarrotes_canastabasica";
            this.btn_abarrotes_canastabasica.Size = new System.Drawing.Size(104, 40);
            this.btn_abarrotes_canastabasica.TabIndex = 176;
            this.btn_abarrotes_canastabasica.Text = "Canasta Basica";
            this.btn_abarrotes_canastabasica.UseVisualStyleBackColor = true;
            this.btn_abarrotes_canastabasica.Visible = false;
            this.btn_abarrotes_canastabasica.Click += new System.EventHandler(this.btn_abarrotes_canastabasica_Click);
            // 
            // lbl_invoice_line_cabys_desc
            // 
            this.lbl_invoice_line_cabys_desc.BackColor = System.Drawing.Color.White;
            this.lbl_invoice_line_cabys_desc.Location = new System.Drawing.Point(113, 269);
            this.lbl_invoice_line_cabys_desc.Name = "lbl_invoice_line_cabys_desc";
            this.lbl_invoice_line_cabys_desc.Size = new System.Drawing.Size(853, 22);
            this.lbl_invoice_line_cabys_desc.TabIndex = 177;
            this.lbl_invoice_line_cabys_desc.Text = "Descripcion CABYS";
            // 
            // txt_invoice_line_cabys_code
            // 
            this.txt_invoice_line_cabys_code.BackColor = System.Drawing.SystemColors.Control;
            this.txt_invoice_line_cabys_code.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_cabys_code.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_invoice_line_cabys_code.Location = new System.Drawing.Point(9, 270);
            this.txt_invoice_line_cabys_code.Name = "txt_invoice_line_cabys_code";
            this.txt_invoice_line_cabys_code.ReadOnly = true;
            this.txt_invoice_line_cabys_code.Size = new System.Drawing.Size(107, 22);
            this.txt_invoice_line_cabys_code.TabIndex = 179;
            this.txt_invoice_line_cabys_code.Text = "1234567890123";
            // 
            // txt_invoice_line_price_descuento_monto
            // 
            this.txt_invoice_line_price_descuento_monto.BackColor = System.Drawing.SystemColors.Window;
            this.txt_invoice_line_price_descuento_monto.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_price_descuento_monto.Location = new System.Drawing.Point(833, 203);
            this.txt_invoice_line_price_descuento_monto.Name = "txt_invoice_line_price_descuento_monto";
            this.txt_invoice_line_price_descuento_monto.Size = new System.Drawing.Size(45, 22);
            this.txt_invoice_line_price_descuento_monto.TabIndex = 180;
            this.txt_invoice_line_price_descuento_monto.Text = "DESC MONTO";
            this.txt_invoice_line_price_descuento_monto.Visible = false;
            // 
            // txt_invoice_line_price_descuento_razon
            // 
            this.txt_invoice_line_price_descuento_razon.BackColor = System.Drawing.SystemColors.Window;
            this.txt_invoice_line_price_descuento_razon.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_invoice_line_price_descuento_razon.Location = new System.Drawing.Point(884, 203);
            this.txt_invoice_line_price_descuento_razon.Name = "txt_invoice_line_price_descuento_razon";
            this.txt_invoice_line_price_descuento_razon.Size = new System.Drawing.Size(45, 22);
            this.txt_invoice_line_price_descuento_razon.TabIndex = 181;
            this.txt_invoice_line_price_descuento_razon.Text = "DESC RAZON";
            this.txt_invoice_line_price_descuento_razon.Visible = false;
            // 
            // TotalDescuento
            // 
            this.TotalDescuento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TotalDescuento.Image = ((System.Drawing.Image)(resources.GetObject("TotalDescuento.Image")));
            this.TotalDescuento.Location = new System.Drawing.Point(659, 619);
            this.TotalDescuento.Name = "TotalDescuento";
            this.TotalDescuento.Size = new System.Drawing.Size(56, 50);
            this.TotalDescuento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TotalDescuento.TabIndex = 182;
            this.TotalDescuento.TabStop = false;
            this.TotalDescuento.Click += new System.EventHandler(this.TotalDescuento_Click);
            // 
            // grp_descuento_total
            // 
            this.grp_descuento_total.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grp_descuento_total.Controls.Add(this.lbl_descuentos_total_original);
            this.grp_descuento_total.Controls.Add(this.label7);
            this.grp_descuento_total.Controls.Add(this.label8);
            this.grp_descuento_total.Controls.Add(this.txt_descuentos_total_precio_final);
            this.grp_descuento_total.Controls.Add(this.btn_descuentos_total_cerrar);
            this.grp_descuento_total.Controls.Add(this.btn_descuentos_total_aplicar);
            this.grp_descuento_total.Location = new System.Drawing.Point(327, 301);
            this.grp_descuento_total.Margin = new System.Windows.Forms.Padding(10);
            this.grp_descuento_total.Name = "grp_descuento_total";
            this.grp_descuento_total.Size = new System.Drawing.Size(539, 160);
            this.grp_descuento_total.TabIndex = 182;
            this.grp_descuento_total.TabStop = false;
            this.grp_descuento_total.Text = "Descuento Total Factura";
            this.grp_descuento_total.Visible = false;
            // 
            // lbl_descuentos_total_original
            // 
            this.lbl_descuentos_total_original.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_descuentos_total_original.Location = new System.Drawing.Point(218, 57);
            this.lbl_descuentos_total_original.Name = "lbl_descuentos_total_original";
            this.lbl_descuentos_total_original.Size = new System.Drawing.Size(145, 14);
            this.lbl_descuentos_total_original.TabIndex = 182;
            this.lbl_descuentos_total_original.Text = "total 0.000.000";
            this.lbl_descuentos_total_original.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label7.Location = new System.Drawing.Point(39, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 14);
            this.label7.TabIndex = 181;
            this.label7.Text = "Monto Total :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label8.Location = new System.Drawing.Point(39, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 14);
            this.label8.TabIndex = 180;
            this.label8.Text = "Monto Total Con Descuento :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_descuentos_total_precio_final
            // 
            this.txt_descuentos_total_precio_final.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_descuentos_total_precio_final.Location = new System.Drawing.Point(212, 71);
            this.txt_descuentos_total_precio_final.Name = "txt_descuentos_total_precio_final";
            this.txt_descuentos_total_precio_final.Size = new System.Drawing.Size(152, 22);
            this.txt_descuentos_total_precio_final.TabIndex = 179;
            // 
            // btn_descuentos_total_cerrar
            // 
            this.btn_descuentos_total_cerrar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_descuentos_total_cerrar.Location = new System.Drawing.Point(495, 11);
            this.btn_descuentos_total_cerrar.Name = "btn_descuentos_total_cerrar";
            this.btn_descuentos_total_cerrar.Size = new System.Drawing.Size(31, 29);
            this.btn_descuentos_total_cerrar.TabIndex = 175;
            this.btn_descuentos_total_cerrar.Text = "X";
            this.btn_descuentos_total_cerrar.UseVisualStyleBackColor = true;
            this.btn_descuentos_total_cerrar.Click += new System.EventHandler(this.btn_descuentos_total_cerrar_Click);
            // 
            // btn_descuentos_total_aplicar
            // 
            this.btn_descuentos_total_aplicar.Enabled = false;
            this.btn_descuentos_total_aplicar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_descuentos_total_aplicar.Location = new System.Drawing.Point(363, 112);
            this.btn_descuentos_total_aplicar.Name = "btn_descuentos_total_aplicar";
            this.btn_descuentos_total_aplicar.Size = new System.Drawing.Size(163, 43);
            this.btn_descuentos_total_aplicar.TabIndex = 172;
            this.btn_descuentos_total_aplicar.Text = "Salvar Descuento Factura";
            this.btn_descuentos_total_aplicar.UseVisualStyleBackColor = true;
            this.btn_descuentos_total_aplicar.Click += new System.EventHandler(this.btn_descuentos_total_aplicar_Click);
            // 
            // frm_pos_invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1294, 685);
            this.Controls.Add(this.lbl_computer_name);
            this.Controls.Add(this.grp_exoneracion);
            this.Controls.Add(this.grp_descuento_total);
            this.Controls.Add(this.TotalDescuento);
            this.Controls.Add(this.txt_invoice_line_price_descuento_razon);
            this.Controls.Add(this.txt_invoice_line_price_descuento_monto);
            this.Controls.Add(this.txt_invoice_line_cabys_code);
            this.Controls.Add(this.lbl_invoice_line_cabys_desc);
            this.Controls.Add(this.grp_descuento);
            this.Controls.Add(this.btn_abarrotes_canastabasica);
            this.Controls.Add(this.grpClientes);
            this.Controls.Add(this.lbl_sel_tipo_doc);
            this.Controls.Add(this.txt_invoice_line_tax_code_iva);
            this.Controls.Add(this.txt_invoice_cliente_saldo);
            this.Controls.Add(this.lbl_invoice_cliente_saldo);
            this.Controls.Add(this.lbl_invoice_pending);
            this.Controls.Add(this.pb_internet);
            this.Controls.Add(this.lv_product_search);
            this.Controls.Add(this.txt_company_ter);
            this.Controls.Add(this.grpFe);
            this.Controls.Add(this.btn_abarrotes_gravado);
            this.Controls.Add(this.txt_company_id);
            this.Controls.Add(this.txt_company_name);
            this.Controls.Add(this.txt_company_identification);
            this.Controls.Add(this.btn_abarrotes_exento);
            this.Controls.Add(this.chk_lock_invoice_detail_qty);
            this.Controls.Add(this.grp_efectivo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_invoice_line_sym_code_type);
            this.Controls.Add(this.txt_invoice_line_tax_code);
            this.Controls.Add(this.txt_invoice_line_id_producto);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_invoice_save_email);
            this.Controls.Add(this.btn_invoice_save_print);
            this.Controls.Add(this.txt_invoice_totals_total);
            this.Controls.Add(this.txt_invoice_totals_tax);
            this.Controls.Add(this.txt_invoice_totals_subtotal);
            this.Controls.Add(this.lbl_invoice_total);
            this.Controls.Add(this.lbl_invoice_total_tax);
            this.Controls.Add(this.lbl_invoice_subtotal);
            this.Controls.Add(this.txt_invoice_line_sym_unit);
            this.Controls.Add(this.grp_invoice_header);
            this.Controls.Add(this.lbl_edit_invoice_line);
            this.Controls.Add(this.cmb_btn_action);
            this.Controls.Add(this.txt_invoice_line_tax);
            this.Controls.Add(this.txt_invoice_line_cur);
            this.Controls.Add(this.txt_invoice_line_sym);
            this.Controls.Add(this.txt_invoice_line_price_tax);
            this.Controls.Add(this.lbl_invoice_line_tax);
            this.Controls.Add(this.lbl_invoice_line_total);
            this.Controls.Add(this.txt_invoice_line_price_total);
            this.Controls.Add(this.lbl_invoice_line_price);
            this.Controls.Add(this.lbl_invoice_line_qty);
            this.Controls.Add(this.lbl_invoice_line_description);
            this.Controls.Add(this.lbl_invoice_line_barcode);
            this.Controls.Add(this.txt_invoice_line_price);
            this.Controls.Add(this.txt_invoice_line_description);
            this.Controls.Add(this.txt_invoice_line_qty);
            this.Controls.Add(this.txt_invoice_line_barcode);
            this.Controls.Add(this.mnuS1);
            this.Controls.Add(this.grp_fe_calculos);
            this.Controls.Add(this.txt_invoice_line_price_subtotal);
            this.Controls.Add(this.chk_lock_invoice_detail_search_description);
            this.Controls.Add(this.grp_invoice_client);
            this.Controls.Add(this.lbl_invoice_line_barcode_result);
            this.Controls.Add(this.pnl_pendientes);
            this.Controls.Add(this.lv_invoice_detail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mnuS1;
            this.MaximizeBox = false;
            this.Name = "frm_pos_invoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_pos_invoice_FormClosing);
            this.Load += new System.EventHandler(this.frm_pos_invoice_Load);
            this.Shown += new System.EventHandler(this.frm_pos_invoice_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_pos_invoice_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frm_pos_invoice_MouseClick);
            this.grp_invoice_client.ResumeLayout(false);
            this.grp_invoice_client.PerformLayout();
            this.grp_invoice_header.ResumeLayout(false);
            this.grp_invoice_header.PerformLayout();
            this.grp_fe_calculos.ResumeLayout(false);
            this.grp_fe_calculos.PerformLayout();
            this.grp_efectivo.ResumeLayout(false);
            this.grp_efectivo.PerformLayout();
            this.grp_exoneracion.ResumeLayout(false);
            this.grp_exoneracion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_internet)).EndInit();
            this.grpClientes.ResumeLayout(false);
            this.grpFe.ResumeLayout(false);
            this.grpFe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_pendientes.ResumeLayout(false);
            this.grp_descuento.ResumeLayout(false);
            this.grp_descuento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDescuento)).EndInit();
            this.grp_descuento_total.ResumeLayout(false);
            this.grp_descuento_total.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lv_invoice_detail;
        private System.Windows.Forms.TextBox txt_invoice_line_barcode;
        private System.Windows.Forms.TextBox txt_invoice_line_qty;
        private System.Windows.Forms.TextBox txt_invoice_line_description;
        private System.Windows.Forms.TextBox txt_invoice_line_price;
        private System.Windows.Forms.Label lbl_invoice_line_barcode;
        private System.Windows.Forms.Label lbl_invoice_line_description;
        private System.Windows.Forms.Label lbl_invoice_line_qty;
        private System.Windows.Forms.Label lbl_invoice_line_price;
        private System.Windows.Forms.Label lbl_invoice_sale_type;
        private System.Windows.Forms.ComboBox cmb_invoice_sale_type;
        private System.Windows.Forms.Label lbl_invoice_client_phone_number;
        private System.Windows.Forms.TextBox txt_invoice_client_phone_number;
        private System.Windows.Forms.Label lbl_invoice_client_name;
        private System.Windows.Forms.TextBox txt_invoice_client_name;
        private System.Windows.Forms.Label lbl_invoice_client_identification;
        private System.Windows.Forms.TextBox txt_invoice_client_identification;
        private System.Windows.Forms.Button btn_invoice_client_add;
        private System.Windows.Forms.Label lbl_invoice_credit_days;
        private System.Windows.Forms.TextBox txt_invoice_credit_days;
        private System.Windows.Forms.Label lbl_invoice_document_type;
        private System.Windows.Forms.GroupBox grp_invoice_client;
        private System.Windows.Forms.Label lbl_invoice_cur;
        private System.Windows.Forms.ComboBox cmb_invoice_cur;
        private System.Windows.Forms.Label lbl_invoice_exchange;
        private System.Windows.Forms.TextBox txt_invoice_cur;
        private System.Windows.Forms.TextBox txt_invoice_line_price_total;
        private System.Windows.Forms.Label lbl_invoice_line_total;
        private System.Windows.Forms.MenuStrip mnuS1;
        private System.Windows.Forms.Label lbl_invoice_line_tax;
        private System.Windows.Forms.ComboBox cmb_invoice_document_type;
        private System.Windows.Forms.Label lbl_invoice_line_barcode_result;
        private System.Windows.Forms.TextBox txt_invoice_line_price_tax;
        private System.Windows.Forms.Label txt_invoice_line_sym;
        private System.Windows.Forms.Label txt_invoice_line_cur;
        private System.Windows.Forms.Label txt_invoice_line_tax;
        private System.Windows.Forms.ComboBox cmb_btn_action;
        private System.Windows.Forms.Label lbl_edit_invoice_line;
        private System.Windows.Forms.GroupBox grp_invoice_header;
        private System.Windows.Forms.Label txt_invoice_line_sym_unit;
        private System.Windows.Forms.Label lbl_invoice_subtotal;
        private System.Windows.Forms.Label lbl_invoice_total_tax;
        private System.Windows.Forms.Label lbl_invoice_total;
        private System.Windows.Forms.TextBox txt_invoice_totals_subtotal;
        private System.Windows.Forms.TextBox txt_invoice_totals_tax;
        private System.Windows.Forms.TextBox txt_invoice_totals_total;
        private System.Windows.Forms.GroupBox grp_fe_calculos;
        private System.Windows.Forms.Label lbl_TotalServGravados;
        private System.Windows.Forms.Label lbl_TotalComprobante;
        private System.Windows.Forms.Label lbl_TotalServExentos;
        private System.Windows.Forms.Label lbl_TotalImpuesto;
        private System.Windows.Forms.Label lbl_TotalMercanciasGravadas;
        private System.Windows.Forms.Label lbl_TotalVentaNeta;
        private System.Windows.Forms.Label lbl_TotalMercanciasExentas;
        private System.Windows.Forms.Label lbl_TotalDescuentos;
        private System.Windows.Forms.Label lbl_TotalGravado;
        private System.Windows.Forms.Label lbl_TotalVenta;
        private System.Windows.Forms.Label lbl_TotalExento;
        private System.Windows.Forms.Button btn_invoice_save_print;
        private System.Windows.Forms.Button btn_invoice_save_email;
        private System.Windows.Forms.TextBox txt_TotalComprobante;
        private System.Windows.Forms.TextBox txt_TotalImpuesto;
        private System.Windows.Forms.TextBox txt_TotalVentaNeta;
        private System.Windows.Forms.TextBox txt_TotalDescuentos;
        private System.Windows.Forms.TextBox txt_TotalVenta;
        private System.Windows.Forms.TextBox txt_TotalExento;
        private System.Windows.Forms.TextBox txt_TotalGravado;
        private System.Windows.Forms.TextBox txt_TotalMercanciasExentas;
        private System.Windows.Forms.TextBox txt_TotalMercanciasGravadas;
        private System.Windows.Forms.TextBox txt_TotalServExentos;
        private System.Windows.Forms.TextBox txt_TotalServGravados;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txt_invoice_client_email;
        private System.Windows.Forms.Label lbl_invoice_client_email;
        private System.Windows.Forms.Label txt_invoice_line_id_producto;
        private System.Windows.Forms.Label txt_invoice_line_tax_code;
        private System.Windows.Forms.Label txt_invoice_line_sym_code_type;
        private System.Windows.Forms.TextBox txt_invoice_line_price_subtotal;
        private System.Windows.Forms.TextBox txt_cal_pagacon;
        private System.Windows.Forms.TextBox txt_cal_vuelto;
        private System.Windows.Forms.Label lbl_cal_vuelto;
        private System.Windows.Forms.Label lbl_cal_pagacon;
        private System.Windows.Forms.Button btn_col1;
        private System.Windows.Forms.Button btn_col2;
        private System.Windows.Forms.Button btn_col3;
        private System.Windows.Forms.Button btn_col4;
        private System.Windows.Forms.Button btn_col5;
        private System.Windows.Forms.Button btn_col6;
        private System.Windows.Forms.GroupBox grp_efectivo;
        private System.Windows.Forms.Button btn_cred;
        private System.Windows.Forms.ListView lv_client;
        private System.Windows.Forms.CheckBox chk_lock_invoice_detail_qty;
        private System.Windows.Forms.Button btn_abarrotes_exento;
        private System.Windows.Forms.TextBox txt_company_name;
        private System.Windows.Forms.TextBox txt_company_identification;
        private System.Windows.Forms.GroupBox grpClientes;
        private System.Windows.Forms.Button btn_search_cloud_api;
        private System.Windows.Forms.ProgressBar pb1;
        private System.Windows.Forms.Label lbl_pb;
        private System.Windows.Forms.GroupBox grpFe;
        private System.Windows.Forms.Button btn_fe_aceptar;
        private System.Windows.Forms.ListView lv_fe_report;
        private System.Windows.Forms.ProgressBar pb_fe;
        private System.Windows.Forms.TextBox txt_company_id;
        private System.Windows.Forms.Button btn_abarrotes_gravado;
        private System.Windows.Forms.Button btn_efectivo;
        private System.Windows.Forms.TextBox txt_lv_fe_report;
        private System.Windows.Forms.TextBox txt_company_ter;
        private System.Windows.Forms.ListView lv_product_search;
        private System.Windows.Forms.CheckBox chk_lock_invoice_detail_search_description;
        private System.Windows.Forms.ComboBox cmb_invoice_clients_id_type;
        private System.Windows.Forms.PictureBox pb_internet;
        private System.Windows.Forms.ImageList il_internet;
        private System.Windows.Forms.Label lbl_invoice_pending;
        private System.Windows.Forms.Timer timer_invoice_pending;
        private System.Windows.Forms.Timer timer_invoice_db;
        private System.Windows.Forms.Panel pnl_pendientes;
        private System.Windows.Forms.Label lbl_enviando;
        private System.Windows.Forms.Label lbl_id_client;
        private System.Windows.Forms.TextBox txt_invoice_cliente_saldo;
        private System.Windows.Forms.Label lbl_invoice_cliente_saldo;
        private System.Windows.Forms.Button btn_invoice_client_search_close;
        private System.Windows.Forms.Label txt_invoice_line_tax_code_iva;
        private System.Windows.Forms.Label lbl_sel_tipo_doc;
        private System.Windows.Forms.Button btn_exoneracion_show;
        private System.Windows.Forms.Label lbl_exoneracion_fecha_emision;
        private System.Windows.Forms.GroupBox grp_exoneracion;
        private System.Windows.Forms.TextBox txt_exoneracion_porcentaje_exoneracion;
        private System.Windows.Forms.Label lbl_exoneracion_nombre_institucion;
        private System.Windows.Forms.TextBox txt_exoneracion_nombre_institucion;
        private System.Windows.Forms.TextBox txt_exoneracion_fecha_emision;
        private System.Windows.Forms.Label lbl_exoneracion_numero_documento;
        private System.Windows.Forms.TextBox txt_exoneracion_numero_documento;
        private System.Windows.Forms.ComboBox cmb_exoneracion_tipo_documento;
        private System.Windows.Forms.Label lbl_exoneracion_tipo_documento;
        private System.Windows.Forms.Button btn_exoneracion_save;
        private System.Windows.Forms.Label lbl_exoneracion_porcentaje_exoneracion;
        private System.Windows.Forms.Button btn_exoneraciones_clear;
        private System.Windows.Forms.ComboBox cmb_invoice_act_eco;
        private System.Windows.Forms.Label lbl_invoice_cod_act_eco;
        private System.Windows.Forms.GroupBox grp_descuento;
        private System.Windows.Forms.Label lbl_descuentos_precio_final;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_descuentos_aplicar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_descuentos_monto;
        private System.Windows.Forms.TextBox txt_descuentos_razon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_descuentos_porcentaje;
        private System.Windows.Forms.Button btn_descuentos_cerrar;
        private System.Windows.Forms.Label lbl_descuento_producto_descripcion;
        private System.Windows.Forms.Label lbl_descuentos_precio_original;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_abarrotes_canastabasica;
        private System.Windows.Forms.Label lbl_computer_name;
        private System.Windows.Forms.Label lbl_invoice_line_cabys_desc;
        private System.Windows.Forms.TextBox txt_invoice_line_cabys_code;
        private System.Windows.Forms.TextBox txt_descuentos_precio_final;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_descuentos_precio_iva;
        private System.Windows.Forms.TextBox txt_invoice_line_price_descuento_monto;
        private System.Windows.Forms.TextBox txt_invoice_line_price_descuento_razon;
        private System.Windows.Forms.PictureBox TotalDescuento;
        private System.Windows.Forms.GroupBox grp_descuento_total;
        private System.Windows.Forms.Label lbl_descuentos_total_original;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_descuentos_total_precio_final;
        private System.Windows.Forms.Button btn_descuentos_total_cerrar;
        private System.Windows.Forms.Button btn_descuentos_total_aplicar;
        private System.Windows.Forms.Label label9;
    }
}