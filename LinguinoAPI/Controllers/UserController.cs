using BLL.Services;
using BLL.Services.Contracts;
using DAL.Models;
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

        //[HttpGet]
       // public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        //{
            //return _userService
       // }
    }
}