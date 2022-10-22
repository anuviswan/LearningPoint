using MassTransit.Mediator;

namespace MassTransit.MediatR.Contracts;

public class OrderSubmitCommand : Request<OrderSubmitResponse>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime TimeStamp { get; set; }
}

public class OrderSubmitResponse:IResponseBase
{
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
}

public interface IResponseBase
{
    string Message { get; set; }
    bool IsSuccess { get; set; }
}
