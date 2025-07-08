using Airbnb.AppService;
using Airbnb.Core;
using Airbnb.Infra.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Infra.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddAirbnbDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAppService();
        services.AddCore();
        services.AddRepository();

        return services;
    }
}