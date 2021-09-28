using System;

namespace Todo.Domain.Entities
{
    public class TodoItem : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Done { get; set; }
        
        public TodoItem(string title, string description, DateTime creationDate, bool done)
        {
            Description = description;
            Title = title;
            CreationDate = creationDate;
            Done = done;
        }

        public void MarkAsDone() => Done = true;
        public void MarkAsUnDone() => Done = false;
    }
}