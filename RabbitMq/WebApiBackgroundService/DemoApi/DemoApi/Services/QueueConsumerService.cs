using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace DemoApi.Services;
public class QueueConsumerService:BackgroundService
{
    private const string CommandQueueName = "UserCommandQueue";
    private IConnection _connection;
    private IModel _channel;
    public QueueConsumerService()
    {
        InitializeQueue();
    }

    private void InitializeQueue()
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(queue: CommandQueueName, true,false,false,null);

    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);
        
        consumer.Received += (s, a) =>
        {
            var replyQueueName = a.BasicProperties.ReplyTo;

            var messageFromClient = Encoding.UTF8.GetString(a.Body.ToArray());

            var message = $"Mock Reply from the Background Service : Reply for '{messageFromClient}'";
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange:"",routingKey:replyQueueName,null,body);
        };

        _channel.BasicConsume(CommandQueueName, true, consumer);
        return Task.CompletedTask;
    }
}
