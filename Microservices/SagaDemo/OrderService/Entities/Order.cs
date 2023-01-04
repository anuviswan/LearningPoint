namespace Saga.Services.OrderService.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public IReadOnlyList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public OrderState State { get; set; }

}

public class OrderItem
{
    public Guid OrderItemId { get; set; }
    public int Quantity { get; set; }
}

public enum OrderState
{
    Initiated,
    Pending,
    Confirmed,
    Rejected,
    Failed,
    Completed
}