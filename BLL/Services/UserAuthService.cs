
using AutoMapper;
using Azure.Core;
using BLL.DTO;
using BLL.Exceptions.Auth;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly EmailHelper _emailHelper;

        public UserAuthService(IMapper mapper, IUnitOfWork unitOfWork, IJwtService jwtService, EmailHelper emailHelper)
        {
            _mapper = mapper;
             _unitOfWork = unitOfWork;
            _jwtService = jwtService;
            _emailHelper = emailHelper;
        }

        public async Task<CreateUserRespDTO> RegisterUser(CreateUserDTO createUserDTO)
        {
            var result = await _unitOfWork.UserManager.CreateAsync(new User() { UserName = createUserDTO.UserName, Email = createUserDTO.Email }, createUserDTO.Password);
            if (result.Succeeded)
            {
                var user = await _unitOfWork.UserManager.FindByNameAsync(createUserDTO.UserName);
                await _unitOfWork.UserManager.AddToRoleAsync(user, "USER");

                var roles = await _unitOfWork.UserManager.GetRolesAsync(user);
                var resp = _mapper.Map<CreateUserRespDTO>(user);
                resp.idToken = _jwtService.CreateToken(user, roles);
                _unitOfWork.SaveChanges();
                return resp;
            }
            else throw new SignupErrorException(result.Errors.First().Code);
        }

        public async Task<CreateUserRespDTO> LoginUser(LoginUserDTO loginUserDTO)
        {
            var user = await _unitOfWork.UserManager.FindByEmailAsync(loginUserDTO.Email);
            if (user != null)
            {
                if (await _unitOfWork.UserManager.CheckPasswordAsync(user, loginUserDTO.Password))
                {
                    var roles = await _unitOfWork.UserManager.GetRolesAsync(user);
                    var resp = _mapper.Map<CreateUserRespDTO>(user);
                    resp.idToken = _jwtService.CreateToken(user, roles);
                    return resp;
                }

            }
            throw new SignupErrorException("WRONG_EMAIL_OR_PASSWORD");
        }

        public async Task ResetPasswordToken(string email)
        {
            var user = await _unitOfWork.UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token = await _unitOfWork.UserManager.GeneratePasswordResetTokenAsync(user);
                _emailHelper.SendEmailPasswordReset(email, token);
            }
            else throw new SignupErrorException("WRONG_EMAIL");
        }

        public async Task ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var user = await _unitOfWork.UserManager.FindByEmailAsync(resetPasswordDTO.Email);
            if (user != null)
            {
                var result = await _unitOfWork.UserManager.ResetPasswordAsync(user, resetPasswordDTO.ResetToken, resetPasswordDTO.Password);
                _unitOfWork.SaveChanges();
                if (!result.Succeeded)
                    throw new SignupErrorException(result.Errors.First().Code);
            }
            else throw new SignupErrorException("WRONG_EMAIL");
        }
    }
}

