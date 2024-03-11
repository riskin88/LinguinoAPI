using AutoMapper;
using DAL.Entities;

namespace BLL.DTO.LessonItems
{
    public class GetWordInLessonDTO : GetLessonItemInLessonDTO
    {
        public string? NameL1 { get; set; }
        public string? NameL2 { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? AudioUrl { get; set; }
    }
}
