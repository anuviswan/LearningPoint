using EventAggregator.Simple.Messages;
using System;
using System.Reflection;

namespace EventAggregator.Simple
{
    public interface ISubscriber<out TMessage> where TMessage : MessageBase
    {
        MethodInfo GetHandler();
        object GetSubscriber();
    }
    public class Subscriber<TMessage>: ISubscriber<TMessage> where TMessage : MessageBase
    {
        private Action<TMessage> Handler { get; set; }
        private WeakReference<object> Instance { get; set; }

        public Subscriber(object subscriberInstance, Action<TMessage> handler)
        {
            (Instance, Handler) = (new WeakReference<object>(subscriberInstance), handler);
        }

        public object GetSubscriber()
        {
            if(Instance.TryGetTarget(out var target))
            {
                return target;
            }
            return null;
        }

        public MethodInfo GetHandler()
        {
            return Handler.GetMethodInfo();
        }

    }
}
