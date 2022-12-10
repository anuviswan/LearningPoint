namespace Saga.Services.PaymentService.Models;

public record ConfirmPaymentRequest
{
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
}
