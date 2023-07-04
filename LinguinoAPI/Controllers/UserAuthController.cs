using BLL.DTO;
using BLL.Services;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Repositories.Contracts;
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
        public ActionResult<CreateUserRespDTO> RegisterUser(CreateUserDTO user)
        {
            var created = _userService.RegisterUser(user);

            return Ok(created);
        }
    }
}