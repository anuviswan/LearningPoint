using System;

namespace EventAggregator.Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventAggregator = new EventAggregator();
            var subscriber = new SubscriberAlpha();

            //eventAggregator.Subscribe(subscriber, subscriber.Invoke());
        }
    }
}
