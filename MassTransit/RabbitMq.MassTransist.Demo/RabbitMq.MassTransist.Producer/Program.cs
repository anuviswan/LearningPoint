using MassTransit;
using RabbitMq.MassTransist.Producer;
using RabbitMq.MassTransit.Shared;

var builder = WebApplication.CreateBuilder(args);

var rabbitMqSettings = builder.Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(mt =>
                        mt.UsingRabbitMq((cntxt, cfg) =>
                        {
                            cfg.Host(rabbitMqSettings.Uri, "/", c =>
                            {
                                c.Username(rabbitMqSettings.UserName);
                                c.Password(rabbitMqSettings.Password);
                            });
                        }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var random = new Random();
app.MapPost("/sendmessage", (string message,IPublishEndpoint publishEndPoint) =>
{
    publishEndPoint.Publish(new CommandMessage(random.Next(),message)); ;
});
app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}