using Airbnb.Core.Events.DomainEvents;

namespace Airbnb.Core.Events.Events.Listing.ListingUpdated;

public class ListingUpdatedEventHandler : IDomainEventHandler<ListingUpdatedEvent>
{
    public async Task HandleAsync(ListingUpdatedEvent @event)
    {
        throw new NotImplementedException();
    }
}