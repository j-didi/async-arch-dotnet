using AsyncArch.Core.Todos;

namespace AsyncArch.Core.Ports;

public interface ITodosPort
{
    Task<Todo> GetById(Guid id);
    Task<List<Todo>> GetByStatus(TodoStatus status);
    Task Save(Todo todo);
    Task Update(Todo todo);
}