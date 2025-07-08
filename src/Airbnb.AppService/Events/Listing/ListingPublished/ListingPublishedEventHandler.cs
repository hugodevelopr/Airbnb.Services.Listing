using Airbnb.Core.Events.DomainEvents;

namespace Airbnb.AppService.Events.Listing.ListingPublished;

public class ListingPublishedEventHandler : IDomainEventHandler<ListingPublishedEvent>
{
    public async Task HandleAsync(ListingPublishedEvent @event)
    {
        throw new NotImplementedException();
    }
}