using DemoGraphQLServer.Services;

namespace DemoGraphQLServer.GraphQL;

[ExtendObjectType(typeof(Query))]
public class InventoryServiceQuery
{
    public async Task<IEnumerable<Inventory>> GetAllInventoryListAsync([Service]InventoryService inventoryService)
    {
        return await inventoryService.GetInventoryListAsync();
    }

    public async Task<IEnumerable<InventoryAssigned>> GetAllAssignedInventoryListAsync([Service]InventoryService inventoryService)
    {
        return await inventoryService.GetAssignedInventoryAsync();
    }
}
