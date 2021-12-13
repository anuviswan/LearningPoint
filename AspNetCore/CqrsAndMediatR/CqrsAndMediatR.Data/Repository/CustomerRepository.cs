using CqrsAndMediatR.Data.Database;
using CqrsAndMediatR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CqrsAndMediatR.Data.Repository;
public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(CustomerDbContext customDbContext) : base(customDbContext)
    {
    }
   
}
