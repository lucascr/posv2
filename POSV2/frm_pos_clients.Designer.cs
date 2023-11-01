namespace POSV2
{
    partial class frm_pos_clients
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
            this.grp_clients = new System.Windows.Forms.GroupBox();
            this.grp_credito = new System.Windows.Forms.GroupBox();
            this.txt_clients_credit_days = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_clients_credit_tipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_clients_credit_maximo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_edit_client_id = new System.Windows.Forms.Label();
            this.btn_clients_update = new System.Windows.Forms.Button();
            this.btn_clients_add = new System.Windows.Forms.Button();
            this.txt_clients_email = new System.Windows.Forms.TextBox();
            this.grp_clients_phone = new System.Windows.Forms.GroupBox();
            this.txt_clients_whastapp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_clients_phone_country_number = new System.Windows.Forms.TextBox();
            this.lbl_clients_phone_country_number = new System.Windows.Forms.Label();
            this.txt_clients_phone_number = new System.Windows.Forms.TextBox();
            this.lbl_clients_phone_number = new System.Windows.Forms.Label();
            this.lbl_clients_email = new System.Windows.Forms.Label();
            this.grp_clients_address = new System.Windows.Forms.GroupBox();
            this.lbl_id_distric = new System.Windows.Forms.Label();
            this.lbl_id_canton = new System.Windows.Forms.Label();
            this.lbl_id_province = new System.Windows.Forms.Label();
            this.cmb_clients_district = new System.Windows.Forms.ComboBox();
            this.txt_clients_full_address = new System.Windows.Forms.TextBox();
            this.cmb_clients_province = new System.Windows.Forms.ComboBox();
            this.lbl_clients_full_address = new System.Windows.Forms.Label();
            this.lbl_clients_province = new System.Windows.Forms.Label();
            this.lbl_clients_canton = new System.Windows.Forms.Label();
            this.cmb_clients_canton = new System.Windows.Forms.ComboBox();
            this.lbl_clients_district = new System.Windows.Forms.Label();
            this.grp_clients_id_info = new System.Windows.Forms.GroupBox();
            this.cmb_clients_id_type = new System.Windows.Forms.ComboBox();
            this.lbl_clients_identification_type = new System.Windows.Forms.Label();
            this.txt_clients_identification = new System.Windows.Forms.TextBox();
            this.lbl_clients_identification = new System.Windows.Forms.Label();
            this.txt_clients_commercial_name = new System.Windows.Forms.TextBox();
            this.txt_clients_name = new System.Windows.Forms.TextBox();
            this.lbl_clients_name = new System.Windows.Forms.Label();
            this.lbl_clients_commercial_name = new System.Windows.Forms.Label();
            this.lv_clients_serach_results = new System.Windows.Forms.ListView();
            this.mnuS1 = new System.Windows.Forms.MenuStrip();
            this.btn_clients_import = new System.Windows.Forms.Button();
            this.grp_clients_search = new System.Windows.Forms.GroupBox();
            this.btn_clients_search = new System.Windows.Forms.Button();
            this.lbl_clients_search_text = new System.Windows.Forms.Label();
            this.txt_clients_search_all = new System.Windows.Forms.TextBox();
            this.lbl_clients_search_identification_type = new System.Windows.Forms.Label();
            this.cmb_clients_search_id_type = new System.Windows.Forms.ComboBox();
            this.cmb_clients_action = new System.Windows.Forms.ComboBox();
            this.grp_asada = new System.Windows.Forms.GroupBox();
            this.txt_client_asada_medidor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_clients_asada_tipo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_client_asada_lectura = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grp_clients.SuspendLayout();
            this.grp_credito.SuspendLayout();
            this.grp_clients_phone.SuspendLayout();
            this.grp_clients_address.SuspendLayout();
            this.grp_clients_id_info.SuspendLayout();
            this.grp_clients_search.SuspendLayout();
            this.grp_asada.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_clients
            // 
            this.grp_clients.Controls.Add(this.grp_asada);
            this.grp_clients.Controls.Add(this.grp_credito);
            this.grp_clients.Controls.Add(this.lbl_edit_client_id);
            this.grp_clients.Controls.Add(this.btn_clients_update);
            this.grp_clients.Controls.Add(this.btn_clients_add);
            this.grp_clients.Controls.Add(this.txt_clients_email);
            this.grp_clients.Controls.Add(this.grp_clients_phone);
            this.grp_clients.Controls.Add(this.lbl_clients_email);
            this.grp_clients.Controls.Add(this.grp_clients_address);
            this.grp_clients.Controls.Add(this.grp_clients_id_info);
            this.grp_clients.Controls.Add(this.txt_clients_commercial_name);
            this.grp_clients.Controls.Add(this.txt_clients_name);
            this.grp_clients.Controls.Add(this.lbl_clients_name);
            this.grp_clients.Controls.Add(this.lbl_clients_commercial_name);
            this.grp_clients.Location = new System.Drawing.Point(10, 25);
            this.grp_clients.Name = "grp_clients";
            this.grp_clients.Size = new System.Drawing.Size(990, 227);
            this.grp_clients.TabIndex = 12;
            this.grp_clients.TabStop = false;
            this.grp_clients.Text = "Client";
            // 
            // grp_credito
            // 
            this.grp_credito.Controls.Add(this.txt_clients_credit_days);
            this.grp_credito.Controls.Add(this.label6);
            this.grp_credito.Controls.Add(this.cmb_clients_credit_tipo);
            this.grp_credito.Controls.Add(this.label4);
            this.grp_credito.Controls.Add(this.txt_clients_credit_maximo);
            this.grp_credito.Controls.Add(this.label5);
            this.grp_credito.Location = new System.Drawing.Point(6, 168);
            this.grp_credito.Name = "grp_credito";
            this.grp_credito.Size = new System.Drawing.Size(366, 59);
            this.grp_credito.TabIndex = 32;
            this.grp_credito.TabStop = false;
            this.grp_credito.Text = "Crédito";
            // 
            // txt_clients_credit_days
            // 
            this.txt_clients_credit_days.Location = new System.Drawing.Point(266, 33);
            this.txt_clients_credit_days.Name = "txt_clients_credit_days";
            this.txt_clients_credit_days.Size = new System.Drawing.Size(97, 20);
            this.txt_clients_credit_days.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(266, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Días de crédito";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_clients_credit_tipo
            // 
            this.cmb_clients_credit_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_clients_credit_tipo.FormattingEnabled = true;
            this.cmb_clients_credit_tipo.Location = new System.Drawing.Point(7, 33);
            this.cmb_clients_credit_tipo.Name = "cmb_clients_credit_tipo";
            this.cmb_clients_credit_tipo.Size = new System.Drawing.Size(125, 21);
            this.cmb_clients_credit_tipo.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(22, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tipo Crédito";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_clients_credit_maximo
            // 
            this.txt_clients_credit_maximo.Location = new System.Drawing.Point(138, 33);
            this.txt_clients_credit_maximo.Name = "txt_clients_credit_maximo";
            this.txt_clients_credit_maximo.Size = new System.Drawing.Size(122, 20);
            this.txt_clients_credit_maximo.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(190, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Monto";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_edit_client_id
            // 
            this.lbl_edit_client_id.Location = new System.Drawing.Point(880, 167);
            this.lbl_edit_client_id.Name = "lbl_edit_client_id";
            this.lbl_edit_client_id.Size = new System.Drawing.Size(94, 12);
            this.lbl_edit_client_id.TabIndex = 93;
            this.lbl_edit_client_id.Text = "0";
            this.lbl_edit_client_id.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_edit_client_id.DoubleClick += new System.EventHandler(this.lbl_edit_client_id_DoubleClick);
            // 
            // btn_clients_update
            // 
            this.btn_clients_update.BackColor = System.Drawing.SystemColors.Control;
            this.btn_clients_update.Enabled = false;
            this.btn_clients_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clients_update.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_clients_update.Location = new System.Drawing.Point(879, 178);
            this.btn_clients_update.Name = "btn_clients_update";
            this.btn_clients_update.Size = new System.Drawing.Size(105, 42);
            this.btn_clients_update.TabIndex = 92;
            this.btn_clients_update.Text = "Actualizar Cliente";
            this.btn_clients_update.UseVisualStyleBackColor = false;
            this.btn_clients_update.Click += new System.EventHandler(this.btn_clients_update_Click);
            // 
            // btn_clients_add
            // 
            this.btn_clients_add.BackColor = System.Drawing.SystemColors.Control;
            this.btn_clients_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clients_add.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_clients_add.Location = new System.Drawing.Point(768, 178);
            this.btn_clients_add.Name = "btn_clients_add";
            this.btn_clients_add.Size = new System.Drawing.Size(105, 42);
            this.btn_clients_add.TabIndex = 91;
            this.btn_clients_add.Text = "Agregar Cliente";
            this.btn_clients_add.UseVisualStyleBackColor = false;
            this.btn_clients_add.Click += new System.EventHandler(this.btn_clients_add_Click);
            // 
            // txt_clients_email
            // 
            this.txt_clients_email.Location = new System.Drawing.Point(521, 15);
            this.txt_clients_email.Name = "txt_clients_email";
            this.txt_clients_email.Size = new System.Drawing.Size(147, 20);
            this.txt_clients_email.TabIndex = 34;
            // 
            // grp_clients_phone
            // 
            this.grp_clients_phone.Controls.Add(this.txt_clients_whastapp);
            this.grp_clients_phone.Controls.Add(this.label2);
            this.grp_clients_phone.Controls.Add(this.txt_clients_phone_country_number);
            this.grp_clients_phone.Controls.Add(this.lbl_clients_phone_country_number);
            this.grp_clients_phone.Controls.Add(this.txt_clients_phone_number);
            this.grp_clients_phone.Controls.Add(this.lbl_clients_phone_number);
            this.grp_clients_phone.Location = new System.Drawing.Point(692, 41);
            this.grp_clients_phone.Name = "grp_clients_phone";
            this.grp_clients_phone.Size = new System.Drawing.Size(295, 96);
            this.grp_clients_phone.TabIndex = 32;
            this.grp_clients_phone.TabStop = false;
            this.grp_clients_phone.Text = "Phone Information (optional)";
            // 
            // txt_clients_whastapp
            // 
            this.txt_clients_whastapp.Location = new System.Drawing.Point(131, 67);
            this.txt_clients_whastapp.Name = "txt_clients_whastapp";
            this.txt_clients_whastapp.Size = new System.Drawing.Size(66, 20);
            this.txt_clients_whastapp.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Whatsapp";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_clients_phone_country_number
            // 
            this.txt_clients_phone_country_number.Location = new System.Drawing.Point(131, 19);
            this.txt_clients_phone_country_number.Name = "txt_clients_phone_country_number";
            this.txt_clients_phone_country_number.Size = new System.Drawing.Size(32, 20);
            this.txt_clients_phone_country_number.TabIndex = 22;
            // 
            // lbl_clients_phone_country_number
            // 
            this.lbl_clients_phone_country_number.Location = new System.Drawing.Point(18, 19);
            this.lbl_clients_phone_country_number.Name = "lbl_clients_phone_country_number";
            this.lbl_clients_phone_country_number.Size = new System.Drawing.Size(107, 13);
            this.lbl_clients_phone_country_number.TabIndex = 21;
            this.lbl_clients_phone_country_number.Text = "Country Code";
            this.lbl_clients_phone_country_number.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_clients_phone_number
            // 
            this.txt_clients_phone_number.Location = new System.Drawing.Point(131, 43);
            this.txt_clients_phone_number.Name = "txt_clients_phone_number";
            this.txt_clients_phone_number.Size = new System.Drawing.Size(66, 20);
            this.txt_clients_phone_number.TabIndex = 20;
            this.txt_clients_phone_number.Text = "12345678";
            // 
            // lbl_clients_phone_number
            // 
            this.lbl_clients_phone_number.Location = new System.Drawing.Point(12, 43);
            this.lbl_clients_phone_number.Name = "lbl_clients_phone_number";
            this.lbl_clients_phone_number.Size = new System.Drawing.Size(115, 13);
            this.lbl_clients_phone_number.TabIndex = 19;
            this.lbl_clients_phone_number.Text = "Phone Number";
            this.lbl_clients_phone_number.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_clients_email
            // 
            this.lbl_clients_email.Location = new System.Drawing.Point(426, 19);
            this.lbl_clients_email.Name = "lbl_clients_email";
            this.lbl_clients_email.Size = new System.Drawing.Size(90, 13);
            this.lbl_clients_email.TabIndex = 33;
            this.lbl_clients_email.Text = "E-Mail (optional)";
            this.lbl_clients_email.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grp_clients_address
            // 
            this.grp_clients_address.Controls.Add(this.lbl_id_distric);
            this.grp_clients_address.Controls.Add(this.lbl_id_canton);
            this.grp_clients_address.Controls.Add(this.lbl_id_province);
            this.grp_clients_address.Controls.Add(this.cmb_clients_district);
            this.grp_clients_address.Controls.Add(this.txt_clients_full_address);
            this.grp_clients_address.Controls.Add(this.cmb_clients_province);
            this.grp_clients_address.Controls.Add(this.lbl_clients_full_address);
            this.grp_clients_address.Controls.Add(this.lbl_clients_province);
            this.grp_clients_address.Controls.Add(this.lbl_clients_canton);
            this.grp_clients_address.Controls.Add(this.cmb_clients_canton);
            this.grp_clients_address.Controls.Add(this.lbl_clients_district);
            this.grp_clients_address.Location = new System.Drawing.Point(6, 91);
            this.grp_clients_address.Name = "grp_clients_address";
            this.grp_clients_address.Size = new System.Drawing.Size(683, 77);
            this.grp_clients_address.TabIndex = 31;
            this.grp_clients_address.TabStop = false;
            this.grp_clients_address.Text = "Address Information (optional)";
            // 
            // lbl_id_distric
            // 
            this.lbl_id_distric.AutoSize = true;
            this.lbl_id_distric.Location = new System.Drawing.Point(657, 20);
            this.lbl_id_distric.Name = "lbl_id_distric";
            this.lbl_id_distric.Size = new System.Drawing.Size(13, 13);
            this.lbl_id_distric.TabIndex = 33;
            this.lbl_id_distric.Text = "0";
            this.lbl_id_distric.Visible = false;
            // 
            // lbl_id_canton
            // 
            this.lbl_id_canton.AutoSize = true;
            this.lbl_id_canton.Location = new System.Drawing.Point(452, 19);
            this.lbl_id_canton.Name = "lbl_id_canton";
            this.lbl_id_canton.Size = new System.Drawing.Size(13, 13);
            this.lbl_id_canton.TabIndex = 32;
            this.lbl_id_canton.Text = "0";
            this.lbl_id_canton.Visible = false;
            // 
            // lbl_id_province
            // 
            this.lbl_id_province.AutoSize = true;
            this.lbl_id_province.Location = new System.Drawing.Point(260, 20);
            this.lbl_id_province.Name = "lbl_id_province";
            this.lbl_id_province.Size = new System.Drawing.Size(13, 13);
            this.lbl_id_province.TabIndex = 31;
            this.lbl_id_province.Text = "0";
            this.lbl_id_province.Visible = false;
            // 
            // cmb_clients_district
            // 
            this.cmb_clients_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_clients_district.FormattingEnabled = true;
            this.cmb_clients_district.Location = new System.Drawing.Point(535, 19);
            this.cmb_clients_district.Name = "cmb_clients_district";
            this.cmb_clients_district.Size = new System.Drawing.Size(122, 21);
            this.cmb_clients_district.TabIndex = 28;
            this.cmb_clients_district.SelectedIndexChanged += new System.EventHandler(this.cmb_clients_district_SelectedIndexChanged);
            // 
            // txt_clients_full_address
            // 
            this.txt_clients_full_address.Location = new System.Drawing.Point(135, 49);
            this.txt_clients_full_address.Multiline = true;
            this.txt_clients_full_address.Name = "txt_clients_full_address";
            this.txt_clients_full_address.Size = new System.Drawing.Size(535, 21);
            this.txt_clients_full_address.TabIndex = 30;
            // 
            // cmb_clients_province
            // 
            this.cmb_clients_province.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_clients_province.FormattingEnabled = true;
            this.cmb_clients_province.Location = new System.Drawing.Point(133, 19);
            this.cmb_clients_province.Name = "cmb_clients_province";
            this.cmb_clients_province.Size = new System.Drawing.Size(122, 21);
            this.cmb_clients_province.TabIndex = 24;
            this.cmb_clients_province.SelectedIndexChanged += new System.EventHandler(this.cmb_clients_province_SelectedIndexChanged);
            // 
            // lbl_clients_full_address
            // 
            this.lbl_clients_full_address.Location = new System.Drawing.Point(14, 52);
            this.lbl_clients_full_address.Name = "lbl_clients_full_address";
            this.lbl_clients_full_address.Size = new System.Drawing.Size(115, 13);
            this.lbl_clients_full_address.TabIndex = 29;
            this.lbl_clients_full_address.Text = "Full Address";
            this.lbl_clients_full_address.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_clients_province
            // 
            this.lbl_clients_province.Location = new System.Drawing.Point(66, 19);
            this.lbl_clients_province.Name = "lbl_clients_province";
            this.lbl_clients_province.Size = new System.Drawing.Size(63, 13);
            this.lbl_clients_province.TabIndex = 23;
            this.lbl_clients_province.Text = "Province";
            this.lbl_clients_province.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_clients_canton
            // 
            this.lbl_clients_canton.Location = new System.Drawing.Point(278, 19);
            this.lbl_clients_canton.Name = "lbl_clients_canton";
            this.lbl_clients_canton.Size = new System.Drawing.Size(44, 13);
            this.lbl_clients_canton.TabIndex = 25;
            this.lbl_clients_canton.Text = "Canton";
            this.lbl_clients_canton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_clients_canton
            // 
            this.cmb_clients_canton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_clients_canton.FormattingEnabled = true;
            this.cmb_clients_canton.Location = new System.Drawing.Point(324, 19);
            this.cmb_clients_canton.Name = "cmb_clients_canton";
            this.cmb_clients_canton.Size = new System.Drawing.Size(122, 21);
            this.cmb_clients_canton.TabIndex = 26;
            this.cmb_clients_canton.SelectedIndexChanged += new System.EventHandler(this.cmb_clients_canton_SelectedIndexChanged);
            // 
            // lbl_clients_district
            // 
            this.lbl_clients_district.Location = new System.Drawing.Point(468, 19);
            this.lbl_clients_district.Name = "lbl_clients_district";
            this.lbl_clients_district.Size = new System.Drawing.Size(63, 13);
            this.lbl_clients_district.TabIndex = 27;
            this.lbl_clients_district.Text = "District";
            this.lbl_clients_district.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grp_clients_id_info
            // 
            this.grp_clients_id_info.Controls.Add(this.cmb_clients_id_type);
            this.grp_clients_id_info.Controls.Add(this.lbl_clients_identification_type);
            this.grp_clients_id_info.Controls.Add(this.txt_clients_identification);
            this.grp_clients_id_info.Controls.Add(this.lbl_clients_identification);
            this.grp_clients_id_info.Location = new System.Drawing.Point(6, 42);
            this.grp_clients_id_info.Name = "grp_clients_id_info";
            this.grp_clients_id_info.Size = new System.Drawing.Size(600, 45);
            this.grp_clients_id_info.TabIndex = 30;
            this.grp_clients_id_info.TabStop = false;
            this.grp_clients_id_info.Text = "Identificaion Information (optional)";
            // 
            // cmb_clients_id_type
            // 
            this.cmb_clients_id_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_clients_id_type.FormattingEnabled = true;
            this.cmb_clients_id_type.Location = new System.Drawing.Point(133, 19);
            this.cmb_clients_id_type.Name = "cmb_clients_id_type";
            this.cmb_clients_id_type.Size = new System.Drawing.Size(167, 21);
            this.cmb_clients_id_type.TabIndex = 13;
            // 
            // lbl_clients_identification_type
            // 
            this.lbl_clients_identification_type.Location = new System.Drawing.Point(14, 21);
            this.lbl_clients_identification_type.Name = "lbl_clients_identification_type";
            this.lbl_clients_identification_type.Size = new System.Drawing.Size(115, 13);
            this.lbl_clients_identification_type.TabIndex = 9;
            this.lbl_clients_identification_type.Text = "Identification Type";
            this.lbl_clients_identification_type.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_clients_identification
            // 
            this.txt_clients_identification.Location = new System.Drawing.Point(424, 19);
            this.txt_clients_identification.Name = "txt_clients_identification";
            this.txt_clients_identification.Size = new System.Drawing.Size(167, 20);
            this.txt_clients_identification.TabIndex = 14;
            // 
            // lbl_clients_identification
            // 
            this.lbl_clients_identification.Location = new System.Drawing.Point(305, 20);
            this.lbl_clients_identification.Name = "lbl_clients_identification";
            this.lbl_clients_identification.Size = new System.Drawing.Size(115, 13);
            this.lbl_clients_identification.TabIndex = 12;
            this.lbl_clients_identification.Text = "Identification";
            this.lbl_clients_identification.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_clients_commercial_name
            // 
            this.txt_clients_commercial_name.Location = new System.Drawing.Point(817, 15);
            this.txt_clients_commercial_name.Name = "txt_clients_commercial_name";
            this.txt_clients_commercial_name.Size = new System.Drawing.Size(160, 20);
            this.txt_clients_commercial_name.TabIndex = 16;
            // 
            // txt_clients_name
            // 
            this.txt_clients_name.Location = new System.Drawing.Point(133, 15);
            this.txt_clients_name.Name = "txt_clients_name";
            this.txt_clients_name.Size = new System.Drawing.Size(281, 20);
            this.txt_clients_name.TabIndex = 15;
            // 
            // lbl_clients_name
            // 
            this.lbl_clients_name.Location = new System.Drawing.Point(20, 19);
            this.lbl_clients_name.Name = "lbl_clients_name";
            this.lbl_clients_name.Size = new System.Drawing.Size(107, 13);
            this.lbl_clients_name.TabIndex = 11;
            this.lbl_clients_name.Text = "Name";
            this.lbl_clients_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_clients_commercial_name
            // 
            this.lbl_clients_commercial_name.Location = new System.Drawing.Point(673, 19);
            this.lbl_clients_commercial_name.Name = "lbl_clients_commercial_name";
            this.lbl_clients_commercial_name.Size = new System.Drawing.Size(139, 13);
            this.lbl_clients_commercial_name.TabIndex = 10;
            this.lbl_clients_commercial_name.Text = "Commercial Name (optional)";
            this.lbl_clients_commercial_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lv_clients_serach_results
            // 
            this.lv_clients_serach_results.CheckBoxes = true;
            this.lv_clients_serach_results.FullRowSelect = true;
            this.lv_clients_serach_results.GridLines = true;
            this.lv_clients_serach_results.HideSelection = false;
            this.lv_clients_serach_results.Location = new System.Drawing.Point(10, 321);
            this.lv_clients_serach_results.Name = "lv_clients_serach_results";
            this.lv_clients_serach_results.Size = new System.Drawing.Size(990, 356);
            this.lv_clients_serach_results.TabIndex = 35;
            this.lv_clients_serach_results.UseCompatibleStateImageBehavior = false;
            this.lv_clients_serach_results.View = System.Windows.Forms.View.Details;
            this.lv_clients_serach_results.SelectedIndexChanged += new System.EventHandler(this.lv_clients_serach_results_SelectedIndexChanged);
            this.lv_clients_serach_results.DoubleClick += new System.EventHandler(this.lv_clients_serach_results_DoubleClick);
            // 
            // mnuS1
            // 
            this.mnuS1.Location = new System.Drawing.Point(0, 0);
            this.mnuS1.Name = "mnuS1";
            this.mnuS1.Size = new System.Drawing.Size(1008, 24);
            this.mnuS1.TabIndex = 37;
            this.mnuS1.Text = "menuStrip1";
            // 
            // btn_clients_import
            // 
            this.btn_clients_import.Location = new System.Drawing.Point(896, 610);
            this.btn_clients_import.Name = "btn_clients_import";
            this.btn_clients_import.Size = new System.Drawing.Size(104, 45);
            this.btn_clients_import.TabIndex = 38;
            this.btn_clients_import.Text = "Import from XLS";
            this.btn_clients_import.UseVisualStyleBackColor = true;
            this.btn_clients_import.Visible = false;
            this.btn_clients_import.Click += new System.EventHandler(this.btn_clients_import_Click);
            // 
            // grp_clients_search
            // 
            this.grp_clients_search.Controls.Add(this.btn_clients_search);
            this.grp_clients_search.Controls.Add(this.lbl_clients_search_text);
            this.grp_clients_search.Controls.Add(this.txt_clients_search_all);
            this.grp_clients_search.Controls.Add(this.lbl_clients_search_identification_type);
            this.grp_clients_search.Controls.Add(this.cmb_clients_search_id_type);
            this.grp_clients_search.Location = new System.Drawing.Point(12, 258);
            this.grp_clients_search.Name = "grp_clients_search";
            this.grp_clients_search.Size = new System.Drawing.Size(604, 57);
            this.grp_clients_search.TabIndex = 96;
            this.grp_clients_search.TabStop = false;
            this.grp_clients_search.Text = "Search options";
            // 
            // btn_clients_search
            // 
            this.btn_clients_search.Location = new System.Drawing.Point(480, 28);
            this.btn_clients_search.Name = "btn_clients_search";
            this.btn_clients_search.Size = new System.Drawing.Size(97, 20);
            this.btn_clients_search.TabIndex = 94;
            this.btn_clients_search.Text = "Buscar Cliente";
            this.btn_clients_search.UseVisualStyleBackColor = true;
            this.btn_clients_search.Click += new System.EventHandler(this.btn_users_search_Click);
            // 
            // lbl_clients_search_text
            // 
            this.lbl_clients_search_text.Location = new System.Drawing.Point(10, 14);
            this.lbl_clients_search_text.Name = "lbl_clients_search_text";
            this.lbl_clients_search_text.Size = new System.Drawing.Size(199, 13);
            this.lbl_clients_search_text.TabIndex = 93;
            this.lbl_clients_search_text.Text = "Text to search";
            // 
            // txt_clients_search_all
            // 
            this.txt_clients_search_all.Location = new System.Drawing.Point(11, 30);
            this.txt_clients_search_all.Name = "txt_clients_search_all";
            this.txt_clients_search_all.Size = new System.Drawing.Size(293, 20);
            this.txt_clients_search_all.TabIndex = 76;
            this.txt_clients_search_all.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_clients_search_all_KeyUp);
            // 
            // lbl_clients_search_identification_type
            // 
            this.lbl_clients_search_identification_type.Location = new System.Drawing.Point(305, 12);
            this.lbl_clients_search_identification_type.Name = "lbl_clients_search_identification_type";
            this.lbl_clients_search_identification_type.Size = new System.Drawing.Size(167, 15);
            this.lbl_clients_search_identification_type.TabIndex = 92;
            this.lbl_clients_search_identification_type.Text = "Identification Type";
            // 
            // cmb_clients_search_id_type
            // 
            this.cmb_clients_search_id_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_clients_search_id_type.FormattingEnabled = true;
            this.cmb_clients_search_id_type.Location = new System.Drawing.Point(308, 30);
            this.cmb_clients_search_id_type.Name = "cmb_clients_search_id_type";
            this.cmb_clients_search_id_type.Size = new System.Drawing.Size(166, 21);
            this.cmb_clients_search_id_type.TabIndex = 86;
            // 
            // cmb_clients_action
            // 
            this.cmb_clients_action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_clients_action.FormattingEnabled = true;
            this.cmb_clients_action.Location = new System.Drawing.Point(833, 288);
            this.cmb_clients_action.Name = "cmb_clients_action";
            this.cmb_clients_action.Size = new System.Drawing.Size(166, 21);
            this.cmb_clients_action.TabIndex = 95;
            this.cmb_clients_action.SelectedIndexChanged += new System.EventHandler(this.cmb_clients_action_SelectedIndexChanged);
            // 
            // grp_asada
            // 
            this.grp_asada.Controls.Add(this.txt_client_asada_medidor);
            this.grp_asada.Controls.Add(this.label8);
            this.grp_asada.Controls.Add(this.cmb_clients_asada_tipo);
            this.grp_asada.Controls.Add(this.label9);
            this.grp_asada.Controls.Add(this.txt_client_asada_lectura);
            this.grp_asada.Controls.Add(this.label10);
            this.grp_asada.Location = new System.Drawing.Point(375, 168);
            this.grp_asada.Name = "grp_asada";
            this.grp_asada.Size = new System.Drawing.Size(366, 59);
            this.grp_asada.TabIndex = 33;
            this.grp_asada.TabStop = false;
            this.grp_asada.Text = "Asada";
            this.grp_asada.Visible = false;
            // 
            // txt_client_asada_medidor
            // 
            this.txt_client_asada_medidor.Location = new System.Drawing.Point(173, 29);
            this.txt_client_asada_medidor.Name = "txt_client_asada_medidor";
            this.txt_client_asada_medidor.Size = new System.Drawing.Size(96, 20);
            this.txt_client_asada_medidor.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(219, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Medidor";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_clients_asada_tipo
            // 
            this.cmb_clients_asada_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_clients_asada_tipo.FormattingEnabled = true;
            this.cmb_clients_asada_tipo.Location = new System.Drawing.Point(5, 29);
            this.cmb_clients_asada_tipo.Name = "cmb_clients_asada_tipo";
            this.cmb_clients_asada_tipo.Size = new System.Drawing.Size(163, 21);
            this.cmb_clients_asada_tipo.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(63, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 14);
            this.label9.TabIndex = 19;
            this.label9.Text = "Tipo Pago";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_client_asada_lectura
            // 
            this.txt_client_asada_lectura.Location = new System.Drawing.Point(274, 29);
            this.txt_client_asada_lectura.Name = "txt_client_asada_lectura";
            this.txt_client_asada_lectura.Size = new System.Drawing.Size(86, 20);
            this.txt_client_asada_lectura.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(280, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "Lectura inicial";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frm_pos_clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.cmb_clients_action);
            this.Controls.Add(this.grp_clients_search);
            this.Controls.Add(this.lv_clients_serach_results);
            this.Controls.Add(this.mnuS1);
            this.Controls.Add(this.btn_clients_import);
            this.Controls.Add(this.grp_clients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mnuS1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_pos_clients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.frm_pos_clients_Load);
            this.Shown += new System.EventHandler(this.frm_pos_clients_Shown);
            this.grp_clients.ResumeLayout(false);
            this.grp_clients.PerformLayout();
            this.grp_credito.ResumeLayout(false);
            this.grp_credito.PerformLayout();
            this.grp_clients_phone.ResumeLayout(false);
            this.grp_clients_phone.PerformLayout();
            this.grp_clients_address.ResumeLayout(false);
            this.grp_clients_address.PerformLayout();
            this.grp_clients_id_info.ResumeLayout(false);
            this.grp_clients_id_info.PerformLayout();
            this.grp_clients_search.ResumeLayout(false);
            this.grp_clients_search.PerformLayout();
            this.grp_asada.ResumeLayout(false);
            this.grp_asada.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_clients;
        private System.Windows.Forms.ComboBox cmb_clients_district;
        private System.Windows.Forms.Label lbl_clients_district;
        private System.Windows.Forms.ComboBox cmb_clients_canton;
        private System.Windows.Forms.Label lbl_clients_canton;
        private System.Windows.Forms.ComboBox cmb_clients_province;
        private System.Windows.Forms.Label lbl_clients_province;
        private System.Windows.Forms.TextBox txt_clients_phone_country_number;
        private System.Windows.Forms.Label lbl_clients_phone_country_number;
        private System.Windows.Forms.TextBox txt_clients_phone_number;
        private System.Windows.Forms.Label lbl_clients_phone_number;
        private System.Windows.Forms.TextBox txt_clients_identification;
        private System.Windows.Forms.ComboBox cmb_clients_id_type;
        private System.Windows.Forms.Label lbl_clients_identification;
        private System.Windows.Forms.Label lbl_clients_identification_type;
        private System.Windows.Forms.GroupBox grp_clients_address;
        private System.Windows.Forms.GroupBox grp_clients_id_info;
        private System.Windows.Forms.GroupBox grp_clients_phone;
        private System.Windows.Forms.TextBox txt_clients_full_address;
        private System.Windows.Forms.Label lbl_clients_full_address;
        private System.Windows.Forms.ListView lv_clients_serach_results;
        private System.Windows.Forms.Button btn_clients_update;
        private System.Windows.Forms.Button btn_clients_add;
        private System.Windows.Forms.MenuStrip mnuS1;
        private System.Windows.Forms.Button btn_clients_import;
        private System.Windows.Forms.Label lbl_edit_client_id;
        private System.Windows.Forms.GroupBox grp_clients_search;
        private System.Windows.Forms.Button btn_clients_search;
        private System.Windows.Forms.Label lbl_clients_search_text;
        private System.Windows.Forms.TextBox txt_clients_search_all;
        private System.Windows.Forms.Label lbl_clients_search_identification_type;
        private System.Windows.Forms.ComboBox cmb_clients_search_id_type;
        private System.Windows.Forms.Label lbl_id_distric;
        private System.Windows.Forms.Label lbl_id_canton;
        private System.Windows.Forms.Label lbl_id_province;
        private System.Windows.Forms.TextBox txt_clients_whastapp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_clients_email;
        private System.Windows.Forms.Label lbl_clients_email;
        private System.Windows.Forms.TextBox txt_clients_commercial_name;
        private System.Windows.Forms.TextBox txt_clients_name;
        private System.Windows.Forms.Label lbl_clients_name;
        private System.Windows.Forms.Label lbl_clients_commercial_name;
        private System.Windows.Forms.GroupBox grp_credito;
        private System.Windows.Forms.ComboBox cmb_clients_credit_tipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_clients_credit_maximo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_clients_credit_days;
        private System.Windows.Forms.ComboBox cmb_clients_action;
        private System.Windows.Forms.GroupBox grp_asada;
        private System.Windows.Forms.TextBox txt_client_asada_medidor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_clients_asada_tipo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_client_asada_lectura;
        private System.Windows.Forms.Label label10;
    }
}