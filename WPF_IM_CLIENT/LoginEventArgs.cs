using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessClientAPI.MessServiceApi;

namespace WPF_IM_CLIENT
{
    public class LoginEventArgs : EventArgs
    {
        public int id_user { get; set; }
        public string password { get; set; }
        public ImUser imUser { get; set; }
    }
}
