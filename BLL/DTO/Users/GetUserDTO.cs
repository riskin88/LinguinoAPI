using AutoMapper;
using DAL.Entities;

namespace BLL.DTO.Users
{
    [AutoMap(typeof(User))]

    public class GetUserDTO
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? Role { get; set; }
        public long? Streak { get; set; }
        public long? Balance { get; set; }
        public long? Xp { get; set; }
        public int? Level { get; set; }
        public DateTime? LastSessionDate { get; set; }
        public bool? AccountInitialized { get; set; }
    }
}
