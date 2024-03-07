using AutoMapper;
using DAL.Entities;

namespace BLL.DTO
{
    [AutoMap(typeof(Topic))]

    public class TopicRespDTO : EntityBase
    {
        public string? Name { get; set; }
        public string? ThumbnailUrl { get; set; }
        public bool Enabled { get; set; } = false;
    }
}
