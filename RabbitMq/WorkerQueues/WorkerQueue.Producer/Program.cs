using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Starting Worker Queue Producer....");

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost",
};


using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue:"AsgardWorkerQueue", 
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

if (args.Any())
{
    var message = CreateMessage(Convert.ToInt32(args[0]));
    var body = Encoding.UTF8.GetBytes(message);

    var properties = channel.CreateBasicProperties();
    properties.Persistent = true;

    channel.BasicPublish("", "AsgardWorkerQueue", properties, body);
    Console.WriteLine($"Published message :{message} to Asgard.");
}

Console.WriteLine("Exiting Worker Queue Producer.");


string CreateMessage(int complexity)
{
    return $"Message from Thor {new string('.', complexity)}";
}