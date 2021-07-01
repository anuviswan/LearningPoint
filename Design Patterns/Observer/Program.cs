using Observer.NewsPublisher;
using Observer.Subscribers;
using System;
using System.Linq;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var publisher = new NewsPublisherConcrete();

            var alphaSubscribers = Enumerable.Range(1,5).Select(x => new AlphaSubscriber(Guid.NewGuid(),publisher)).ToList();
            var betaSubscribers = Enumerable.Range(1,3).Select(x => new BetaSubscriber(x,publisher)).ToList();

            alphaSubscribers.ForEach(x => x.Subscribe());
            betaSubscribers.ForEach(x => x.Subscribe());

            Console.WriteLine("Adding message to News");
            publisher.AddNews("Hello World");

            alphaSubscribers.ForEach(x => x.Unsubscribe());
            betaSubscribers.First(x => x.Id == 2).Unsubscribe();
            Console.WriteLine("Adding another message to News");
            publisher.AddNews("Another Hello World");
            Console.ReadLine();
        }
    }
}
