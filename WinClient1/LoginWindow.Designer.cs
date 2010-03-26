namespace WinClient1
{
    partial class LoginWindow
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
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPASSWORD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbID_USR = new System.Windows.Forms.TextBox();
            this.btnRegistration = new System.Windows.Forms.LinkLabel();
            this.gbLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.btnLogin);
            this.gbLogin.Controls.Add(this.label2);
            this.gbLogin.Controls.Add(this.tbPASSWORD);
            this.gbLogin.Controls.Add(this.label1);
            this.gbLogin.Controls.Add(this.tbID_USR);
            this.gbLogin.Location = new System.Drawing.Point(13, 13);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(190, 121);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Přihlášení";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(58, 86);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Přihlásit";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Heslo:";
            // 
            // tbPASSWORD
            // 
            this.tbPASSWORD.Location = new System.Drawing.Point(58, 49);
            this.tbPASSWORD.Name = "tbPASSWORD";
            this.tbPASSWORD.PasswordChar = '*';
            this.tbPASSWORD.Size = new System.Drawing.Size(100, 20);
            this.tbPASSWORD.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            // 
            // tbID_USR
            // 
            this.tbID_USR.Location = new System.Drawing.Point(58, 23);
            this.tbID_USR.Name = "tbID_USR";
            this.tbID_USR.Size = new System.Drawing.Size(100, 20);
            this.tbID_USR.TabIndex = 0;
            // 
            // btnRegistration
            // 
            this.btnRegistration.AutoSize = true;
            this.btnRegistration.Location = new System.Drawing.Point(78, 137);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(61, 13);
            this.btnRegistration.TabIndex = 1;
            this.btnRegistration.TabStop = true;
            this.btnRegistration.Text = "Registrovat";
            this.btnRegistration.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnRegistration_LinkClicked);
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 170);
            this.Controls.Add(this.btnRegistration);
            this.Controls.Add(this.gbLogin);
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RegistrationWindow";
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.LinkLabel btnRegistration;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPASSWORD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbID_USR;

    }
}