using Saga.Services.PaymentService.Entities;
using System.Text.Json.Serialization;

namespace Saga.Services.PaymentService.Models;

public record GetAllPaymentResponse
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }

    public Guid CustomerId { get; init; }

    public decimal Amount { get; init; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PaymentState State { get; set; }
}
