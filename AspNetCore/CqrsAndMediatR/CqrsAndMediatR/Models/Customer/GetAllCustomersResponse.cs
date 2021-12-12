namespace CqrsAndMediatR.Api.Models.Customer;
public class GetAllCustomersResponse
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public List<AddressModel> AddressList { get; init; } = new List<AddressModel>();
}
