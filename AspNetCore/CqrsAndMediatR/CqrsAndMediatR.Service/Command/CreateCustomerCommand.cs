using CqrsAndMediatR.Domain.Entities;
using MediatR;

namespace CqrsAndMediatR.Service.Command
{
    public class CreateCustomerCommand:IRequest<Customer>
    {
        public Customer Customer { get; set; }
    }
}
