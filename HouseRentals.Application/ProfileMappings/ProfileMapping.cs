namespace HouseRentals.Application.ProfileMappings;

public class ProfileMapping : Profile
{
    public ProfileMapping()
    {
        CreateMap<Tenant, TenantDto>().ReverseMap();
        CreateMap<Tenant, TenantInsertDto>().ReverseMap();

        CreateMap<House, HouseDto>().ReverseMap();
        CreateMap<House, HouseInsertDto>().ReverseMap();

        CreateMap<Rental, RentalDto>().ReverseMap();
        CreateMap<Rental, RentalInsertDto>().ReverseMap();
        CreateMap<Rental, RentalUpdateDto>().ReverseMap();
    }
}
