using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AggregatoryService.Services;
public class UserService : ServiceBase, IUserService
{
    private readonly ILogger<UserService> _logger;
    public UserService(
        IHttpClientFactory httpClientFactory,
        ConsulServiceResolver consulResolver,
        ILogger<UserService> logger,
        IOptions<ServiceDiscoveryOptions> serviceDiscovery) : base(httpClientFactory, logger, consulResolver,serviceDiscovery,nameof(UserService))
    {
        _logger = logger;
    }

    public async Task<UserDto?> GetUserByIdAsync(string userId)
    {
        var client = await GetClientAsync();
        var response = await client.GetAsync($"/user/GetUserInfo?userName={userId}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<UserDto>(json);
        }

        _logger.LogError("Failed to get user {UserId}: {StatusCode}", userId, response.StatusCode);
        throw new Exception($"Failed to get user {userId}: {response.StatusCode}");
    }
}
