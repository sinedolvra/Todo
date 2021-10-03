using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Repositories;
using static System.Threading.Tasks.Task;

namespace Todo.Domain.CommandHandlers
{
    public class CreateTodoCommandHandler : BaseCommandHandler, IRequestHandler<CreateTodo, ICommandResult>
    {
        private const string ResultMessage = "Todo created sucessfully!";

        public CreateTodoCommandHandler(ITodoRepository repository) : base(repository)
        {
        }

        public async Task<ICommandResult> Handle(CreateTodo request, CancellationToken cancellationToken)
        {
            request.Validate();
            
            if (request.IsInvalid())
                return await FromResult(request.GetValidationResult());
            
            var createdTodo = await _repository.Add(request.ToToDo());
            return await FromResult(new GenericCommandResult(true, ResultMessage, createdTodo));
        }
    }
}