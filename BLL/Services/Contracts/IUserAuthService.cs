using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.Auth;
using BLL.DTO.Users;
using DAL.Entities;
using DAL.Repositories.Contracts;

namespace BLL.Services.Contracts
{
    public interface IUserAuthService
    {
        Task<AuthUserRespDTO> RegisterUser(CreateUserDTO user);
        Task<AuthUserRespDTO> LoginUser(LoginUserDTO loginUserDTO);
        Task ResetPasswordToken(string email);
        Task ChangePassword(ResetPasswordDTO resetPassword);
        Task ChangeEmail(ChangeEmailDTO changeEmailDTO);
        Task ChangeEmailConfirm(ChangeEmailConfirmDTO changeEmailConfirmDTO);
        Task<RefreshTokenRespDTO> RefreshToken(string refreshToken);

    }
}
