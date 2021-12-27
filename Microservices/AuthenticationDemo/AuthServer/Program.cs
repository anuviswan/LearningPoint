using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITokenService>(new TokenService());

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
            ValidAudience = builder.Configuration["Jwt:Aud3"], 
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

app.MapPost("/validate", [AllowAnonymous] (UserValidationRequestModel request,HttpContext http,ITokenService tokenService) =>
{
    if (request is UserValidationRequestModel { UserName: "john.doe", Password: "123456" })
    {
        var token = tokenService.BuildToken(builder.Configuration["Jwt:Key"], 
                                            builder.Configuration["Jwt:Issuer"],
                                            new[] 
                                            { 
                                                builder.Configuration["Jwt:Aud1"], 
                                                builder.Configuration["Jwt:Aud2"],
                                                builder.Configuration["Jwt:Aud3"],
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

app.UseAuthentication();
app.UseAuthorization();
app.Run();


internal record UserValidationRequestModel(string UserName,string Password);

public interface ITokenService
{
    string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName);
}
public class TokenService : ITokenService
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