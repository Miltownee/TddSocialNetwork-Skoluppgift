using System;

namespace TddSocialNetwork.Model
{
    public class Message : IEntity
    {
        public int Id { get; set; }

        public string Body { get; set; }
        public string From { get; set; }
        public DateTime SentDateTime { get; set; }

        public Message()
        {
        }

        public Message(string userName, string message)
        {
            Body = message;
            From = userName;
            SentDateTime = DateTime.Now;
        }
    }
}