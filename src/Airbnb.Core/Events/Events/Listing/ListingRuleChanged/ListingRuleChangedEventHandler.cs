using Airbnb.Core.Events.DomainEvents;

namespace Airbnb.Core.Events.Events.Listing.ListingRuleChanged;

public class ListingRuleChangedEventHandler : IDomainEventHandler<ListingRuleChangedEvent>
{
    public async Task HandleAsync(ListingRuleChangedEvent @event)
    {
        throw new NotImplementedException();
    }
}