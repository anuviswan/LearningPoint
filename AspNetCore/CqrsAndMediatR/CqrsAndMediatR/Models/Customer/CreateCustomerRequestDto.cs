namespace CqrsAndMediatR.Api.Models.Customer;
public record CreateCustomerRequestDto
{
    [Required]
    [MinLength(6,ErrorMessage = $"{nameof(FirstName)} should have minimum 6 characters")]  
    public string FirstName { get; init; }
    [Required]
    [MinLength(6, ErrorMessage = $"{nameof(LastName)} should have minimum 6 characters")]
    public string LastName { get; init; }
    public List<AddressModel> AddressList { get; init; } = new List<AddressModel>();
}
