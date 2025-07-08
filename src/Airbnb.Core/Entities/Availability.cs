using Airbnb.SharedKernel.Entities;

namespace Airbnb.Core.Entities;

public class Availability : BaseEntity
{
    public TimeOnly CheckInTime { get; private set; }
    public TimeOnly CheckOutTime { get; private set; }
    public int MinimumNights { get; private set; }
    public int MaximumNights { get; private set; }
    public List<DateOnly> BlockedDates { get; private set; } = new();
}