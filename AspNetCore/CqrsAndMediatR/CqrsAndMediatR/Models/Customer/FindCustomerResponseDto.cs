namespace CqrsAndMediatR.Api.Models.Customer;
public record FindCustomerResponseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}