using Observer.NewsPublisher;
using System;

namespace Observer.Subscribers
{
    public abstract class SubscriberBase
    {
        protected readonly INewsPublisher _newsPublisher;
        protected WeakReference<SubscriberBase> _weakReference;
        public SubscriberBase(INewsPublisher publisher)
        {
            _newsPublisher = publisher;
            Subscribe();
        }
        public abstract void Update(string message);

        protected void Subscribe()
        {
            _newsPublisher.Register(this);
        }

        protected void Unsubscribe()
        {
            _newsPublisher.Unregister(_weakReference);
        }
    }
}
