namespace AsyncArch.Core.Todos;

public class Todo
{
    public Guid Id { get; }
    public string Description { get; }
    public TodoStatus Status { get; private set; }

    public Todo(Guid id, string description)
    {
        Id = id;
        Description = description;
        Status = TodoStatus.InProgress;
    }

    private Todo() {}
    
    public void MarkAsDone() =>
        Status = TodoStatus.Done;
}