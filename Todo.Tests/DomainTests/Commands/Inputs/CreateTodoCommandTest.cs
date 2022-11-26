using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands.Inputs;

namespace Todo.Tests.DomainTests.Commands.Inputs
{
    [TestClass]
    public class CreateTodoCommandTest
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("", "Usuario", "Preencha o título da tarefa.")]
        [DataRow("Titulo", "", "Usuário inválido.")]
        [DataRow("", "", "Preencha o título da tarefa.\r\nUsuário inválido.")]
        public void Given_an_invalid_command_validation_should_return_false(string title, string user, string errorMessage)
        {
            //Arrange
            var sut = new CreateTodoCommand() {Title = title, User = user };

            //Act
            sut.Validate();

            //Assert
            Assert.IsFalse(sut.IsValid);
            Assert.AreEqual(errorMessage, sut.Messages);
        }

        [TestMethod]
        public void Given_a_valid_command_validation_should_return_true()
        {
            //Arrange
            var sut = new CreateTodoCommand("Titulo", "Usuario", DateTime.Now);

            //Act
            sut.Validate();

            //Assert
            Assert.IsTrue(sut.IsValid);
            Assert.AreEqual(string.Empty, sut.Messages);
        }
    }
}
