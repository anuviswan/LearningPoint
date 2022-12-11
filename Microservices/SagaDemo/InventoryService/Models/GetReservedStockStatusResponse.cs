using Saga.Services.InventoryService.Entities;

namespace Saga.Services.InventoryService.Models;

public class GetReservedStockStatusResponse
{
    public Guid OrderId { get; set; }
    public IEnumerable<ReservedStockItemResponse> ReservedStockItems { get; set; }
}

public class ReservedStockItemResponse
{
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }

    public OrderItemState State { get; set; }
}
