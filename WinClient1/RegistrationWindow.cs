using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MessClientAPI;

namespace WinClient1
{
    public partial class RegistrationWindow : Form
    {
        public event EventHandler Registered;

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text.Equals(tbPasswordAgain.Text))
            {
                int id;
                if ((id = MessApi.User_RegisterNewContact(tbNick.Text, tbPasswordAgain.Text)) != 0)
                {
                    tbUserID.Text = id.ToString();
                    Registered(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Registrace se nezdařila !");
                }
            }
        }
    }
}
