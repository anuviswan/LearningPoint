using Consul;
using Microsoft.Extensions.Options;

namespace AggregatoryService;

public class ConsulServiceResolver : IDisposable
{
    private readonly ConsulClient _client;
    private bool _disposed = false;
    public ConsulServiceResolver(IOptions<ServiceDiscoveryOptions> serviceDiscoveryOptions)
    {
        var serviceDiscovery = serviceDiscoveryOptions.Value;
        _client = new ConsulClient(cfg => cfg.Address = new Uri($"http://{serviceDiscovery.ResolverName}:{serviceDiscovery.ResolverPort}"));
    }

    /// <summary>
    /// Resolves a healthy instance of the given service name from Consul.
    /// </summary>
    public async Task<(string Address, int Port)> ResolveServiceAsync(string serviceName)
    {
        var result = await _client.Health.Service(serviceName, tag: null, passingOnly: true);

        if (result.Response == null || result.Response.Length == 0)
            throw new Exception($"No healthy instances found for service '{serviceName}'");

        var serviceEntry = result.Response.First();

        return (serviceEntry.Service.Address, serviceEntry.Service.Port);
    }


    public void Dispose()   
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            // Dispose managed state (managed objects).
            _client?.Dispose();
        }
        _disposed = true;
    }

    // Destructor (finalizer) only if needed
    ~ConsulServiceResolver()
    {
        Dispose(false);
    }
}