using Saga.Shared.Contracts.Attributes;

namespace Saga.Shared.Contracts.Events;

[RabbitQueue("order-creation-failed")]
public record OrderCreationFailed : IBaseEvent<OrderCreationFailed>
{
    public Guid EventId { get; init; }
    public Guid OrderId { get; init; }
    public string? Reason { get; init; }
}
