
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AggregatoryService.Services;

public class PaymentService : ServiceBase, IPaymentService
{
    private readonly ILogger<PaymentService> _logger;
    public PaymentService(
        IHttpClientFactory httpClientFactory,
        ConsulServiceResolver consulResolver,
        ILogger<PaymentService> logger,
        IOptions<ServiceDiscoveryOptions> serviceDiscovery) : base(httpClientFactory, logger, consulResolver, serviceDiscovery, nameof(PaymentService))
    {
        _logger = logger;
    }
    public async Task<IEnumerable<PaymentInfo>?> GetPaymentInfo(string userName)
    {
        var client = await GetClientAsync();
        var response = await client.GetAsync($"/payment/GetPaymentInfo?userName={userName}");
        if (response.IsSuccessStatusCode)
        {
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<PaymentInfo>>(responseJson);
        }
        else
        {
            _logger.LogError($"Failed to get user with userName {userName}. Status code: {response.StatusCode}");
            throw new Exception($"Failed to get user with userName {userName}. Status code: {response.StatusCode}");
        }
    }
}
