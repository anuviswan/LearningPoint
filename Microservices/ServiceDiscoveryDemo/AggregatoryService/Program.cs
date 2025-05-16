using AggregatoryService.Services;
using Consul;

var builder = WebApplication.CreateBuilder(args);
var consulConfig = builder.Configuration.GetSection(nameof(ServiceDiscovery)).Get<ServiceDiscovery>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//builder.Services.AddHttpClient<IUserService>(static client =>
//{
//    client.BaseAddress = new("https://userservice:8081");
//    //client.BaseAddress = new("http://userservice.service.consul");
//}).AddServiceDiscovery();



builder.Services.AddSingleton(new ConsulServiceResolver("http://servicediscovery:8500"));

var resolver = new ConsulServiceResolver("http://servicediscovery:8500");
var (address, port) = await resolver.ResolveServiceAsync("userservice");


builder.Services.AddHttpClient<IUserService,UserService>(client =>
{
    client.BaseAddress = new Uri($"https://{address}:{port}");
}).ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    };
});
//builder.Services.AddTransient<IUserService, UserService>();


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



public class ConsulServiceResolver : IDisposable
{
    private readonly ConsulClient _client;

    public ConsulServiceResolver(string consulAddress = "http://servicediscovery:8500")
    {
        _client = new ConsulClient(cfg => cfg.Address = new Uri(consulAddress));
    }

    /// <summary>
    /// Resolves a healthy instance of the given service name from Consul.
    /// </summary>
    public async Task<(string Address, int Port)> ResolveServiceAsync(string serviceName)
    {
        var result = await _client.Health.Service(serviceName, tag: null, passingOnly: true);

        if (result.Response == null || result.Response.Length == 0)
            throw new Exception($"No healthy instances found for service '{serviceName}'");

        // Simple round-robin/random strategy
        var random = new Random();
        var serviceEntry = result.Response[random.Next(result.Response.Length)];

        return (serviceEntry.Service.Address, serviceEntry.Service.Port);
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}
