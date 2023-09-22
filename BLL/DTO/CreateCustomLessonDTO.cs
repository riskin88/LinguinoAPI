using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;

namespace BLL.DTO
{
    [AutoMap(typeof(Lesson), ReverseMap = true)]
    public class CreateCustomLessonDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        [Ignore]
        public List<IdDTO> Items { get; set; }
    }
}
