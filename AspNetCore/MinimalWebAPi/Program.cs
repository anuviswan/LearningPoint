
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITokenService>(new TokenService());
builder.Services.AddSingleton<IUserRepositoryService>(new UserRepositoryService());
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new ()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

await using var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", (Func<string>)(() => "This a demo for JWT Authentication using Minimalist Web API"));

app.MapGet("/login", [AllowAnonymous] async (HttpContext http,ITokenService tokenService,IUserRepositoryService userRepositoryService) => {
    var userModel = await http.Request.ReadFromJsonAsync<UserModel>();
    var userDto = userRepositoryService.GetUser(userModel);
    if (userDto == null)
    {
        http.Response.StatusCode = 401;
        return;
    }

    var token = tokenService.BuildToken(builder.Configuration["Jwt:Key"], builder.Configuration["Jwt:Issuer"], userDto);
    await http.Response.WriteAsJsonAsync(new { token = token });
    return;
});

app.MapGet("/doaction", (Func<string>)([Authorize]() => "Action Succeeded"));

await app.RunAsync();

public record UserDto(string UserName,string Password);

public record UserModel([Required] string UserName,[Required] string Password);

public interface IUserRepositoryService
{
    UserDto GetUser(UserModel userModel);
}
public class UserRepositoryService : IUserRepositoryService
{
    private List<UserDto> _users => new ()
    {
        new ("Anu Viswan","anu"),
        new ("Jia Anu","jia"),
        new ("Naina Anu","naina"),
        new ("Sreena Anu","sreena"),
    };
    public UserDto GetUser(UserModel userModel)
    {
        return _users.FirstOrDefault(x => string.Equals(x.UserName,userModel.UserName) && string.Equals(x.Password, userModel.Password));
    }
}

public interface ITokenService
{
    string BuildToken(string key, string issuer, UserDto user);
}
public class TokenService : ITokenService
{
    private TimeSpan ExpiryDuration = new TimeSpan(0, 30, 0);
    public string BuildToken(string key, string issuer, UserDto user)
    {
        var claims = new[]
        {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier,
                Guid.NewGuid().ToString())
             };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
            expires: DateTime.Now.Add(ExpiryDuration), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}
