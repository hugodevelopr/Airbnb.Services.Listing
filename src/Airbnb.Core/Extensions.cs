using Airbnb.Core.Commands.Dispatcher;
using Airbnb.Core.Commands;
using Airbnb.Core.Events.DomainEvents;
using Airbnb.Core.Events.IntegrationEvents;
using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
        => services
            .AddInMemoryCommandDispatcher()
            .AddInMemoryDomainEventDispatcher();

    private static IServiceCollection AddInMemoryCommandDispatcher(this IServiceCollection services)
        => services
            .AddSingleton<ICommandDispatcher, CommandDispatcher>();

    private static IServiceCollection AddInMemoryDomainEventDispatcher(this IServiceCollection services)
    {
        services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();
        services.AddSingleton<IIntegrationEventDispatcher, IntegrationEventDispatcher>();
        return services;
    }
}