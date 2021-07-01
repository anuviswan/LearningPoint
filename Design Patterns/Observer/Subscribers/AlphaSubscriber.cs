using Observer.NewsPublisher;
using System;

namespace Observer.Subscribers
{
    public class AlphaSubscriber : SubscriberBase
    {
        public AlphaSubscriber(INewsPublisher publisher):base(publisher)
        {
        }
        public override void Update(string message)
        {
            Console.WriteLine(message);
        }
    }
}
