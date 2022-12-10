namespace Saga.Shared.Contracts.Events;

public record OrderCreationFailed
{
    public Guid OrderId { get; init; }
    public string? Reason { get; init; }

}
