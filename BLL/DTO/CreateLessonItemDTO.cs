using AutoMapper;
using DAL.Entities;

namespace BLL.DTO
{
    [AutoMap(typeof(LessonItem), ReverseMap = true)]
    public class CreateLessonItemDTO
    {
        public string Name { get; set; }
    }
}
