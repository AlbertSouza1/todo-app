using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Tests.DomainTests.Shareds.Validations.Utils.Mocks;

namespace Todo.Tests.DomainTests.Shareds.Validations.Utils
{
    [TestClass]
    public class ValidationTest
    {
        [TestMethod]
        public void Messages_should_return_all_messages_separeted_by_line_break()
        {
            //Arrange & Act
            var sut = new FakeValidation(0, "", "");

            //Assert
            Assert.AreEqual("Id inválido.\r\nNome vazio.\r\nEndereço vazio.", sut.Messages);
        }

        [TestMethod]
        public void Messages_should_return_empty_string_if_it_has_no_notifications()
        {
            //Arrange & Act
            var sut = new FakeValidation(1, "Teste", "Teste");

            //Assert
            Assert.AreEqual(string.Empty, sut.Messages);
        }

        [TestMethod]
        public void FirstMessage_should_return_first_notification_message()
        {
            //Arrange & Act
            var sut = new FakeValidation(0, "", "");

            //Assert
            Assert.AreEqual("Id inválido.", sut.FirstMessage);
        }

        [TestMethod]
        public void FirstMessage_should_return_empty_string_if_it_has_no_notifications()
        {
            //Arrange & Act
            var sut = new FakeValidation(1, "Teste", "Teste");

            //Assert
            Assert.AreEqual(string.Empty, sut.FirstMessage);
        }
    }
}
