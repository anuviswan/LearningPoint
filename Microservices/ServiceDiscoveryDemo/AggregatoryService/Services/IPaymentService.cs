using System.Text.Json.Serialization;

namespace AggregatoryService.Services;

public interface IPaymentService
{
    Task<IEnumerable<PaymentInfo>?> GetPaymentInfo(string userName);
}
public record PaymentInfo(
    [property: JsonPropertyName("userName")] string UserName, [property: JsonPropertyName("amount")] string Amount,
    [property: JsonPropertyName("currency")] string Currency, [property: JsonPropertyName("status")] string Status);