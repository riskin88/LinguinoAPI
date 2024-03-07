using AutoMapper;
using DAL.Entities;

namespace BLL.DTO.Users
{
    [AutoMap(typeof(User))]

    public class CreateUserRespDTO
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? IdToken { get; set; }
        public long? Streak { get; set; }
        public long? Balance { get; set; }
        public bool? AccountInitialized { get; set; }
    }
}
