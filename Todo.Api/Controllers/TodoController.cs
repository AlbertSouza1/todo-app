using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Results;
using Todo.Domain.Commands.Results.Contracts;
using Todo.Domain.Handlers;

namespace Todo.Api.Controllers
{
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public ICommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "albert";
            return handler.Handle(command);
        }
    }
}
