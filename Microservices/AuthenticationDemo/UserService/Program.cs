
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/GetUsers", [Authorize]() =>
{
    return new[]
    {
        "John.Doe",
        "Jane.Doe",
        "Jewel.Doe",
        "Jayden.Doe",
    };
}).WithName("GetUsers");

app.MapGet("/RandomFail", () =>
{
    var randomValue = new Random().Next(0,2);
    if(randomValue == 1)
    {
        throw new HttpRequestException("Random Failure");
    }

    return "SomeData";
}).WithName("RandomFail");

app.MapGet("/RandomTimeout", async () =>
{
    var randomValue = new Random().Next(0, 2);
    if (randomValue == 1)
    {
        await Task.Delay(10000);
    }

    return "SomeData";
}).WithName("RandomTimeout");

app.UseAuthentication();
app.UseAuthorization();
app.Run();
