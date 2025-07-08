using Airbnb.SharedKernel.Events;

namespace Airbnb.Core.Events.IntegrationEvents;

public interface IIntegrationEventHandler<in TEvent> where TEvent : IIntegrationEvent
{
    Task HandleAsync(TEvent @event);
}