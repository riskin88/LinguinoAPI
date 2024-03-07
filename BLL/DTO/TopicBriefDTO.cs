using AutoMapper;
using DAL.Entities;

namespace BLL.DTO
{
    [AutoMap(typeof(Topic))]
    public class TopicBriefDTO : EntityBase
    {
        public string? Name { get; set; }
        public string? ThumbnailUrl { get; set; }
    }
}
