
using AutoMapper;
using Azure.Core;
using BLL.DTO;
using BLL.Exceptions.User;
using BLL.Helpers;
using BLL.Services.Auth;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtService _jwtService;
        private readonly EmailHelper _emailHelper;

        public UserAuthService(IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IJwtService jwtService, EmailHelper emailHelper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
            _emailHelper = emailHelper;
        }

        public async Task<CreateUserRespDTO> RegisterUser(CreateUserDTO createUserDTO)
        {
            var result = await _userManager.CreateAsync(new User() { UserName = createUserDTO.UserName, Email = createUserDTO.Email }, createUserDTO.Password);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(createUserDTO.UserName);
                await _userManager.AddToRoleAsync(user, "USER");

                var roles = await _userManager.GetRolesAsync(user);
                var resp = _mapper.Map<CreateUserRespDTO>(user);
                resp.idToken = _jwtService.CreateToken(user, roles);
                return resp;
            }
            else throw new SignupErrorException(result.Errors.First().Code);
        }

        public async Task<CreateUserRespDTO> LoginUser(LoginUserDTO loginUserDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginUserDTO.Email);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, loginUserDTO.Password))
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var resp = _mapper.Map<CreateUserRespDTO>(user);
                    resp.idToken = _jwtService.CreateToken(user, roles);
                    return resp;
                }

            }
            throw new SignupErrorException("WRONG_EMAIL_OR_PASSWORD");
        }

        public async Task ResetPasswordToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                _emailHelper.SendEmailPasswordReset(email, token);
            }
            else throw new SignupErrorException("WRONG_EMAIL");
        }

        public async Task ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, resetPasswordDTO.Token, resetPasswordDTO.Password);
                if (!result.Succeeded)
                    throw new SignupErrorException(result.Errors.First().Code);
            }
            else throw new SignupErrorException("WRONG_EMAIL");
        }
    }
}

