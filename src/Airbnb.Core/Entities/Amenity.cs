using Airbnb.SharedKernel.Entities;

namespace Airbnb.Core.Entities;

public class Amenity : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
}