namespace CqrsAndMediatR.Api.Models.Customer;
public record AddressModel
{
    public string HouseName { get; init; }
    public string Street { get; init; }
    public string District { get; init; }
    public string State { get; init; }
    public string Pincode { get; init; }
    public string Country { get; init; }
}