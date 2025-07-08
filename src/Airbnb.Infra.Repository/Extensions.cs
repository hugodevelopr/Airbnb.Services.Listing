using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Infra.Repository;

public static class Extensions
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        return services;
    }
}