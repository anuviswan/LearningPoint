namespace Saga.Services.InventoryService.Dtos;

public record OrderDto
{
    public Guid Id { get; set; }
    public Dictionary<Guid, int> Items { get; set; } = new Dictionary<Guid, int>();

}
