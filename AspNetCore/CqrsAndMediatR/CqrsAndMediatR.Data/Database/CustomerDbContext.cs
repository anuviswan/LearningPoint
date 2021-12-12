using CqrsAndMediatR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CqrsAndMediatR.Data.Database;
public class CustomerDbContext : DbContext
{
    public CustomerDbContext()
    {
    }
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>()
                    .HasData(
            new Customer { Id = 1, FirstName = "Jia", LastName = "Anu" },
            new Customer { Id = 2, FirstName = "Naina", LastName = "Anu" },
            new Customer { Id = 3, FirstName = "Sreena", LastName = "Anu" },
            new Customer { Id = 4, FirstName = "Anu", LastName = "Viswan" }
            );
    }

    public DbSet<Customer> Customer { get; set; }

}
