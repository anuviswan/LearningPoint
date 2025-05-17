
using System.Text.Json;

namespace AggregatoryService.Services;

public class PaymentService : IPaymentService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<PaymentService> _logger;
    public PaymentService(HttpClient httpClient, ILogger<PaymentService> logger)
    {
        (_httpClient, _logger) = (httpClient, logger);
    }
    public async Task<IEnumerable<PaymentInfo>?> GetPaymentInfo(string userName)
    {
        return Enumerable.Empty<PaymentInfo>();
        //var response = await _httpClient.GetAsync($"/payment/GetPaymentInfo?userName={userName}");
        //if (response.IsSuccessStatusCode)
        //{
        //    var responseJson = await response.Content.ReadAsStringAsync();
        //    return JsonSerializer.Deserialize<IEnumerable<PaymentInfo>>(responseJson);
        //}
        //else
        //{
        //    _logger.LogError($"Failed to get user with userName {userName}. Status code: {response.StatusCode}");
        //    throw new Exception($"Failed to get user with userName {userName}. Status code: {response.StatusCode}");
        //}
    }
}
