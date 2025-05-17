using System.Net.Http;
using System.Text.Json;

namespace AggregatoryService.Services;

public abstract class ServiceBase
{
    protected readonly Task<HttpClient> _httpClientTask;
    protected readonly ConsulServiceResolver _consulResolver;
    protected ServiceBase(IHttpClientFactory httpClientFactory, ILogger<ServiceBase> logger,ConsulServiceResolver consulResolver, string serviceName)
    {
        _consulResolver = consulResolver;
        _httpClientTask = InitializeHttpClientAsync(httpClientFactory,serviceName);
    }

    private async Task<HttpClient> InitializeHttpClientAsync(IHttpClientFactory httpClientFactory,string serviceName)
    {
        var client = httpClientFactory.CreateClient(); // unnamed/default
        var (address, port) = await _consulResolver.ResolveServiceAsync(serviceName);
        client.BaseAddress = new Uri($"https://{address}:{port}");
        return client;
    }

    protected Task<HttpClient> GetClientAsync()
    {
        return _httpClientTask;
    }
}
public class UserService : ServiceBase, IUserService
{
    
    private readonly ILogger<UserService> _logger;

    public UserService(
        IHttpClientFactory httpClientFactory,
        ConsulServiceResolver consulResolver,
        ILogger<UserService> logger) : base(httpClientFactory, logger, consulResolver, "userservice")
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
