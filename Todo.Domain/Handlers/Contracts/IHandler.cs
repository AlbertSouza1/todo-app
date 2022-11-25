using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Commands.Results.Contracts;

namespace Todo.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
