using EventAggregator.Messages;
using System.Threading.Tasks;

namespace EventAggregator
{
    public interface IHandleAsync<T> where T : EventMessageBase
    {
        Task HandleAsync(T message);
    }
}
