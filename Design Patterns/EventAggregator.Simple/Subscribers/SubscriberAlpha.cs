using EventAggregator.Simple.Messages;
using System;

namespace EventAggregator.Simple.Subscribers
{
    public interface ISubscriberAlpha
    {
        void Invoke(UserLoggedInMessage message);
        void Invoke(UserLoggedOutMessage message);
    }
    public class SubscriberAlpha:ISubscriberAlpha
    {
        public void Invoke(UserLoggedInMessage message)
        {
            Console.WriteLine($"Recieved Message in {nameof(SubscriberAlpha)}");
        }

        public void Invoke(UserLoggedOutMessage message)
        {
            Console.WriteLine($"Recieved Message in {nameof(SubscriberAlpha)}");
        }
    }
}
