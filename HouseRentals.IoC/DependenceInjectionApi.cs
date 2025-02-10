namespace HouseRentals.IoC;

public static class DependenceInjectionApi
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<AppDbContext, AppDbContext>();
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<ITenantRepository, TenantRepository>();
        services.AddScoped<IHouseRepository, HouseRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();
        
        services.AddScoped<ITenantService, TenantService>();
        services.AddScoped<IHouseService, HouseService>();
        services.AddScoped<IRentalService, RentalService>();

        services.AddAutoMapper(typeof(ProfileMapping));

        return services;
    }
}
