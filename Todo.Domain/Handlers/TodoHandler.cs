using Flunt.Notifications;
using System;
using System.Linq;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Results;
using Todo.Domain.Commands.Results.Contracts;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : 
        Notifiable<Notification>,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public TodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            if (!command.Validate())
                return new CommandResult(false, command.Messages);

            return new CommandResult(true);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
