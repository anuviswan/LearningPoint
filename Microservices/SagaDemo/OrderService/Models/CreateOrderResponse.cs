using Saga.Services.OrderService.Entities;
using System.Text.Json.Serialization;

namespace Saga.Services.OrderService.Models;

public class CreateOrderResponse
{
    public Guid OrderId { get; init; }
    public Guid CustomerId { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrderState State { get; set; }
}
