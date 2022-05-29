using SimpleRetryPattern;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/retrydemo", async (IHttpClientFactory clientFactory) =>
{
    return await ExecuteOperation(_);

    async Task<string> _()
    {
        var url = $"https://jsonplaceholder.typicode.com/todos/1";

        var client = clientFactory.CreateClient("Demo");
        var response = await client.GetAsync(url);
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }


}).WithName("RetryDemo");


async Task<T> ExecuteOperation<T>(Func<Task<T>> action,int maxRetries = 5, int delay = 5000)
{
    int currentRetry = 0;
    while (true)
    {
        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            currentRetry++;

            if (currentRetry > maxRetries || !ex.IsTransient())
            {
                Debugger.Break();
                throw;
            }

            await Task.Delay(delay);
        }
    }
} 

app.Run();
