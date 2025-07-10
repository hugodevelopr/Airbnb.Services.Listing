using Airbnb.SharedKernel.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Core.Events.DomainEvents;

public class DomainEventDispatcher(IServiceProvider serviceProvider) : IDomainEventDispatcher
{
    public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IDomainEvent
    {
        using var scope = serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<IDomainEventHandler<TEvent>>();
        await handler.HandleAsync(@event);
    }
}