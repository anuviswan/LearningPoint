using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Starting Hello World Producer...");
var factory = new ConnectionFactory
{
    HostName = "my-rabbit-host"
};

using(var connection = factory.CreateConnection())
{
    using(var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "Asgard",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var message = "Hello World !!";
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: String.Empty,
            routingKey: "hello",
            basicProperties: null,
            body: body);

        Console.WriteLine($"Message :'{message}' Send....");
    }
}

Console.WriteLine("Press [enter] to exit");
Console.ReadLine();
