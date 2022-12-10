namespace Saga.Services.PaymentService.Models;

public record MakePaymentRequest
{
    public Guid OrderId { get; init; }
    public Guid CustomerId { get; init; }
}
