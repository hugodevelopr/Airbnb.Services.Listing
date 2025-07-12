using Airbnb.Core.Events.DomainEvents;
using Airbnb.Core.Events.Events.Listings.ListingPriceUpdated;

namespace Airbnb.Core.Events.Events.Listings.ListingPriceRollback;

public class ListingPriceUpdatedEventHandler : IDomainEventHandler<ListingPriceUpdatedEvent>
{
    public async Task HandleAsync(ListingPriceUpdatedEvent @event)
    {
        throw new NotImplementedException();
    }
}