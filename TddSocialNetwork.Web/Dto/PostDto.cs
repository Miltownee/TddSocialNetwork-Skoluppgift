using System;

namespace TddSocialNetwork.Web.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }

        public UserDto User { get; set; }

    }
}