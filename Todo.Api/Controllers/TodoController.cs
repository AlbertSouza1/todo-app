using Microsoft.AspNetCore.Mvc;
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
            => repository.GetAll("albert");

        [Route("")]
        [HttpPost]
        public ICommandResult Create([FromBody] CreateTodoCommand command,
                                     [FromServices] TodoHandler handler)
        {
            command.User = "albert";
            return handler.Handle(command);
        }
    }
}
