using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITokenService>(new TokenService());

await using var app = builder.Build();

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();
}


app.MapPost("/validate", [AllowAnonymous] (UserValidationRequestModel request, HttpContext http, ITokenService tokenService) =>
{
    if (request is UserValidationRequestModel { UserName: "john.doe", Password: "123456" })
    {
        var token = tokenService.BuildToken(builder.Configuration["Jwt:Key"],
                                            builder.Configuration["Jwt:Issuer"],
                                            new[]
                                            {
                                                        builder.Configuration["Jwt:Aud1"],
                                                        builder.Configuration["Jwt:Aud2"]
                                                    },
                                            request.UserName);
        return new
        {
            Token = token,
            IsAuthenticated = true,
        };
    }
    return new
    {
        Token = string.Empty,
        IsAuthenticated = false
    };
})
.WithName("Validate");


await app.RunAsync();


internal record UserValidationRequestModel([Required]string UserName, [Required] string Password);

internal interface ITokenService
{
    string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName);
}
internal class TokenService : ITokenService
{
    private TimeSpan ExpiryDuration = new TimeSpan(0, 30, 0);
    public string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, userName),
        };

        claims.AddRange(audience.Select(aud => new Claim(JwtRegisteredClaimNames.Aud, aud)));

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
            expires: DateTime.Now.Add(ExpiryDuration), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}
