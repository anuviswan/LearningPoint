using Observer.NewsPublisher;
using System;

namespace Observer.Subscribers
{
    public class AlphaSubscriber : SubscriberBase
    {
        public Guid Id { get; set; }
        public AlphaSubscriber(Guid id, INewsPublisher publisher):base(publisher)
        {
            Id = id;
        }
        public override void Update(string message)
        {
            Console.WriteLine($"{nameof(AlphaSubscriber)}-{Id} has recieved the message {message}");
        }
    }
}
