using MassTransit;
using Saga.Services.OrderService.Services;
using Saga.Shared.Contracts.Events;

namespace Saga.Services.OrderService.Consumers;

public class PaymentFailedConsumer : IConsumer<PaymentFailed>
{
    private readonly IOrderService _orderService;
    private readonly ILogger<PaymentFailedConsumer> _logger;
    public PaymentFailedConsumer(IOrderService orderService, ILogger<PaymentFailedConsumer> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }
    public Task Consume(ConsumeContext<PaymentFailed> context)
    {
        var orderId = context.Message.OrderId;
        _logger.LogInformation($"Initiating Order [#{orderId}] Cancellation due to failed Payment");
        _orderService.RejectOrder(orderId);
        return Task.CompletedTask;
    }
}
