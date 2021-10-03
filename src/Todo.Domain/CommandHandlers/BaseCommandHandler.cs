using Todo.Domain.Repositories;

namespace Todo.Domain.CommandHandlers
{
    public abstract class BaseCommandHandler
    {
        protected readonly ITodoRepository _repository;

        protected BaseCommandHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
    }
}