using Airbnb.SharedKernel.Entities;

namespace Airbnb.Core.Entities;

public class RuleParameterDefinition : BaseEntity
{
    public string Name { get; private set; } = string.Empty;                    // e.g. "max_guests"
    public string Type { get; private set; } = string.Empty;                    // e.g. "bool", "int", "string", "decimal", etc.
    public string? DefaultValue { get; private set; }
    public Guid RuleCatalogId { get; private set; }

    private RuleParameterDefinition()
    {
    }

    public RuleParameterDefinition(string name, string type, string? defaultValue, Guid ruleCatalogId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Type = type;
        DefaultValue = defaultValue;
        RuleCatalogId = ruleCatalogId;
    }
}