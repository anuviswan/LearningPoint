using Saga.Services.InventoryService.Entities;
using System.Data.Common;

namespace Saga.Services.InventoryService.Repositories;

public interface IOrderItemRepository : IRepository<OrderItem>
{
    IEnumerable<OrderItem> BulkInsert(IEnumerable<OrderItem> items);

    IEnumerable<OrderItem>  DeleteForOrder(Guid orderId);
}


public class OrderItemRepository : IOrderItemRepository
{
    private readonly ILogger<OrderItemRepository> _logger;
    public OrderItemRepository(ILogger<OrderItemRepository> logger)
    {
        _logger = logger;
        SeedDatabase();
    }

    private Dictionary<Guid, OrderItem> Database { get; set; } = null!;

    private void SeedDatabase()
    {
        _logger.LogInformation($"Seeding {nameof(OrderItemRepository)}....");
        Database = new Dictionary<Guid, OrderItem>
        {

        };
    }
    public void Delete(Guid id)
    {
        _logger.LogInformation($"Deleting OrderItem #{id}");
        if(Database.TryGetValue(id,out var orderItem))
        {
            Database.Remove(id);
        }
    }

    public IEnumerable<OrderItem> DeleteForOrder(Guid orderId)
    {
        _logger.LogInformation($"Deleting Order Items for #{orderId}");

        var orderItems = Database.Values.Where(x=>x.OrderId == orderId);

        foreach(var item in orderItems)
        {
            item.State = OrderItemState.Rejected;
            Delete(item.Id);
            yield return item;
        }
    }

    public OrderItem Get(Guid id)
    {
        _logger.LogInformation($"Retrieving OrderItem #{id}");

        if(Database.TryGetValue(id, out var item))
        {
            return item;
        }
        else
        {
            _logger.LogError($"Item not found. OrderItem #{id}");
        }
        return Database[id];
    }

    public OrderItem Insert(OrderItem entity)
    {
        _logger.LogInformation($"Adding new OrderItem from OrderId {entity.OrderId}..");

        var id = Guid.NewGuid();
        entity.Id = id;
        Database.Add(id, entity);
        return entity;
    }

    public OrderItem Update(OrderItem entity)
    {
        _logger.LogInformation($"Updating OrderItem #{entity.Id}....");

        if (Database.TryGetValue(entity.Id, out var order))
        {
            order.State = entity.State;
            order.Quantity = entity.Quantity;

            _logger.LogInformation($"Current State for OrderItem #{order.Id} : {order.State}");
        }

        return order;
    }

    public IEnumerable<OrderItem> BulkInsert(IEnumerable<OrderItem> items)
    {
        foreach(var item in items)
        {
            yield return Insert(item);
        }
    }
}
