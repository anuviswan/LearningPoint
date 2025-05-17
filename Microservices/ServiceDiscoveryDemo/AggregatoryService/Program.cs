using AggregatoryService;
using AggregatoryService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.Configure<ServiceDiscoveryOptions>(
    builder.Configuration.GetSection(nameof(ServiceDiscoveryOptions)));
builder.Services.AddHttpClient();
builder.Services.AddScoped<ConsulServiceResolver>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddSingleton<IHttpClientFactory>(sp => new DevelopmentHttpClientFactory(sp));
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

