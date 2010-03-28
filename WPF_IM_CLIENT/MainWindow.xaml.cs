using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessClientAPI.MessServiceApi;
using MessClientAPI;
using System.Windows.Threading;
using System.ComponentModel;

namespace WPF_IM_CLIENT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowTemplate
    {
        #region global variables
        BackgroundWorker bw_ContactsUpdate;
        BackgroundWorker bw_CommonOperations;
        DispatcherTimer tmr_CheckContacts;
        #endregion

        #region properties
        private int id_user { get; set; }
        private string password { get; set; }
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            TimersSetUp();

            AsyncProcessingSetUp();
        }

        #region SetUp
        /// <summary>
        /// Nastaveni backgroundWorkeru a jejich handleru
        /// </summary>
        private void AsyncProcessingSetUp()
        {
            bw_ContactsUpdate = new BackgroundWorker();
            bw_ContactsUpdate.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_ContactsUpdate_RunWorkerCompleted);
            bw_ContactsUpdate.DoWork += new DoWorkEventHandler(bw_ContactsUpdate_DoWork);
        }
        
        /// <summary>
        /// Nastaveni potrebnych timeru kvuli cyklicke kontrole kontaktu a novych zprav na serveru
        /// </summary>
        private void TimersSetUp()
        {
            tmr_CheckContacts = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(15) };
            tmr_CheckContacts.Tick += new EventHandler(tmr_CheckContacts_Tick);
            //tmr_CheckContacts.IsEnabled = true;
        }
        #endregion

        #region window events
        /// <summary>
        /// pocatecni nastaveni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginDialogInit();

            //bw_ContactsUpdate.RunWorkerAsync();
        }

        /// <summary>
        /// akce pri zavirani okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowTemplate_Closing(object sender, CancelEventArgs e)
        {
            MessApi.User_Logout(id_user, password);
            
            for (int i = ChildWindows.Count-1; i >= 0; i--)
            {
                ChildWindows[i].Close();
            }
        }

        /// <summary>
        /// inicializace loginDialogu
        /// </summary>
        private void LoginDialogInit()
        {
            LoginDialog ld = new LoginDialog();
            ld.Authenticated += new EventHandler<LoginEventArgs>(ld_Authenticated);
            ld.Closed += new EventHandler(child_Closed);
            ld.ShowDialog();
        }

        /// <summary>
        /// Handle udalosi LoginDialogu indikujici uspesne overeni prihlasovacich udaju
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ld_Authenticated(object sender, LoginEventArgs e)
        {
            id_user = e.id_user;
            password = e.password;

            this.Title = e.imUser.USR_NICK;

            tmr_CheckContacts.IsEnabled = true;
            bw_ContactsUpdate.RunWorkerAsync();
        }

        /// <summary>
        /// akce vazana na casovac, spousti update informaci o kontaktech
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tmr_CheckContacts_Tick(object sender, EventArgs e)
        {
            if (!bw_ContactsUpdate.IsBusy)
                bw_ContactsUpdate.RunWorkerAsync();
        }

        /// <summary>
        /// spusteni asynchronniho stahovani dat o uzivatelich
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bw_ContactsUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            List<ImUser> contacts = new List<ImUser>(MessApi.Contact_GetAllContacts().Where(i=>i.ID_USR != id_user));
            e.Result = contacts;
        }

        /// <summary>
        /// Konec asynchronniho stahovani dat o uzivatelich
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bw_ContactsUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listContacts.ItemsSource = e.Result as List<ImUser>;
        }

        
        /// <summary>
        /// Vyvolani nove konverzace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void listContacts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ImUser imu = listContacts.SelectedItem as ImUser;
            if (this.ChildWindows.Where(w => w.GetType().Equals(typeof(ChatWindow)) && ((ChatWindow)w).chatWithUser.ID_USR == imu.ID_USR).Count() == 0)
            {
                ChatWindow chw = new ChatWindow() { Title = imu.USR_NICK + " say Hello!", chatWithUser = imu };
                chw.ParentWindow = this;
                ChildWindows.Add(chw);
                chw.Closed += new EventHandler(child_Closed);
                chw.Show();
                
            }
        }

        /// <summary>
        /// Odstraneni potomka z kolekce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void child_Closed(object sender, EventArgs e)
        {
            this.ChildWindows.Remove((Window)sender);
        }

        /// <summary>
        /// Posuv okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        /// <summary>
        /// Odhlaseni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessApi.User_Logout(id_user, password);
        }


        /// <summary>
        /// Vyvolani dialogu pro prihlaseni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            foreach (var w in this.ChildWindows)
            {
                if (((Window)w).GetType().Equals(typeof(LoginDialog)))
                    return;
            }
            LoginDialogInit();
        }
        #endregion
        
    }
}
