using Saga.Services.OrderService.Entities;
using System.Text.Json.Serialization;

namespace Saga.Services.OrderService.Models;

public class GetOrderByIdResponse
{
    public Guid OrderdId { get; set; }
    public Guid CustomerId { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrderState State { get; set; }
}
