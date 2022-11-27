using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands.Inputs;

namespace Todo.Tests.DomainTests.Commands.Inputs
{
    [TestClass]
    public class MarkTodoCommandTest
    {
        [TestMethod]
        public void Given_an_invalid_command_validation_should_return_false()
        {
            //Arrange
            var sut = new MarkTodoCommand(id: Guid.NewGuid(), user: string.Empty, done: true);

            //Act
            sut.Validate();

            //Assert
            Assert.IsFalse(sut.IsValid);
            Assert.AreEqual("Usuário inválido.", sut.Messages);
        }

        [TestMethod]
        public void Given_a_valid_command_validation_should_return_true()
        {
            //Arrange
            var sut = new MarkTodoCommand(id: Guid.NewGuid(), user: "Usuario", done: true);

            //Act
            sut.Validate();

            //Assert
            Assert.IsTrue(sut.IsValid);
        }

        [TestMethod]
        public void If_command_marks_todo_as_done_changingStateMessage_should_return_message_for_done()
        {
            //Arrange
            var sut = new MarkTodoCommand(id: Guid.NewGuid(), user: "Usuario", done: true);

            //Act & Assert
            Assert.AreEqual("Tarefa marcada com sucesso.", sut.ChangingStateMessage);
        }

        [TestMethod]
        public void If_command_marks_todo_as_undone_changingStateMessage_should_return_message_for_undone()
        {
            //Arrange
            var sut = new MarkTodoCommand(id: Guid.NewGuid(), user: "Usuario", done: false);

            //Act & Assert
            Assert.AreEqual("Tarefa desmarcada com sucesso.", sut.ChangingStateMessage);
        }
    }
}
