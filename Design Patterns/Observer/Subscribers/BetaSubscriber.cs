using Observer.NewsPublisher;
using System;

namespace Observer.Subscribers
{
    public class BetaSubscriber : SubscriberBase
    {
        public int Id { get; set; }
        public BetaSubscriber(int id, INewsPublisher publisher):base(publisher)
        {
            Id = id;
        }
        public override void Update(string message)
        {
            Console.WriteLine($"{nameof(BetaSubscriber)}-{Id} has recieved the message {message}");
        }
    }
}
