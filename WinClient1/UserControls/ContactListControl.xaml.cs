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
using MessClientAPI.MessServiceApi;

namespace WinClient1.UserControls
{
    /// <summary>
    /// Interaction logic for ContactListControl.xaml
    /// </summary>
    public partial class ContactListControl : UserControl
    {
        public ContactListControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void listBox1_SettingData(object sender, DataObjectSettingDataEventArgs e)
        {
            
        }

    }
}
