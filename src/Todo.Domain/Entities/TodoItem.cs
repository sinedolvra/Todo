using System;
using Todo.Domain.Commands;

namespace Todo.Domain.Entities
{
    public class TodoItem : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Done { get; set; }
        
        public TodoItem(string title, string description, DateTime creationDate, bool done) : base()
        {
            Description = description;
            Title = title;
            CreationDate = creationDate;
            Done = done;
        }

        public void MarkAsDone() => Done = true;
        public void MarkAsUnDone() => Done = false;

        public void Update(UpdateTodo request)
        {
            Title = request.Title ?? Title;
            Description = request.Description ?? Description;
            Done = request.Done ?? Done;
        }
    }
}