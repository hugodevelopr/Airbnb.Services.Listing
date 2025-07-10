using Airbnb.SharedKernel.Entities;
using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Entities;

public class Listing : BaseEntity
{
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public PropertyType Type { get; private set; }
    public ListingStatus Status { get; private set; }
    public int Bathrooms { get; private set; }
    public int Bedrooms { get; private set; }
    public int Beds { get; private set; }
    public Guid HostId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public virtual Location Location { get; private set; } = null!;
    public virtual Price Price { get; private set; } = null!;
    public virtual Availability Availability { get; private set; } = null!;

    private readonly List<Image> _images = new();
    public IReadOnlyCollection<Image> Images => _images.AsReadOnly();

    private readonly List<ListingRule> _rules = new();
    public IReadOnlyCollection<ListingRule> Rules => _rules.AsReadOnly();

    public void AddRule(ListingRule rule)
    {
        _rules.Add(rule);
    }

    public enum PropertyType
    {
        Apartment = 2,
        House = 4,
        Studio = 6,
        Other = 9
    }

    public enum ListingStatus
    {
        Draft = 2,
        Published = 4,
        Unlisted = 6,
    }

    protected override void Apply(IDomainEvent @event)
    {
        throw new NotImplementedException();
    }
}