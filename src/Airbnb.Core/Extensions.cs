using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}