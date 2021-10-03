using FluentValidation.Results;
using MediatR;
using Todo.Domain.Commands.Validators;
using Todo.Shared;

namespace Todo.Domain.Commands.Contracts
{
    public abstract class Command : ICommand, IRequest<ICommandResult>
    {
        protected ValidationResult ValidationResult;

        public virtual void Validate()
        {
            ValidationResult = new CommandBaseValidator<Command>().Validate(this);
        }

        public bool IsInvalid()
        {
            return !ValidationResult.IsValid;
        }
        
        public GenericCommandResult GetValidationResult()
        {
            return new (ValidationResult.IsValid, ValidationResult.Errors.GetErrorsValidation(), this);
        }
    }
}