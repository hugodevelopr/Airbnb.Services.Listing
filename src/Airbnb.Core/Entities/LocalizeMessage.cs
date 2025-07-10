using Airbnb.SharedKernel.Entities;
using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Entities;

public class LocalizeMessage : BaseEntity
{
    public string Language { get; private set; } = string.Empty;
    public string Key { get; private set; } = string.Empty;
    public string MessageTemplate { get; private set; } = string.Empty;

    protected override void Apply(IDomainEvent @event)
    {
        throw new NotImplementedException();
    }
}