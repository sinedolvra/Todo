using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        Task<TodoItem> Add(TodoItem todoItem);
        Task<TodoItem> Get(string id);
        Task<List<TodoItem>> GetUnDone();
        Task<List<TodoItem>> GetDone();
        Task<List<TodoItem>> GetAll();
    }
}