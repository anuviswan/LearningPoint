using Saga.Services.OrderService.Entities;

namespace Saga.Services.OrderService.Repositories;

public class OrderRepository : IRepository<Order>
{
    private ILogger<OrderRepository> _logger;   
    public OrderRepository(ILogger<OrderRepository> logger)
    {
        _logger = logger;
        SeedDatabase();
    }

    private static Dictionary<Guid, Order> OrderPersistence { get; set; }
    private void SeedDatabase()
    {
        OrderPersistence = new Dictionary<Guid, Order>()
        {
            [Guid.Parse("d5694807-094a-40cb-8e37-8658d040d6af")] = new Order()
            {
                Id = Guid.Parse("d5694807-094a-40cb-8e37-8658d040d6af"),
                CustomerId = Guid.Parse("58f37ff1-277c-4c6e-91b6-de08f024f598"),
                OrderItems = new[]
                {
                    Guid.Parse("d8e1c8fd-53bb-474d-bc63-2f59e46e58c1"),
                    Guid.Parse("dd469fa8-44c4-44df-8b9c-7a13271707cf"),
                    Guid.Parse("fee6fa44-bc29-488f-949f-fec5b75d899e"),
                },
                State = OrderState.Completed
            }
        };
    }
    public void Delete(Guid id)
    {
        _logger.LogInformation($"Deleting Order #{id}");
        OrderPersistence.Remove(id);
    }

    public Order Get(Guid id)
    {
        _logger.LogInformation($"Retrieving Order #{id}");
        var order = OrderPersistence[id];

        if(order is null)
        {
            _logger.LogInformation($"Unable to find Order #{id}");
        }
        else
        {
            _logger.LogInformation($"Found Order #{id} [State:{order.State}]");
        }

        return order;
    }

    public Order Insert(Order entity)
    {
        _logger.LogInformation($"Adding new Order with State {OrderState.Pending}");
        var id = Guid.NewGuid();
        entity.Id = id;
        entity.State = OrderState.Pending;
        OrderPersistence[id] = entity;
        return entity;
    }

    public Order? Update(Order entity)
    {
        _logger.LogInformation($"Updating Order #{entity.Id}");
        if(OrderPersistence.TryGetValue(entity.Id, out var order))
        {
            order.State = entity.State;
            order.CustomerId = entity.CustomerId;
            order.OrderItems = entity.OrderItems;

            _logger.LogInformation($"Current State for Order #{order.Id} : {order.State}");
        }

        return order;
    }
}
