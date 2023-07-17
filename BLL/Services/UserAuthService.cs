using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Exceptions.User;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Repositories.Contracts;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public UserAuthService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<CreateUserRespDTO> RegisterUser(CreateUserDTO createUserDTO)
        {
            var result = await _userManager.CreateAsync(new User() { UserName = createUserDTO.UserName, Email = createUserDTO.Email }, createUserDTO.Password);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(createUserDTO.UserName);
                return _mapper.Map<CreateUserRespDTO>(user);
            }
            else throw new SignupErrorException(result.Errors.First().Code);
        }
    }
}
