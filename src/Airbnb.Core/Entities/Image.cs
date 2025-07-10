using Airbnb.SharedKernel.Entities;
using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Entities;

public class Image : BaseEntity
{
    public string Url { get; private set; } = string.Empty;
    public bool IsCoverPhoto { get; private set; }
    public int Order { get; private set; }
    public Guid ListingId { get; private set; }
    public virtual Listing Listing { get; private set; } = null!;

    protected override void Apply(IDomainEvent @event)
    {
        throw new NotImplementedException();
    }
}