using EventAggregator.Messages;
using System;
using System.Threading.Tasks;

namespace EventAggregator.Subscribers
{
    public class SubscriberAlpha:IHandleAsync<UserSaysHelloMessage>
    {
        public SubscriberAlpha(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
        }

        public Task HandleAsync(UserSaysHelloMessage message)
        {
            Console.WriteLine($"Message : {message.Message}");
            return Task.CompletedTask;
        }

    }
}
