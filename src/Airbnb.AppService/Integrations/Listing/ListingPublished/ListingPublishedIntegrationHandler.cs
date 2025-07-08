using Airbnb.Core.Events.IntegrationEvents;

namespace Airbnb.AppService.Integrations.Listing.ListingPublished;

public class ListingPublishedIntegrationHandler : IIntegrationEventHandler<ListingPublishedIntegrationEvent>
{
    public async Task HandleAsync(ListingPublishedIntegrationEvent @event)
    {
        throw new NotImplementedException();
    }
}