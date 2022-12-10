using Saga.Services.PaymentService.Entities;

namespace Saga.Services.PaymentService.Repositories;

public interface ICustomerPaymentRepository : IRepository<CustomerPayment>
{

}
public class CustomerPaymentRepository : ICustomerPaymentRepository
{
    private readonly ILogger<CustomerPaymentRepository> _logger;
    public CustomerPaymentRepository(ILogger<CustomerPaymentRepository> logger)
    {
        _logger = logger;
        SeedDatabase();
    }

    private static Dictionary<Guid, CustomerPayment> Database { get; set; } = null!;
    private void SeedDatabase()
    {
        Database = new Dictionary<Guid, CustomerPayment>();
    }
    public void Delete(Guid id)
    {
        throw new NotImplementedException("Should not be able to deleting payment transaction records");
    }

    public CustomerPayment? Get(Guid id)
    {
        _logger.LogInformation($"Retrieving Payment Information #{id}");
        return Database[id];
    }

    public CustomerPayment Insert(CustomerPayment entity)
    {
        _logger.LogInformation($"Adding Payment Information for Customer #{entity.CustomerId} for Order #{entity.OrderId}");
        var entityToSave = entity with { Id = Guid.NewGuid() };
        Database[entityToSave.Id] = entityToSave;
        return entityToSave;
    }

    public CustomerPayment? Update(CustomerPayment entity)
    {
        _logger.LogInformation($"Updating Payment Information #{entity.Id}");
        var existingEntity = Database[entity.Id];
        var entityToSave = existingEntity with { State = entity.State};
        Database[entityToSave.Id] = entityToSave;
        return entityToSave;
    }
}
