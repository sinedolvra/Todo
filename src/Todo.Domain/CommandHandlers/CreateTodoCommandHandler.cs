using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.CommandHandlers
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodo, ICommandResult>
    {
        private const string ResultMessage = "Todo created sucessfully!";
        
        public async Task<ICommandResult> Handle(CreateTodo request, CancellationToken cancellationToken)
        {
            request.Validate();
            
            return await Task.FromResult(request.CommandResult());
        }
    }
}