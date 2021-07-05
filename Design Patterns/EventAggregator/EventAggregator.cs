using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator
{
    public class EventAggregator : IEventAggregator
    {
        private readonly List<WeakReference<Handler>> _handlers = new List<WeakReference<Handler>>();
        public void PublishMessage(object message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var handlersToNotify = new List<Handler>();
            lock (_handlers)
            {

                foreach(var handler in _handlers)
                {
                    if(handler.TryGetTarget(out var target))
                    {
                        handlersToNotify.Add(target);
                    }
                }
            }

            foreach (var handler in handlersToNotify)
            {
                handler.Handle(message.GetType(), message);
            }

        }

        public void Subscribe(object subscriber)
        {
            lock (_handlers)
            {
                if (_handlers.Any(x => x == subscriber))
                {
                    return;
                }

                _handlers.Add(new WeakReference<Handler>(new Handler(subscriber)));
            }
        }

        public void Unsubscribe(object subscriber)
        {
            lock (_handlers)
            {
                WeakReference<Handler> toRemove = null;
                lock (_handlers)
                {

                    foreach (var handler in _handlers)
                    {
                        if (handler.TryGetTarget(out var target))
                        {
                            if (target.Subscriber == subscriber)
                                toRemove = handler;
                        }
                    }

                    if(toRemove != null)
                    {
                        _handlers.Remove(toRemove);
                    }
                }
            }
        }

        private class Handler
        {
            private readonly object _subscriber;
            private Dictionary<Type, MethodInfo> _handlers = new Dictionary<Type, MethodInfo>();
            public Handler(object subscriber)
            {
                _subscriber = subscriber;

                var interfaces = _subscriber.GetType()
                                           .GetTypeInfo()
                                           .ImplementedInterfaces
                                           .Where(x => x.GetTypeInfo().IsGenericType && x.GetGenericTypeDefinition() == typeof(IHandleAsync<>));

                foreach (var @interface in interfaces)
                {
                    var genericTypeArg = @interface.GetTypeInfo().GenericTypeArguments[0];
                    var method = @interface.GetRuntimeMethod("HandleAsync", new[] { genericTypeArg });

                    _handlers.Add(genericTypeArg, method);
                }

            }

            public object Subscriber => _subscriber;
            public void Handle(Type messageType, object message)
            {
                if (!_handlers.ContainsKey(messageType))
                {
                    throw new Exception($"Message type {message} not registered");
                }

                var method = _handlers[messageType];
                method.Invoke(_subscriber, new[] { message });
            }
        }
    }
}
