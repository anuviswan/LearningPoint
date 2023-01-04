using Saga.Shared.Contracts.Attributes;

namespace Saga.Shared.Contracts.Events;

[RabbitQueue("order-creation-succeeded")]
public record OrderCreationSucceeded : IBaseEvent<OrderCreationSucceeded>
{
    public Guid EventId { get; init; }
    public Guid OrderId { get; init; }
}
