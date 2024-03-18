using BLL.DTO.Users;
using BLL.Services.Contracts;
using DAL.Filters;
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
        public async Task<ActionResult<GetUserDTO>> GetUser()
        {
            return Ok(await _userService.GetUser());
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

        [HttpGet, Authorize]
        [Route("user/settings")]
        public ActionResult<GetUserSettingsDTO> GetSettings()
        {
            return Ok(_userService.GetSettings());
        }

        [HttpPatch, Authorize]
        [Route("user/settings")]
        public ActionResult<GetUserSettingsDTO> ChangeSettings(ChangeUserSettingsDTO changeSettingsDTO)
        {
            return Ok(_userService.ChangeSettings(changeSettingsDTO));
        }

        [HttpGet, Authorize]
        [Route("users")]
        public async Task<ActionResult<IEnumerable<GetUserBriefDTO>>> GetUsers([FromQuery] UserFilter filter)
        {
            return Ok(await _userService.GetUsers(filter));
        }

        [HttpGet, Authorize]
        [Route("users/{userId}")]
        public async Task<ActionResult<GetUserPublicDTO>> GetUserPublic(string userId)
        {
            return Ok(await _userService.GetUserPublicData(userId));
        }

        [HttpPost, Authorize]
        [Route("user/account-setup")]
        public ActionResult AccountSetup(AccountSetupDTO accountSetupDTO)
        {
            _userService.AccountSetup(accountSetupDTO);
            return Ok();
        }
    }
}
