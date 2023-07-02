using BLL.Services;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LinguinoAPI.Controllers
{
    [ApiController]
    [Route("[controller]/users")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> RegisterUser(User user)
        {
            var created = _userService.CreateUser(user);

            return Ok(created);
        }
    }
}