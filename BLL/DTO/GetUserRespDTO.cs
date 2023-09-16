using AutoMapper;
using DAL.Entities;

namespace BLL.DTO
{
    [AutoMap(typeof(User))]

    public class GetUserRespDTO
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public long? Streak { get; set; }
        public long? Balance { get; set; }
        public bool? AccountInitialized { get; set; }
    }
}
