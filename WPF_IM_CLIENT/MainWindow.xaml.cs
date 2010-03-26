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
        #region global properties
        BackgroundWorker bw_ContactsUpdate;
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
            DispatcherTimer tmr_CheckContacts = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(15) };
            tmr_CheckContacts.Tick += new EventHandler(tmr_CheckContacts_Tick);
            tmr_CheckContacts.IsEnabled = true;
        }
        #endregion

        #region window events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            base.Window_Loaded();
            bw_ContactsUpdate.RunWorkerAsync();
        }

        void tmr_CheckContacts_Tick(object sender, EventArgs e)
        {
            if (!bw_ContactsUpdate.IsBusy)
                bw_ContactsUpdate.RunWorkerAsync();
        }

        void bw_ContactsUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            List<ImUser> contacts = new List<ImUser>(MessApi.Contact_GetAllContacts());
            e.Result = contacts;
        }

        void bw_ContactsUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listContacts.ItemsSource = e.Result as List<ImUser>;
        }

        

        protected void listContacts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new ChatWindow() { Title = ((ImUser)listContacts.SelectedItem).USR_NICK + " say Hello!" }.Show();

        }

        protected void btnLogin_MouseDown(object sender, RoutedEventArgs e)
        {
            
        }

        public void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        
    }
}
