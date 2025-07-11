using Airbnb.SharedKernel.Events;

namespace Airbnb.Infra.Broker.EventSourcing;

public interface IStoreEvent
{
    Task SaveEventAsync(IDomainEvent @event, Guid aggregateId, Guid actorId);
}