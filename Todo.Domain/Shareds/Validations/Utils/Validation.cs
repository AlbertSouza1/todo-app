using Flunt.Notifications;
using System;
using System.Linq;

namespace Todo.Domain.Shareds.Validations.Utils
{
    public abstract class Validation : Notifiable<Notification>
    {
        public string Messages => string.Join(Environment.NewLine, Notifications.Select(x => x.Message));

        public string FirstMessage => Notifications.FirstOrDefault()?.Message;
    }
}
