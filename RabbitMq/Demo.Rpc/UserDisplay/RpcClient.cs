using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDisplay
{
    internal class RpcClient
    {
        private IConnection _connection;
        private IModel _channel;
        private string _responseQueueName;
        private string QueueName = "UserRpcQueue";
        private ConcurrentDictionary<string,TaskCompletionSource<string>> _activeTaskQueue = new ConcurrentDictionary<string, TaskCompletionSource<string>>();

        public void Initialiaze()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _responseQueueName = _channel.QueueDeclare().QueueName;

            var consumer = new EventingBasicConsumer(_channel);
            
            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

//                 UpdateLogOnUIThread(message);
            };
            _channel.BasicConsume(queue: _responseQueueName, consumer: consumer, autoAck: true);
        }


        public async Task SendAsync(string message)
        {
            var basicProperties = _channel.CreateBasicProperties();
            basicProperties.ReplyTo = _responseQueueName;
            var messageId = Guid.NewGuid().ToString();
            basicProperties.CorrelationId = messageId;

            var messageToSend = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "", routingKey: "UserRpcQueue", basicProperties: basicProperties, body: messageToSend);
        }
    }
}
