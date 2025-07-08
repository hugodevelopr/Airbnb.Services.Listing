using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Events.DomainEvents;

public interface IDomainEventDispatcher
{
    Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IDomainEvent;
}