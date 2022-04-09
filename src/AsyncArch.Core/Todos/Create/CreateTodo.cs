using AsyncArch.Core.Ports;
using MassTransit;

namespace AsyncArch.Core.Todos.Create;

public record CreateTodoMessage(
    Guid OperationId,
    string Hash,
    string Description
);

public class CreateTodoConsumer : IConsumer<CreateTodoMessage>
{
    private readonly ITodosPort _todos;
    private readonly INotificationsPort _notifier;

    public CreateTodoConsumer(
        ITodosPort todos,
        INotificationsPort notifier
    )
    {
        _todos = todos;
        _notifier = notifier;
    }
    
    public async Task Consume(ConsumeContext<CreateTodoMessage> context)
    {
        var todo = new Todo(
            context.Message.OperationId,
            context.Message.Description
        );
        
        await _todos.Save(todo);

        await _notifier.Notify(
            context.Message.Hash,
            $"Todo with id {todo.Id} successfully created!"
        );
    }
}