using BLL.DTO.Auth;
using BLL.DTO.Users;
using BLL.Helpers;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinguinoAPI.Controllers
{
    [ApiController]
    public class UserAuthController : ControllerBase
    {

        private readonly ILogger<UserAuthController> _logger;
        private readonly IUserAuthService _userService;

        public UserAuthController(ILogger<UserAuthController> logger, IUserAuthService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<AuthUserRespDTO>> RegisterUser(CreateUserDTO user)
        {
            var resp = await _userService.RegisterUser(user);
            return Ok(resp);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthUserRespDTO>> LoginUser(LoginUserDTO user)
        {
            var resp = await _userService.LoginUser(user);
            return Ok(resp);
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<ActionResult> ResetPassword(string email)
        {
            await _userService.ResetPasswordToken(email);
            return Ok();
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<ActionResult> ChangePassword(ResetPasswordDTO resetPassword)
        {
            await _userService.ChangePassword(resetPassword);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("change-email")]
        public async Task<ActionResult> ChangeEmail(ChangeEmailDTO changeEmailDTO)
        {
            await _userService.ChangeEmail(changeEmailDTO);
            return Ok();
        }

        [HttpPost]
        [Route("change-email-confirm")]
        public async Task<ActionResult> ChangeEmailConfirm(ChangeEmailConfirmDTO changeEmailConfirmDTO)
        {
            await _userService.ChangeEmailConfirm(changeEmailConfirmDTO);
            return Ok();
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<ActionResult<RefreshTokenRespDTO>> RefreshToken(string token)
        {
            return Ok(await _userService.RefreshToken(token));
        }
    }
}