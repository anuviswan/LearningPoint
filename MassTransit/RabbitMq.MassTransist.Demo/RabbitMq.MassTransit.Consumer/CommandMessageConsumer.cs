using MassTransit;
using RabbitMq.MassTransit.Shared;
using System.Text.Json;

namespace RabbitMq.MassTransit.Consumer
{
    public class CommandMessageConsumer : IConsumer<CommandMessage>
    {
        public async Task Consume(ConsumeContext<CommandMessage> context)
        {
            var message = context.Message;
            await Console.Out.WriteLineAsync($"Message from Producer : {message.MessageString}");
        }
    }
}
