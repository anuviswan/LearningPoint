namespace CqrsAndMediatR.Data.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}

        public IEnumerable<Address> AddressList { get; set; }
    }
}
