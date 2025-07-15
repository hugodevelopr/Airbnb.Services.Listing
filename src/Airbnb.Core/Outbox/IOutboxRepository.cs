namespace Airbnb.Core.Outbox;

public interface IOutboxRepository
{
    Task<IEnumerable<OutboxMessage>> GetUnpublishedEventAsync();
    Task MarkAsPublishedAsync(OutboxMessage outboxMessage);
}