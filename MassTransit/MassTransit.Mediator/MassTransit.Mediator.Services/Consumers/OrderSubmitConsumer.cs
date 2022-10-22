using MassTransit.MediatR.Contracts;

namespace MassTransit.Mediator.Services.Consumers;

public class OrderSubmitConsumer : IConsumer<IOrderSubmit>
{
    public async Task Consume(ConsumeContext<IOrderSubmit> context)
    {
        var request = context.Message;

        if (request.CustomerId.Equals(Guid.Empty))
        {
            await context.RespondAsync<IOrderSubmitRejected>(new 
            { 
                OrderId = request.Id,
                TimeStamp = DateTime.UtcNow,
                Reason = "Invalid User"
            });
            return;
        }
        await context.RespondAsync<IOrderSubmitAccepted>(new
        {
            OrderId = request.Id,
            request.CustomerId,
            TimeStamp = DateTime.UtcNow
        });
    }
}
