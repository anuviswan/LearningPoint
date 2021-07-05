using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.Simple.Messages
{
    public class UserLoggedInMessage:MessageBase
    {
        public UserLoggedInMessage(string userName,object sender):base(sender)
        {
            UserName = userName;
        }
        public string UserName { get; set; }
    }
}
