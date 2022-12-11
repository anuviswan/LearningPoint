using Saga.Services.OrderService.Entities;

namespace Saga.Services.OrderService.Models;

public class CreateOrderResponse
{
    public Guid OrderId { get; init; }
    public Guid CustomerId { get; init; }
    public OrderState State { get; set; }
}
