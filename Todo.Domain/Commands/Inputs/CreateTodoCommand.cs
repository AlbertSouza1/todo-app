using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Shareds.Validations.Utils;

namespace Todo.Domain.Commands.Inputs
{
    public class CreateTodoCommand : Validation, ICommand
    {
        public CreateTodoCommand()
        {
        }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }

        public TodoItem GetTodoItem() => new TodoItem(Title, Date, User);

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
