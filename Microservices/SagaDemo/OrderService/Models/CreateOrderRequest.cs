using Saga.Services.OrderService.Entities;

namespace Saga.Services.OrderService.Models;

public record CreateOrderRequest
{
    public Guid CustomerId { get; set; }
    public IReadOnlyList<OrderItem> Items { get; set; } = null!;
    
}

