namespace CqrsAndMediatR.Domain.Entities;
public class Customer:IEntity
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set;}
    public IEnumerable<Address> AddressList { get; set; }
}
