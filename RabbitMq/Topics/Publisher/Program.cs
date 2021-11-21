

using RabbitMQ.Client;
using System.Text;

if (args.Count() != 2) return;


var routingKey = args[0];
var message = args[1];
Console.WriteLine($"Starting Topic Logger for {args.First()}");

var factory = new ConnectionFactory()
{
    HostName = "localhost",
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare("TopicLogs", ExchangeType.Topic);

var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish("TopicLogs",routingKey,null,body);

Console.WriteLine($"Sending message `{message}` with RoutingKey `{routingKey}` ");
