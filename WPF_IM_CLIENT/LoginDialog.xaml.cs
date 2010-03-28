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
using MessClientAPI;
using System.ComponentModel;
using MessClientAPI.MessServiceApi;

namespace WPF_IM_CLIENT
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : WindowTemplate
    {
        #region custom events
        public event EventHandler<LoginEventArgs> Authenticated = delegate { };
        #endregion

        #region global objects
        BackgroundWorker bw_ValidateUser;
        #endregion

        public LoginDialog()
        {
            InitializeComponent();

            bw_ValidateUser = new BackgroundWorker();
            bw_ValidateUser.DoWork += new DoWorkEventHandler(bw_ValidateUser_DoWork);
            bw_ValidateUser.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_ValidateUser_RunWorkerCompleted);
        }

        void bw_ValidateUser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                Authenticated(this, (LoginEventArgs)e.Result);
                this.Close();
            }
            else
            {
                gbLoginInfo.IsEnabled = true;
                SetInfoMessage("Přihlášení se nezdařilo, zadejte správné ID a heslo a opakujte pokus.");
            }
        }

        private void SetInfoMessage(string message)
        {
            
            tbInfoMessage.Text = message;
            tbInfoMessage.Visibility = Visibility.Visible;
        }

        void bw_ValidateUser_DoWork(object sender, DoWorkEventArgs e)
        {
            LoginEventArgs lea = e.Argument as LoginEventArgs;
            if (MessApi.User_Validate(lea.id_user, lea.password))
            {
                MessApi.User_Login(lea.id_user, lea.password);
                lea.imUser = MessApi.Contact_GetContactById(lea.id_user);
                e.Result = lea;
            }
            else
                e.Cancel = true;
        }


        private void WindowTemplate_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (int.TryParse(tbLoginId.Text, out id))
            {
                bw_ValidateUser.RunWorkerAsync(new LoginEventArgs() { id_user = id, password = tbPassword.Password });
                gbLoginInfo.IsEnabled = false;
            }
            else
                SetInfoMessage("ID musí být číselné");
        }

    }
}
