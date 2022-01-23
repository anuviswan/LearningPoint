var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("services/raiseexception", () =>
{
    throw new Exception("Mock Exception");
})
.WithName("raiseexception");

app.MapGet("services/randomtimeout", async () =>
{
    var random = new Random();
    var value = random.Next(0, 2);
    if ( value== 0)
    {
        await Task.Delay(4000);
    }
    return value;
})
.WithName("randomtimeout");

app.Run();
