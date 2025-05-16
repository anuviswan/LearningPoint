using AggregatoryService;
using AggregatoryService.Services;

var builder = WebApplication.CreateBuilder(args);
var consulConfig = builder.Configuration.GetSection(nameof(ServiceDiscovery)).Get<ServiceDiscovery>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var resolver = new ConsulServiceResolver("http://servicediscovery:8500");
var (userServiceAddress, userServicePort) = await resolver.ResolveServiceAsync("userservice");
var (paymentServiceAddress, paymentServicePort) = await resolver.ResolveServiceAsync("paymentService");

builder.Services.AddHttpClient<IUserService,UserService>(client =>
{
    client.BaseAddress = new Uri($"https://{userServiceAddress}:{userServicePort}");
}).ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    };
});

builder.Services.AddHttpClient<IPaymentService, PaymentService>(client =>
{
    client.BaseAddress = new Uri($"https://{paymentServiceAddress}:{paymentServicePort}");
}).ConfigurePrimaryHttpMessageHandler(() =>
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


