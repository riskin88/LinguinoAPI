using AutoMapper;
using DAL.Entities;

namespace BLL.DTO.Users
{
    [AutoMap(typeof(User))]

    public class GetUserBriefDTO
    {
        public string Id { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? ProfileImageUrl { get; set; }
        public bool IsFollowed { get; set; } = false;
    }
}
