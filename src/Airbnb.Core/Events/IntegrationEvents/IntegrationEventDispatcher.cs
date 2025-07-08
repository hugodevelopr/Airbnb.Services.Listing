using Airbnb.Core.Events.DomainEvents;
using Airbnb.SharedKernel.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Core.Events.IntegrationEvents;

public class IntegrationEventDispatcher(IServiceProvider serviceProvider) : IIntegrationEventDispatcher
{
    public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IIntegrationEvent
    {
        using var scope = serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<IIntegrationEventHandler<TEvent>>();
        await handler.HandleAsync(@event);
    }
}