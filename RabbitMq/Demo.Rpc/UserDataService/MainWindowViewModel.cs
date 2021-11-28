using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UserDataService
{
    internal class MainWindowViewModel
    {
        private IConnection _connection;
        private IModel _channel;
        public MainWindowViewModel()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "RpcQueue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            _channel.BasicQos(0, 1, false);

            var consumer = new EventingBasicConsumer(_channel);

            _channel.BasicConsume(queue: "RpcQueue", autoAck: false, consumer: consumer);

            consumer.Received += Consumer_Received;

        }

        private void Consumer_Received(object? sender, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var replyProps = _channel.CreateBasicProperties();
            replyProps.CorrelationId = ea.BasicProperties.CorrelationId;
            replyProps.ReplyTo = ea.BasicProperties.ReplyTo;


            var value = int.Parse(message);

            var userNames = GenerateUserNames(value);
            var response = JsonSerializer.Serialize<IEnumerable<string>>(userNames);

            var responseBody = Encoding.UTF8.GetBytes(response);

            _channel.BasicPublish(exchange: "",
                                routingKey: replyProps.ReplyTo,
                                basicProperties: replyProps,
                                body: responseBody);
            _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        }

        public IEnumerable<string> GenerateUserNames(int count)
        {
            return Enumerable.Range(1, count).Select(x=>$"UserName {x}");
        }
    }
}
