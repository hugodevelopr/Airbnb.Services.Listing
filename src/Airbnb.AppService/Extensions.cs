using Airbnb.AppService.Integrations.Listings.ListingPublished;
using Airbnb.AppService.Services;
using Airbnb.Core.Events.DomainEvents;
using Airbnb.Core.Events.Events.Listings.ListingPublished;
using Airbnb.Core.Events.Events.Listings.ListingUpdated;
using Airbnb.Core.Events.IntegrationEvents;
using Airbnb.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.AppService;

public static class Extensions
{
    public static IServiceCollection AddAppService(this IServiceCollection services)
    {
        services
            .AddScoped<IListingService, ListingService>()
            .AddScoped<ILocalizeMessageService, LocalizeMessageService>()
            .AddDomainEventHandlers()
            .AddIntegrationEventHandlers();

        return services;
    }


    private static IServiceCollection AddDomainEventHandlers(this IServiceCollection services)
    {
        services
            .AddTransient<IDomainEventHandler<ListingUpdatedEvent>, ListingUpdatedEventHandler>()
            .AddTransient<IDomainEventHandler<ListingPublishedEvent>, ListingPublishedEventHandler>();

        return services;
    }

    private static IServiceCollection AddIntegrationEventHandlers(this IServiceCollection services)
    {
        services
            .AddTransient<IIntegrationEventHandler<ListingPublishedIntegrationEvent>, ListingPublishedIntegrationHandler>();

        return services;
    }
}