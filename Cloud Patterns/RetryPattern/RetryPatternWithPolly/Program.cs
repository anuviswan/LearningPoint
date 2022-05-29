using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("Demo")
        .AddPolicyHandler(GetRetryPolicy()); ;
IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
         .HandleTransientHttpError()
         .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
         .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                                                                     retryAttempt)));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/retrydemo", async (IHttpClientFactory clientFactory) =>
{
    var url = $"https://jsonplaceholder.typicode.com/todos/1";

    var client = clientFactory.CreateClient("Demo");
    var response = await client.GetAsync(url);
    var result = await response.Content.ReadAsStringAsync();
    return result;
}).WithName("RetryDemo");

app.Run();
