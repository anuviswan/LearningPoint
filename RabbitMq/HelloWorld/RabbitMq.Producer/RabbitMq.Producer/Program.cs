using RabbitMQ.Client;

Console.WriteLine("Starting Hello World Producer...");
var factory = new ConnectionFactory
{
    HostName = "my-rabbit-host"
};

using(var connection = factory.CreateConnection())
{
    using(var channel = connection.CreateModel())
    {

    }
}
