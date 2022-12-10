using MassTransit;
using Saga.Services.PaymentService.Entities;
using Saga.Services.PaymentService.Repositories;
using Saga.Shared.Contracts.Events;

namespace Saga.Services.PaymentService.Services;

public interface IPaymentService
{
    void MakePayment(CustomerPayment customerPayment);

    void ConfirmPayment(Guid orderId);

    void CancelPayment(Guid orderId);
}
public class PaymentService : IPaymentService
{
    private readonly ILogger<PaymentService> _logger;
    private readonly ICustomerPaymentRepository _customerPaymentRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    public PaymentService(ICustomerPaymentRepository customerPaymentRepository,
        IPublishEndpoint publishEndpoint,
        ILogger<PaymentService> logger)
    {
        _logger = logger;
        _customerPaymentRepository = customerPaymentRepository;
        _publishEndpoint = publishEndpoint;
    }
    public void MakePayment(CustomerPayment customerPayment)
    {
        _logger.LogInformation($"Adding new Payment record");
        _customerPaymentRepository.Insert(customerPayment);
    }

    public void ConfirmPayment(Guid orderId)
    {
        _logger.LogInformation($"Confirming payment for OrderId #{orderId}");
        try
        {
            var payment = _customerPaymentRepository.GetForOrderId(orderId);
            var updatedPayment = payment with { State = PaymentState.Accepted };
            _customerPaymentRepository.Update(updatedPayment);
            _logger.LogInformation($"Confirming payment for OrderId #{orderId}");
        }
        catch
        {
            throw new Exception($"Unable to confirm payment for OrderId #{orderId}");
        }
        
    }

    public void CancelPayment(Guid orderId)
    {
        _logger.LogInformation($"Cancelling payment for OrderId #{orderId}");
        try
        {
            var payment = _customerPaymentRepository.GetForOrderId(orderId);
            var updatedPayment = payment with { State = PaymentState.Rejected };
            var result = _customerPaymentRepository.Update(updatedPayment);

            if(result is { State : PaymentState.Failed or PaymentState.Rejected}) 
            {
                _publishEndpoint.Publish(new PaymentFailed
                {
                    OrderId = orderId,
                    Reason = "Payment Cancelled"
                });
            }

            _logger.LogInformation($"Cancelled payment for OrderId #{orderId}");
        }
        catch
        {
            throw new Exception($"Unable to cancel payment for OrderId #{orderId}");
        }

    }
}
