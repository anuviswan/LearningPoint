using HelloWorldApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldApi.Database;

public class DemoGraphContext : DbContext
{
    public DemoGraphContext(DbContextOptions<DemoGraphContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Project> Projects { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().HasData(new Project
        {
            CreatedBy = "Giorgi",
            Id = 1,
            Name = "Migrate to TLS 1.2"
        }, new Project
        {
            CreatedBy = "Giorgi",
            Id = 2,
            Name = "Move Blog to Hugo"
        });

        
    }
}
