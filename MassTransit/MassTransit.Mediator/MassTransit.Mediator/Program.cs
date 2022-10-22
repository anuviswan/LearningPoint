using MassTransit;
using MassTransit.Mediator.Services.Consumers;
using MassTransit.MediatR.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediator(cfg =>
{
    cfg.AddConsumersFromNamespaceContaining<OrderSubmitConsumer>();
    cfg.AddRequestClient<IOrderSubmit>();
});

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
