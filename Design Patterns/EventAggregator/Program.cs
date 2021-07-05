using EventAggregator.Publishers;
using EventAggregator.Subscribers;
using System;

namespace EventAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventAggregator = new EventAggregator();
            var subscriber = new SubscriberAlpha(eventAggregator);
            var publisher = new PublisherAlpha(eventAggregator);

            publisher.PublishMessage("John says hello");
            Console.ReadLine();
        }
    }
}
