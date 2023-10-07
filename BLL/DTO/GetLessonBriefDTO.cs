using AutoMapper;
using DAL.Entities;
using DAL.Entities.Enums;

namespace BLL.DTO
{
    [AutoMap(typeof(Lesson))]
    public class GetLessonBriefDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
    }
}
