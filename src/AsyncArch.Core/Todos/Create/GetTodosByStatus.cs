using AsyncArch.Core.Ports;
using MassTransit;
using Newtonsoft.Json;

namespace AsyncArch.Core.Todos.Create;

public record GetTodosByStatusMessage(
    Guid OperationId,
    string Hash,
    TodoStatus Status
);

public class GetTodosByStatusConsumer : IConsumer<GetTodosByStatusMessage>
{
    private readonly ITodosPort _todos;
    private readonly ICachePort _cache;
    private readonly INotificationsPort _notifier;

    public GetTodosByStatusConsumer(
        ITodosPort todos,
        ICachePort cache,
        INotificationsPort notifier
    )
    {
        _todos = todos;
        _cache = cache;
        _notifier = notifier;
    }
    
    public async Task Consume(ConsumeContext<GetTodosByStatusMessage> context)
    {
        var todos = await _todos.GetByStatus(context.Message.Status);

        await _cache.Write(
            context.Message.OperationId,
            JsonConvert.SerializeObject(todos)
        );
        
        await _notifier.Notify(
            context.Message.Hash,
            $"Get Todos operation with id {context.Message.OperationId} read!"
        );
    }
}