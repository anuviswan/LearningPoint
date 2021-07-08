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
        private object Instance { get; set; }

        public Subscriber(object subscriberInstance, Action<TMessage> handler) => (Instance, Handler) = (subscriberInstance, handler);

        public object GetSubscriber() => Instance;

        public MethodInfo GetHandler()
        {
            return Handler.GetMethodInfo();
        }

    }
}
