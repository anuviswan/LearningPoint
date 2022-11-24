using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Saga.Services.OrderService.Models;
using Saga.Services.OrderService.Repositories;
using Saga.Services.OrderService.Services;
using Saga.Shared.Contracts.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//set up RabbitMq
var rabbitMqSettings = builder.Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
builder.Services.AddMassTransit(mt => mt.AddMassTransit(x => 
{
    x.UsingRabbitMq((cntxt, cfg) => {
        cfg.Host(rabbitMqSettings.Uri, "/", c => {
            c.Username(rabbitMqSettings.UserName);
            c.Password(rabbitMqSettings.Password);
        });
    });
}));

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

app.MapPost("/createorder", (CreateOrderRequest orderRequest, 
    [FromServices]ILogger<Program> logger, 
    [FromServices]IOrderService orderService,
    [FromServices]IPublishEndpoint publishEndPoint) =>
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
        publishEndPoint.Publish(new OrderCreationInitiated()
        {
            OrderId = currentOrder.Id,
            CustomerId = currentOrder.CustomerId,
            OrderItems = currentOrder.OrderItems.Select(x => new OrderItemEntry()
            {
                ItemId = x.OrderItemId,
                Qty = x.Quantity
            }).ToList().AsReadOnly()
        });
    }
    
});




app.Run();


public class RabbitMqSettings
{
    public string Uri { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}