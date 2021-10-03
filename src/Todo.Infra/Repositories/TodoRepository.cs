using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
using Todo.Infra.Contexts;

namespace Todo.Infra.Repositories
{
    
    [ExcludeFromCodeCoverage]
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoItemContext _context;

        public TodoRepository(TodoItemContext ctx)
        {
            _context = ctx;
        }
        
        public async Task<TodoItem> Add(TodoItem todoItem)
        {
            var todo = await _context.Todos.AddAsync(todoItem);
            await _context.SaveChangesAsync();
            return todo.Entity;
        }
    }
}