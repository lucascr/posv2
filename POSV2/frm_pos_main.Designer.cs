namespace POSV2
{
    partial class frm_pos_main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_pos_main));
            this.btn_new_invoice = new System.Windows.Forms.Button();
            this.btn_products = new System.Windows.Forms.Button();
            this.btn_clients = new System.Windows.Forms.Button();
            this.btn_users = new System.Windows.Forms.Button();
            this.btn_invoice_maintenance = new System.Windows.Forms.Button();
            this.btn_config = new System.Windows.Forms.Button();
            this.lbl_config_db_errors = new System.Windows.Forms.Label();
            this.mnuS1 = new System.Windows.Forms.MenuStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_version = new System.Windows.Forms.Label();
            this.btn_invoice_report = new System.Windows.Forms.Button();
            this.btn_proveedores = new System.Windows.Forms.Button();
            this.lbl_backup = new System.Windows.Forms.Label();
            this.btn_backup = new System.Windows.Forms.Button();
            this.pb1 = new System.Windows.Forms.ProgressBar();
            this.txt_company_ter = new System.Windows.Forms.TextBox();
            this.txt_company_db_name = new System.Windows.Forms.Label();
            this.main_txt_for = new System.Windows.Forms.TextBox();
            this.main_txt_then = new System.Windows.Forms.TextBox();
            this.btn_main_encrypt = new System.Windows.Forms.Button();
            this.btn_main_descrypt = new System.Windows.Forms.Button();
            this.grp_lucas = new System.Windows.Forms.GroupBox();
            this.pb_internet = new System.Windows.Forms.PictureBox();
            this.il_internet = new System.Windows.Forms.ImageList(this.components);
            this.btn_cxc = new System.Windows.Forms.Button();
            this.lbl_license = new System.Windows.Forms.Label();
            this.btn_asadas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_academia = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_cabys_total = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_cabys_count_total = new System.Windows.Forms.Label();
            this.lbl_cabys_product_pendientes = new System.Windows.Forms.Label();
            this.btn_cabys = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grp_lucas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_internet)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_new_invoice
            // 
            this.btn_new_invoice.Location = new System.Drawing.Point(16, 47);
            this.btn_new_invoice.Name = "btn_new_invoice";
            this.btn_new_invoice.Size = new System.Drawing.Size(90, 55);
            this.btn_new_invoice.TabIndex = 0;
            this.btn_new_invoice.Text = "New  Invoice";
            this.btn_new_invoice.UseVisualStyleBackColor = true;
            this.btn_new_invoice.Click += new System.EventHandler(this.btn_new_invoice_Click);
            // 
            // btn_products
            // 
            this.btn_products.Location = new System.Drawing.Point(122, 109);
            this.btn_products.Name = "btn_products";
            this.btn_products.Size = new System.Drawing.Size(90, 55);
            this.btn_products.TabIndex = 1;
            this.btn_products.Text = "Products Maintenace";
            this.btn_products.UseVisualStyleBackColor = true;
            this.btn_products.Click += new System.EventHandler(this.btn_products_Click);
            // 
            // btn_clients
            // 
            this.btn_clients.Location = new System.Drawing.Point(334, 109);
            this.btn_clients.Name = "btn_clients";
            this.btn_clients.Size = new System.Drawing.Size(90, 55);
            this.btn_clients.TabIndex = 2;
            this.btn_clients.Text = "Clientes Maintenace";
            this.btn_clients.UseVisualStyleBackColor = true;
            this.btn_clients.Click += new System.EventHandler(this.btn_clients_Click);
            // 
            // btn_users
            // 
            this.btn_users.Location = new System.Drawing.Point(228, 109);
            this.btn_users.Name = "btn_users";
            this.btn_users.Size = new System.Drawing.Size(90, 55);
            this.btn_users.TabIndex = 3;
            this.btn_users.Text = "Users Maintenace";
            this.btn_users.UseVisualStyleBackColor = true;
            this.btn_users.Click += new System.EventHandler(this.btn_users_Click);
            // 
            // btn_invoice_maintenance
            // 
            this.btn_invoice_maintenance.Location = new System.Drawing.Point(16, 109);
            this.btn_invoice_maintenance.Name = "btn_invoice_maintenance";
            this.btn_invoice_maintenance.Size = new System.Drawing.Size(90, 55);
            this.btn_invoice_maintenance.TabIndex = 4;
            this.btn_invoice_maintenance.Text = "Invoice Maintenance";
            this.btn_invoice_maintenance.UseVisualStyleBackColor = true;
            this.btn_invoice_maintenance.Click += new System.EventHandler(this.btn_invoice_maintenance_Click);
            // 
            // btn_config
            // 
            this.btn_config.Location = new System.Drawing.Point(440, 109);
            this.btn_config.Name = "btn_config";
            this.btn_config.Size = new System.Drawing.Size(90, 55);
            this.btn_config.TabIndex = 5;
            this.btn_config.Text = "Config";
            this.btn_config.UseVisualStyleBackColor = true;
            this.btn_config.Click += new System.EventHandler(this.btn_config_Click);
            // 
            // lbl_config_db_errors
            // 
            this.lbl_config_db_errors.Location = new System.Drawing.Point(331, 228);
            this.lbl_config_db_errors.Name = "lbl_config_db_errors";
            this.lbl_config_db_errors.Size = new System.Drawing.Size(196, 43);
            this.lbl_config_db_errors.TabIndex = 19;
            this.lbl_config_db_errors.Click += new System.EventHandler(this.lbl_config_db_errors_Click);
            // 
            // mnuS1
            // 
            this.mnuS1.Location = new System.Drawing.Point(0, 0);
            this.mnuS1.Name = "mnuS1";
            this.mnuS1.Size = new System.Drawing.Size(812, 24);
            this.mnuS1.TabIndex = 20;
            this.mnuS1.Text = "menuStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(253, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // lbl_version
            // 
            this.lbl_version.Location = new System.Drawing.Point(412, 295);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(91, 13);
            this.lbl_version.TabIndex = 23;
            this.lbl_version.Text = "version 0.0.0.0";
            this.lbl_version.Click += new System.EventHandler(this.lbl_version_Click);
            // 
            // btn_invoice_report
            // 
            this.btn_invoice_report.Location = new System.Drawing.Point(122, 171);
            this.btn_invoice_report.Name = "btn_invoice_report";
            this.btn_invoice_report.Size = new System.Drawing.Size(90, 55);
            this.btn_invoice_report.TabIndex = 24;
            this.btn_invoice_report.Text = "Invoice Reports";
            this.btn_invoice_report.UseVisualStyleBackColor = true;
            this.btn_invoice_report.Click += new System.EventHandler(this.btn_invoice_report_Click);
            // 
            // btn_proveedores
            // 
            this.btn_proveedores.Location = new System.Drawing.Point(228, 171);
            this.btn_proveedores.Name = "btn_proveedores";
            this.btn_proveedores.Size = new System.Drawing.Size(90, 55);
            this.btn_proveedores.TabIndex = 25;
            this.btn_proveedores.Text = "Gastos";
            this.btn_proveedores.UseVisualStyleBackColor = true;
            this.btn_proveedores.Click += new System.EventHandler(this.btn_gastos_Click);
            // 
            // lbl_backup
            // 
            this.lbl_backup.AutoSize = true;
            this.lbl_backup.Location = new System.Drawing.Point(324, 295);
            this.lbl_backup.Name = "lbl_backup";
            this.lbl_backup.Size = new System.Drawing.Size(13, 13);
            this.lbl_backup.TabIndex = 26;
            this.lbl_backup.Text = "0";
            // 
            // btn_backup
            // 
            this.btn_backup.Location = new System.Drawing.Point(440, 170);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(90, 55);
            this.btn_backup.TabIndex = 27;
            this.btn_backup.Text = "Backup";
            this.btn_backup.UseVisualStyleBackColor = true;
            this.btn_backup.Click += new System.EventHandler(this.btn_backup_Click);
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(16, 231);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(302, 23);
            this.pb1.TabIndex = 28;
            this.pb1.Click += new System.EventHandler(this.pb1_Click);
            // 
            // txt_company_ter
            // 
            this.txt_company_ter.BackColor = System.Drawing.SystemColors.Control;
            this.txt_company_ter.Enabled = false;
            this.txt_company_ter.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_company_ter.Location = new System.Drawing.Point(544, 24);
            this.txt_company_ter.Name = "txt_company_ter";
            this.txt_company_ter.Size = new System.Drawing.Size(89, 22);
            this.txt_company_ter.TabIndex = 154;
            this.txt_company_ter.Text = "api:cli";
            // 
            // txt_company_db_name
            // 
            this.txt_company_db_name.Location = new System.Drawing.Point(324, 271);
            this.txt_company_db_name.Name = "txt_company_db_name";
            this.txt_company_db_name.Size = new System.Drawing.Size(208, 13);
            this.txt_company_db_name.TabIndex = 155;
            this.txt_company_db_name.Text = "dbname";
            this.txt_company_db_name.DoubleClick += new System.EventHandler(this.txt_company_db_name_DoubleClick);
            // 
            // main_txt_for
            // 
            this.main_txt_for.Location = new System.Drawing.Point(6, 0);
            this.main_txt_for.Multiline = true;
            this.main_txt_for.Name = "main_txt_for";
            this.main_txt_for.Size = new System.Drawing.Size(145, 45);
            this.main_txt_for.TabIndex = 156;
            // 
            // main_txt_then
            // 
            this.main_txt_then.Location = new System.Drawing.Point(154, 0);
            this.main_txt_then.Multiline = true;
            this.main_txt_then.Name = "main_txt_then";
            this.main_txt_then.Size = new System.Drawing.Size(142, 45);
            this.main_txt_then.TabIndex = 157;
            // 
            // btn_main_encrypt
            // 
            this.btn_main_encrypt.Location = new System.Drawing.Point(30, 51);
            this.btn_main_encrypt.Name = "btn_main_encrypt";
            this.btn_main_encrypt.Size = new System.Drawing.Size(90, 18);
            this.btn_main_encrypt.TabIndex = 158;
            this.btn_main_encrypt.Text = "Config";
            this.btn_main_encrypt.UseVisualStyleBackColor = true;
            this.btn_main_encrypt.Click += new System.EventHandler(this.btn_main_encrypt_Click);
            // 
            // btn_main_descrypt
            // 
            this.btn_main_descrypt.Location = new System.Drawing.Point(187, 51);
            this.btn_main_descrypt.Name = "btn_main_descrypt";
            this.btn_main_descrypt.Size = new System.Drawing.Size(90, 18);
            this.btn_main_descrypt.TabIndex = 159;
            this.btn_main_descrypt.Text = "Config";
            this.btn_main_descrypt.UseVisualStyleBackColor = true;
            this.btn_main_descrypt.Click += new System.EventHandler(this.btn_main_descrypt_Click);
            // 
            // grp_lucas
            // 
            this.grp_lucas.Controls.Add(this.main_txt_for);
            this.grp_lucas.Controls.Add(this.btn_main_descrypt);
            this.grp_lucas.Controls.Add(this.main_txt_then);
            this.grp_lucas.Controls.Add(this.btn_main_encrypt);
            this.grp_lucas.Location = new System.Drawing.Point(16, 299);
            this.grp_lucas.Name = "grp_lucas";
            this.grp_lucas.Size = new System.Drawing.Size(302, 77);
            this.grp_lucas.TabIndex = 160;
            this.grp_lucas.TabStop = false;
            this.grp_lucas.Visible = false;
            // 
            // pb_internet
            // 
            this.pb_internet.Image = ((System.Drawing.Image)(resources.GetObject("pb_internet.Image")));
            this.pb_internet.Location = new System.Drawing.Point(509, 287);
            this.pb_internet.Name = "pb_internet";
            this.pb_internet.Size = new System.Drawing.Size(21, 21);
            this.pb_internet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_internet.TabIndex = 162;
            this.pb_internet.TabStop = false;
            this.pb_internet.Click += new System.EventHandler(this.pb_internet_Click);
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
            // btn_cxc
            // 
            this.btn_cxc.Location = new System.Drawing.Point(16, 171);
            this.btn_cxc.Name = "btn_cxc";
            this.btn_cxc.Size = new System.Drawing.Size(90, 55);
            this.btn_cxc.TabIndex = 163;
            this.btn_cxc.Text = "Cuentas por Cobrar";
            this.btn_cxc.UseVisualStyleBackColor = true;
            this.btn_cxc.Click += new System.EventHandler(this.btn_cxc_Click);
            // 
            // lbl_license
            // 
            this.lbl_license.Location = new System.Drawing.Point(19, 24);
            this.lbl_license.Name = "lbl_license";
            this.lbl_license.Size = new System.Drawing.Size(178, 24);
            this.lbl_license.TabIndex = 164;
            this.lbl_license.Text = "Sistema sin license";
            // 
            // btn_asadas
            // 
            this.btn_asadas.Enabled = false;
            this.btn_asadas.Location = new System.Drawing.Point(543, 171);
            this.btn_asadas.Name = "btn_asadas";
            this.btn_asadas.Size = new System.Drawing.Size(90, 55);
            this.btn_asadas.TabIndex = 165;
            this.btn_asadas.Text = "Asadas";
            this.btn_asadas.UseVisualStyleBackColor = true;
            this.btn_asadas.Click += new System.EventHandler(this.btn_asadas_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 39);
            this.label1.TabIndex = 167;
            this.label1.Text = "Version de Hacienda : 4.3";
            // 
            // btn_academia
            // 
            this.btn_academia.Enabled = false;
            this.btn_academia.Location = new System.Drawing.Point(544, 109);
            this.btn_academia.Name = "btn_academia";
            this.btn_academia.Size = new System.Drawing.Size(90, 55);
            this.btn_academia.TabIndex = 168;
            this.btn_academia.Text = "Academia";
            this.btn_academia.UseVisualStyleBackColor = true;
            this.btn_academia.Click += new System.EventHandler(this.btn_academia_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 55);
            this.button1.TabIndex = 169;
            this.button1.Text = "Currency";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_cabys_total
            // 
            this.lbl_cabys_total.AutoSize = true;
            this.lbl_cabys_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cabys_total.Location = new System.Drawing.Point(650, 29);
            this.lbl_cabys_total.Name = "lbl_cabys_total";
            this.lbl_cabys_total.Size = new System.Drawing.Size(134, 20);
            this.lbl_cabys_total.TabIndex = 170;
            this.lbl_cabys_total.Text = "Codigos CABYS :";
            this.lbl_cabys_total.Click += new System.EventHandler(this.lbl_cabys_total_Click);
            this.lbl_cabys_total.DoubleClick += new System.EventHandler(this.lbl_cabys_total_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(650, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 20);
            this.label3.TabIndex = 172;
            this.label3.Text = "Pendientes CABYS :";
            // 
            // lbl_cabys_count_total
            // 
            this.lbl_cabys_count_total.AutoSize = true;
            this.lbl_cabys_count_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cabys_count_total.Location = new System.Drawing.Point(650, 63);
            this.lbl_cabys_count_total.Name = "lbl_cabys_count_total";
            this.lbl_cabys_count_total.Size = new System.Drawing.Size(63, 20);
            this.lbl_cabys_count_total.TabIndex = 173;
            this.lbl_cabys_count_total.Text = "000000";
            this.lbl_cabys_count_total.DoubleClick += new System.EventHandler(this.lbl_cabys_count_total_DoubleClick);
            // 
            // lbl_cabys_product_pendientes
            // 
            this.lbl_cabys_product_pendientes.AutoSize = true;
            this.lbl_cabys_product_pendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cabys_product_pendientes.Location = new System.Drawing.Point(650, 144);
            this.lbl_cabys_product_pendientes.Name = "lbl_cabys_product_pendientes";
            this.lbl_cabys_product_pendientes.Size = new System.Drawing.Size(63, 20);
            this.lbl_cabys_product_pendientes.TabIndex = 175;
            this.lbl_cabys_product_pendientes.Text = "000000";
            // 
            // btn_cabys
            // 
            this.btn_cabys.Location = new System.Drawing.Point(639, 171);
            this.btn_cabys.Name = "btn_cabys";
            this.btn_cabys.Size = new System.Drawing.Size(90, 55);
            this.btn_cabys.TabIndex = 176;
            this.btn_cabys.Text = "CABYS";
            this.btn_cabys.UseVisualStyleBackColor = true;
            this.btn_cabys.Click += new System.EventHandler(this.btn_cabys_Click);
            // 
            // frm_pos_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 314);
            this.Controls.Add(this.btn_cabys);
            this.Controls.Add(this.lbl_cabys_product_pendientes);
            this.Controls.Add(this.lbl_cabys_count_total);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_cabys_total);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_academia);
            this.Controls.Add(this.grp_lucas);
            this.Controls.Add(this.btn_asadas);
            this.Controls.Add(this.lbl_license);
            this.Controls.Add(this.btn_cxc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_internet);
            this.Controls.Add(this.txt_company_db_name);
            this.Controls.Add(this.txt_company_ter);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.btn_backup);
            this.Controls.Add(this.lbl_backup);
            this.Controls.Add(this.btn_proveedores);
            this.Controls.Add(this.btn_invoice_report);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_config_db_errors);
            this.Controls.Add(this.btn_config);
            this.Controls.Add(this.btn_invoice_maintenance);
            this.Controls.Add(this.btn_users);
            this.Controls.Add(this.btn_clients);
            this.Controls.Add(this.btn_products);
            this.Controls.Add(this.btn_new_invoice);
            this.Controls.Add(this.mnuS1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.MainMenuStrip = this.mnuS1;
            this.MaximizeBox = false;
            this.Name = "frm_pos_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_pos_main_FormClosing);
            this.Load += new System.EventHandler(this.frm_pos_main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grp_lucas.ResumeLayout(false);
            this.grp_lucas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_internet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_new_invoice;
        private System.Windows.Forms.Button btn_products;
        private System.Windows.Forms.Button btn_clients;
        private System.Windows.Forms.Button btn_users;
        private System.Windows.Forms.Button btn_invoice_maintenance;
        private System.Windows.Forms.Button btn_config;
        private System.Windows.Forms.Label lbl_config_db_errors;
        private System.Windows.Forms.MenuStrip mnuS1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.Button btn_invoice_report;
        private System.Windows.Forms.Button btn_proveedores;
        private System.Windows.Forms.Label lbl_backup;
        private System.Windows.Forms.Button btn_backup;
        private System.Windows.Forms.ProgressBar pb1;
        private System.Windows.Forms.TextBox txt_company_ter;
        private System.Windows.Forms.Label txt_company_db_name;
        private System.Windows.Forms.TextBox main_txt_for;
        private System.Windows.Forms.TextBox main_txt_then;
        private System.Windows.Forms.Button btn_main_encrypt;
        private System.Windows.Forms.Button btn_main_descrypt;
        private System.Windows.Forms.GroupBox grp_lucas;
        private System.Windows.Forms.PictureBox pb_internet;
        private System.Windows.Forms.ImageList il_internet;
        private System.Windows.Forms.Button btn_cxc;
        private System.Windows.Forms.Label lbl_license;
        private System.Windows.Forms.Button btn_asadas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_academia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_cabys_total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_cabys_count_total;
        private System.Windows.Forms.Label lbl_cabys_product_pendientes;
        private System.Windows.Forms.Button btn_cabys;
    }
}