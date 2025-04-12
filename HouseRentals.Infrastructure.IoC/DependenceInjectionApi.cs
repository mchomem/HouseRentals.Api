namespace HouseRentals.IoC;

public static class DependenceInjectionApi
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region Database

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<AppDbContext, AppDbContext>();

        #endregion

        #region Repositories

        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<ITenantRepository, TenantRepository>();
        services.AddScoped<IHouseRepository, HouseRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();

        #endregion

        #region Services

        services.AddScoped<ITenantService, TenantService>();
        services.AddScoped<IHouseService, HouseService>();
        services.AddScoped<IRentalService, RentalService>();

        #endregion

        #region Mapster

        var config = TypeAdapterConfig.GlobalSettings;
        ProfileMapping.RegisterMappings(config);
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        services.AddMapster();

        #endregion

        return services;
    }

    public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        var linkedinProfile = "https://www.linkedin.com/in/misael-da-costa-homem-8b07a158/";

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => {
            options.SwaggerDoc(
                "v1"
                , new OpenApiInfo
                {
                    Title = "HouseRentals.Api",
                    Version = "v1",
                    Description = "Web Api to control house rentals.",
                    Contact = new OpenApiContact
                    {
                        Name = "Misael C. Homem",
                        Email = "misael.homem@gmail.com",
                        Url = new Uri(linkedinProfile)
                    },
                });

            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }
}
