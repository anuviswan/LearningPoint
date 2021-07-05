using EventAggregator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator
{
    public interface IHandleAsync<T> where T : EventMessageBase
    {
        Task HandleAsync(T message);
    }
}
