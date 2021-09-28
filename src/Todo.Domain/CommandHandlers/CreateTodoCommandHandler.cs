using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.CommandHandlers
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodo, ICommandResult>
    {
        public Task<ICommandResult> Handle(CreateTodo request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}