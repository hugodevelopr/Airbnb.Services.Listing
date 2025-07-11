using Airbnb.Core.Events.DomainEvents;

namespace Airbnb.Core.Events.Events.Listings.ListingCreated;

public class ListingCreatedEventHandler : IDomainEventHandler<ListingCreatedEvent>
{
    public async Task HandleAsync(ListingCreatedEvent @event)
    {
        throw new NotImplementedException();
    }
}