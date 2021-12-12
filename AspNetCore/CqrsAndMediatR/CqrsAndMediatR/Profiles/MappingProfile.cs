using AutoMapper;
using CqrsAndMediatR.Api.Models.Customer;
using CqrsAndMediatR.Domain.Entities;

namespace CqrsAndMediatR.Api.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerModel, Customer>();
            CreateMap<AddressModel,Address>();
        }
    }
}
