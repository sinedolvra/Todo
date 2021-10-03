using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Infra.Contexts
{
    public class TodoItemContext : DbContext
    {
        public TodoItemContext(DbContextOptions<TodoItemContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }

    }
}