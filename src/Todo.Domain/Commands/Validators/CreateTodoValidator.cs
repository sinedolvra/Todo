using System;
using FluentValidation;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands.Validators
{
    public class CreateTodoValidator : CommandBaseValidator<CreateTodo>
    {
        public CreateTodoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(3);
            RuleFor(x => x.CreationDate).GreaterThanOrEqualTo(DateTime.UtcNow);
        }
    }
}