# Processing Queue Using Background Service from Asp.Net Core Web Api

This code sample provides a basic implementation of how to process a Queue (RabbitMq) from an Asp.Net Core Web Api. The example code uses [BackgroundService](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.backgroundservice?view=dotnet-plat-ext-6.0) to illustrate the working.

For executing the demo, you could either create a custom client or use the RabbitMq Management Interface to publish message directly to the Queue ("UserCommandQueue"). Please make sure you add "reply_to" property to message. This would be the Queue in which Web API would be sending the reply to.
