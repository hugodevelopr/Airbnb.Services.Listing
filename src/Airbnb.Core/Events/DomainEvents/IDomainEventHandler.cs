using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Events.DomainEvents;

public interface IDomainEventHandler<in TEvent> where TEvent : class, IDomainEvent
{
    Task HandleAsync(TEvent @event);
}