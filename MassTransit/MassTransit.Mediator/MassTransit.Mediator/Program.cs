using MassTransit;
using MassTransit.Mediator.Services.Consumers;
using MassTransit.MediatR.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediator(cfg =>
{
    cfg.AddConsumersFromNamespaceContaining<OrderSubmitHandler>();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(cfg=>
{
    cfg.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Mediator With MassTransit",
        Description = "Demonstration to build a Mediator using MassTransit",
        Version = "v1.0",
    });
});

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
