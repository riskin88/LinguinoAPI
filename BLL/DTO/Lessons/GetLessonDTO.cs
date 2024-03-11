using AutoMapper;
using AutoMapper.Configuration.Annotations;
using BLL.DTO.LessonItems;
using DAL.Entities;
using DAL.Entities.Enums;

namespace BLL.DTO.Lessons
{
    [AutoMap(typeof(Lesson))]
    public class GetLessonDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public LessonType? Type { get; set; }
        public LessonLevel? Level { get; set; }
        public string? BackgroundImageUrl { get; set; }
        public string? VideoId { get; set; }
        public string? Icon { get; set; }
        public double? OrderOnMap { get; set; }
        public bool IsCustom { get; set; } = false;
        public bool Visible { get; set; } = false;
        public bool Favorite { get; set; } = false;
        public LessonFeedbackDTO? Feedback { get; set; }
        [SourceMember(nameof(Lesson.LessonItems))]
        public List<GetLessonItemInLessonDTO> LessonItems { get; set; }
    }
}
