
using CqrsAndMediatR.Domain.Entities;

namespace CqrsAndMediatR.Data.Repository
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        Task<Customer> GetCustomerByIdAsync(long id, CancellationToken cancellationToken);
    }
}