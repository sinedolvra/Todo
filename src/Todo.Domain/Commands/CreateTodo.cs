using System;
using FluentValidation.Results;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Commands.Validators;

namespace Todo.Domain.Commands
{
    public class CreateTodo : Command
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Done { get; set; }
        
        public CreateTodo(string title, string description, DateTime creationDate, bool done)
        {
            Description = description;
            Title = title;
            CreationDate = creationDate;
            Done = done;
        }

        public override ValidationResult Validate() => new CreateTodoValidator().Validate(this);
    }
}