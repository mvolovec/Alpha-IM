using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MessagingDataDbLibrary
{
    public class MessDataContext : MessagingDbDataContext
    {
        public MessDataContext()
            : base(ConfigurationManager.ConnectionStrings["MessConnectionString"].ConnectionString)
        {
        }
    }
}
