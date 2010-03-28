using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessClientAPI.MessServiceApi;

namespace WPF_IM_CLIENT
{
    public class NewMessagesReceivedEventArgs : EventArgs
    {
        private List<ImMessage> _newMessages;
        public List<ImMessage> NewMessages 
        {
            get { return _newMessages; }
            set { _newMessages = value; }
        }

        public NewMessagesReceivedEventArgs(List<ImMessage> Messages)
        {
            _newMessages = Messages;
        }
    }
}
