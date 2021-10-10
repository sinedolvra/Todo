using FluentValidation;

namespace Todo.Domain.Commands.Validators
{
    public class UpdateTodoValidator : CommandBaseValidator<UpdateTodo>
    {
        public UpdateTodoValidator()
        {
            RuleFor(x => x.Id).NotNull();
            When(x => x.Title != null, () =>
            {
                RuleFor(x => x.Title).NotEmpty().MinimumLength(3);
            });
            When(x => x.Description != null, () =>
            {
                RuleFor(x => x.Description).NotEmpty().MinimumLength(3);
            });
            When(x => x.Done != null, () =>
            {
                RuleFor(x => x.Done).NotNull();
            });
        }
    }
}