using Airbnb.Core.ValueObject;
using Airbnb.SharedKernel.Entities;

namespace Airbnb.Core.Entities;

public class Location : BaseEntity
{
    public Address Address { get; private set; } 
    public int Latitude { get; private set; }
    public int Longitude { get; private set; }
}