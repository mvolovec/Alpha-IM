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
    public partial class LoginWindow : Form
    {
        public event EventHandler<LoginEventArgs> Authenticated;

        public LoginWindow()
        {
            InitializeComponent();
            this.Focus();
        }

        private void btnRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationWindow rWin = new RegistrationWindow();
            rWin.Registered += new EventHandler(rWin_Registered);
            rWin.Show();
            rWin.Focus();
        }

        void rWin_Registered(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int id_usr;
            if (int.TryParse(tbID_USR.Text, out id_usr) && MessApi.User_Validate(id_usr, tbPASSWORD.Text))
            {
                Authenticated(this, new LoginEventArgs(id_usr, tbPASSWORD.Text));
                this.Close();
            }
        }
    }

    public class LoginEventArgs : EventArgs
    {
        public int id_usr { get; set; }
        public string password { get; set; }

        public LoginEventArgs(int _id_usr, string _password)
        {
            id_usr = _id_usr;
            password = _password;
        }
    }
}
