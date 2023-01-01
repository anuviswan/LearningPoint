using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Saga.Services.OrderService.Services;
using Saga.Shared.Contracts.Events;

namespace Saga.Services.OrderService.Consumers;

public class OrderCreationFailedConsumer : IConsumer<OrderCreationFailed>
{
    private readonly IOrderService _orderService;
    private readonly ILogger<OrderCreationFailedConsumer> _logger;
    public OrderCreationFailedConsumer([FromServices] IOrderService orderService, [FromServices] ILogger<OrderCreationFailedConsumer> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }
    public Task Consume(ConsumeContext<OrderCreationFailed> context)
    {
        _logger.LogInformation($"Order Failed Event Occured (Order #{context.Message.OrderId})");
        _orderService.SetOrderAsFailed(context.Message.OrderId);
        return Task.CompletedTask;
    }
}

public class OrderCreationFailedConsumerDefinition : ConsumerDefinition<OrderCreationFailedConsumer>
{
    public OrderCreationFailedConsumerDefinition()
    {
        EndpointName = IBaseEvent<OrderCreationFailed>.QueueName;
    }
}
