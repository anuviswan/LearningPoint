using EventAggregator.Simple.Messages;
using System;

namespace EventAggregator.Simple
{
    public interface IEventAggregator
    {
        void Publish(MessageBase messageBase);
        void Subscribe<TMessage>(object subscriber, Expression<Action<TMessage>> action) where TMessage : MessageBase;
        int SubscriptionCount<TMessageType>();
        void Unsubscribe(object subscriber);
        void Unsubscribe<TMessage>(object subscriber) where TMessage : MessageBase;
    }
}