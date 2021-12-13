namespace CqrsAndMediatR.Api.Models.Customer;
public record CreateCustomerResponseDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public List<AddressModel> AddressList { get; init; } = new List<AddressModel>();
}
