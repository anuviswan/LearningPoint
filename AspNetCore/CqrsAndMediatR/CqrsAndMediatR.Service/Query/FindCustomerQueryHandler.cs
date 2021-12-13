namespace CqrsAndMediatR.Service.Query;
public class FindCustomerQueryHandler : IRequestHandler<FindCustomerQuery, Customer>
{
    private readonly ICustomerRepository _customerRepository;

    public FindCustomerQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<Customer> Handle(FindCustomerQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetByIdAsync(request.CustomerId);
    }
}
