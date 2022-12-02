using Saga.Services.InventoryService.Entities;

namespace Saga.Services.InventoryService.Repositories;

public interface IOrderItemRepository : IRepository<OrderItem>
{
}


public class OrderItemRepository : IOrderItemRepository
{
    private readonly ILogger<OrderItemRepository> _logger;
    public OrderItemRepository(ILogger<OrderItemRepository> logger)
    {
        _logger = logger;
        SeedDatabase();
    }

    private Dictionary<Guid,OrderItem> OrderItemDatabase { get; set; }

    private void SeedDatabase()
    {
        _logger.LogInformation($"Seeding {nameof(OrderItemRepository)}....");
        OrderItemDatabase = new Dictionary<Guid, OrderItem>
        {

        };
    }
    public void Delete(Guid id)
    {
        _logger.LogInformation($"Deleting OrderItem #{id}");
        if(OrderItemDatabase.ContainsKey(id))
        {
            OrderItemDatabase.Remove(id);
        }
    }

    public OrderItem Get(Guid id)
    {
        _logger.LogInformation($"Retrieving OrderItem #{id}");

        if(OrderItemDatabase.TryGetValue(id, out var item))
        {
            return item;
        }
        else
        {
            _logger.LogError($"Item not found. OrderItem #{id}");
        }
        return OrderItemDatabase[id];
    }

    public OrderItem Insert(OrderItem entity)
    {
        _logger.LogInformation($"Adding new OrderItem from OrderId {entity.OrderId}..");

        var id = Guid.NewGuid();
        entity.Id = id;
        OrderItemDatabase.Add(id, entity);
        return entity;
    }

    public OrderItem Update(OrderItem entity)
    {
        throw new NotImplementedException();
    }
}
