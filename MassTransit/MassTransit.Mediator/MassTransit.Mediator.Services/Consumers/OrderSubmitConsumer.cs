using MassTransit.MediatR.Contracts;

namespace MassTransit.Mediator.Services.Consumers;

public class OrderSubmitConsumer : IConsumer<IOrderSubmit>
{
    public async Task Consume(ConsumeContext<IOrderSubmit> context)
    {
        await context.RespondAsync<IOrderSubmitAccepted>(new
        {
            OrderId = context.Message.Id,
            context.Message.CustomerId,
            TimeStamp = DateTime.UtcNow
        });
    }
}
