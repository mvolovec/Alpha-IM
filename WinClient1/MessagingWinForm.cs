using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinClient1
{
    public partial class MessagingWinForm : Form
    {
        public MessagingWinForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            htmlEditControl1.Html = textBox1.Text;
        }
    }
}
