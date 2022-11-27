using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Shareds.Validations.Utils;

namespace Todo.Domain.Commands.Inputs
{
    public class MarkTodoCommand : Validation, ICommand
    {
        public MarkTodoCommand(Guid id, string user, bool done)
        {
            Id = id;
            User = user;
            Done = done;
        }

        public Guid Id { get; private set; }
        public string User { get; private set; }
        public bool Done { get; private set; }
        public string ChangingStateMessage
        {
            get
            {
                if (Done) return "Tarefa marcada com sucesso.";

                return "Tarefa desmarcada com sucesso.";
            }
        }

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
