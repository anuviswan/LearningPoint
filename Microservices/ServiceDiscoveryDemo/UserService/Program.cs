using Consul;

var builder = WebApplication.CreateBuilder(args);
var consulConfig = builder.Configuration.GetSection(nameof(ConsulConfig)).Get<ConsulConfig>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

if(consulConfig is not null)
{
    var consulClient = new ConsulClient(x => x.Address = new Uri(consulConfig.ConsulAddress));
    var registration = new AgentServiceRegistration
    {
        ID = consulConfig.ServiceId,
        Name = consulConfig.ServiceName,
        Address = consulConfig.ServiceAddress,
        Port = consulConfig.ServicePort,
        Check = new AgentServiceCheck
        {
            HTTP = $"https://{consulConfig.ServiceAddress}:{consulConfig.ServicePort}{consulConfig.HealthCheckUrl}",
            Interval = TimeSpan.FromSeconds(10),
            Timeout = TimeSpan.FromSeconds(5),
            DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(consulConfig.DeregisterAfterMinutes),
            TLSSkipVerify = consulConfig.TLSSkipVerify,
        }
    };


    // Register service with Consul
    await consulClient.Agent.ServiceRegister(registration);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public record ConsulConfig
{
    public string ConsulAddress { get; set; } = null!;
    public string ServiceName { get; set; } = null!;
    public string ServiceId { get; set; } = null!;
    public string ServiceAddress { get; set; } = null!;
    public int ServicePort { get; set; }
    public string HealthCheckUrl { get; set; } = null!;
    public int DeregisterAfterMinutes { get; set; }
    public bool TLSSkipVerify { get; set; } = true;
}
