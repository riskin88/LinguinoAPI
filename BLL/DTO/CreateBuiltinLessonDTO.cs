using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;
using DAL.Entities.Enums;

namespace BLL.DTO
{
    [AutoMap(typeof(Lesson), ReverseMap = true)]
    public class CreateBuiltinLessonDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public LessonType? Type { get; set; }
        public LessonLevel? Level { get; set; }
        public long OrderOnMap {  get; set; }
        [Ignore]
        public List<CreateLessonNestedItemDTO> Items { get; set; }
    }
}
