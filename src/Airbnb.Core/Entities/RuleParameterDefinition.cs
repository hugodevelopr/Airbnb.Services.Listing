using Airbnb.SharedKernel.Entities;
using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Entities;

public class RuleParameterDefinition : BaseEntity
{
    public string Name { get; private set; } = string.Empty;                    // e.g. "max_guests"
    public string Type { get; private set; } = string.Empty;                    // e.g. "bool", "int", "string", "decimal", etc.
    public string? DefaultValue { get; private set; }
    public Guid RuleCatalogId { get; private set; }
    public virtual RuleCatalog RuleCatalog { get; private set; } = null!;

    private RuleParameterDefinition()
    {
    }

    public RuleParameterDefinition(Guid ruleCatalogId, string name, string type, string? defaultValue)
    {
        Id = Guid.NewGuid();
        Name = name;
        Type = type;
        DefaultValue = defaultValue;
        RuleCatalogId = ruleCatalogId;
    }

    protected override void Apply(IDomainEvent @event)
    {
        throw new NotImplementedException();
    }
}