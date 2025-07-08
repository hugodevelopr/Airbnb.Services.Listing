using Airbnb.SharedKernel.Events;

namespace Airbnb.SharedKernel.Aggregates;

public abstract class AggregateRoot
{
    protected AggregateRoot()
    {
        _changes = new List<IDomainEvent>();
    }

    public int Version { get; private set; } = -1;
    private readonly List<IDomainEvent> _changes;

    public void Load(IEnumerable<IDomainEvent> changes)
    {
        if (changes == null) 
            throw new ArgumentNullException(nameof(changes));


        foreach (var change in changes)
        {
            ApplyChange(change);
            Version++;
        }

        ClearChanges();
    }

    public IEnumerable<IDomainEvent> GetChanges()
    {
        return _changes.AsReadOnly();
    }

    public void ClearChanges()
    {
        _changes.Clear();
    }

    protected virtual void ApplyChange(IDomainEvent @event)
    {
        Apply((dynamic)@event);
        _changes.Add(@event);
    }

    protected abstract void Apply(IDomainEvent @event);
}