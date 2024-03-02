using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;
using DAL.Entities.Enums;

namespace BLL.DTO
{
    [AutoMap(typeof(LessonItem), ReverseMap = true)]
    public class CreateItemDTO
    {
        public LessonType Type { get; set; }
    }
}
