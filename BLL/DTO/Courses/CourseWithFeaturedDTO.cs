using AutoMapper;
using AutoMapper.Configuration.Annotations;
using BLL.DTO.Topics;
using DAL.Entities;

namespace BLL.DTO.Courses
{
    [AutoMap(typeof(Course))]
    public class CourseWithFeaturedDTO : EntityBase
    {
        public string? Language1 { get; set; }
        public string? Language2 { get; set; }
        public string? Name { get; set; }
        public string? ThumbnailUrl { get; set; }
        [SourceMember(nameof(Course.Topics))]
        public List<TopicBriefDTO> FeaturedTopics { get; set; }
    }
}
