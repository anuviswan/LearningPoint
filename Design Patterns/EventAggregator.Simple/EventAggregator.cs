using EventAggregator.Simple.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventAggregator.Simple
{
    public class EventAggregator : IEventAggregator
    {
        private Dictionary<Type, List<ISubscriber<MessageBase>>> SubscriberCollection = new Dictionary<Type, List<ISubscriber<MessageBase>>>();

        public void Publish(MessageBase messageBase)
        {
            var invocationList = SubscriberCollection[messageBase.GetType()];
            foreach (var subscriber in invocationList)
            {
                var handler = subscriber.GetHandler();
                handler?.Invoke(subscriber.GetSubscriber(), new[] { messageBase });
            }
        }

        public int SubscriptionCount<TMessageType>()
        {
            if (SubscriberCollection.ContainsKey(typeof(TMessageType)))
            {
                return SubscriberCollection[typeof(TMessageType)].Count;
            }
            return 0;
        }


        public void Subscribe<TMessage>(object subscriber, Expression<Action<TMessage>> action) where TMessage : MessageBase
        {
            var messageType = typeof(TMessage);

            if (!SubscriberCollection.ContainsKey(messageType))
                SubscriberCollection.Add(typeof(TMessage), new List<ISubscriber<MessageBase>>());

            var currentList = SubscriberCollection[messageType];

            if (currentList.Any(x => x.GetSubscriber() == subscriber))
            {
                return;
            }
            SubscriberCollection[typeof(TMessage)].Add(new Subscriber<TMessage>(subscriber, action.Compile()));
        }

        public void Unsubscribe<TMessage>(object subscriber) where TMessage : MessageBase
        {
            var messageType = typeof(TMessage);

            if (SubscriberCollection.ContainsKey(messageType))
            {
                var currentList = SubscriberCollection[messageType];
                SubscriberCollection[messageType] = currentList.Where(x => x.GetSubscriber() != subscriber).ToList();
            }
        }

        public void Unsubscribe(object subscriber)
        {
            foreach (var messageTypePair in SubscriberCollection)
            {
                if (messageTypePair.Value.Any(x => x.GetSubscriber() == subscriber))
                {
                    SubscriberCollection[messageTypePair.Key] = SubscriberCollection[messageTypePair.Key].Where(x => x.GetSubscriber() != subscriber).ToList();
                }
            }
        }

    }
}
