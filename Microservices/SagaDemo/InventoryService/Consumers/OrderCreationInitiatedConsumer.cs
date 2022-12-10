using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Saga.Services.InventoryService.Dtos;
using Saga.Services.InventoryService.Services;
using Saga.Shared.Contracts.Events;

namespace Saga.Services.InventoryService.Consumers;

public class OrderCreationInitiatedConsumer : IConsumer<OrderCreationInitiated>
{
    private readonly IInventoryService _inventoryService;
    public OrderCreationInitiatedConsumer([FromServices]IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }
    public Task Consume(ConsumeContext<OrderCreationInitiated> context)
    {
        var orderInfo = new OrderDto
        {
            OrderId = context.Message.OrderId,
            Items = context.Message.OrderItems.ToDictionary(x => x.ItemId, y => y.Qty)
        };

        try
        {
            _inventoryService.ReserveStock(orderInfo);
        }
        catch(Exception ex)
        {

        }
        throw new NotImplementedException();
    }
}
