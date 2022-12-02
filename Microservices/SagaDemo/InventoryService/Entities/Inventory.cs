namespace Saga.Services.InventoryService.Entities;

public class Inventory
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required int Quantity { get; set; }

}
