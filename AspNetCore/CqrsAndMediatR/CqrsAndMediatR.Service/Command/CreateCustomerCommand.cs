namespace CqrsAndMediatR.Service.Command;
public class CreateCustomerCommand : IRequest<Customer>
{
    public Customer Customer { get; set; }
}
