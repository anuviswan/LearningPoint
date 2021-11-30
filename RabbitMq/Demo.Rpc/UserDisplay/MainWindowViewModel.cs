using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using UserDisplay.Commands;

namespace UserDisplay
{
    internal class MainWindowViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<string> _resultCollection = new ObservableCollection<string>();
        private IConnection _connection;
        private string _replyQueueName;
        private IBasicProperties _basicProperties;
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
            _replyQueueName = _channel.QueueDeclare().QueueName;

            var consumer = new EventingBasicConsumer(_channel);
            _basicProperties = _channel.CreateBasicProperties();
            _basicProperties.ReplyTo = _replyQueueName;
            _basicProperties.CorrelationId = Guid.NewGuid().ToString();

            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                

                UpdateLogOnUIThread(message);
            };

            _channel.BasicConsume(queue: _replyQueueName, consumer: consumer, autoAck: true);
        }

        private void UpdateLogOnUIThread(string message)
        {
            Application.Current.Dispatcher.Invoke(() => _resultCollection.Add(message));
        }

        public void ExecuteFetchCommand()
        {
            var messageToSend = Encoding.UTF8.GetBytes(Count.ToString());
            _channel.BasicPublish(exchange: "", routingKey: "RpcQueue", basicProperties: _basicProperties, body: messageToSend);
            var result = _resultCollection.First();
            var userList = JsonSerializer.Deserialize<IEnumerable<string>>(result);

            

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
