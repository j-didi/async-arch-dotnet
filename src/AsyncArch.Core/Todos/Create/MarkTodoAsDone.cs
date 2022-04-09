using AsyncArch.Core.Ports;
using MassTransit;

namespace AsyncArch.Core.Todos.Create;

public record MarkTodoAsDoneMessage(
    Guid TodoId,
    string Hash
);

public class MarkTodoAsDoneConsumer : IConsumer<MarkTodoAsDoneMessage>
{
    private readonly ITodosPort _todos;
    private readonly INotificationsPort _notifier;

    public MarkTodoAsDoneConsumer(
        ITodosPort todos,
        INotificationsPort notifier
    )
    {
        _todos = todos;
        _notifier = notifier;
    }
    
    public async Task Consume(ConsumeContext<MarkTodoAsDoneMessage> context)
    {
        var todo = await _todos.GetById(context.Message.TodoId);

        if (todo == null)
        {
            await _notifier.Notify(
                context.Message.Hash,
                $"Todo with id {context.Message.TodoId} Not Found!"
            );

            return;
        }
        
        todo.MarkAsDone();
        await _todos.Update(todo);

        await _notifier.Notify(
            context.Message.Hash,
            $"Todo with id {todo.Id} marked as done successfully!"
        );
    }
}