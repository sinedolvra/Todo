using FluentValidation.Results;
using MediatR;
using Todo.Domain.Commands.Validators;
using Todo.Domain.Exceptions;

namespace Todo.Domain.Commands.Contracts
{
    public abstract class Command : ICommand, IRequest<ICommandResult>
    {
        protected ValidationResult ValidationResult;

        public virtual void Validate()
        {
            ValidationResult = new CommandBaseValidator<Command>().Validate(this);
        } 
        
        public bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        public bool IsInvalid()
        {
            return !IsValid();
        }

        public virtual void ValidateAndThrow()
        {
            if (IsInvalid())
            {
                throw new InvalidCommandException(ValidationResult.Errors.ToString());
            }
        }

        public virtual GenericCommandResult CommandResult()
        {
            return new (IsValid(), ValidationResult.ToString(), this);
        }
    }
}