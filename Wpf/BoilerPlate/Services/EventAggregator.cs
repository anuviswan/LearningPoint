using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BoilerPlate.Services
{
    public class EventAggregator : IEventAggregator
    {
        private readonly List<Handler> _handlers = new List<Handler>();
        public void PublishMessage(object message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var handlersToNotify = new List<Handler>();
            lock (_handlers)
            {
                handlersToNotify = _handlers.ToList();
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

                _handlers.Add(new Handler(subscriber));
            }
        }

        public void Unsubscribe(object subscriber)
        {
            lock (_handlers)
            {
                var found = _handlers.FirstOrDefault(x => x == subscriber);
                if (found != null)
                {
                    _handlers.Remove(found);
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
                                           .Where(x => x.GetTypeInfo().IsGenericType && x.GetGenericTypeDefinition() == typeof(IHandle<>));

                foreach (var @interface in interfaces)
                {
                    var genericTypeArg = @interface.GetTypeInfo().GenericTypeArguments[0];
                    var method = @interface.GetRuntimeMethod("HandleAsync", new[] { genericTypeArg });

                    _handlers.Add(genericTypeArg, method);
                }

            }

            public void Handle(Type messageType, object message)
            {
                if (!_handlers.ContainsKey(messageType))
                    return;

                var method = _handlers[messageType];
                method.Invoke(_subscriber, new[] { message });
            }
        }
    }
}
