using WinWinCinema.Api.Services.Interfaces;
using WinWinCinema.Api.Services.Implementations;
using WinWinCinema.Api.UnitOfWork;
using WinWinCinema.Api.Mappings;

namespace WinWinCinema.Api.Extensions;

internal static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddAutoMapper(cfg => cfg.AddProfile<LocationProfile>());
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAddressService, AddressService>();
        //services.AddScoped<ICinemaService, CinemaService>();
        return services;
    }

    public static IServiceCollection AddDatabaseService(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = GetDatabaseConnectionString(configuration);
        return services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
    }

    private static string GetDatabaseConnectionString(IConfiguration configuration)
    {
        return configuration.GetConnectionString("DbConnection")!;
    }
}
