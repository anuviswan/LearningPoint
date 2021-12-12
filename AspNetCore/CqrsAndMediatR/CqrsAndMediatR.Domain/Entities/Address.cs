namespace CqrsAndMediatR.Domain.Entities;
public class Address:IEntity
{
    public long Id { get; set; }
    public string HouseName { get; set; }
    public string Street { get; set; }
    public string District { get; set; }
    public string State { get; set; }
    public string Pincode { get; set; }
    public string Country { get; set; }
}
