using Microsoft.Extensions.Options;

namespace AggregatoryService.Services;

public abstract class ServiceBase
{
    protected readonly Task<HttpClient> _httpClientTask;
    protected readonly ConsulServiceResolver _consulResolver;
    protected ServiceBase(IHttpClientFactory httpClientFactory, ILogger<ServiceBase> logger,ConsulServiceResolver consulResolver,IOptions<ServiceDiscoveryOptions> serviceDiscoveryOptions, string serviceName)
    {
        _consulResolver = consulResolver;
        var registeredService = serviceDiscoveryOptions.Value.Services.FirstOrDefault(s => s.Key == serviceName)?.Name;
        if (registeredService == null)
        {
            logger.LogError("Service {ServiceName} not found in service discovery options", serviceName);
            throw new ArgumentException($"Service {serviceName} not found in service discovery options");
        }

        _httpClientTask = InitializeHttpClientAsync(httpClientFactory,registeredService);
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
