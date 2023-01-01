using Saga.Shared.Contracts.Attributes;

namespace Saga.Shared.Contracts.Events;

[RabbitQueue("payment-failed")]
public record PaymentFailed : IBaseEvent<PaymentFailed>
{
    public required Guid OrderId { get; init; }

    public required string Reason { get; init; }
    public Guid EventId { get; init; }
}
