using Airbnb.SharedKernel.Entities;
using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Entities;

public class Amenity : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    protected override void Apply(IDomainEvent @event)
    {
        throw new NotImplementedException();
    }
}