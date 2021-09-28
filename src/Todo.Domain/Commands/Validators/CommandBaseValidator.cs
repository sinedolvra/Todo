using FluentValidation;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands.Validators
{
    public class CommandBaseValidator<T> : AbstractValidator<T> where T: Command
    {
    }
}