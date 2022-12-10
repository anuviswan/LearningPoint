using Saga.Services.PaymentService.Entities;
using Saga.Services.PaymentService.Repositories;

namespace Saga.Services.PaymentService.Services;

public interface IPaymentService
{
    void MakePayment(CustomerPayment customerPayment);
}
public class PaymentService : IPaymentService
{
    private readonly ILogger<PaymentService> _logger;
    private readonly ICustomerPaymentRepository _customerPaymentRepository;
    public PaymentService(ICustomerPaymentRepository customerPaymentRepository, ILogger<PaymentService> logger)
    {
        _logger = logger;
        _customerPaymentRepository = customerPaymentRepository;
    }
    public void MakePayment(CustomerPayment customerPayment)
    {
        _logger.LogInformation($"Adding new Payment record");
        _customerPaymentRepository.Insert(customerPayment);
    }
}
