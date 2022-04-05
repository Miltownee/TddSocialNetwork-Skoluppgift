using System;

namespace TddSocialNetwork.Model
{
    public class Post : IEntity
    {
        public int Id { get; set; }

        public string Message { get; set; }
        public DateTime Created { get; set; }
        public virtual User User { get; set; }

        public Post()
        {
        }

        public Post(string message)
        {
            Message = message;
            Created = DateTime.UtcNow;
        }
    }
}
