using Airbnb.Core.Outbox;
using Airbnb.Infra.Broker;
using Airbnb.Infra.Broker.Publisher;
using Airbnb.SharedKernel.Common;
using Airbnb.SharedKernel.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Airbnb.AppService.Jobs.Outbox;

public class OutboxProcessor : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    /// <inheritdoc />
    public OutboxProcessor(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var outboxRepository = scope.ServiceProvider.GetRequiredService<IOutboxRepository>();
        var publisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<OutboxProcessor>>();

        while (!stoppingToken.IsCancellationRequested)
        {
            var events = await outboxRepository.GetUnpublishedEventAsync();
            var outboxMessages = events?.ToList();

            if (outboxMessages != null && (events is null || !outboxMessages.Any()))
            {
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
                continue;
            }

            foreach (var message in outboxMessages!)
            {
                if (Helper.PopulateObject(message.Assembly, message.Payload) is not IIntegrationEvent @event)
                {
                    logger.LogError("Unable to deserialize event from assembly {Assembly} with payload {Payload}", message.Assembly, message.Payload);
                    continue;
                }

                var topicOrQueue = BrokerHelper.GetTopicOrQueueName(message.EventName);

                await publisher.PublishAsync(@event, topicOrQueue, stoppingToken);
                await outboxRepository.MarkAsPublishedAsync(message);
            }

            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
        }
    }
}