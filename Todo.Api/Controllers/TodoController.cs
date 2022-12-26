using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Results.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
            var user = GetUser();
            return repository.GetAll(user);
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
        {
            var user = GetUser();
            return repository.GetAllDone(user);
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
        {
            var user = GetUser();
            return repository.GetAllUndone(user);
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
        {
            var user = GetUser();
            return repository.GetByPeriod(user, date: DateTime.Now.Date, done: true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForToday([FromServices] ITodoRepository repository)
        {
            var user = GetUser();
            return repository.GetByPeriod(user, date: DateTime.Now.Date, done: false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
        {
            var user = GetUser();
            return repository.GetByPeriod(user, date: DateTime.Now.Date.AddDays(1), done: true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow([FromServices] ITodoRepository repository)
        {
            var user = GetUser();
            return repository.GetByPeriod(user, date: DateTime.Now.Date.AddDays(1), done: false);
        }

        [Route("")]
        [HttpPost]
        public ICommandResult Create([FromBody] CreateTodoCommand command,
                                     [FromServices] TodoHandler handler)
        {
            command.User = GetUser();
            return handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public ICommandResult Update([FromBody] UpdateTodoCommand command,
                                     [FromServices] TodoHandler handler)
        {
            command.User = GetUser();
            return handler.Handle(command);
        }

        [Route("change-state")]
        [HttpPut]
        public ICommandResult ChangeState([FromBody] MarkTodoCommand command,
                                     [FromServices] TodoHandler handler)
        {
            command.User = GetUser();
            return handler.Handle(command);
        }

        private string GetUser() => User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
    }
}
