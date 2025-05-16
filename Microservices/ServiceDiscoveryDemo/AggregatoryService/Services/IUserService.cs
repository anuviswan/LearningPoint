
using System.Text.Json.Serialization;

namespace AggregatoryService.Services;

public interface IUserService
{
    Task<UserDto?> GetUserByIdAsync(string userId);
}
public record UserDto([property: JsonPropertyName("id")] string Name, [property: JsonPropertyName("name")] string Phone, [property: JsonPropertyName("email")] string Email);