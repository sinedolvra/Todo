using Todo.Domain.Repositories;

namespace Todo.Domain.CommandHandlers
{
    public class BaseCommandHandler
    {
        protected readonly ITodoRepository _repository;

        public BaseCommandHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
    }
}