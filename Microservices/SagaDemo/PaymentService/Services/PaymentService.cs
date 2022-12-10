using Saga.Services.PaymentService.Entities;

namespace Saga.Services.PaymentService.Services;

public interface IPaymentService
{
    void MakePayment(CustomerPayment customerPayment);
}
public class PaymentService : IPaymentService
{
    private readonly ILogger<PaymentService> _logger;
    public PaymentService(ILogger<PaymentService> logger)
    {
        _logger = logger;
    }
    public void MakePayment(CustomerPayment customerPayment)
    {
        throw new NotImplementedException();
    }
}
