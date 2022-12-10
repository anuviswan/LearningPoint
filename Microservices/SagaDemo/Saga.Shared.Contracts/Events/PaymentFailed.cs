namespace Saga.Shared.Contracts.Events;

public record PaymentFailed
{
    public required Guid OrderId { get; init; }

    public required string Reason { get; init; }
}
