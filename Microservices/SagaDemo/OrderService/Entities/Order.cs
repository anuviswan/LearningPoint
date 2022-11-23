namespace Saga.Services.OrderService.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public IEnumerable<Guid> OrderItems { get; set; } = Enumerable.Empty<Guid>();
    public OrderState State { get; set; }

}

public enum OrderState
{
    Pending,
    Accepted,
    Rejected,
    Completed
}