using Airbnb.Core.Events.IntegrationEvents;

namespace Airbnb.AppService.Integrations.Listings.ListingCreated;

public class ListingCreatedIntegrationHandler : IIntegrationEventHandler<ListingCreatedIntegrationEvent>
{
    public async Task HandleAsync(ListingCreatedIntegrationEvent @event)
    {
        throw new NotImplementedException();
    }
}