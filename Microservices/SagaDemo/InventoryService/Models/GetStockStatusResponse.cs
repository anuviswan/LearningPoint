namespace Saga.Services.InventoryService.Models;

public class GetStockStatusResponse
{
    public Guid ItemId { get; set; }

    public string Name { get; set; }

    public int Quantity { get; set; }

}
