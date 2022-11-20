namespace Saga.Shared.Contracts;

public class OrderRejected
{
    public required Guid OrderId { get; set; }

    public required string Reason { get; set; }
}