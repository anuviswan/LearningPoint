using Observer.Subscribers;
using System;

namespace Observer.NewsPublisher
{
    public interface INewsPublisher
    {
        WeakReference<SubscriberBase> Register(SubscriberBase subscriber);
        void Unregister(WeakReference<SubscriberBase> subscriber);
        void Publish(string message);
        void AddNews(string news);
    }
}
