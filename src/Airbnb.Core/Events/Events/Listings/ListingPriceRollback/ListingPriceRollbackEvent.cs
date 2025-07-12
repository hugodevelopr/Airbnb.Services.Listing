using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Events.Events.Listings.ListingPriceRollback;

public class ListingPriceRollbackEvent : IDomainEvent
{
    public Guid ListingId { get; set; }
    public decimal CurrentPrice { get; set; }
}