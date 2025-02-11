using Microsoft.OpenApi.Models;
using System.Reflection;

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

    public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
                        Url = new Uri("https://www.linkedin.com/in/misael-da-costa-homem-8b07a158/")
                    },
                });

            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }
}
