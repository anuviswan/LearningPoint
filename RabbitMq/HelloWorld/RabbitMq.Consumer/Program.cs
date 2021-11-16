// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Starting Hello World Consumer...");

var factory = new ConnectionFactory
{
    HostName = "my-rabbit-host"
};

using (var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "Asgard",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Recieved message from Earth : {message}");
        };

        channel.BasicConsume("Asgard",true,consumer);
    }
}

Console.WriteLine("Press [enter] to exit");
Console.ReadLine();
