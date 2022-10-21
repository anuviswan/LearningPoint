namespace MassTransit.MediatR.Contracts;

public interface IOrderSubmit
{
    Guid Id { get; set; }
    Guid CustomerId { get; set; }

    DateTime TimeStamp { get; set; }
}