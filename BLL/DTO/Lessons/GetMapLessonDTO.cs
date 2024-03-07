using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;
using DAL.Entities.Enums;

namespace BLL.DTO.Lessons
{
    [AutoMap(typeof(Lesson))]
    public class GetMapLessonDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public LessonType? Type { get; set; }
        public LessonLevel? Level { get; set; }
        public string? Icon { get; set; }
        public double? OrderOnMap { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
