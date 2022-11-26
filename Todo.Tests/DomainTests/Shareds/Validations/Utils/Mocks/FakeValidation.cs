using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Shareds.Validations.Utils;

namespace Todo.Tests.DomainTests.Shareds.Validations.Utils.Mocks
{
    internal class FakeValidation : Validation
    {
        public FakeValidation(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;

            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Id, 0, "Id", "Id inválido.")
                .IsNotNullOrEmpty(Name, "Name", "Nome vazio.")
                .IsNotNullOrEmpty(Name, "Name", "Endereço vazio.")
                );
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
