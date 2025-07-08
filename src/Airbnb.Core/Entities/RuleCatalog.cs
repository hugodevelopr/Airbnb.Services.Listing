using Airbnb.SharedKernel.Entities;
using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Entities;

public class RuleCatalog : BaseEntity
{
    public string Key { get; private set; } = string.Empty;                   // e.g., "no_smoking", "no_pets"
    public string Title { get; private set; } = string.Empty;
    public string? DescriptionTemplate { get; private set; }

    private readonly List<RuleParameterDefinition> _parameterDefinitions = new();
    public IReadOnlyCollection<RuleParameterDefinition> ParameterDefitions => _parameterDefinitions.AsReadOnly();

    private RuleCatalog()
    {
    }

    public RuleCatalog(string key, string title, string? descriptionTemplate = null)
    {
        Id = Guid.NewGuid();
        Key = key;
        Title = title;
        DescriptionTemplate = descriptionTemplate;
    }

    public void AddParameter(string name, string type, string? defaultValue = null)
    {
        _parameterDefinitions.Add(new RuleParameterDefinition(Id, name, type, defaultValue));
    }

    protected override void Apply(IDomainEvent @event)
    {
        throw new NotImplementedException();
    }
}