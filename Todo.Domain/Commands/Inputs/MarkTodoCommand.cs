﻿using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Inputs.Contracts;

namespace Todo.Domain.Commands.Inputs
{
    public class MarkTodoCommand : Notifiable<Notification>, ICommand
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