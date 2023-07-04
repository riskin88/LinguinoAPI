using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Repositories.Contracts;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        public UserAuthService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<CreateUserRespDTO> RegisterUser(CreateUserDTO userDTO)
        {
            var result = await _userManager.CreateAsync(new User() { UserName = userDTO.UserName, Email = userDTO.Email }, userDTO.Password);
            return new CreateUserRespDTO();
        }
    }
}
