﻿using Airbnb.Core.Events.DomainEvents;

namespace Airbnb.Core.Events.Events.Listings.ListingPriceUpdated;

public class ListingPriceUpdatedEventHandler : IDomainEventHandler<ListingPriceUpdatedEvent>
{
    public async Task HandleAsync(ListingPriceUpdatedEvent @event)
    {
        throw new NotImplementedException();
    }
}