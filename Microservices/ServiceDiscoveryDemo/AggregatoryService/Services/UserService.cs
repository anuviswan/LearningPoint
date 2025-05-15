using System.Text.Json;

namespace AggregatoryService.Services;


public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<UserService> _logger;
    public UserService(HttpClient httpClient, ILogger<UserService> logger)
    {
        (_httpClient, _logger) = (httpClient, logger);
    }

    public async Task<UserDto?> GetUserByIdAsync(string userId)
    {
        var response = await _httpClient.GetAsync($"/api/users/{userId}");
        if (response.IsSuccessStatusCode)
        {
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<UserDto>(responseJson);
        }
        else
        {
            _logger.LogError($"Failed to get user with ID {userId}. Status code: {response.StatusCode}");
            throw new Exception($"Failed to get user with ID {userId}. Status code: {response.StatusCode}");
        }
    }

    public record UserDto(string Name, string Phone, string Email);

}
