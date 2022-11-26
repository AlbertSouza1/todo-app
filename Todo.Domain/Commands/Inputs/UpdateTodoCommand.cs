using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Shareds.Validations.Utils;

namespace Todo.Domain.Commands.Inputs
{
    public class UpdateTodoCommand : Validation, ICommand
    {
        public UpdateTodoCommand()
        {
        }

        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public bool Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Title, "Title", "Preencha o título da tarefa.")
                .IsNotNullOrEmpty(User, "User", "Usuário inválido.")
                );

            return IsValid;
        }
    }
}
