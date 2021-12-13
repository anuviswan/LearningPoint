namespace CqrsAndMediatR.Service.Query;
public class FindCustomerQuery:IRequest<Customer>
{
    public long CustomerId { get; set; }
}
