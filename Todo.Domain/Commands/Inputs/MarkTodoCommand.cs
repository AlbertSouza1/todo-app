using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Shareds.Validations.Utils;

namespace Todo.Domain.Commands.Inputs
{
    public class MarkTodoCommand : Validation, ICommand
    {
        public MarkTodoCommand()
        {
        }

        public MarkTodoCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(User, "User", "Usuário inválido.")
                );

            return IsValid;
        }
    }
}
