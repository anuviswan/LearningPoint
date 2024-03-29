﻿using RabbitMQ.Client;
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
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

var consumer = new EventingBasicConsumer(channel);

var autoAck = args.Any(x=>x =="/autoack");

var useFairDespatch = args.Any(x => x == @"\e");

if (useFairDespatch)
{
    channel.BasicQos(0, 1, false);
}
consumer.Received += async (sender, eventArgs) =>
{
    if (!autoAck)
    {
        channel.BasicAck(deliveryTag: eventArgs.DeliveryTag, multiple: false);
    }

    Console.WriteLine("Recieving message from Asgard....");

    var body = eventArgs.Body;
    var message = Encoding.UTF8.GetString(body.ToArray());

    var delayTime = message.Where(x => x == '.').Count();
  
    Console.WriteLine("Executing task...");
    await Task.Delay(delayTime*1000);
    Console.WriteLine($"Task Completed, Message {message}");
};



channel.BasicConsume(queue: "AsgardWorkerQueue", 
                    autoAck: autoAck, 
                    consumer: consumer);
Console.ReadLine();

