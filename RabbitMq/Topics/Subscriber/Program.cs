
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

if (!args.Any()) return;

Console.WriteLine($"Starting logger for {string.Join(",",args)}");

var factory = new ConnectionFactory()
{
    HostName = "localhost",
};


using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare("TopicLogs", ExchangeType.Topic);

var queueName = channel.QueueDeclare().QueueName;

foreach(var key in args)
{
    channel.QueueBind(queueName, "TopicLogs", key);
}

Console.WriteLine("Waiting for message");

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) =>
{
    var body = args.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var routingKey = args.RoutingKey;

    Console.WriteLine($"Recieved Message : '{message}' with key '{routingKey}");
};

channel.BasicConsume(queueName,true,consumer);
Console.ReadLine();