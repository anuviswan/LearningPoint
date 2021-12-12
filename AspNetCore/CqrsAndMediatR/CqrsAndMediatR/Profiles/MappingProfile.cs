using AutoMapper;
using CqrsAndMediatR.Api.Models.Customer;
using CqrsAndMediatR.Domain.Entities;

namespace CqrsAndMediatR.Api.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddressModel, Address>().ReverseMap();
        CreateMap<Customer, GetAllCustomersResponse>();

        CreateMap<CreateCustomerRequest, Customer>();
        CreateMap<Customer, CreateCustomerResponse>();
        
        CreateMap<DeleteCustomerRequest, Customer>();
        CreateMap<Customer,DeleteCustomerResponse>();
    }
}