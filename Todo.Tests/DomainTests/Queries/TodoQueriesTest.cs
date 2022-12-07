using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Tests.DomainTests.Queries
{
    [TestClass]
    public class TodoQueriesTest
    {
        private readonly List<TodoItem> _todos;

        public TodoQueriesTest()
        {
            _todos = new List<TodoItem>() 
            { 
                new TodoItem(title: "Item 1", date: new DateTime(2022, 7, 1), user: "Other user"),
                new TodoItem(title: "Item 2", date: new DateTime(2022, 7, 1), user: "Albert"),
                new TodoItem(title: "Item 3", date: new DateTime(2022, 7, 1), user: "Albert"),
                new TodoItem(title: "Item 4", date: new DateTime(2022, 7, 1), user: "Albert"),
                new TodoItem(title: "Item 5", date: new DateTime(2022, 7, 2), user: "Albert"),
                new TodoItem(title: "Item 6", date: new DateTime(2022, 7, 2), user: "Other user"),
            };
        }

        [TestMethod]
        public void GetAll_should_return_all_todo_items_of_the_user()
        {
            //Arrange
            var expression = TodoQueries.GetAll("Albert");

            //Act
            var result = _todos.AsQueryable().Where(expression);

            //Assert
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void GetAllDone_should_return_all_done_todo_items_of_the_user()
        {
            //Arrange
            _todos[0].ChangeMarkState(done: true);
            _todos[1].ChangeMarkState(done: true);
            _todos[2].ChangeMarkState(done: true);
            var expression = TodoQueries.GetAllDone(user: "Albert");

            //Act
            var result = _todos.AsQueryable().Where(expression);

            //Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetAllUndone_should_return_all_undone_todo_items_of_the_user()
        {
            //Arrange
            _todos[0].ChangeMarkState(done: true);
            _todos[1].ChangeMarkState(done: true);
            var expression = TodoQueries.GetAllUndone(user: "Albert");

            //Act
            var result = _todos.AsQueryable().Where(expression);

            //Assert
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        [DataRow(true, 1)]
        [DataRow(false, 2)]
        public void GetByPeriod_should_return_all_todo_items_of_the_user_in_the_period_and_done_state_filtered(bool done, int expectedItems)
        {
            //Arrange
            var period = new DateTime(2022, 7, 1);
            _todos[0].ChangeMarkState(done: true);
            _todos[1].ChangeMarkState(done: true);
            var expression = TodoQueries.GetByPeriod(user: "Albert", period, done);

            //Act
            var result = _todos.AsQueryable().Where(expression);

            //Assert
            Assert.AreEqual(expectedItems, result.Count());
        }
    }
}
