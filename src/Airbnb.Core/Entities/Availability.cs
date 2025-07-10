using Airbnb.SharedKernel.Entities;
using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Entities;

public class Availability : BaseEntity
{
    public TimeOnly CheckInTime { get; private set; }
    public TimeOnly CheckOutTime { get; private set; }
    public int MinimumNights { get; private set; }
    public int MaximumNights { get; private set; }
    public List<DateOnly> BlockedDates { get; private set; } = new();
    public Guid ListingId { get; private set; }

    protected override void Apply(IDomainEvent @event)
    {
        throw new NotImplementedException();
    }
}