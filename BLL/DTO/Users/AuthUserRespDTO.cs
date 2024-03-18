using AutoMapper;
using DAL.Entities;

namespace BLL.DTO.Users
{

    public class AuthUserRespDTO
    {
        public string? IdToken { get; set; }
        public string? RefreshToken { get; set; }
        public GetUserDTO? User { get; set; }
    }
}
