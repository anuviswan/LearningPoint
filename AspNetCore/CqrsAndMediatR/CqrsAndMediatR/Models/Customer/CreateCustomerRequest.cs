namespace CqrsAndMediatR.Api.Models.Customer;
public record CreateCustomerRequest
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public List<AddressModel> AddressList { get; init; } = new List<AddressModel>();
}
