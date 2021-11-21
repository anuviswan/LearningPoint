
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

if (!args.Any()) return;

Console.WriteLine($"Starting subscriber for {string.Join(",",args)}");

var factory = new ConnectionFactory
{
    HostName = "localhost",
};


using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare("filteredLogs", ExchangeType.Direct);

var queueName = channel.QueueDeclare().QueueName;

foreach(var severity in args)
{
    channel.QueueBind(queueName, "filteredLogs", severity);
}

Console.WriteLine("Waiting for message");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (s, a) =>
{
    var body = a.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Recived message {message}");
};

channel.BasicConsume(queue:queueName,autoAck:true, consumer: consumer);

Console.ReadLine();