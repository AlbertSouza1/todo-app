using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Results;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Tests.DomainTests.Handlers
{
    [TestClass]
    public class TodoHandlerTest
    {
        private readonly TodoHandler _handler;
        private readonly Mock<ITodoRepository> _repository;
        private readonly TodoItem _validTodoItem;

        public TodoHandlerTest()
        {
            _repository = new Mock<ITodoRepository>();
            _handler = new TodoHandler(_repository.Object);
            _validTodoItem = new TodoItem("Titulo", DateTime.Now, "Usuário");
        }

        [TestMethod]
        public void Given_an_invalid_createTodoCommand_should_return_fail_result()
        {
            //Arrange
            var command = new CreateTodoCommand("", "Usuario", DateTime.Now);           

            //Act
            var result = (CommandResult)_handler.Handle(command);

            //Assert
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void Given_a_valid_createTodoCommand_should_create_todo()
        {
            //Arrange
            var command = new CreateTodoCommand("Titulo", "Usuario", DateTime.Now);

            //Act
            var result = (CommandResult)_handler.Handle(command);

            //Assert
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void Given_an_invalid_updateTodoCommand_should_return_fail_result()
        {
            //Arrange
            var command = new UpdateTodoCommand(Guid.NewGuid(), title:"", "Usuario");
            _repository.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<string>())).Returns(_validTodoItem);

            //Act
            var result = (CommandResult)_handler.Handle(command);

            //Assert
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void Given_a_valid_updateTodoCommand_should_update_todo_title()
        {
            //Arrange
            var command = new UpdateTodoCommand(Guid.NewGuid(), "Novo Titulo", "Usuario");

            _repository.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<string>())).Returns(_validTodoItem);

            //Act
            var result = (CommandResult)_handler.Handle(command);
            var todoUpdated = (TodoItem)result.Data;

            //Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Novo Titulo", todoUpdated.Title);
        }

        [TestMethod]
        public void Given_an_invalid_markTodoCommand_should_return_fail_result()
        {
            //Arrange
            var command = new MarkTodoCommand(id: Guid.NewGuid(), user: string.Empty, done: true);
            _repository.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<string>())).Returns(_validTodoItem);

            //Act
            var result = (CommandResult)_handler.Handle(command);

            //Assert
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void If_markTodoCommand_marks_state_to_done_should_update_todoItem_state_to_done()
        {
            //Arrange
            var command = new MarkTodoCommand(id: Guid.NewGuid(), user: "Usuario", done: true);

            _repository.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<string>())).Returns(_validTodoItem);

            //Act
            var result = (CommandResult)_handler.Handle(command);
            var todoUpdated = (TodoItem)result.Data;

            //Assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(todoUpdated.Done);
        }

        [TestMethod]
        public void If_markTodoCommand_marks_state_to_undone_should_update_todoItem_state_to_undone()
        {
            //Arrange
            var command = new MarkTodoCommand(id: Guid.NewGuid(), user: "Usuario", done: false);
            _validTodoItem.ChangeMarkState(done: true);

            _repository.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<string>())).Returns(_validTodoItem);

            //Act
            var result = (CommandResult)_handler.Handle(command);
            var todoUpdated = (TodoItem)result.Data;

            //Assert
            Assert.IsTrue(result.Success);
            Assert.IsFalse(todoUpdated.Done);
        }
    }
}
