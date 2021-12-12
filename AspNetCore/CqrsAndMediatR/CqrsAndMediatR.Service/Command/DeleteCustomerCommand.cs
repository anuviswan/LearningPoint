namespace CqrsAndMediatR.Service.Command;
public class DeleteCustomerCommand : IRequest<Customer>
{
    public Customer Customer { get; set; }
}
