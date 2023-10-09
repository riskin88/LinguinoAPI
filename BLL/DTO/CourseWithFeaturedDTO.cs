using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;

namespace BLL.DTO
{
    [AutoMap(typeof(Course))]
    public class CourseWithFeaturedDTO : EntityBase
    {
        public string? Language1 { get; set; }
        public string? Language2 { get; set; }
        public string? Name { get; set; }
        public string? ThumbnailURL { get; set; }
        [SourceMember(nameof(Course.Topics))]
        public List<TopicBriefDTO> FeaturedTopics { get; set; }
    }
}
