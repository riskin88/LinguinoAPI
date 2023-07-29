﻿using BLL.DTO;
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
    }
}
