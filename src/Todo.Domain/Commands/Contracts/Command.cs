using FluentValidation.Results;
using MediatR;
using Todo.Domain.Commands.Validators;

namespace Todo.Domain.Commands.Contracts
{
    public abstract class Command : ICommand, IRequest<ICommandResult>
    {
        public ValidationResult ValidationResult { get; private set; }

        public virtual ValidationResult Validate() => new CommandBaseValidator<Command>().Validate(this);
        
        public bool IsValid()
        {
            var validationResult = Validate();
            ValidationResult = new ValidationResult(validationResult.Errors);
            return validationResult.IsValid;
        }

        public bool IsInvalid()
        {
            return !IsValid();
        }
    }
}