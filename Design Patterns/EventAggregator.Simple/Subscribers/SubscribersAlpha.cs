using EventAggregator.Simple.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.Simple.Subscribers
{
    public class SubscribersAlpha
    {
        public void Invoke(UserLoggedInMessage message)
        {
            Console.WriteLine("Recieved Message");
        }
    }
}
