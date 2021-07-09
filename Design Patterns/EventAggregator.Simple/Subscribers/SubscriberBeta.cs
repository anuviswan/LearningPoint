using EventAggregator.Simple.Messages;
using System;

namespace EventAggregator.Simple.Subscribers
{
    public interface ISubscriberBeta
    {
        void InvokeBetaHandler(UserLoggedInMessage message);
        void InvokeBetaHandler(UserLoggedOutMessage message);
    }
    public class SubscriberBeta:ISubscriberBeta
    {
        public void InvokeBetaHandler(UserLoggedInMessage message)
        {
            Console.WriteLine($"Recieved Message in {nameof(SubscriberBeta)}");
        }
        public void InvokeBetaHandler(UserLoggedOutMessage message)
        {
            Console.WriteLine($"Recieved Message in {nameof(SubscriberBeta)}");
        }
    }
}
