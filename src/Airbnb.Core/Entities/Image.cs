using Airbnb.SharedKernel.Entities;

namespace Airbnb.Core.Entities;

public class Image : BaseEntity
{
    public string Url { get; private set; } = string.Empty;
    public bool IsCoverPhoto { get; private set; }
    public int Order { get; private set; }
    public Guid ListingId { get; private set; }
}