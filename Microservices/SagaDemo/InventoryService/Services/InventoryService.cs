using Saga.Services.InventoryService.Dtos;
using Saga.Services.InventoryService.Entities;
using Saga.Services.InventoryService.Repositories;

namespace Saga.Services.InventoryService.Services;

public interface IInventoryService
{
    void ReserveStock(OrderDto orderDto);
}
public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly ILogger<InventoryService> _logger;
    public InventoryService(IInventoryRepository inventoryRepository, IOrderItemRepository orderItemRepository,ILogger<InventoryService> logger)
    {
        (_inventoryRepository,_orderItemRepository) = (inventoryRepository, orderItemRepository);   
        _logger = logger;
    }
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

        // Check If stock available
        var orderedItemGroups = orderItemList.GroupBy(x => x.ItemId)
                                             .Select(x => x.ToList())
                                             .Select(x=>new 
                                             { 
                                                 ItemId = x.First().ItemId,
                                                 TotalQty = x.Sum(c=>c.Quantity)
                                             });


        var stock = _inventoryRepository.RetrieveStock(orderItemList.Select(x => x.ItemId).Distinct());

        foreach(var item in orderedItemGroups)
        {
            if (item.TotalQty > stock[item.ItemId].Quantity)
            {
                _logger.LogError($"{stock[item.ItemId].Name} is out of stock. Available ({stock[item.ItemId].Quantity}), Required ({item.TotalQty})");
                throw new Exception("Item out of stock !!");
            }
        }

        var orderedItems = _orderItemRepository.BulkInsert(orderItemList);

        foreach(var item in orderedItemGroups)
        {
            var current = stock[item.ItemId];
            current.Quantity -= item.TotalQty;
            _inventoryRepository.Update(current);
        }
    }
}
