using Airbnb.Infra.Broker.Publisher;
using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Infra.Broker;

public static class Extensions
{
    public static IServiceCollection AddBroker(this IServiceCollection services)
    {
        services.AddScoped<IEventPublisher, ServiceBusPublisher>();
        return services;
    }
}