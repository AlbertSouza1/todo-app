using Todo.Domain.Commands.Results.Contracts;

namespace Todo.Domain.Commands.Results
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message = "", object data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }
    }
}
