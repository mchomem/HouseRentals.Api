namespace HouseRentals.Core.Application.ProfileMappings;

public static class ProfileMapping
{
    public static void RegisterMappings(TypeAdapterConfig config)
    {
        config.NewConfig<Tenant, TenantDto>().TwoWays();
        config.NewConfig<Tenant, TenantInsertDto>().TwoWays();

        config.NewConfig<House, HouseDto>().TwoWays();
        config.NewConfig<House, HouseInsertDto>().TwoWays();

        config.NewConfig<Rental, RentalDto>().TwoWays();
        config.NewConfig<Rental, RentalInsertDto>().TwoWays();
        config.NewConfig<Rental, RentalUpdateDto>().TwoWays();
    }
}
