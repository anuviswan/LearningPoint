namespace CqrsAndMediatR.Api.Models.Customer
{
    public record CreateCustomerModel
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public List<AddressModel> AddressList { get; init; } = new List<AddressModel>();
    }

    public record AddressModel
    {
        public string HouseName { get; init; }
        public string Street { get; init; }
        public string District { get; init; }
        public string State { get; init; }
        public string Pincode { get; init; }
        public string Country { get; init; }
    }
}
