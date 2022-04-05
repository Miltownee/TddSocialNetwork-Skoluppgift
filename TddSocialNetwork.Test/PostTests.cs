using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddSocialNetwork.Model;

namespace TddSocialNetwork.Test
{
    [TestClass]
    public class PostTests
    {
        [DataRow("What a wonderfully sunny day!")]
        [TestMethod]
        public void PostCanBeCreatedWIthMessage(string inputMessage)
        {
            // Arrange
            var post = new Post(inputMessage);

            // Act
            var outputMessage = post.Message;

            // Assert
            Assert.AreEqual(inputMessage, outputMessage);
        }
    }
}
