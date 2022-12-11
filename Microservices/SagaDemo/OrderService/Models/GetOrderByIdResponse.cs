using Saga.Services.OrderService.Entities;

namespace Saga.Services.OrderService.Models;

public class GetOrderByIdResponse
{
    public Guid OrderdId { get; set; }
    public Guid CustomerId { get; set; }
    public OrderState State { get; set; }
}
