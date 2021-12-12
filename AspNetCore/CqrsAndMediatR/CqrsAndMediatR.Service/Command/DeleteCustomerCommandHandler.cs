namespace CqrsAndMediatR.Service.Command
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository) => _customerRepository = customerRepository;
        
        public async Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _customerRepository.DeleteAsync(request.Customer);
        }
    }
}
