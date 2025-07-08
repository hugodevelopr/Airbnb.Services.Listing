using Airbnb.SharedKernel.Entities;
using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Entities;

public class ListingRule : BaseEntity
{
    public Guid ListingId { get; private set; }
    public Guid RuleCatalogId { get; private set; }
    public virtual Listing Listing { get; private set; } = null!;
    public virtual RuleCatalog RuleCatalog { get; private set; } = null!;

    private readonly Dictionary<string, string> _parameters = new();
    public IReadOnlyDictionary<string, string> Parameters => _parameters;

    private ListingRule()
    {
    }

    public ListingRule(Guid listingId, Guid ruleCatalogId, Dictionary<string, string> parameters)
    {
        Id = Guid.NewGuid();
        ListingId = listingId;
        RuleCatalogId = ruleCatalogId;
        _parameters = parameters;
    }

    public string? GetParameter(string key)
    {
        return _parameters.GetValueOrDefault(key);
    }

    protected override void Apply(IDomainEvent @event)
    {
        throw new NotImplementedException();
    }
}