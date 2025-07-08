using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Events.IntegrationEvents;

public interface IIntegrationEventDispatcher
{
    Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IIntegrationEvent;
}