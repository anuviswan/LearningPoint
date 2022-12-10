using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Saga.Services.OrderService.Services;
using Saga.Shared.Contracts.Events;

namespace Saga.Services.OrderService.Consumers;

public class OrderCreationFailedConsumer : IConsumer<OrderCreationFailed>
{
    private readonly IOrderService _orderService;
    public OrderCreationFailedConsumer([FromServices] IOrderService orderService)
    {
        _orderService = orderService;
    }
    public Task Consume(ConsumeContext<OrderCreationFailed> context)
    {
        _orderService.SetOrderAsFailed(context.Message.OrderId);
        return Task.CompletedTask;
    }
}
