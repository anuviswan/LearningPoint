using Saga.Services.InventoryService.Entities;

namespace Saga.Services.InventoryService.Repositories;

public interface IInventoryRepository : IRepository<Stock>
{
}
public class InventoryRepository : IInventoryRepository
{
    public InventoryRepository()
    {
        SeedDatabase();
    }

    private Dictionary<Guid,Stock> StockDatabase { get; set; }

    private void SeedDatabase()
    {
        StockDatabase = new Dictionary<Guid, Stock>()
        {
            [Guid.Parse("71dff6b9-2592-468b-85f1-3acfe4e67daf")] = new Stock() 
            {
                Id = Guid.Parse("71dff6b9-2592-468b-85f1-3acfe4e67daf"),
                Name = "Logitech Mouse",
                Quantity = 100,
            },
            [Guid.Parse("0e7f6d70-b753-4708-b369-aa292ce84b76")] = new Stock()
            {
                Id = Guid.Parse("0e7f6d70-b753-4708-b369-aa292ce84b76"),
                Name = "Hp Keyboard",
                Quantity = 50,
            },
            [Guid.Parse("559865ce-1572-4a76-b35f-fbc86b114754")] = new Stock()
            {
                Id = Guid.Parse("559865ce-1572-4a76-b35f-fbc86b114754"),
                Name = "Microsoft Keyboard",
                Quantity = 10,
            },
            [Guid.Parse("5e20dcb5-7dbb-4f4d-a78a-dff165964d61")] = new Stock()
            {
                Id = Guid.Parse("5e20dcb5-7dbb-4f4d-a78a-dff165964d61"),
                Name = "Microsoft Mouse",
                Quantity = 10,
            },
        };
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Stock Get(Guid id)
    {
        return StockDatabase[id];
    }

    public Stock Insert(Stock entity)
    {
        throw new NotImplementedException();
    }

    public Stock Update(Stock entity)
    {
        StockDatabase[entity.Id] = entity;
        return StockDatabase[entity.Id];
    }
}
