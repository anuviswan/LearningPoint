using CqrsAndMediatR.Api.Controllers;
using CqrsAndMediatR.Data.Database;
using CqrsAndMediatR.Data.Repository;
using CqrsAndMediatR.Service.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(CustomerController));
builder.Services.AddDbContext<CustomerDbContext>(o=>o.UseInMemoryDatabase(Guid.NewGuid().ToString()),ServiceLifetime.Singleton);
builder.Services.AddMediatR(typeof(GetAllCustomersQuery).Assembly);
builder.Services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
