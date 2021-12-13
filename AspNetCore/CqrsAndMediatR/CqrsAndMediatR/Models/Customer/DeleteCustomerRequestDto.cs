namespace CqrsAndMediatR.Api.Models.Customer;
public record DeleteCustomerRequestDto
{
    [Required]
    public long Id { get; set; }
}
