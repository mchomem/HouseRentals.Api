namespace HouseRentals.Api.ProfileMappings;

public class ProfileMapping : Profile
{
    public ProfileMapping()
    {
        CreateMap<Tenant, TenantDto>().ReverseMap();
    }
}
