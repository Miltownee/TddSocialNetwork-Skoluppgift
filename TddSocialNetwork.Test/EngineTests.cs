using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TddSocialNetwork.Data;
using TddSocialNetwork.Engine;
using TddSocialNetwork.Model;

namespace TddSocialNetwork.Test
{
    [TestClass]
    public class EngineTests
    {
        [TestInitialize]
        public void Setup()
        {

        }

        [DataRow("Alice", "What a wonderful day")]
        [DataRow("Bob ", "Its raining today!")]
        [TestMethod]
        public void CanPostToAUserWall(string userName, string message)
        {
            // Arrange
            var postRepository = new Mock<IRepository<Post>>();
            postRepository.Setup(x => x.Insert(It.IsAny<Post>()));
            var userRepository = new Mock<IRepository<User>>();

            var engine = new SocialNetworkEngine(
                postRepository.Object,
                userRepository.Object
            );

            //// Act
            engine.Post(userName, message);

            // Assert
            postRepository.Verify(x => x.Insert(It.IsAny<Post>()), Times.AtLeastOnce);

        }

        //[TestMethod]
        //[DataRow("Alice", "Message")]
        //[DataRow("Bob", "Message")]
        //[DataRow("Charlie", "Message")]
        //public void CanViewAUserTimeline(string userName, string message)
        //{
        //    // Arrange
        //    var engine = new SocialNetworkEngine();

        //    // Act
        //    engine.Post(userName, message);
        //    var posts = engine.Timeline(userName);

        //    // Assert
        //    Assert.AreEqual(message, posts.FirstOrDefault()?.Message);
        //}

        //[DataRow("Alice", "Bob", "Hello World!")]
        //[DataRow("Bob ", "Alice", "Carpe Diem!")]
        //[TestMethod]
        //public void CanFollowUser(string userName, string userToFollow, string message)
        //{
        //    // Arrange
        //    var engine = new SocialNetworkEngine();

        //    // Act
        //    engine.Post(userName, message);
        //    engine.Post(userToFollow, message);
        //    engine.Follow(userName, userToFollow);
        //    engine.Post(userToFollow + userName, message);
        //    engine.Follow(userName, userToFollow + userName);

        //    var user = engine.Users.FirstOrDefault(x => x.Name == userName)?.FollowerUsers;

        //    // Assert
        //    Assert.AreEqual(user?.Count, 2);
        //    Assert.AreEqual(user?.FirstOrDefault()?.Name, userToFollow);
        //}

        ////[DataRow("Alice", "Bob", "Hello World!")]
        ////[DataRow("Bob ", "Alice", "Carpe Diem!")]
        ////[TestMethod]
        ////public void CanViewWall(string userName, string userToFollow, string message)
        ////{
        ////    // Arrange
        ////    var engine = new SocialNetworkEngine();

        ////    // Act
        ////    engine.Post(userName, message);
        ////    engine.Post(userName, message);
        ////    engine.Post(userToFollow, message);
        ////    engine.Follow(userName, userToFollow);

        ////    var wall = engine.Wall(userName);

        ////    // Assert
        ////    Assert.AreEqual(wall.Count, 1);
        ////    Assert.AreEqual(wall.FirstOrDefault()?.Message, message);
        ////}

        //[DataRow("Alice", "Bob", "@Bob What a wonderful day")]
        //[DataRow("Bob ", "Alice", "@Alice Its raining today!")]
        //[TestMethod]
        //public void CanPostToAnotherUsersWall(string userName, string userMentioned, string message)
        //{
        //    // Arrange
        //    var engine = new SocialNetworkEngine();

        //    // Act
        //    engine.Post(userName, message);
        //    var posts = engine.Timeline(userMentioned);

        //    // Assert
        //    Assert.AreEqual(1, posts.Count);
        //    Assert.AreEqual(posts.FirstOrDefault().Message, message);
        //}

        //[DataRow("Alice", "Bob", "Hello, how are you?")]
        //[TestMethod]
        //public void CanSendPrivateMessages(string userName, string receiverName, string message)
        //{
        //    // Act
        //    var engine = new SocialNetworkEngine();

        //    // Arrange
        //    engine.SendMessage(userName, receiverName, message);

        //    var receiverUser = engine.Users.FirstOrDefault(x => x.Name == receiverName);

        //    // Assert
        //    Assert.AreEqual(message, receiverUser?.PrivateMessages.FirstOrDefault()?.Body);
        //}

        //[DataRow("Alice", "Bob", "Hello, how are you?")]
        //[DataRow("Bob", "Alice", "Godbye my friend")]
        //[TestMethod]
        //public void CanReadPrivateMessages(string userName, string receiverName, string message)
        //{
        //    // Act
        //    var engine = new SocialNetworkEngine();

        //    // Arrange
        //    engine.SendMessage(userName, receiverName, message);

        //    var messages = engine.ViewMessages(receiverName);

        //    // Assert
        //    Assert.AreEqual(message, messages.FirstOrDefault()?.Body);
        //}

        //[DataRow("Alice", "Bob", "Hello World!")]
        //[TestMethod]
        //public void CanViewWall(string userName, string userToFollow, string message)
        //{
        //    // Arrange
        //    var engine = new SocialNetworkEngine();

        //    // Act
        //    engine.Post(userName, message);
        //    engine.Post(userName, message);
        //    engine.Post(userToFollow, message);
        //    engine.Follow(userName, userToFollow);

        //    // Assert
        //    var wall = engine.Wall(userName);

        //    // Assert
        //    Assert.AreEqual(wall.Count, 1);
        //    Assert.AreEqual(wall.FirstOrDefault()?.Message, message);

        //}
    }
}
