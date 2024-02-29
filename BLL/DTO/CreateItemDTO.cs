using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;
using DAL.Entities.Enums;

namespace BLL.DTO
{
    [AutoMap(typeof(LessonItem), ReverseMap = true)]
    public class CreateItemDTO
    {
        public LessonItemType Type { get; set; }
    }
}
