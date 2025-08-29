using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Extensions;

internal static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
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
