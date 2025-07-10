using Airbnb.Infra.DependencyInjection;
using Airbnb.Infra.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Api.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddAirbnb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddOpenApi();

        services.AddDbContext<AirbnbDbContext>(options =>
        {
            options.EnableDetailedErrors();
            options.UseSqlServer(configuration.GetConnectionString("AirbnbDb"), sqlOptions =>
            {
                sqlOptions.MigrationsAssembly("Airbnb.Api");
                sqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", "Airbnb");
            });
        });

        services.AddAirbnbDependencies(configuration);
        return services;
    }
}