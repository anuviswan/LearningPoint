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

if (rabbitMqSettings is null) throw new Exception("Unable to find RabbitMq Settings");

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

    

    return Results.Ok(new CreateOrderResponse
    {
        OrderId = currentOrder.Id,
        CustomerId = currentOrder.CustomerId,
        State = currentOrder.State,
    });
    
});


app.MapGet("/getall", ([FromServices]IOrderService orderService, [FromServices]ILogger<Program> logger) =>
{
    logger.LogInformation($"Retrieving all order items");

    var result = orderService.GetAll();
    var response = result.Select(x => new GetAllOrderResponse
    {
        OrderId = x.Id,
        CustomerId = x.CustomerId,
        State = x.State
    });

    return response;
});


app.MapGet("/getbyid", (Guid orderId, [FromServices] IOrderService orderService, [FromServices] ILogger<Program> logger) =>
{
    logger.LogInformation($"Retrieving order info for #{orderId}");
    try
    {
        var result = orderService.GetById(orderId);
        return Results.Ok(new GetOrderByIdResponse
        {
            OrderdId = result.Id,
            CustomerId = result.CustomerId,
            State = result.State
        });
    }
    catch(Exception ex) 
    {
        logger.LogError($"Error Retrieving Order #{orderId} - [{ex.Message}]");
        return Results.NotFound("OrderId not found !!");
    }
});


app.Run();


public class RabbitMqSettings
{
    public string Uri { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}