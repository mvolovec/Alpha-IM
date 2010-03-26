namespace WinClient1
{
    partial class MessagingWinForm
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
            this.htmlEditControl1 = new Decav.Windows.Forms.Controls.HtmlEditControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.contactListControl1 = new WinClient1.UserControls.ContactListControl();
            this.SuspendLayout();
            // 
            // htmlEditControl1
            // 
            this.htmlEditControl1.BodyCssClass = "";
            this.htmlEditControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.htmlEditControl1.IsWebBrowserContextMenuEnabled = false;
            this.htmlEditControl1.Location = new System.Drawing.Point(0, 0);
            this.htmlEditControl1.MinimumSize = new System.Drawing.Size(20, 20);
            this.htmlEditControl1.Name = "htmlEditControl1";
            this.htmlEditControl1.Size = new System.Drawing.Size(292, 250);
            this.htmlEditControl1.TabIndex = 0;
            this.htmlEditControl1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 256);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 32);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(12, 295);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(200, 100);
            this.elementHost1.TabIndex = 3;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.contactListControl1;
            // 
            // MessagingWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 448);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.htmlEditControl1);
            this.Name = "MessagingWinForm";
            this.Text = "MessagingWinForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Decav.Windows.Forms.Controls.HtmlEditControl htmlEditControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WinClient1.UserControls.ContactListControl contactListControl1;


    }
}