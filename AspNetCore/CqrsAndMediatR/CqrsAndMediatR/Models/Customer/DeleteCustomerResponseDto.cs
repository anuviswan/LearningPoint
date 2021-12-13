namespace CqrsAndMediatR.Api.Models.Customer;
public record DeleteCustomerResponseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}