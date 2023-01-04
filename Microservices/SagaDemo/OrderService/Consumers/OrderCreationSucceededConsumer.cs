using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Saga.Services.OrderService.Services;
using Saga.Shared.Contracts.Events;

namespace Saga.Services.OrderService.Consumers;

public class OrderCreationSucceededConsumer : IConsumer<OrderCreationSucceeded>
{
    private readonly IOrderService _orderService;
    private readonly ILogger<OrderCreationFailedConsumer> _logger;
    public OrderCreationSucceededConsumer([FromServices] IOrderService orderService, [FromServices] ILogger<OrderCreationFailedConsumer> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }
    public Task Consume(ConsumeContext<OrderCreationSucceeded> context)
    {
        _logger.LogInformation($"Order Succeeded Event Occured (Order #{context.Message.OrderId})");
        _orderService.SetOrderAsPending(context.Message.OrderId);
        return Task.CompletedTask;
    }
}

public class OrderCreationSucceededConsumerDefinition : ConsumerDefinition<OrderCreationSucceededConsumer>
{
    public OrderCreationSucceededConsumerDefinition()
    {
        EndpointName = $"{IBaseEvent<OrderCreationSucceeded>.QueueName}-order-service";
    }
}
