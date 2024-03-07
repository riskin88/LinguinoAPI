using AutoMapper;
using AutoMapper.Configuration.Annotations;
using BLL.DTO.LessonItems;
using DAL.Entities;
using DAL.Entities.Enums;

namespace BLL.DTO.Lessons
{
    [AutoMap(typeof(Lesson), ReverseMap = true)]
    public class CreateBuiltinLessonDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public LessonType? Type { get; set; }
        public LessonLevel? Level { get; set; }
        public string? BackgroundImageUrl { get; set; }
        public string? VideoId { get; set; }
        public string? Icon { get; set; }
        public double? OrderOnMap { get; set; }
        [Ignore]
        public List<CreateLessonNestedItemDTO> Items { get; set; }
    }
}
