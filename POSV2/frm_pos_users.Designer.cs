namespace POSV2
{
    partial class frm_pos_users
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
            this.txt_users_search_all = new System.Windows.Forms.TextBox();
            this.lv_users_search_results = new System.Windows.Forms.ListView();
            this.lbl_users_access_level = new System.Windows.Forms.Label();
            this.lbl_users_password = new System.Windows.Forms.Label();
            this.lbl_users_username = new System.Windows.Forms.Label();
            this.txt_users_password = new System.Windows.Forms.TextBox();
            this.txt_users_username = new System.Windows.Forms.TextBox();
            this.lbl_users_initials = new System.Windows.Forms.Label();
            this.txt_users_initials = new System.Windows.Forms.TextBox();
            this.lbl_users_fullname = new System.Windows.Forms.Label();
            this.txt_users_fullname = new System.Windows.Forms.TextBox();
            this.lbl_users_email = new System.Windows.Forms.Label();
            this.txt_users_email = new System.Windows.Forms.TextBox();
            this.grp_users = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_edit_user_id = new System.Windows.Forms.Label();
            this.btn_users_update = new System.Windows.Forms.Button();
            this.lbl_state = new System.Windows.Forms.Label();
            this.cmb_users_state = new System.Windows.Forms.ComboBox();
            this.lv_users_access_list = new System.Windows.Forms.ListView();
            this.btn_users_add = new System.Windows.Forms.Button();
            this.cmb_users_search_access_level = new System.Windows.Forms.ComboBox();
            this.mnuS1 = new System.Windows.Forms.MenuStrip();
            this.cmb_users_search_state = new System.Windows.Forms.ComboBox();
            this.lbl_users_search_state = new System.Windows.Forms.Label();
            this.lbl_users_search_access_level = new System.Windows.Forms.Label();
            this.lbl_users_search_text = new System.Windows.Forms.Label();
            this.btn_users_search = new System.Windows.Forms.Button();
            this.grp_users_search = new System.Windows.Forms.GroupBox();
            this.grp_users.SuspendLayout();
            this.grp_users_search.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_users_search_all
            // 
            this.txt_users_search_all.Location = new System.Drawing.Point(11, 32);
            this.txt_users_search_all.Name = "txt_users_search_all";
            this.txt_users_search_all.Size = new System.Drawing.Size(196, 20);
            this.txt_users_search_all.TabIndex = 76;
            this.txt_users_search_all.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_user_search_all_KeyUp);
            // 
            // lv_users_search_results
            // 
            this.lv_users_search_results.FullRowSelect = true;
            this.lv_users_search_results.Location = new System.Drawing.Point(10, 356);
            this.lv_users_search_results.Name = "lv_users_search_results";
            this.lv_users_search_results.Size = new System.Drawing.Size(990, 315);
            this.lv_users_search_results.TabIndex = 75;
            this.lv_users_search_results.UseCompatibleStateImageBehavior = false;
            this.lv_users_search_results.View = System.Windows.Forms.View.Details;
            this.lv_users_search_results.SelectedIndexChanged += new System.EventHandler(this.lv_users_SelectedIndexChanged);
            this.lv_users_search_results.DoubleClick += new System.EventHandler(this.lv_users_DoubleClick);
            // 
            // lbl_users_access_level
            // 
            this.lbl_users_access_level.Location = new System.Drawing.Point(230, 16);
            this.lbl_users_access_level.Name = "lbl_users_access_level";
            this.lbl_users_access_level.Size = new System.Drawing.Size(199, 20);
            this.lbl_users_access_level.TabIndex = 74;
            this.lbl_users_access_level.Text = "Access level";
            // 
            // lbl_users_password
            // 
            this.lbl_users_password.Location = new System.Drawing.Point(12, 172);
            this.lbl_users_password.Name = "lbl_users_password";
            this.lbl_users_password.Size = new System.Drawing.Size(199, 13);
            this.lbl_users_password.TabIndex = 70;
            this.lbl_users_password.Text = "Password";
            // 
            // lbl_users_username
            // 
            this.lbl_users_username.Location = new System.Drawing.Point(12, 133);
            this.lbl_users_username.Name = "lbl_users_username";
            this.lbl_users_username.Size = new System.Drawing.Size(199, 13);
            this.lbl_users_username.TabIndex = 69;
            this.lbl_users_username.Text = "Username";
            // 
            // txt_users_password
            // 
            this.txt_users_password.Location = new System.Drawing.Point(12, 188);
            this.txt_users_password.Name = "txt_users_password";
            this.txt_users_password.Size = new System.Drawing.Size(199, 20);
            this.txt_users_password.TabIndex = 67;
            // 
            // txt_users_username
            // 
            this.txt_users_username.Location = new System.Drawing.Point(12, 149);
            this.txt_users_username.Name = "txt_users_username";
            this.txt_users_username.Size = new System.Drawing.Size(199, 20);
            this.txt_users_username.TabIndex = 66;
            this.txt_users_username.TextChanged += new System.EventHandler(this.txt_users_username_TextChanged);
            // 
            // lbl_users_initials
            // 
            this.lbl_users_initials.Location = new System.Drawing.Point(12, 55);
            this.lbl_users_initials.Name = "lbl_users_initials";
            this.lbl_users_initials.Size = new System.Drawing.Size(199, 13);
            this.lbl_users_initials.TabIndex = 78;
            this.lbl_users_initials.Text = "Initials";
            // 
            // txt_users_initials
            // 
            this.txt_users_initials.Location = new System.Drawing.Point(12, 71);
            this.txt_users_initials.Name = "txt_users_initials";
            this.txt_users_initials.Size = new System.Drawing.Size(199, 20);
            this.txt_users_initials.TabIndex = 77;
            // 
            // lbl_users_fullname
            // 
            this.lbl_users_fullname.Location = new System.Drawing.Point(12, 16);
            this.lbl_users_fullname.Name = "lbl_users_fullname";
            this.lbl_users_fullname.Size = new System.Drawing.Size(199, 13);
            this.lbl_users_fullname.TabIndex = 80;
            this.lbl_users_fullname.Text = "Fullname";
            // 
            // txt_users_fullname
            // 
            this.txt_users_fullname.Location = new System.Drawing.Point(12, 32);
            this.txt_users_fullname.Name = "txt_users_fullname";
            this.txt_users_fullname.Size = new System.Drawing.Size(199, 20);
            this.txt_users_fullname.TabIndex = 79;
            this.txt_users_fullname.TextChanged += new System.EventHandler(this.txt_users_fullname_TextChanged);
            // 
            // lbl_users_email
            // 
            this.lbl_users_email.Location = new System.Drawing.Point(12, 94);
            this.lbl_users_email.Name = "lbl_users_email";
            this.lbl_users_email.Size = new System.Drawing.Size(199, 13);
            this.lbl_users_email.TabIndex = 82;
            this.lbl_users_email.Text = "Email";
            // 
            // txt_users_email
            // 
            this.txt_users_email.Location = new System.Drawing.Point(12, 110);
            this.txt_users_email.Name = "txt_users_email";
            this.txt_users_email.Size = new System.Drawing.Size(199, 20);
            this.txt_users_email.TabIndex = 81;
            // 
            // grp_users
            // 
            this.grp_users.BackColor = System.Drawing.SystemColors.Control;
            this.grp_users.Controls.Add(this.label4);
            this.grp_users.Controls.Add(this.lbl_edit_user_id);
            this.grp_users.Controls.Add(this.btn_users_update);
            this.grp_users.Controls.Add(this.lbl_state);
            this.grp_users.Controls.Add(this.cmb_users_state);
            this.grp_users.Controls.Add(this.lv_users_access_list);
            this.grp_users.Controls.Add(this.txt_users_initials);
            this.grp_users.Controls.Add(this.txt_users_username);
            this.grp_users.Controls.Add(this.btn_users_add);
            this.grp_users.Controls.Add(this.lbl_users_email);
            this.grp_users.Controls.Add(this.txt_users_password);
            this.grp_users.Controls.Add(this.txt_users_email);
            this.grp_users.Controls.Add(this.lbl_users_username);
            this.grp_users.Controls.Add(this.lbl_users_fullname);
            this.grp_users.Controls.Add(this.lbl_users_password);
            this.grp_users.Controls.Add(this.txt_users_fullname);
            this.grp_users.Controls.Add(this.lbl_users_initials);
            this.grp_users.Controls.Add(this.lbl_users_access_level);
            this.grp_users.Location = new System.Drawing.Point(10, 25);
            this.grp_users.Name = "grp_users";
            this.grp_users.Size = new System.Drawing.Size(990, 260);
            this.grp_users.TabIndex = 83;
            this.grp_users.TabStop = false;
            this.grp_users.Text = "User information";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(437, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 20);
            this.label4.TabIndex = 92;
            this.label4.Text = "Company Access";
            this.label4.Visible = false;
            // 
            // lbl_edit_user_id
            // 
            this.lbl_edit_user_id.Location = new System.Drawing.Point(882, 185);
            this.lbl_edit_user_id.Name = "lbl_edit_user_id";
            this.lbl_edit_user_id.Size = new System.Drawing.Size(94, 14);
            this.lbl_edit_user_id.TabIndex = 91;
            this.lbl_edit_user_id.Text = "0";
            this.lbl_edit_user_id.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_users_update
            // 
            this.btn_users_update.BackColor = System.Drawing.Color.Transparent;
            this.btn_users_update.Enabled = false;
            this.btn_users_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_users_update.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_users_update.Location = new System.Drawing.Point(874, 198);
            this.btn_users_update.Name = "btn_users_update";
            this.btn_users_update.Size = new System.Drawing.Size(105, 50);
            this.btn_users_update.TabIndex = 90;
            this.btn_users_update.Text = "Actualizar Usuario";
            this.btn_users_update.UseVisualStyleBackColor = false;
            this.btn_users_update.Click += new System.EventHandler(this.btn_users_update_Click);
            // 
            // lbl_state
            // 
            this.lbl_state.Location = new System.Drawing.Point(12, 211);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(199, 13);
            this.lbl_state.TabIndex = 89;
            this.lbl_state.Text = "State";
            // 
            // cmb_users_state
            // 
            this.cmb_users_state.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_users_state.FormattingEnabled = true;
            this.cmb_users_state.Location = new System.Drawing.Point(12, 227);
            this.cmb_users_state.Name = "cmb_users_state";
            this.cmb_users_state.Size = new System.Drawing.Size(201, 21);
            this.cmb_users_state.TabIndex = 88;
            // 
            // lv_users_access_list
            // 
            this.lv_users_access_list.CheckBoxes = true;
            this.lv_users_access_list.FullRowSelect = true;
            this.lv_users_access_list.Location = new System.Drawing.Point(230, 38);
            this.lv_users_access_list.Name = "lv_users_access_list";
            this.lv_users_access_list.Size = new System.Drawing.Size(201, 210);
            this.lv_users_access_list.TabIndex = 88;
            this.lv_users_access_list.UseCompatibleStateImageBehavior = false;
            this.lv_users_access_list.View = System.Windows.Forms.View.Details;
            // 
            // btn_users_add
            // 
            this.btn_users_add.BackColor = System.Drawing.Color.Transparent;
            this.btn_users_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_users_add.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_users_add.Location = new System.Drawing.Point(763, 198);
            this.btn_users_add.Name = "btn_users_add";
            this.btn_users_add.Size = new System.Drawing.Size(105, 50);
            this.btn_users_add.TabIndex = 39;
            this.btn_users_add.Text = "Agregar Usuario";
            this.btn_users_add.UseVisualStyleBackColor = false;
            this.btn_users_add.Click += new System.EventHandler(this.btn_users_save_Click);
            // 
            // cmb_users_search_access_level
            // 
            this.cmb_users_search_access_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_users_search_access_level.FormattingEnabled = true;
            this.cmb_users_search_access_level.Location = new System.Drawing.Point(226, 31);
            this.cmb_users_search_access_level.Name = "cmb_users_search_access_level";
            this.cmb_users_search_access_level.Size = new System.Drawing.Size(201, 21);
            this.cmb_users_search_access_level.TabIndex = 86;
            // 
            // mnuS1
            // 
            this.mnuS1.Location = new System.Drawing.Point(0, 0);
            this.mnuS1.Name = "mnuS1";
            this.mnuS1.Size = new System.Drawing.Size(1008, 24);
            this.mnuS1.TabIndex = 87;
            this.mnuS1.Text = "menuStrip1";
            // 
            // cmb_users_search_state
            // 
            this.cmb_users_search_state.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_users_search_state.FormattingEnabled = true;
            this.cmb_users_search_state.Location = new System.Drawing.Point(445, 31);
            this.cmb_users_search_state.Name = "cmb_users_search_state";
            this.cmb_users_search_state.Size = new System.Drawing.Size(201, 21);
            this.cmb_users_search_state.TabIndex = 89;
            // 
            // lbl_users_search_state
            // 
            this.lbl_users_search_state.Location = new System.Drawing.Point(447, 15);
            this.lbl_users_search_state.Name = "lbl_users_search_state";
            this.lbl_users_search_state.Size = new System.Drawing.Size(199, 13);
            this.lbl_users_search_state.TabIndex = 90;
            this.lbl_users_search_state.Text = "State";
            // 
            // lbl_users_search_access_level
            // 
            this.lbl_users_search_access_level.Location = new System.Drawing.Point(226, 15);
            this.lbl_users_search_access_level.Name = "lbl_users_search_access_level";
            this.lbl_users_search_access_level.Size = new System.Drawing.Size(199, 13);
            this.lbl_users_search_access_level.TabIndex = 92;
            this.lbl_users_search_access_level.Text = "Access level";
            // 
            // lbl_users_search_text
            // 
            this.lbl_users_search_text.Location = new System.Drawing.Point(10, 16);
            this.lbl_users_search_text.Name = "lbl_users_search_text";
            this.lbl_users_search_text.Size = new System.Drawing.Size(199, 13);
            this.lbl_users_search_text.TabIndex = 93;
            this.lbl_users_search_text.Text = "Text to search";
            // 
            // btn_users_search
            // 
            this.btn_users_search.Location = new System.Drawing.Point(881, 30);
            this.btn_users_search.Name = "btn_users_search";
            this.btn_users_search.Size = new System.Drawing.Size(97, 21);
            this.btn_users_search.TabIndex = 94;
            this.btn_users_search.Text = "Buscar Usuario";
            this.btn_users_search.UseVisualStyleBackColor = true;
            this.btn_users_search.Click += new System.EventHandler(this.btn_users_search_Click);
            // 
            // grp_users_search
            // 
            this.grp_users_search.Controls.Add(this.btn_users_search);
            this.grp_users_search.Controls.Add(this.lbl_users_search_text);
            this.grp_users_search.Controls.Add(this.txt_users_search_all);
            this.grp_users_search.Controls.Add(this.lbl_users_search_access_level);
            this.grp_users_search.Controls.Add(this.cmb_users_search_access_level);
            this.grp_users_search.Controls.Add(this.lbl_users_search_state);
            this.grp_users_search.Controls.Add(this.cmb_users_search_state);
            this.grp_users_search.Location = new System.Drawing.Point(10, 290);
            this.grp_users_search.Name = "grp_users_search";
            this.grp_users_search.Size = new System.Drawing.Size(990, 60);
            this.grp_users_search.TabIndex = 95;
            this.grp_users_search.TabStop = false;
            this.grp_users_search.Text = "Search options";
            // 
            // frm_pos_users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.grp_users_search);
            this.Controls.Add(this.grp_users);
            this.Controls.Add(this.lv_users_search_results);
            this.Controls.Add(this.mnuS1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_pos_users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.Load += new System.EventHandler(this.frm_pos_users_Load);
            this.Shown += new System.EventHandler(this.frm_pos_users_Shown);
            this.grp_users.ResumeLayout(false);
            this.grp_users.PerformLayout();
            this.grp_users_search.ResumeLayout(false);
            this.grp_users_search.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_users_search_all;
        private System.Windows.Forms.Label lbl_users_access_level;
        private System.Windows.Forms.Label lbl_users_password;
        private System.Windows.Forms.Label lbl_users_username;
        private System.Windows.Forms.TextBox txt_users_password;
        private System.Windows.Forms.TextBox txt_users_username;
        private System.Windows.Forms.Label lbl_users_initials;
        private System.Windows.Forms.TextBox txt_users_initials;
        private System.Windows.Forms.Label lbl_users_fullname;
        private System.Windows.Forms.TextBox txt_users_fullname;
        private System.Windows.Forms.Label lbl_users_email;
        private System.Windows.Forms.TextBox txt_users_email;
        private System.Windows.Forms.GroupBox grp_users;
        private System.Windows.Forms.Button btn_users_add;
        private System.Windows.Forms.ComboBox cmb_users_search_access_level;
        private System.Windows.Forms.MenuStrip mnuS1;
        private System.Windows.Forms.ListView lv_users_access_list;
        private System.Windows.Forms.Label lbl_state;
        private System.Windows.Forms.ComboBox cmb_users_state;
        private System.Windows.Forms.ComboBox cmb_users_search_state;
        private System.Windows.Forms.ListView lv_users_search_results;
        private System.Windows.Forms.Button btn_users_update;
        private System.Windows.Forms.Label lbl_edit_user_id;
        private System.Windows.Forms.Label lbl_users_search_state;
        private System.Windows.Forms.Label lbl_users_search_access_level;
        private System.Windows.Forms.Label lbl_users_search_text;
        private System.Windows.Forms.Button btn_users_search;
        private System.Windows.Forms.GroupBox grp_users_search;
        private System.Windows.Forms.Label label4;
    }
}