using System.Net;
using System.Net.Http;
using BLL.DTO;
using BLL.Services;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Repositories.Contracts;
using LinguinoAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LinguinoAPI.Controllers
{
    //[ErrorHandlingFilter]
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
        public async Task<ActionResult<CreateUserRespDTO>> RegisterUser(CreateUserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }
            
            var created = await _userService.RegisterUser(user);
            return Ok(created);
        }
    }
}