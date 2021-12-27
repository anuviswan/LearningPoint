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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapPost("/validate", (UserValidationRequestModel request) =>
{
    if(request is UserValidationRequestModel { UserName: "john.doe", Password: "123456" })
    {
        return new
        {
            IsValidated = true,
        };
    }
    return new
    {
        IsValidated = false
    };
})
.WithName("Validate");

app.Run();


internal record UserValidationRequestModel(string UserName,string Password);
