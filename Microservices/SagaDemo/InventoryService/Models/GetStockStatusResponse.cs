namespace Saga.Services.InventoryService.Models;

public record GetStockStatusResponse
{
    public Guid ItemId { get; init; }

    public string Name { get; init; } = null!;  

    public int Quantity { get; init; }

}
