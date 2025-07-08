using Airbnb.SharedKernel.Aggregates;

namespace Airbnb.SharedKernel.Entities;

public abstract class BaseEntity : AggregateRoot
{
    public Guid Id { get; set; }
}