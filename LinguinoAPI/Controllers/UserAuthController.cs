using System.Net;
using System.Net.Http;
using BLL.DTO;
using BLL.Helpers;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace LinguinoAPI.Controllers
{
    [ApiController]
    public class UserAuthController : ControllerBase
    {

        private readonly ILogger<UserAuthController> _logger;
        private readonly IUserAuthService _userService;
        private readonly EmailHelper _emailHelper;

        public UserAuthController(ILogger<UserAuthController> logger, IUserAuthService userService, EmailHelper emailHelper)
        {
            _logger = logger;
            _userService = userService;
            _emailHelper = emailHelper;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<CreateUserRespDTO>> RegisterUser(CreateUserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }
            
            var resp = await _userService.RegisterUser(user);
            return Ok(resp);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<CreateUserRespDTO>> LoginUser(LoginUserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }

            var resp = await _userService.LoginUser(user);
            return Ok(resp);
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<ActionResult> ResetPassword(string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }

            await _userService.ResetPasswordToken(email);
            return Ok();
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<ActionResult> ChangePassword(ResetPasswordDTO resetPassword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }

            await _userService.ResetPassword(resetPassword);
            return Ok();
        }
    }
}