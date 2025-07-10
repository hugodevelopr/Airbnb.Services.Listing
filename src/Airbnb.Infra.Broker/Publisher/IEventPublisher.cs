using Airbnb.SharedKernel.Events;

namespace Airbnb.Infra.Broker.Publisher;

public interface IEventPublisher
{
    Task PublishAsync<T>(T @event, string topicOrQueue, CancellationToken cancellation = default) where T : class, IIntegrationEvent;
}