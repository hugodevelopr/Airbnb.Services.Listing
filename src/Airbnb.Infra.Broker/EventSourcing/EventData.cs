using Airbnb.SharedKernel;
using Airbnb.SharedKernel.Events;

namespace Airbnb.Infra.Broker.EventSourcing;

public class EventData : IIntegrationEvent
{
    public Guid Id { get; set; }
    public Guid AggregateId { get; set; }
    public string EventName { get; set; } = string.Empty;
    public string Payload { get; set; } = string.Empty;
    public string AssemblyQualifiedName { get; set; } = string.Empty;
    public string ServiceName { get; private set; } = AirbnbSettings.ServiceName;
    public Guid ActorId { get; set; }
    public DateTime CreatedAt { get; set; }
}