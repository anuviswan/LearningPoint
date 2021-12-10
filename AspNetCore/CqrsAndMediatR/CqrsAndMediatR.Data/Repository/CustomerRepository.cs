using CqrsAndMediatR.Data.Database;
using CqrsAndMediatR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsAndMediatR.Data.Repository
{
    public class CustomerRepository : GenericRepository<Customer>
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
