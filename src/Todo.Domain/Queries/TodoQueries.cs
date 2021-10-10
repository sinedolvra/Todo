using System;
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetUnDone()
        {
            return todo => !todo.Done;
        }
        
        public static Expression<Func<TodoItem, bool>> GetDone()
        {
            return todo => todo.Done;
        }
        
        public static Expression<Func<TodoItem, bool>> GetAll()
        {
            return todo => true;
        }
    }
}