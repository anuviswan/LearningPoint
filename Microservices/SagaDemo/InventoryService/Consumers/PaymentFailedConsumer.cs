using MassTransit;
using Saga.Services.InventoryService.Services;
using Saga.Shared.Contracts.Events;

namespace Saga.Services.InventoryService.Consumers;

public class PaymentFailedConsumer : IConsumer<PaymentFailed>
{
    private readonly IInventoryService _inventoryService;
    private readonly ILogger<PaymentFailedConsumer> _logger;
    public PaymentFailedConsumer(IInventoryService inventoryService, ILogger<PaymentFailedConsumer> logger)
    {
        _inventoryService = inventoryService;
        _logger = logger;
    }
    public Task Consume(ConsumeContext<PaymentFailed> context)
    {
        var orderId = context.Message.OrderId;
        _logger.LogInformation($"Cancelling Ordering [#{orderId}]");

        _inventoryService.CancelOrder(orderId);
        return Task.CompletedTask;
    }
}

public class PaymentFailedConsumerDefinition : ConsumerDefinition<PaymentFailedConsumer>
{
    public PaymentFailedConsumerDefinition()
    {
        EndpointName = $"{IBaseEvent<PaymentFailed>.QueueName}-inventory-service";
    }
}
