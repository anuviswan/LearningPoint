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
        }
        public abstract void Update(string message);

        public void Subscribe()
        {
            _weakReference= _newsPublisher.Register(this);
        }

        public void Unsubscribe()
        {
            _newsPublisher.Unregister(_weakReference);
        }
    }
}
