using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        Task<TodoItem> Add(TodoItem todoItem);
    }
}