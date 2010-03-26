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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessClientAPI;
using System.ComponentModel;
using MessClientAPI.MessServiceApi;
using System.Windows.Threading;
using System.Threading;


namespace WPF_IM_CLIENT
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ContactList : Window
    {
        BackgroundWorker bw_ContactsUpdate;

        public ContactList()
        {
            InitializeComponent();

            DispatcherTimer tmr_CheckContacts = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(5) };
            tmr_CheckContacts.Tick += new EventHandler(tmr_CheckContacts_Tick);
            tmr_CheckContacts.IsEnabled = true;

            bw_ContactsUpdate = new BackgroundWorker();
            bw_ContactsUpdate.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_ContactsUpdate_RunWorkerCompleted);
            bw_ContactsUpdate.DoWork += new DoWorkEventHandler(bw_ContactsUpdate_DoWork);    

            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close,
                new ExecutedRoutedEventHandler(delegate(object sender, ExecutedRoutedEventArgs args) { this.Close(); })));
        }

        void tmr_CheckContacts_Tick(object sender, EventArgs e)
        {
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            bw_ContactsUpdate.RunWorkerAsync();
            //listContacts.ItemsSource = MessApi.Contact_GetAllContacts(); //users; //listSource;
        }

        protected void listContacts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(((ImUser)listContacts.SelectedItem).USR_NICK + " say Hello!");
        }

        protected void btnLogin_MouseDown(object sender, RoutedEventArgs e)
        {
            if(!bw_ContactsUpdate.IsBusy)
                bw_ContactsUpdate.RunWorkerAsync();
        }

        public void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        public void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
