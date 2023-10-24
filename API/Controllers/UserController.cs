using BLL.DTO;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinguinoAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Authorize]
        [Route("user")]
        public ActionResult<GetUserRespDTO> GetUser()
        {
            return Ok(_userService.GetUser());
        }

        [HttpPut, Authorize]
        [Route("user/following/{userId}")]
        public async Task<ActionResult> FollowUser(string userId)
        {
            await _userService.FollowUser(userId);
            return NoContent();
        }

        [HttpDelete, Authorize]
        [Route("user/following/{userId}")]
        public async Task<ActionResult> UnfollowUser(string userId)
        {
            await _userService.UnfollowUser(userId);
            return NoContent();
        }

        [HttpGet, Authorize]
        [Route("users/{userId}/following")]
        public async Task<ActionResult<IEnumerable<GetFollowerDTO>>> GetFollowing(string userId)
        {
            return Ok(await _userService.GetFollowing(userId));
        }

        [HttpGet, Authorize]
        [Route("users/{userId}/followers")]
        public async Task<ActionResult<IEnumerable<GetFollowerDTO>>> GetFollowers(string userId)
        {
            return Ok(await _userService.GetFollowers(userId));
        }
    }
}
