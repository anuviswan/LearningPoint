using CqrsAndMediatR.Data.Repository;
using CqrsAndMediatR.Domain.Entities;
using MediatR;

namespace CqrsAndMediatR.Service.Query
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return _customerRepository.GetAll().ToList();
        }
    }
}
