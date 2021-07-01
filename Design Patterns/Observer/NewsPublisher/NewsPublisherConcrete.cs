using Observer.Subscribers;
using System;
using System.Collections.Generic;

namespace Observer.NewsPublisher
{
    public class NewsPublisherConcrete : INewsPublisher
    {
        public List<WeakReference<SubscriberBase>> _SubscribersCollection = new List<WeakReference<SubscriberBase>>();
        public void AddNews(string news)
        {
            Publish(news);
        }

        public void Publish(string message)
        {
            foreach(var weakReference in _SubscribersCollection)
            {
                if(weakReference.TryGetTarget(out var subscriber))
                {
                    subscriber.Update(message);
                }
                else
                {
                    _SubscribersCollection.Remove(weakReference);
                }
            }
        }

        public WeakReference<SubscriberBase> Register(SubscriberBase subscriber)
        {
            var weakReference = new WeakReference<SubscriberBase>(subscriber);
            _SubscribersCollection.Add(weakReference);
            return weakReference;
        }

        public void Unregister(WeakReference<SubscriberBase> subscriber)
        {
            _SubscribersCollection.Remove(subscriber);
        }
    }
}
