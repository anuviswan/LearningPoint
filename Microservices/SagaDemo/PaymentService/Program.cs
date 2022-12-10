using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Saga.Services.PaymentService.Entities;
using Saga.Services.PaymentService.Models;
using Saga.Services.PaymentService.Repositories;
using Saga.Services.PaymentService.Services;

var builder = WebApplication.CreateBuilder(args);

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
    x.UsingRabbitMq((cntxt, cfg) => {
        cfg.Host(rabbitMqSettings.Uri, "/", c => {
            c.Username(rabbitMqSettings.UserName);
            c.Password(rabbitMqSettings.Password);
        });
    });
}));


// Setup Services
builder.Services.AddSingleton<IPaymentService, PaymentService>();
builder.Services.AddSingleton<ICustomerPaymentRepository, CustomerPaymentRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/makepayment", (MakePaymentRequest paymentRequest,
    [FromServices] ILogger<Program> logger,
    [FromServices] IPaymentService paymentService,
    [FromServices] IPublishEndpoint publishEndPoint) =>
{
    logger.LogInformation($"PaymentService.MakePayment started with ");

    var payment = new CustomerPayment
    {
        CustomerId = paymentRequest.CustomerId,
        Amount = paymentRequest.Amount,
        OrderId = paymentRequest.OrderId,
        State = PaymentState.Pending,
    };

    paymentService.MakePayment(payment);
});


app.Run();

public class RabbitMqSettings
{
    public string Uri { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
