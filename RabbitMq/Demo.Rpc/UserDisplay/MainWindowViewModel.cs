using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Windows.Input;
using UserDisplay.Commands;

namespace UserDisplay
{
    internal class MainWindowViewModel:INotifyPropertyChanged
    {
        private BlockingCollection<IEnumerable<string>> _resultCollection = new BlockingCollection<IEnumerable<string>>();
        private IConnection _connection;
        private IModel _channel;
        public IEnumerable<string> UserNames { get; set; }
        public int Count { get; set; } = 15;

        public ICommand FetchCommand { get; set; }

        public MainWindowViewModel()
        {
            FetchCommand = new DelegateCommand((_) => ExecuteFetchCommand());
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }


        public void ExecuteFetchCommand()
        {
            var replyQueueName = _channel.QueueDeclare().QueueName;
            var consumer = new EventingBasicConsumer(_channel);
            var props = _channel.CreateBasicProperties();
            props.ReplyTo = replyQueueName;
            props.CorrelationId = Guid.NewGuid().ToString();

            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var userList = JsonSerializer.Deserialize<IEnumerable<string>>(message);

                _resultCollection.Add(userList);
            };

            _channel.BasicConsume(queue: replyQueueName, consumer: consumer, autoAck: true);

            var messageToSend = Encoding.UTF8.GetBytes(Count.ToString());
            _channel.BasicPublish(exchange: "", routingKey: "RpcQueue", basicProperties: props, body: messageToSend);
            var result = _resultCollection.Take();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
