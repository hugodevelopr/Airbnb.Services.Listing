using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Events.Events.Listings.ListingPriceUpdated;

public class ListingPriceUpdatedEvent : IDomainEvent
{
    public Guid ListingId { get; set; }
    public decimal NewPrice { get; set; }
}