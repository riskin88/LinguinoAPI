using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;

namespace BLL.DTO
{
    [AutoMap(typeof(Course))]
    public class CourseWithFeaturedDTO : EntityBase
    {
        public string? LanguageFrom { get; set; }
        public string? LanguageTo { get; set; }
        public string? Name { get; set; }
        public string? ThumbnailURL { get; set; }
        [SourceMember(nameof(Course.Topics))]
        public List<TopicBriefDTO> FeaturedTopics { get; set; }
    }
}
