using AutoMapper;
using DAL.Entities;

namespace BLL.DTO
{
    [AutoMap(typeof(LessonItem))]
    public class LessonItemDTO
    {
        public string? Name { get; set; }
    }
}
