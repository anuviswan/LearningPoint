using Saga.Services.InventoryService.Dtos;
using Saga.Services.InventoryService.Entities;

namespace Saga.Services.InventoryService.Services;

public interface IInventoryService
{
    void ReserveStock(OrderDto orderDto);
}
public class InventoryService : IInventoryService
{
    public void ReserveStock(OrderDto orderDto)
    {
        ArgumentNullException.ThrowIfNull(orderDto, nameof(orderDto));
        ArgumentNullException.ThrowIfNull(orderDto.Items, nameof(orderDto.Items));

        var orderItemList = new List<OrderItem>();
        
        foreach (var item in orderDto.Items)
        {
            orderItemList.Add(new()
            {
                OrderId = orderDto.Id,
                ItemId = item.Key,
                Quantity = item.Value,
                State = OrderItemState.Pending
            });
        }

    }
}
