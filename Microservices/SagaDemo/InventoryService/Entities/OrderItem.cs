namespace Saga.Services.InventoryService.Entities;

public class OrderItem
{
    public Guid Id { get; set; }
    public required Guid OrderId {get;set;}

    public required Guid ItemId { get;set;}

    public required int Quantity { get; set; }

    public required OrderItemState State { get; set; }
}


public enum OrderItemState
{
    Pending,
    Accepted,
    Rejected
}
