using Saga.Shared.Contracts.Attributes;
using System.Reflection;

namespace Saga.Shared.Contracts.Events;

public interface IBaseEvent<TDerieved> where TDerieved : IBaseEvent<TDerieved>
{
    public Guid EventId { get; init; }
    public static string QueueName => typeof(TDerieved).GetCustomAttribute<RabbitQueueAttribute>()?.Name ?? string.Empty;
}
