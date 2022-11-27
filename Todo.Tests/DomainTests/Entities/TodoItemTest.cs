using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Entities;

namespace Todo.Tests.DomainTests.Entities
{
    [TestClass]
    public class TodoItemTest
    {
        [TestMethod]
        public void Given_a_new_todoItem_done_should_be_false()
        {
            //Arrange & Act
            var sut = new TodoItem("Titulo", DateTime.Now, "Usuário");

            //Assert
            Assert.IsFalse(sut.Done);
        }
    }
}
