using AggregatoryService;
using AggregatoryService.Services;

var builder = WebApplication.CreateBuilder(args);
var consulConfig = builder.Configuration.GetSection(nameof(ServiceDiscovery)).Get<ServiceDiscovery>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


//var resolver = new ConsulServiceResolver("http://servicediscovery:8500");
//var (userServiceAddress, userServicePort) = await resolver.ResolveServiceAsync("userservice");
//var (paymentServiceAddress, paymentServicePort) = await resolver.ResolveServiceAsync("paymentService");

builder.Services.AddHttpClient();
builder.Services.AddScoped<ConsulServiceResolver>();
//builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddSingleton<IHttpClientFactory>(sp => new MyCustomHttpClientFactory(sp));

//builder.Services.AddHttpClient("ASd")  // default unnamed client
//    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
//    {
//        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
//    });
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddHttpClient<PaymentService>(client =>
{
    // Don't set BaseAddress here since it's resolved via Consul
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    };
});


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

public class MyCustomHttpClientFactory : IHttpClientFactory
{
    private readonly IServiceProvider _serviceProvider;

    public MyCustomHttpClientFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public HttpClient CreateClient(string name)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        return new HttpClient(handler);
    }
}

