using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// For IOptions API
//builder.Services.AddOptions<TwilioOptions>()
//    .Bind(builder.Configuration.GetSection(nameof(TwilioOptions)));

// For Singleton
builder.Services.AddSingleton(builder.Configuration.GetSection(nameof(TwilioOptions)).Get<TwilioOptions>()!);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/create", (TwilioOptions settings,  string roomName) =>
{
    Console.WriteLine($"Settings : {settings.RoomType}");
    return roomName;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();


public record TwilioOptions
{
    public string AccountSid { get; set; } = string.Empty;
    public string AuthToken { get; set; } = string.Empty;
    public string ApiKeySid { get; set; } = string.Empty;
    public string ApiSecret { get; set; } = string.Empty;
    public string RoomType { get; set; } = "group"; // Default if not set
}
