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

namespace WPF_IM_CLIENT
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : WindowTemplate
    {
        public LoginDialog()
        {
            InitializeComponent();
        }


        private void WindowTemplate_Loaded(object sender, RoutedEventArgs e)
        {
            base.Window_Loaded();

        }

    }
}
