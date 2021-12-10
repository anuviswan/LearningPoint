using CqrsAndMediatR.Data.Database;
using CqrsAndMediatR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CqrsAndMediatR.Data.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerDbContext customDbContext) : base(customDbContext)
        {
        }

        public async Task<Customer> GetCustomerByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await CustomerDbContext.Customer.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
