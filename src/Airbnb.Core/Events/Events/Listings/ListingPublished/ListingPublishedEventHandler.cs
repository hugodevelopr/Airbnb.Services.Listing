using Airbnb.Core.Events.DomainEvents;

namespace Airbnb.Core.Events.Events.Listings.ListingPublished;

public class ListingPublishedEventHandler : IDomainEventHandler<ListingPublishedEvent>
{
    public async Task HandleAsync(ListingPublishedEvent @event)
    {
        throw new NotImplementedException();
    }
}