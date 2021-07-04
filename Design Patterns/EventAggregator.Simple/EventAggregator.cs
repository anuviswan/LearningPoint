using EventAggregator.Simple.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventAggregator.Simple
{
    public class EventAggregator
    { 
        private Dictionary<Type,List<WeakReference>> SubscriberCollection = new Dictionary<Type, List<WeakReference>>();

        public void Publish(MessageBase messageBase)
        {

        }

        public int SubscriptionCount<TMessageType>()
        {
            if (SubscriberCollection.ContainsKey(typeof(TMessageType)))
            {
                return SubscriberCollection[typeof(TMessageType)].Count;
            }
            return -1;
        }


        public void Subscribe<TSubscriber, TMessage>(TSubscriber subscriber,Action<TMessage> action) where TMessage : MessageBase
        {
            var messageType = typeof(TMessage);

            if (SubscriberCollection.ContainsKey(messageType))
            {
                var currentList = SubscriberCollection[messageType];
                if(!currentList.Any(x=> (x.Target as Subscriber<TMessage>).Instance == (object)subscriber))
                {
                    SubscriberCollection[typeof(TMessage)].Add(new WeakReference(new Subscriber<TMessage>(subscriber, action)));
                }
            }
           
        }

        private class Subscriber<TMessage> where TMessage : MessageBase
        {
            public Action<TMessage> Action { get; set; }
            public object Instance { get; set; }

            public Subscriber(object subscriberInstance, Action<TMessage> action) => (Instance, Action) = (subscriberInstance, action);
        }

    }

}
