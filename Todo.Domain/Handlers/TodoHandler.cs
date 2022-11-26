﻿using Flunt.Notifications;
using System;
using System.Linq;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Results;
using Todo.Domain.Commands.Results.Contracts;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;
using Todo.Domain.Shareds.Validations.Utils;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : 
        Validation,
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
                return new CommandResult(success:false, command.Messages);

            var todo = command.GetTodoItem();

            _todoRepository.Create(todo);

            return new CommandResult(success:true, "Tarefa salva com sucesso.", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
