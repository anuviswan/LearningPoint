namespace Saga.Shared.Contracts.Events;

public record OrderCreationInitiated
{
    public Guid OrderId { get; set; }

    public Guid CustomerId { get; set; }
    public IReadOnlyList<OrderItemEntry> OrderItems { get; set; } = null!;
}


public record OrderItemEntry
{
    public Guid ItemId { get; set; }
    public int Qty { get; set; }
}
