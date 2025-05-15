using AggregatoryService.Services;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);
var consulConfig = builder.Configuration.GetSection(nameof(ServiceDiscovery)).Get<ServiceDiscovery>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddServiceDiscovery(o => o.UseConsul());
;
builder.Services.AddHttpClient<IUserService>(static client =>
{
    client.BaseAddress = new("https://userservice:8081");
    //client.BaseAddress = new("http://userservice.service.consul");
}).AddServiceDiscovery();
builder.Services.AddScoped<IUserService, UserService>();




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

public record ServiceDiscovery
{
    public List<string> Services { get; set; } = new List<string>();
    public string ResolverName { get; set; } = null!;
    public string ResolverPort { get; set; } = null!;
}