using Saga.Services.InventoryService.Entities;

namespace Saga.Services.InventoryService.Repositories;

public interface IInventoryRepository : IRepository<Inventory>
{
    IDictionary<Guid, Inventory> RetrieveStock(IEnumerable<Guid> itemIds);
}
public class InventoryRepository : IInventoryRepository
{
    private readonly ILogger<InventoryRepository> _logger;
    public InventoryRepository(ILogger<InventoryRepository> logger)
    {
        _logger = logger;
        SeedDatabase();
    }

    private Dictionary<Guid, Inventory> Database { get; set; } = null!;

    private void SeedDatabase()
    {
        Database = new Dictionary<Guid, Inventory>()
        {
            [Guid.Parse("71dff6b9-2592-468b-85f1-3acfe4e67daf")] = new Inventory() 
            {
                Id = Guid.Parse("71dff6b9-2592-468b-85f1-3acfe4e67daf"),
                Name = "Logitech Mouse",
                Quantity = 100,
            },
            [Guid.Parse("0e7f6d70-b753-4708-b369-aa292ce84b76")] = new Inventory()
            {
                Id = Guid.Parse("0e7f6d70-b753-4708-b369-aa292ce84b76"),
                Name = "Hp Keyboard",
                Quantity = 50,
            },
            [Guid.Parse("559865ce-1572-4a76-b35f-fbc86b114754")] = new Inventory()
            {
                Id = Guid.Parse("559865ce-1572-4a76-b35f-fbc86b114754"),
                Name = "Microsoft Keyboard",
                Quantity = 10,
            },
            [Guid.Parse("5e20dcb5-7dbb-4f4d-a78a-dff165964d61")] = new Inventory()
            {
                Id = Guid.Parse("5e20dcb5-7dbb-4f4d-a78a-dff165964d61"),
                Name = "Microsoft Mouse",
                Quantity = 10,
            },
        };
    }

    public void Delete(Guid id)
    {
       throw new NotImplementedException("Deleting Entity from Inventory not allowed");
    }

    public Inventory Get(Guid id)
    {
        _logger.LogInformation($"Retrieving Inventory #{id}");

        if (Database.TryGetValue(id, out var item))
        {
            return item;
        }
        else
        {
            _logger.LogError($"Item not found. Inventory #{id}");
        }
        return Database[id];
    }

    public IDictionary<Guid, Inventory> RetrieveStock(IEnumerable<Guid> itemIds)
    {
        return itemIds.Select(x => Get(x)).ToDictionary(x=>x.Id, y=> y);
    }

    public Inventory Insert(Inventory entity)
    {
        _logger.LogInformation($"Adding new Inventory..");

        var id = Guid.NewGuid();
        entity.Id = id;
        Database.Add(id, entity);
        return entity;
    }

    public Inventory? Update(Inventory entity)
    {
        _logger.LogInformation($"Updating Inventory #{entity.Id}....");

        if (Database.TryGetValue(entity.Id, out var order))
        {
            order.Quantity = entity.Quantity;

            _logger.LogInformation($"Current State for Inventory #{order.Id}");
        }

        return order;
    }
}
