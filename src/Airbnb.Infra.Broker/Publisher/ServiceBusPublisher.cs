using System.Text;
using Airbnb.SharedKernel;
using Airbnb.SharedKernel.Common;
using Airbnb.SharedKernel.Events;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Airbnb.Infra.Broker.Publisher;

public class ServiceBusPublisher(IConfiguration configuration) : IEventPublisher
{
    public async Task PublishAsync<T>(T @event, string topicOrQueue, CancellationToken cancellation = default) where T : class, IIntegrationEvent
    {
        var options = Options;

        var client = new ServiceBusClient(configuration.GetConnectionString("ServiceBus"), options);

        var sender = client.CreateSender(topicOrQueue);
        var json = JsonConvert.SerializeObject(@event);

        var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(json))
        {
            ContentType = "application/json",
            MessageId = Helper.GenerateHash(json)
        };

        message.ApplicationProperties.Add("event-type", @event.GetType().Name);
        message.ApplicationProperties.Add("source", AirbnbSettings.ServiceName);

        await sender.SendMessageAsync(message, cancellation);
        await sender.CloseAsync(cancellation);
        await client.DisposeAsync();
    }

    private static ServiceBusClientOptions Options => new()
    {
        RetryOptions = new ServiceBusRetryOptions
        {
            Mode = ServiceBusRetryMode.Exponential,
            MaxRetries = 10,
            MaxDelay = TimeSpan.FromSeconds(10),
        }
    };
}