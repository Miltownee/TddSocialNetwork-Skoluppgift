using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TddSocialNetwork.Engine;
using TddSocialNetwork.Model;
using TddSocialNetwork.Web.Dto;

namespace TddSocialNetwork.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialNetworkEngine _socialNetworkEngine;
        private readonly ILogger<SocialMediaController> _logger;
        private readonly IMapper _mapper;

        public SocialMediaController(
            ILogger<SocialMediaController> logger, 
            IMapper mapper,
            ISocialNetworkEngine socialNetworkEngine)
        {
            _logger = logger;
            _mapper = mapper;
            _socialNetworkEngine = socialNetworkEngine;
        }


        [HttpGet("wall")]
        public async Task<ActionResult<IEnumerable<PostDto>>> Wall()
        {
            var posts = await _socialNetworkEngine.Wall();
            return _mapper.Map<List<PostDto>> (posts);
        }

        [HttpGet("wall/{id}")]
        public async Task<ActionResult<WallUserDto>> Wall(string id)
        {
            var user =  await _socialNetworkEngine.Wall(int.Parse(id));

            return _mapper.Map<WallUserDto> (user);
        }

        // GET: api/users
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserDto>>> Users()
        {
            var users = await _socialNetworkEngine.Users();
            return _mapper.Map<List<UserDto>> (users.OrderBy(x => x.Name));
        }

        [HttpPost("post")]
        public async Task<ActionResult> Post([FromBody]SendPostDto sendPostDto)
        {
            _socialNetworkEngine.Post(sendPostDto.Id, sendPostDto.Message);

            return Ok();
        }

    }
}
