namespace Saga.Services.PaymentService.Models;

public record CancelPaymentRequest
{
    public required Guid OrderId { get; init; }
}
