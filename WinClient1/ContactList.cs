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
    public partial class ContactList : Form
    {
        #region properties
        public int id_usr { get; set; }
        public string password { get; set; }
        private List<ChatWindow> openedWins { get; set; }
        public List<ImMessage> messages_tmp { get; set; }

        private UserControls.ContactListControl listboxContacts;
        #endregion

        #region Event handlers
        #endregion

        public ContactList()
        {
            InitializeComponent();
            
            openedWins = new List<ChatWindow>();
            messages_tmp = new List<ImMessage>();
            
            listboxContacts = elementHost1.Child as UserControls.ContactListControl;
            listboxContacts.listBox1.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(listBox1_MouseDoubleClick);
        }

        void listBox1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ImUser imuser = (ImUser)listboxContacts.listBox1.SelectedItem;
            bool isIn = false;
            foreach (var item in openedWins)
            {
                isIn = (item.comm_usr == imuser.ID_USR);
                item.Focus();
            }

            if (!isIn)
            {
                ChatWindow chw = new ChatWindow(id_usr, imuser.ID_USR, password, imuser.USR_NICK);
                openedWins.Add(chw);
                chw.FormClosed += new FormClosedEventHandler(chw_FormClosed);
                chw.Show();
            }
        }        

        void lw_Authenticated(object sender, LoginEventArgs e)
        {
            id_usr = e.id_usr;
            password = e.password;
            tmrCheckForNewMessages.Enabled = true;
            tmrCheckOnlineUsers.Enabled = true;
            MessApi.User_Login(id_usr, password);
            listboxContacts.listBox1.ItemsSource = MessApi.Contact_GetAllContacts()
                .Where(i => i.USR_STATUS.Equals((int)UsrStatus.online) && i.ID_USR != id_usr).ToList<ImUser>();
                //.Where(i => i.ID_USR != id_usr).ToList<ImUser>();
            //listboxContacts.DisplayMember = "USR_NICK";
            this.Text = MessApi.Contact_GetAllContacts().Where(i => i.ID_USR.Equals(id_usr)).Select(i => i.USR_NICK).FirstOrDefault();
            this.Focus();
        }

        private void tmrCheckForNewMessages_Tick(object sender, EventArgs e)
        {
            CheckNewMessages();
        }

        private void CheckNewMessages()
        {
            messages_tmp.AddRange(MessApi.Message_GetMyNewMessages(id_usr, password));

            if (messages_tmp != null && messages_tmp.Count > 0)
            {
                FillMessagesToWins();

                if (messages_tmp.Count > 0)
                {
                    foreach (var item in messages_tmp)
                    {
                        ImUser imu = MessApi.Contact_GetAllContacts().Where(i => i.ID_USR.Equals(item.ID_SENDER)).FirstOrDefault();
                        if (imu != null)
                        {
                            ChatWindow chw = new ChatWindow(id_usr, item.ID_SENDER, password, imu.USR_NICK);
                            openedWins.Add(chw);
                            chw.FormClosed += new FormClosedEventHandler(chw_FormClosed);
                            chw.Show();
                        }
                    }
                    FillMessagesToWins();
                }
            }
        }

        private void FillMessagesToWins()
        {
            foreach (var item in openedWins)
            {
                item.NewMessagesReceived(messages_tmp
                    .Where(i => i.ID_SENDER.Equals(item.comm_usr)).ToList<ImMessage>());
                messages_tmp.RemoveAll(i => i.ID_SENDER.Equals(item.comm_usr));



                //foreach (var msg in messages_tmp)
                //{
                //    if (msg.ID_SENDER.Equals(item.comm_usr))
                //        messages_tmp.Remove(msg);
                //}
            }
        }

        private void listboxContacts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //ImUser imuser = (ImUser)listboxContacts.SelectedItem;
            //bool isIn = false;
            //foreach (var item in openedWins)
            //{
            //    isIn = (item.comm_usr == imuser.ID_USR);
            //    item.Focus();
            //}

            //if (!isIn)
            //{
            //    ChatWindow chw = new ChatWindow(id_usr, imuser.ID_USR, password, imuser.USR_NICK);
            //    openedWins.Add(chw);
            //    chw.FormClosed += new FormClosedEventHandler(chw_FormClosed);
            //    chw.Show();
            //}
        }

        void chw_FormClosed(object sender, FormClosedEventArgs e)
        {
            openedWins.Remove((ChatWindow)sender);
        }

        private void ContactList_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessApi.User_Logout(id_usr, password);
        }

        private void tmrCheckOnlineUsers_Tick(object sender, EventArgs e)
        {
            listboxContacts.listBox1.ItemsSource = MessApi.Contact_GetAllContacts()
                .Where(i => i.USR_STATUS.Equals((int)UsrStatus.online) && i.ID_USR != id_usr).ToList<ImUser>();
                //.Where(i => i.ID_USR != id_usr).ToList<ImUser>();
        }

        private void ContactList_Load(object sender, EventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            lw.Focus();
            lw.Authenticated += new EventHandler<LoginEventArgs>(lw_Authenticated);
        }

        private void bwCheckMessages_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void bwCheckMessages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

    #region Events Classes
    public class NewMessageEventArgs : EventArgs
    {
        public List<ImMessage> NewMessages { get; set; }

        public NewMessageEventArgs(List<ImMessage> _NewMessages)
        {
            NewMessages = _NewMessages;
        }
    }
    #endregion
}
