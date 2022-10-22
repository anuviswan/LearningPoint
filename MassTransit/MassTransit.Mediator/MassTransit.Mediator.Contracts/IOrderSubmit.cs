namespace MassTransit.MediatR.Contracts;

public interface IOrderSubmit
{
    Guid Id { get; set; }
    Guid CustomerId { get; set; }

    DateTime TimeStamp { get; set; }
}

public interface IOrderSubmitAccepted
{
    Guid OrderId { get; set; }
    Guid CustomerId { get; set; }

    DateTime TimeStamp { get; set; }
}