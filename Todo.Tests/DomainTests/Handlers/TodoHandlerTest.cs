using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Results;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Tests.DomainTests.Handlers
{
    [TestClass]
    public class TodoHandlerTest
    {
        private readonly TodoHandler _handler;
        private readonly Mock<ITodoRepository> _repository;

        public TodoHandlerTest()
        {
            _repository = new Mock<ITodoRepository>();
            _handler = new TodoHandler(_repository.Object);
        }

        [TestMethod]
        public void Given_an_invalid_todoCommand_should_return_fail_result()
        {
            //Arrange
            var command = new CreateTodoCommand("", "Usuario", DateTime.Now);           

            //Act
            var result = (CommandResult)_handler.Handle(command);

            //Assert
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void Given_a_valid_todoCommand_should_create_todo()
        {
            //Arrange
            var command = new CreateTodoCommand("Titulo", "Usuario", DateTime.Now);

            //Act
            var result = (CommandResult)_handler.Handle(command);

            //Assert
            Assert.IsTrue(result.Success);
        }
    }
}
