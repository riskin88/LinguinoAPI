
using AutoMapper;
using Azure.Core;
using BLL.Config;
using BLL.DTO.Auth;
using BLL.DTO.Users;
using BLL.Exceptions.Auth;
using BLL.Helpers;
using BLL.Services.Auth;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Migrations;
using DAL.Repositories.Contracts;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using System.CodeDom.Compiler;
using System.Data;
using System.Security.Cryptography;
using System.Text;


namespace BLL.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly EmailHelper _emailHelper;
        private readonly SecuritySettings _configuration;

        public UserAuthService(IMapper mapper, IUnitOfWork unitOfWork, IJwtService jwtService, EmailHelper emailHelper, IOptions<SecuritySettings> configuration)
        {
            _mapper = mapper;
             _unitOfWork = unitOfWork;
            _jwtService = jwtService;
            _emailHelper = emailHelper;
            _configuration = configuration.Value;
        }

        public async Task<AuthUserRespDTO> RegisterUser(CreateUserDTO createUserDTO)
        {
            var result = await _unitOfWork.UserManager.CreateAsync(new User() { UserName = createUserDTO.Username, Email = createUserDTO.Email }, createUserDTO.Password);
            if (result.Succeeded)
            {
                var user = await _unitOfWork.UserManager.FindByNameAsync(createUserDTO.Username);
                await _unitOfWork.UserManager.AddToRoleAsync(user, "USER");
                user.Name = GenerateRandomName();

                var roles = await _unitOfWork.UserManager.GetRolesAsync(user);
                var resp = new AuthUserRespDTO();
                var userFull = await _unitOfWork.UserRepository.GetUserWithCourse(user.Id);
                var userDTO = _mapper.Map<GetUserDTO>(userFull);
                userDTO.Role = roles.FirstOrDefault();
                resp.User = userDTO;
                resp.IdToken = _jwtService.CreateAccessToken(user, roles);
                resp.RefreshToken = CreateAndSaveRefreshToken(user);

                _unitOfWork.SaveChanges();
                return resp;
            }
            else throw new SignupErrorException(result.Errors.First().Code);
        }

        public async Task<AuthUserRespDTO> LoginUser(LoginUserDTO loginUserDTO)
        {
            var user = await _unitOfWork.UserManager.FindByEmailAsync(loginUserDTO.Email);
            if (user != null)
            {
                if (await _unitOfWork.UserManager.CheckPasswordAsync(user, loginUserDTO.Password))
                {
                    var roles = await _unitOfWork.UserManager.GetRolesAsync(user);
                    var resp = new AuthUserRespDTO();
                    var userFull = await _unitOfWork.UserRepository.GetUserWithCourse(user.Id);
                    var userDTO = _mapper.Map<GetUserDTO>(userFull);
                    userDTO.Role = roles.FirstOrDefault();
                    resp.User = userDTO;
                    resp.IdToken = _jwtService.CreateAccessToken(user, roles);
                    resp.RefreshToken = CreateAndSaveRefreshToken(user);
                    _unitOfWork.SaveChanges();
                    return resp;
                }

            }
            throw new SignupErrorException("WRONG_EMAIL_OR_PASSWORD");
        }

        public async Task<RefreshTokenRespDTO> RefreshToken(string refreshToken)
        {
            var tokenHash = HashToken(refreshToken);
            var user = await _unitOfWork.UserRepository.GetUserByRefreshTokenHash(tokenHash);
            if (user != null && user.RefreshTokenExpirationDate >= DateTime.Now)
            {
                var resp = new RefreshTokenRespDTO();
                var roles = await _unitOfWork.UserManager.GetRolesAsync(user);
                resp.IdToken = _jwtService.CreateAccessToken(user, roles);
                resp.RefreshToken = CreateAndSaveRefreshToken(user);
                _unitOfWork.SaveChanges();
                return resp;
            }
            else throw new InvalidTokenException("Invalid refresh token.");

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

        public async Task ChangePassword(ResetPasswordDTO resetPasswordDTO)
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



        public async Task ChangeEmail(ChangeEmailDTO changeEmailDTO)
        {
            var user = _unitOfWork.UserRepository.GetCurrentUser();
            var token = await _unitOfWork.UserManager.GenerateChangeEmailTokenAsync(user, changeEmailDTO.NewEmail);
            _emailHelper.SendEmailChangeEmail(user.Email, changeEmailDTO.NewEmail, token);
        }


        public async Task ChangeEmailConfirm(ChangeEmailConfirmDTO changeEmailConfirmDTO)
        {
            var user = await _unitOfWork.UserManager.FindByEmailAsync(changeEmailConfirmDTO.OldEmail);
            if (user != null)
            {
                var result = await _unitOfWork.UserManager.ChangeEmailAsync(user, changeEmailConfirmDTO.NewEmail, changeEmailConfirmDTO.Token);
                _unitOfWork.SaveChanges();
                if (!result.Succeeded)
                    throw new SignupErrorException(result.Errors.First().Code);
            }
            else throw new SignupErrorException("WRONG_EMAIL");
        }

        private string CreateAndSaveRefreshToken(User user)
        {
            var token = _jwtService.CreateRefreshToken();
            var tokenHash = HashToken(token);
            user.RefreshToken = tokenHash;
            user.RefreshTokenExpirationDate = DateTime.UtcNow.AddMinutes(_configuration.RefreshTokenExpirationMinutes);
            return token;
        }

        private string HashToken(string token)
        {
            var inputBytes = Encoding.UTF8.GetBytes(token);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }

        private static string GenerateRandomName()
        {
            const int nameLength = 10;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            Random random = new Random();
            char[] stringChars = new char[nameLength];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

    }
}

