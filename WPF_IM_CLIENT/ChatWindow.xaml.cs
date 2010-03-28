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

namespace WPF_IM_CLIENT
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : WindowTemplate
    {
        #region properties
        public ImUser chatWithUser { get; set; }
        #endregion

        public ChatWindow()
        {
            InitializeComponent();
        }

        private void WindowTemplate_Loaded(object sender, RoutedEventArgs e)
        {
            if (chatWithUser != null)
            {
                Title = "Konverzace s " + chatWithUser.USR_NICK;
            }
            List<ImMessage> list = new List<ImMessage>();
            list.Add(new ImMessage() { MSG_BODY = "Nejaky text kter7 nemus9 b7t sfsadfkj a sdkfjah sdfkjas dfl", ID_SENDER = 10, C_DATE = DateTime.Now });
            list.Add(new ImMessage() { MSG_BODY = "Nejaky text kter7 nemus9 b7t sfsadfkj a sdkfjah sdfkjas dfl", C_DATE = DateTime.Now });
            list.Add(new ImMessage() { MSG_BODY = "Nejaky text kter7 nemus9 b7t sfsadfkj a sdkfjah sdfkjas dfl", ID_SENDER = 10, C_DATE = DateTime.Now });
            list.Add(new ImMessage() { MSG_BODY = "Nejaky text kter7 nemus9 b7t sfsadfkj a sdkfjah sdfkjas dfl", C_DATE = DateTime.Now });
            list.Add(new ImMessage() { MSG_BODY = "Nejaky text kter7 nemus9 b7t sfsadfkj a sdkfjah sdfkjas dfl", ID_SENDER = 10, C_DATE = DateTime.Now });
            list.Add(new ImMessage() { MSG_BODY = "Nejaky text kter7 nemus9 b7t sfsadfkj a sdkfjah sdfkjas dfl", C_DATE = DateTime.Now });
            list.Add(new ImMessage() { MSG_BODY = "Nejaky text kter7 nemus9 b7t sfsadfkj a sdkfjah sdfkjas dfl", ID_SENDER = 10, C_DATE = DateTime.Now });
            chatWithUser = new ImUser() { USR_NICK = "Karel" };

            InsertNewMessages(list);
        }

        private void InsertNewMessages(IEnumerable<ImMessage> listMessages)
        {
            foreach (var imm in listMessages)
            {
                pConversation.Inlines.Add(new TextBlock() 
                { 
                    Text = ((imm.ID_SENDER != 0) ? chatWithUser.USR_NICK + ": " : "Já: ") + string.Format("({0} {1})", imm.C_DATE.ToShortDateString(), imm.C_DATE.ToShortTimeString()), 
                    Foreground = (imm.ID_SENDER != 0) ? Brushes.Blue : Brushes.Red, 
                    FontWeight = FontWeights.Bold 
                });

                pConversation.Inlines.Add(new LineBreak());
                pConversation.Inlines.Add(new Run(imm.MSG_BODY));
                pConversation.Inlines.Add(new LineBreak());
            }

            fdsvConversation.FindScrollViewer().ScrollToBottom();
        }

        private void WindowTemplate_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            fdsvConversation.Zoom += 10;
        }
    }
}
