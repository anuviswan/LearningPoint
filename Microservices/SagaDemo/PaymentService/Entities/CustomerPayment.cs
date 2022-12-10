using MassTransit;

namespace Saga.Services.PaymentService.Entities;

public class CustomerPayment
{
    public required Guid Id { get; init; }
    public required Guid OrderId { get; init; }

    public required Guid CustomerId { get; init; }

    public decimal Amount { get; init; }

    public PaymentState State { get; set; }
}


public enum PaymentState
{
    Pending,
    Accepted,
    Rejected,
    Failed
}
