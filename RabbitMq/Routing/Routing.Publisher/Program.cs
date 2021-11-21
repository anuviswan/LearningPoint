using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Starting Routing Publisher....");
if (!args.Any()) return;

var factory = new ConnectionFactory
{
    HostName = "localhost",
};


using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare("filteredLogs", ExchangeType.Direct);

var severity = args[0];
var message = args[1];

var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: "filteredLogs",routingKey:severity,body:body);
Console.WriteLine($"Sending Message `{message}` with severity `{severity}` to the exchange");


