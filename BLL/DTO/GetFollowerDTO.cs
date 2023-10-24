using AutoMapper;
using DAL.Entities;

namespace BLL.DTO
{
    [AutoMap(typeof(User))]

    public class GetFollowerDTO
    {
        public string Id { get; set; }
        public string? Username { get; set; }
        public bool IsFollowed { get; set; } = false;
    }
}
