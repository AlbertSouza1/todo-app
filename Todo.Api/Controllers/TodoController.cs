using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Results.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
            => repository.GetAll(user: "albert");

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
            => repository.GetAllDone(user: "albert");

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
            => repository.GetAllUndone(user: "albert");

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
            => repository.GetByPeriod(user: "albert", date: DateTime.Now.Date, done: true);

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForToday([FromServices] ITodoRepository repository)
            => repository.GetByPeriod(user: "albert", date: DateTime.Now.Date, done: false);

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
            => repository.GetByPeriod(user: "albert", date: DateTime.Now.Date.AddDays(1), done: true);

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow([FromServices] ITodoRepository repository)
            => repository.GetByPeriod(user: "albert", date: DateTime.Now.Date.AddDays(1), done: false);

        [Route("")]
        [HttpPost]
        public ICommandResult Create([FromBody] CreateTodoCommand command,
                                     [FromServices] TodoHandler handler)
        {
            command.User = "albert";
            return handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public ICommandResult Update([FromBody] UpdateTodoCommand command,
                                     [FromServices] TodoHandler handler)
        {
            command.User = "albert";
            return handler.Handle(command);
        }

        [Route("change-state")]
        [HttpPut]
        public ICommandResult ChangeState([FromBody] MarkTodoCommand command,
                                     [FromServices] TodoHandler handler)
        {
            command.User = "albert";
            return handler.Handle(command);
        }
    }
}
