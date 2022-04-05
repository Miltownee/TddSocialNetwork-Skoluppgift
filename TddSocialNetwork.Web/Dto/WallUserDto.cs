using System.Collections.Generic;

namespace TddSocialNetwork.Web.Dto
{
    public class WallUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WallPostDto> TimelinePosts { get; set; }
    }
}