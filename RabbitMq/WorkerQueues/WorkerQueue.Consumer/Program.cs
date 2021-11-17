using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Starting Worker Queue Consumer.....");

var factory = new ConnectionFactory()
{
    HostName = "localhost",
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "AsgardWorkerQueue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += async (sender, args) =>
{
    Console.WriteLine("Reciding message from Asgard....");

    var body = args.Body;
    var message = Encoding.UTF8.GetString(body.ToArray());

    var delayTime = message.Where(x => x == '.').Count();
  
    Console.WriteLine("Executing task...");
    await Task.Delay(delayTime*1000);
    Console.WriteLine($"Task Completed, Message {message}");
};

channel.BasicConsume("AsgardWorkerQueue", true, consumer);
Console.ReadLine();

