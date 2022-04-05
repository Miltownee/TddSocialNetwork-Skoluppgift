using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TddSocialNetwork.Data;
using TddSocialNetwork.Model;

namespace TddSocialNetwork.Engine
{
    public class SocialNetworkEngine : ISocialNetworkEngine
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<User> _userRepository;

        public SocialNetworkEngine(
            IRepository<Post> postRepository,
            IRepository<User> userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public void Post(string userId, string message)
        {
            var existingUser = _userRepository
                .GetAll()
                .Include(x => x.TimelinePosts)
                .FirstOrDefault(x => x.Id == int.Parse(userId));
            
            if (existingUser != null)
            {
                var post = new Post(message)
                {
                    User = existingUser
                };
                _postRepository.Insert(post);
                _userRepository.Save();
            }
            else
            {
                var newUser = new User(userId);
                var post = new Post(message);
                newUser.TimelinePosts.Add(post);
                _userRepository.Insert(newUser);
                _userRepository.Save();
            }

            if (message.Contains("@"))
            {
                var messageArray = message.Split(' ');
                var newUserName = messageArray[0].Split('@')[1];

                var userToReceiveMessage = _userRepository.GetAll()
                    .FirstOrDefault(x => x.Name == newUserName);

                if (userToReceiveMessage == null)
                {
                    var newUser = new User(newUserName);
                    newUser.TimelinePosts.Add(new Post(message));

                    _userRepository.Insert(newUser);
                }
                else
                {
                    userToReceiveMessage?.TimelinePosts.Add(new Post(message));
                }

                _userRepository.Save();

            }
        }

       

        public void Follow(string userName, string userNameToFollow)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Name == userName);
            
            var userToFollow = _userRepository.GetAll().FirstOrDefault(x => x.Name == userNameToFollow);

            if (user != null && userToFollow != null)
            {
                user.FollowerUsers.Add(userToFollow);
            }

        }

        public List<Post> Timeline(string userName)
        {
            return _userRepository
                .GetAll()
                .FirstOrDefault(x => x.Name == userName)?
                .TimelinePosts
                .ToList();
        }

        public void SendMessage(string userName, string receiverName, string messageToSend)
        {
            var message = new Message(userName, messageToSend);
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Name == userName);
            if (user == null)
            {
                user = new User(userName);
                _userRepository.Insert(user);
            }

            var receiverUser = _userRepository.GetAll().FirstOrDefault(x => x.Name == receiverName);
            if (receiverUser == null)
            {
                receiverUser = new User(receiverName);
                _userRepository.Insert(receiverUser);
            }

            receiverUser = _userRepository.GetAll().FirstOrDefault(x => x.Name == receiverName);
            receiverUser?.PrivateMessages.Add(message);
            _userRepository.Update(receiverUser);
            _userRepository.Save();
        }

        public List<Message> ViewMessages(string receiverName)
        {
            return _userRepository
                .GetAll()
                .FirstOrDefault(x => x.Name == receiverName)?
                .PrivateMessages;
        }

        public async Task<User> Wall(int userId)
        {
            return await _userRepository
                .GetAll()
                .Include(x => x.TimelinePosts)
                .Include(x => x.FollowerUsers)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<List<Post>> Wall()
        {
            var allPosts = new List<Post>();
            var users = await _userRepository
                .GetAll()
                .Include(x => x.TimelinePosts)
                .ToListAsync();

            if (users != null)
            {
                foreach (var user in users.Where(user => user.TimelinePosts != null))
                {
                    allPosts.AddRange(user.TimelinePosts);
                }
            }
                

            return allPosts.OrderByDescending(x => x.Created).ToList();
        }

        public async Task<List<User>> Users()
        {
            return await _userRepository
                .GetAll()
                .ToListAsync();
        }
    }
}
