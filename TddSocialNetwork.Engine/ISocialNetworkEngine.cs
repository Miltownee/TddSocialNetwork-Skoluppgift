using System.Collections.Generic;
using System.Threading.Tasks;
using TddSocialNetwork.Model;

namespace TddSocialNetwork.Engine
{
    public interface ISocialNetworkEngine
    {
        void Post(string userId, string message);
        void Follow(string userName, string userNameToFollow);
        List<Post> Timeline(string userName);
        void SendMessage(string userName, string receiverName, string messageToSend);
        List<Message> ViewMessages(string receiverName);
        Task<User> Wall(int userId);
        Task<List<Post>> Wall();
        Task<List<User>> Users();
    }
}