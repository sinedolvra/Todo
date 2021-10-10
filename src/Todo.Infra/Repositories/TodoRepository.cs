using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
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

        public async Task<TodoItem> Get(string id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<List<TodoItem>> GetUnDone()
        {
            return await Task.FromResult(
                _context.Todos.AsNoTracking()
                    .Where(TodoQueries.GetUnDone())
                    .OrderBy(x => x.CreationDate)
                    .ToList()
                );
        }

        public async Task<List<TodoItem>> GetDone()
        {
            return await Task.FromResult(
                _context.Todos.AsNoTracking()
                    .Where(TodoQueries.GetDone())
                    .OrderBy(x => x.CreationDate)
                    .ToList()
            );
        }

        public async Task<List<TodoItem>> GetAll()
        {
            return await Task.FromResult(
                _context.Todos.AsNoTracking()
                    .Where(TodoQueries.GetAll())
                    .OrderBy(x => x.CreationDate)
                    .ToList()
            );
        }
        
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}