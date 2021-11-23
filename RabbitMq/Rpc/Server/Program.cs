using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Starting Server....");

var factory = new ConnectionFactory
{
    HostName = "localhost",
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "RpcQueue",
    durable:false,
    exclusive: false, 
    autoDelete: false, 
    arguments: null);
channel.BasicQos(0,1,false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (s, ea) =>
{
    string response = default;

    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    var replyProps = channel.CreateBasicProperties();
    replyProps.CorrelationId = ea.BasicProperties.CorrelationId;

    try
    {
        var value = int.Parse(message);
        Console.WriteLine($"Generating Fib Value for {value}");

        response = fib(value).ToString();
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error : {e.Message}");
        response = String.Empty;
    }
    finally
    {
        var responseBody = Encoding.UTF8.GetBytes(response);
        Console.WriteLine($"Sending response to client : {response}");
        channel.BasicPublish(exchange: "", 
                            routingKey: replyProps.ReplyTo, 
                            basicProperties: replyProps, 
                            body: responseBody);
        Console.WriteLine("Sending acknowledgement");
        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
    }
};

channel.BasicConsume(queue:"RpcQueue",autoAck:false,consumer:consumer);

Console.ReadLine();


int fib(int n)
{
    if (n == 0 || n == 1)
    {
        return n;
    }

    return fib(n - 1) + fib(n - 2);
}