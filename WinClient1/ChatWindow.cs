using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MessClientAPI;
using MessClientAPI.MessServiceApi;


namespace WinClient1
{
    public partial class ChatWindow : Form
    {
        #region properties
        public int id_usr { get; set; }
        public string comm_usr_nick { get; set; }
        public int comm_usr { get; set; }
        public string password { get; set; }
        #endregion

        #region events
        #endregion

        public ChatWindow(int _id_usr, int _comm_usr, string _password, string _comm_usr_nick)
        {
            id_usr = _id_usr;
            comm_usr = _comm_usr;
            password = _password;
            comm_usr_nick = _comm_usr_nick;
            this.Text = comm_usr_nick;
            InitializeComponent();
            tbMessageBody.Focus();
        }

        public void NewMessagesReceived(List<ImMessage> newMessages)
        {
            foreach (var nMess in newMessages)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(comm_usr_nick + " - " + nMess.C_DATE.ToShortTimeString() + ":");
                sb.AppendLine(nMess.MSG_BODY);
                tbMessages.Text += sb.ToString();
            }
            tbMessages.SelectionStart = tbMessages.TextLength;
            tbMessages.ScrollToCaret();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            int [] users = {comm_usr};
            if (MessApi.Message_InsertMessageForUser(id_usr, password, tbMessageBody.Text, (int)MsgState.New, users))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Ja - " + DateTime.Now.ToShortTimeString() + ":");
                sb.AppendLine(tbMessageBody.Text);
                tbMessages.Text += sb.ToString();
                tbMessages.SelectionStart = tbMessages.TextLength;
                tbMessages.ScrollToCaret();
                tbMessageBody.Text = string.Empty;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbCommPartner.Text = comm_usr_nick;
        }

        private void tbMessageBody_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSendMessage.PerformClick();
            }
        }
    }
}
