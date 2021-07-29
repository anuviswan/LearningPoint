using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
await using var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", (Func<string>)(() => "This a demo for JWT Authentication using Minimalist Web API"));
app.MapGet("/sayhello", async (http) => {
    await http.Response.WriteAsJsonAsync("Hello");
});

await app.RunAsync();

public record UserDto(string UserName,string Password);

public record UserModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}

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
