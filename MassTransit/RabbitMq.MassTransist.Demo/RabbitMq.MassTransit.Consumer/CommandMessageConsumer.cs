using MassTransit;
using RabbitMq.MassTransit.Shared;
using System.Text.Json;

namespace RabbitMq.MassTransit.Consumer
{
    public class CommandMessageConsumer : IConsumer<CommandMessage>
    {
        public Task Consume(ConsumeContext<CommandMessage> context)
        {
            var message = context.Message;
            // do something useful
            return Task.CompletedTask;
        }
    }
}
