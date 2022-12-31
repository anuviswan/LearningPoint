using Saga.Shared.Contracts.Attributes;

namespace Saga.Shared.Contracts.Events;

[RabbitQueue("order-creation-initiated")]
public record OrderCreationInitiated : IBaseEvent<OrderCreationInitiated>
{
    public Guid EventId { get; init; }
    public Guid OrderId { get; init; }

    public Guid CustomerId { get; init; }
    public IReadOnlyList<OrderItemEntry> OrderItems { get; init; } = null!;
}


public record OrderItemEntry
{
    public Guid ItemId { get; init; }
    public int Qty { get; init; }
}
