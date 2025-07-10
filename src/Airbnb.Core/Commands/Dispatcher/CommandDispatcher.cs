using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Core.Commands.Dispatcher;

public class CommandDispatcher(IServiceScopeFactory serviceScopeFactory) : ICommandDispatcher
{
    public async Task<TResult> DispatchAsync<TResult>(ICommand<TResult> query)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        return await (Task<TResult>)handlerType
            .GetMethod(nameof(ICommandHandler<ICommand<TResult>, TResult>.HandleAsync))!
            .Invoke(handler, [query])!;
    }

    public async Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command) where TCommand : class, ICommand<TResult>
    {
        using var scope = serviceScopeFactory.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
        return await handler.HandleAsync(command);
    }
}