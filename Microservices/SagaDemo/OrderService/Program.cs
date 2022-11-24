using Microsoft.AspNetCore.Mvc;
using Saga.Services.OrderService.Models;
using Saga.Services.OrderService.Repositories;
using Saga.Services.OrderService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//set up RabbitMq


//set up Services
builder.Services.AddSingleton<IOrderRepository,OrderRepository>();
builder.Services.AddSingleton<IOrderService,OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/createorder", (CreateOrderRequest orderRequest, [FromServices]ILogger<Program> logger, [FromServices]IOrderService orderService) =>
{
    logger.LogInformation($"OrderService.CreateOrder started with ");


    // Place Order (in pending state) and Raise OrderCreatedEvent
    var currentOrder = orderService.CreateOrder(new()
    {
        CustomerId = orderRequest.CustomerId,
        OrderItems = orderRequest.Items,
    });

    if(currentOrder.Id != default)
    {
        
    }
    
});




app.Run();
