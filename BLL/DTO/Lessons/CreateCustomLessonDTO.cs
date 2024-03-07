using AutoMapper;
using AutoMapper.Configuration.Annotations;
using BLL.DTO.LessonItems;
using DAL.Entities;

namespace BLL.DTO.Lessons
{
    [AutoMap(typeof(Lesson), ReverseMap = true)]
    public class CreateCustomLessonDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        [Ignore]
        public List<CreateLessonNestedItemDTO> Items { get; set; }
    }
}
