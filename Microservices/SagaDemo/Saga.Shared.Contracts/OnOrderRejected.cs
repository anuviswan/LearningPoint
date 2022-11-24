namespace Saga.Shared.Contracts;

public class OnOrderRejected
{
    public required Guid OrderId { get; set; }

    public required string Reason { get; set; }
}