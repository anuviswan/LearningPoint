using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;
using System.Text;

Console.WriteLine("Starting RPC client....");

if (!args.Any()) return;

var resultCollection = new BlockingCollection<string>();

var factory = new ConnectionFactory
{
    HostName = "localhost",
}; 

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

var queueName = channel.QueueDeclare().QueueName;

var consumer = new EventingBasicConsumer(channel);

var props = channel.CreateBasicProperties();
props.ReplyTo = queueName;
props.CorrelationId = Guid.NewGuid().ToString();

consumer.Received += (sender, args) =>
{
    var body = args.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Recieved {message}");
    resultCollection.Add(message);
};

channel.BasicConsume(queue:queueName,consumer:consumer);


var messageToSend = Encoding.UTF8.GetBytes(args[0]);
channel.BasicPublish(exchange:"",routingKey: "RpcQueue",basicProperties:props,body:messageToSend);
var result = resultCollection.Take();

Console.WriteLine(result);