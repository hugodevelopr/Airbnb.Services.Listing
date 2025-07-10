using Airbnb.Core.ValueObject;
using Airbnb.SharedKernel.Entities;
using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Entities;

public class Location : BaseEntity
{
    public Address? Address { get; private set; } 
    public int Latitude { get; private set; }
    public int Longitude { get; private set; }

    protected override void Apply(IDomainEvent @event)
    {
        throw new NotImplementedException();
    }
}