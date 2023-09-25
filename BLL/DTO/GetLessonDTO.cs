using AutoMapper;
using DAL.Entities;
using DAL.Entities.Enums;

namespace BLL.DTO
{
    [AutoMap(typeof(Lesson))]
    public class GetLessonDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public LessonType? Type { get; set; }
        public LessonLevel? Level { get; set; }
        public bool IsCustom { get; set; }
        public bool isFavorite { get; set; }
    }
}
