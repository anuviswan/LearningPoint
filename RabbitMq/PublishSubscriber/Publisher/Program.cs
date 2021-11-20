using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Starting Publisher....");

var factory = new ConnectionFactory
{
    HostName = "localhost",
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare("logs", ExchangeType.Fanout);

if (args.Length == 0)
{
    Console.WriteLine("No message found");
};

var message = args.First();

Console.WriteLine($"Processing message : {message}");

var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: "logs", routingKey: "", body: body);

Console.WriteLine($"Sending message : {message}");
