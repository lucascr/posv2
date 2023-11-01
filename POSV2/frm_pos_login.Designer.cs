namespace POSV2
{
    partial class frm_pos_login
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
            this.grp_login = new System.Windows.Forms.GroupBox();
            this.lbl_login_error = new System.Windows.Forms.Label();
            this.lbl_login_password = new System.Windows.Forms.Label();
            this.btn_login_login = new System.Windows.Forms.Button();
            this.txt_login_password = new System.Windows.Forms.TextBox();
            this.mnuS1 = new System.Windows.Forms.MenuStrip();
            this.grp_login.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_login
            // 
            this.grp_login.Controls.Add(this.lbl_login_error);
            this.grp_login.Controls.Add(this.lbl_login_password);
            this.grp_login.Controls.Add(this.btn_login_login);
            this.grp_login.Controls.Add(this.txt_login_password);
            this.grp_login.Location = new System.Drawing.Point(-1, 27);
            this.grp_login.Name = "grp_login";
            this.grp_login.Size = new System.Drawing.Size(372, 142);
            this.grp_login.TabIndex = 40;
            this.grp_login.TabStop = false;
            this.grp_login.Text = "LOGIN";
            // 
            // lbl_login_error
            // 
            this.lbl_login_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login_error.Location = new System.Drawing.Point(10, 108);
            this.lbl_login_error.Name = "lbl_login_error";
            this.lbl_login_error.Size = new System.Drawing.Size(351, 19);
            this.lbl_login_error.TabIndex = 45;
            this.lbl_login_error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_login_error.DoubleClick += new System.EventHandler(this.lbl_login_error_DoubleClick);
            // 
            // lbl_login_password
            // 
            this.lbl_login_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login_password.Location = new System.Drawing.Point(108, 24);
            this.lbl_login_password.Name = "lbl_login_password";
            this.lbl_login_password.Size = new System.Drawing.Size(155, 13);
            this.lbl_login_password.TabIndex = 44;
            this.lbl_login_password.Text = "Password";
            this.lbl_login_password.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_login_login
            // 
            this.btn_login_login.Location = new System.Drawing.Point(138, 73);
            this.btn_login_login.Name = "btn_login_login";
            this.btn_login_login.Size = new System.Drawing.Size(95, 32);
            this.btn_login_login.TabIndex = 42;
            this.btn_login_login.Text = "Login";
            this.btn_login_login.UseVisualStyleBackColor = true;
            this.btn_login_login.Click += new System.EventHandler(this.btn_login_login_Click);
            // 
            // txt_login_password
            // 
            this.txt_login_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_login_password.Location = new System.Drawing.Point(110, 45);
            this.txt_login_password.Name = "txt_login_password";
            this.txt_login_password.PasswordChar = '*';
            this.txt_login_password.Size = new System.Drawing.Size(151, 22);
            this.txt_login_password.TabIndex = 41;
            this.txt_login_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_login_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_login_password_KeyPress);
            // 
            // mnuS1
            // 
            this.mnuS1.Location = new System.Drawing.Point(0, 0);
            this.mnuS1.Name = "mnuS1";
            this.mnuS1.Size = new System.Drawing.Size(375, 24);
            this.mnuS1.TabIndex = 41;
            this.mnuS1.Text = "menuStrip1";
            // 
            // frm_pos_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 173);
            this.Controls.Add(this.grp_login);
            this.Controls.Add(this.mnuS1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mnuS1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_pos_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frm_pos_login_Load);
            this.grp_login.ResumeLayout(false);
            this.grp_login.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grp_login;
        private System.Windows.Forms.Label lbl_login_password;
        private System.Windows.Forms.Button btn_login_login;
        private System.Windows.Forms.TextBox txt_login_password;
        private System.Windows.Forms.MenuStrip mnuS1;
        private System.Windows.Forms.Label lbl_login_error;
    }
}