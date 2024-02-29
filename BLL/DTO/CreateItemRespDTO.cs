using AutoMapper;
using DAL.Entities;
using DAL.Entities.Enums;

namespace BLL.DTO
{
    [AutoMap(typeof(LessonItem))]
    public class CreateItemRespDTO
    {
        public long Id { get; set; }
        public LessonItemType? Type { get; set; }

    }
}
