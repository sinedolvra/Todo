using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.CommandHandlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}