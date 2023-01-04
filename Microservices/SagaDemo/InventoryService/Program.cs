using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Saga.Services.InventoryService.Consumers;
using Saga.Services.InventoryService.Models;
using Saga.Services.InventoryService.Repositories;
using Saga.Services.InventoryService.Services;
using Saga.Shared.Contracts.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var rabbitMqSettings = builder.Configuration
                              .GetSection(nameof(RabbitMqSettings))
                              .Get<RabbitMqSettings>();

if (rabbitMqSettings is null) throw new Exception("Unable to find RabbitMq Settings");

builder.Services.AddMassTransit(mt => mt.AddMassTransit(x =>
{
    x.AddConsumer<OrderCreationInitiatedConsumer>(typeof(OrderCreationInitiatedConsumerDefinition));
    x.AddConsumer<PaymentFailedConsumer>(typeof(PaymentFailedConsumerDefinition));

    x.UsingRabbitMq((cntxt, cfg) => {
        cfg.Host(rabbitMqSettings.Uri, "/", c => {
            c.Username(rabbitMqSettings.UserName);
            c.Password(rabbitMqSettings.Password);
        });
        cfg.ConfigureEndpoints(cntxt);
    });
}));


//set up Services
builder.Services.AddSingleton<IInventoryService, InventoryService>();
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddSingleton<IOrderItemRepository, OrderItemRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/getstock", ([FromServices] IInventoryService inventoryService,
    [FromServices]ILogger<Program> logger) =>{

        logger.LogInformation($"Retrieving current stock status");
        var stock = inventoryService.GetStock();
        return Results.Ok(stock.Select(x => new GetStockStatusResponse
        {
            ItemId = x.Id,
            Name = x.Name,
            Quantity = x.Quantity
        }));
});


app.MapGet("/getreservedstock", ([FromServices] IInventoryService inventory,
    [FromServices]ILogger<Program> logger) =>
{
    logger.LogInformation($"Retrieving reserved stock status");

    var stock = inventory.GetReservedStock();

    return Results.Ok(stock.GroupBy(x => x.OrderId).Select(x =>
    new GetReservedStockStatusResponse
    {
        OrderId = x.Key,
        ReservedStockItems = x.Select(c=> new ReservedStockItemResponse
        {
            ItemId= c.Id,
            Quantity= c.Quantity,
            State  = c.State
        })
    }));
});

app.Run();



public class RabbitMqSettings
{
    public string Uri { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
