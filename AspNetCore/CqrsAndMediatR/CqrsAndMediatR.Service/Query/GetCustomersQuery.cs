using CqrsAndMediatR.Domain.Entities;
using MediatR;

namespace CqrsAndMediatR.Service.Query
{
    public class GetCustomersQuery:IRequest<List<Customer>>
    {
    }
}
