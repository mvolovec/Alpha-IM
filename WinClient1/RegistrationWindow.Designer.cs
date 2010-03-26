namespace WinClient1
{
    partial class RegistrationWindow
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
            this.gbRegistration = new System.Windows.Forms.GroupBox();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPasswordAgain = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbNick = new System.Windows.Forms.TextBox();
            this.gbRegistration.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRegistration
            // 
            this.gbRegistration.Controls.Add(this.tbUserID);
            this.gbRegistration.Controls.Add(this.label2);
            this.gbRegistration.Controls.Add(this.lbStatus);
            this.gbRegistration.Controls.Add(this.btnRegister);
            this.gbRegistration.Controls.Add(this.label3);
            this.gbRegistration.Controls.Add(this.lbPassword);
            this.gbRegistration.Controls.Add(this.label1);
            this.gbRegistration.Controls.Add(this.tbPasswordAgain);
            this.gbRegistration.Controls.Add(this.tbPassword);
            this.gbRegistration.Controls.Add(this.tbNick);
            this.gbRegistration.Location = new System.Drawing.Point(13, 13);
            this.gbRegistration.Name = "gbRegistration";
            this.gbRegistration.Size = new System.Drawing.Size(267, 176);
            this.gbRegistration.TabIndex = 0;
            this.gbRegistration.TabStop = false;
            this.gbRegistration.Text = "Registrace";
            // 
            // tbUserID
            // 
            this.tbUserID.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbUserID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbUserID.Location = new System.Drawing.Point(101, 131);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.ReadOnly = true;
            this.tbUserID.Size = new System.Drawing.Size(160, 19);
            this.tbUserID.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID uživatele:";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(98, 131);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 13);
            this.lbStatus.TabIndex = 7;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(101, 94);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 23);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Registruj";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kontrola hesla:";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(63, 43);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(37, 13);
            this.lbPassword.TabIndex = 4;
            this.lbPassword.Text = "Heslo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nick:";
            // 
            // tbPasswordAgain
            // 
            this.tbPasswordAgain.Location = new System.Drawing.Point(101, 67);
            this.tbPasswordAgain.Name = "tbPasswordAgain";
            this.tbPasswordAgain.PasswordChar = '*';
            this.tbPasswordAgain.Size = new System.Drawing.Size(100, 20);
            this.tbPasswordAgain.TabIndex = 2;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(101, 40);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // tbNick
            // 
            this.tbNick.Location = new System.Drawing.Point(101, 13);
            this.tbNick.Name = "tbNick";
            this.tbNick.Size = new System.Drawing.Size(100, 20);
            this.tbNick.TabIndex = 0;
            // 
            // RegistrationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 201);
            this.Controls.Add(this.gbRegistration);
            this.Name = "RegistrationWindow";
            this.Text = "RegistrationWindow";
            this.gbRegistration.ResumeLayout(false);
            this.gbRegistration.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRegistration;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPasswordAgain;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbNick;
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.Label label2;
    }
}