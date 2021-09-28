using System;
using FluentValidation.Results;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Commands.Validators;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands
{
    public class CreateTodo : Command
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Done { get; set; }
        
        public CreateTodo(string title, string description, bool done)
        {
            Description = description;
            Title = title;
            CreationDate = DateTime.UtcNow;
            Done = done;
        }

        public override void Validate()
        {
            ValidationResult = new CreateTodoValidator().Validate(this);
        }

        public TodoItem ToToDo() => new(Title, Description, CreationDate, Done);
    }
}