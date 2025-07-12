using Airbnb.Api.Infrastructure.Filters;
using Airbnb.Infra.DependencyInjection;
using Airbnb.Infra.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Airbnb.Api.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddAirbnb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add<UserContextInjectionFilter>();
        });

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