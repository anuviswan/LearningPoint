using Microsoft.AspNetCore.OpenApi;
using Saga.Services.OrderService.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/createorder", (CreateOrderRequest orderRequest, ILogger logger) =>
{
    logger.LogInformation($"OrderService.CreateOrder started with ");
    // Place Order (in pending state) and Raise OrderCreatedEvent
});




app.Run();
