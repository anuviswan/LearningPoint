﻿using Saga.Services.OrderService.Entities;

namespace Saga.Services.OrderService.Repositories;


public interface IOrderRepository : IRepository<Order>
{

}
public class OrderRepository : IOrderRepository
{
    private ILogger<OrderRepository> _logger;   
    public OrderRepository(ILogger<OrderRepository> logger)
    {
        _logger = logger;
        SeedDatabase();
    }

    private static Dictionary<Guid, Order> Database { get; set; } = null!;
    private void SeedDatabase()
    {
        Database = new Dictionary<Guid, Order>()
        {
            [Guid.Parse("d5694807-094a-40cb-8e37-8658d040d6af")] = new Order()
            {
                Id = Guid.Parse("d5694807-094a-40cb-8e37-8658d040d6af"),
                CustomerId = Guid.Parse("58f37ff1-277c-4c6e-91b6-de08f024f598"),
                OrderItems = new OrderItem[]
                {
                    new() { OrderItemId = Guid.Parse("d8e1c8fd-53bb-474d-bc63-2f59e46e58c1") , Quantity = 1 },
                    new() { OrderItemId = Guid.Parse("dd469fa8-44c4-44df-8b9c-7a13271707cf"), Quantity = 2 },
                    new() { OrderItemId = Guid.Parse("fee6fa44-bc29-488f-949f-fec5b75d899e") , Quantity = 3 }
                },
                State = OrderState.Completed
            }
        };
    }

    public IEnumerable<Order> GetAll()
    {
        return Database.Values;
    }
    public void Delete(Guid id)
    {
        _logger.LogInformation($"Deleting Order #{id}");
        Database.Remove(id);
    }

    public Order? Get(Guid id)
    {
        _logger.LogInformation($"Retrieving Order #{id}");
        var order = Database[id];

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
        _logger.LogInformation($"Adding new Order with State {OrderState.Initiated}");
        var id = Guid.NewGuid();
        entity.Id = id;
        Database[id] = entity;
        return entity;
    }

    public Order? Update(Order entity)
    {
        _logger.LogInformation($"Updating Order #{entity.Id}");
        if(Database.TryGetValue(entity.Id, out var order))
        {
            order.State = entity.State;
            order.CustomerId = entity.CustomerId;
            order.OrderItems = entity.OrderItems;

            _logger.LogInformation($"Current State for Order #{order.Id} : {order.State}");
        }

        return order;
    }
}
