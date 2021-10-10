using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Repositories;
using static System.Threading.Tasks.Task;

namespace Todo.Domain.CommandHandlers
{
    public class UpdateTodoCommandHandler : BaseCommandHandler, IRequestHandler<UpdateTodo, ICommandResult>
    {
        private const string ResultMessage = "Todo updated sucessfully!";

        public UpdateTodoCommandHandler(ITodoRepository repository) : base(repository)
        {
        }

        public async Task<ICommandResult> Handle(UpdateTodo request, CancellationToken cancellationToken)
        {
            request.Validate();
            
            if (request.IsInvalid())
                return await FromResult(request.GetValidationResult());

            var todo = await _repository.Get(request.Id);
            todo.Update(request);
            await _repository.SaveChanges();
            return await FromResult(new GenericCommandResult(true, ResultMessage, todo));
        }
    }
}