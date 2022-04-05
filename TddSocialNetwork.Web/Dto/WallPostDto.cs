using System;

namespace TddSocialNetwork.Web.Dto
{
    public class WallPostDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }

    }
}