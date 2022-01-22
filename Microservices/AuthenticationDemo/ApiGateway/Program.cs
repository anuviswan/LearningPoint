using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Errors;
using Ocelot.Logging;
using Ocelot.Middleware;
using Ocelot.Provider.Polly;
using Ocelot.Requester;
using Polly;
using Polly.CircuitBreaker;
using Polly.Extensions.Http;
using Polly.Timeout;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("GatewayAuthenticationKey", option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Aud"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();
builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot().AddPollyExtended();
//builder.Services.AddOcelot().AddPolly();

//builder.Services.AddHttpClient("UserService", client =>
//{
//    client.BaseAddress = new Uri("https://localhost:7173/");
//}).AddPolicyHandler(GetCircuitBreakerPolicy()); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseOcelot().Wait();

app.MapRazorPages();

app.Run();


public class ExtendedPollyCircuitBreakingDelegatingHandler : PollyCircuitBreakingDelegatingHandler
{
    private IOcelotLogger _logger;
    public ExtendedPollyCircuitBreakingDelegatingHandler(PollyQoSProvider qoSProvider, IOcelotLoggerFactory loggerFactory) : base(qoSProvider, loggerFactory)
    {
        _logger =  loggerFactory.CreateLogger<ExtendedPollyCircuitBreakingDelegatingHandler>(); ;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            var policy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                                            .CircuitBreakerAsync(2, TimeSpan.FromSeconds(60));

            var response = await policy.ExecuteAsync(() => base.SendAsync(request, cancellationToken));
            Console.WriteLine($"Error Code {response.StatusCode}");
            return response;
        }
        catch (Exception e)
        {
            throw;
        }
        
    }
}


public static class OcelotBuilderExtensions
{
    public static IOcelotBuilder AddPollyExtended(this IOcelotBuilder builder)
    {
        //builder.AddPolly();
        var errorMapping = new Dictionary<Type, Func<Exception, Error>>
            {
                {typeof(TaskCanceledException), e => new RequestTimedOutError(e)},
                {typeof(TimeoutRejectedException), e => new RequestTimedOutError(e)},
                {typeof(BrokenCircuitException), e => new RequestTimedOutError(e)}
            };

        builder.Services.AddSingleton(errorMapping);

        DelegatingHandler QosDelegatingHandlerDelegate(DownstreamRoute route, IOcelotLoggerFactory logger)
        {
            return new ExtendedPollyCircuitBreakingDelegatingHandler(new PollyQoSProvider(route, logger), logger);
        }

        builder.Services.AddSingleton((QosDelegatingHandlerDelegate)QosDelegatingHandlerDelegate);
        return builder;
    }
}