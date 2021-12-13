namespace CqrsAndMediatR.Api.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddressModel, Address>().ReverseMap();
        CreateMap<Customer, GetAllCustomersResponseDto>();

        CreateMap<CreateCustomerRequestDto, Customer>();
        CreateMap<Customer, CreateCustomerResponseDto>();
        
        CreateMap<DeleteCustomerRequestDto, Customer>();
        CreateMap<Customer,DeleteCustomerResponseDto>();

        CreateMap<Customer, FindCustomerResponseDto>();
    }
}