using MassTransit.MediatR.Contracts;

namespace MassTransit.Mediator.Services.Consumers;

public class OrderSubmitHandler : IConsumer<OrderSubmitCommand>
{
    public async Task Consume(ConsumeContext<OrderSubmitCommand> context)
    {
        var request = context.Message;

        await context.RespondAsync(new OrderSubmitResponse
        {
            OrderId = request.Id,
            TimeStamp = DateTime.UtcNow,
            Message = request.CustomerId.Equals(Guid.Empty) ? "Invalid User" : "Order Submission Successful;",
            IsSuccess = !request.CustomerId.Equals(Guid.Empty)
        });
    }
}
