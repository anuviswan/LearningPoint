namespace Saga.Shared.Contracts.Events;

public record OrderCreationInitiated
{
    public Guid OrderId { get; init; }

    public Guid CustomerId { get; init; }
    public IReadOnlyList<OrderItemEntry> OrderItems { get; init; } = null!;
}


public record OrderItemEntry
{
    public Guid ItemId { get; init; }
    public int Qty { get; init; }
}
