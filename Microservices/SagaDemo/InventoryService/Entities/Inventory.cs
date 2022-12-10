namespace Saga.Services.InventoryService.Entities;

public record Inventory
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required int Quantity { get; set; }

}
