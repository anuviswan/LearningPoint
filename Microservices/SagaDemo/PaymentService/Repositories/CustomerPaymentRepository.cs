using Saga.Services.PaymentService.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Saga.Services.PaymentService.Repositories;

public interface ICustomerPaymentRepository : IRepository<CustomerPayment>
{
    IEnumerable<CustomerPayment> GetAll();
    CustomerPayment GetForOrderId(Guid orderId);
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

    public IEnumerable<CustomerPayment> GetAll()
    {
        _logger.LogInformation($"Retrieving all payment information");
        return Database.Values;
    }

    public CustomerPayment GetForOrderId(Guid orderId)
    {
        _logger.LogInformation($"Retrieving Payment Information for OrderId ${orderId}");
        var payment = Database.Values.SingleOrDefault(x => x.OrderId == orderId);

        if (payment is null) throw new ArgumentException($"Unable to find Payment for Order #{orderId}");

        return payment;
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
