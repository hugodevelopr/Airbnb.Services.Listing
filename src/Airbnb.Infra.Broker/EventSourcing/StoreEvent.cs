using Airbnb.Infra.Broker.Publisher;
using Airbnb.SharedKernel.Events;
using Newtonsoft.Json;

namespace Airbnb.Infra.Broker.EventSourcing;

public class StoreEvent(IEventPublisher publisher) : IStoreEvent
{
    public async Task SaveEventAsync(IDomainEvent @event, Guid aggregateId, Guid actorId)
    {
        var eventData = new EventData()
        {
            AggregateId = aggregateId,
            ActorId = actorId,
            EventName = @event.GetType().Name,
            AssemblyQualifiedName = @event.GetType().AssemblyQualifiedName!,
            Payload = JsonConvert.SerializeObject(@event),
            CreatedAt = DateTime.UtcNow
        };

        await publisher.PublishAsync(eventData, "event-store");
    }
}