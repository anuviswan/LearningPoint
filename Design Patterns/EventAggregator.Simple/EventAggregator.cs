using EventAggregator.Simple.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventAggregator.Simple
{
    public class EventAggregator
    { 
        private Dictionary<Type,List<WeakReference<ISubscriber<MessageBase>>>> SubscriberCollection = new Dictionary<Type, List<WeakReference<ISubscriber<MessageBase>>>>();

        public void Publish(MessageBase messageBase)
        {
            var invocationList = SubscriberCollection[messageBase.GetType()];
            foreach(var reference in invocationList)
            {
                if(reference.TryGetTarget(out var subscriber))
                {
                    var handler = subscriber.GetHandler();
                    handler.Invoke(subscriber.GetSubscriber(), new[] { messageBase });
                }
            }
        }

        public int SubscriptionCount<TMessageType>()
        {
            if (SubscriberCollection.ContainsKey(typeof(TMessageType)))
            {
                return SubscriberCollection[typeof(TMessageType)].Count;
            }
            return -1;
        }


        public void Subscribe<TMessage>(object subscriber,Action<TMessage> action) where TMessage : MessageBase
        {
            var messageType = typeof(TMessage);

            if (!SubscriberCollection.ContainsKey(messageType))
                SubscriberCollection.Add(typeof(TMessage), new List<WeakReference<ISubscriber<MessageBase>>>());

            var currentList = SubscriberCollection[messageType];
            if (!currentList.Any(x => x.TryGetTarget(out var sub) && sub.GetSubscriber() == subscriber))
            {
                SubscriberCollection[typeof(TMessage)].Add(new WeakReference<ISubscriber<MessageBase>>(new Subscriber<TMessage>(subscriber, action)));
            }
        }

    }

}
