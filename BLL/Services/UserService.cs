using AutoMapper;
using BLL.DTO;
using BLL.Exceptions.User;
using BLL.Services.Contracts;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<User> userManager, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetUserRespDTO> GetUser()
        {
            var id = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(id);
            return _mapper.Map<GetUserRespDTO>(user);
        }

    }
}
