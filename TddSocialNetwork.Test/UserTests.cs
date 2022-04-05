using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddSocialNetwork.Model;

namespace TddSocialNetwork.Test
{
    [TestClass]
    public class UserTests
    {
        private const string Name = "Alice";

        [DataRow("Alice")]
        [DataRow("")]
        [TestMethod]
        public void UserCanBeCreatedWithName(string inputName)
        {
            // Arrange
            var user = new User(inputName);

            // Act
            var name = user.Name;

            //Assert
            Assert.AreEqual(inputName, name);
        }
    }
}
