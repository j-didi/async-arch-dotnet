using AsyncArch.Core.Ports;
using AsyncArch.Core.Todos;
using Microsoft.EntityFrameworkCore;

namespace AsyncArch.Infra.Database;

public class TodosAdapter: ITodosPort
{
    private readonly DatabaseContext _context;
    private readonly DbSet<Todo> _todos;

    public TodosAdapter(
        DatabaseContext context    
    )
    {
        _context = context;
        _todos = context.Set<Todo>();
    }

    public async Task<Todo> GetById(Guid id) =>
        await _todos.FindAsync(id);
    
    public async Task<List<Todo>> GetByStatus(TodoStatus status) =>
        await _todos
            .Where(e => e.Status != status)
            .ToListAsync();
    
    public async Task Save(Todo todo)
    {
        await _todos.AddAsync(todo);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Todo todo)
    {
        _context.Entry(todo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
