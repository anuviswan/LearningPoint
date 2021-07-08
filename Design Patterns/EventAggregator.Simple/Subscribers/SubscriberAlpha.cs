using EventAggregator.Simple.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.Simple.Subscribers
{
    public interface ISubscriberAlpha
    {
        void Invoke(UserLoggedInMessage message);
    }
    public class SubscriberAlpha:ISubscriberAlpha
    {
        public void Invoke(UserLoggedInMessage message)
        {
            Console.WriteLine($"Recieved Message in {nameof(SubscriberAlpha)}");
        }
    }
}
