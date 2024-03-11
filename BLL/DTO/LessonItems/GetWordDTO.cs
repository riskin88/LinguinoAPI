using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;
using DAL.Entities.Enums;

namespace BLL.DTO.LessonItems
{
    [AutoMap(typeof(Word))]
    public class GetWordDTO
    {
        public long Id { get; set; }
        public string? NameL1 { get; set; }
        public string? NameL2 { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? AudioUrl { get; set; }
        public bool Favorite { get; set; } = false;
        public LessonItemState? LearningState { get; set; }
        public DateTime? DateToReview { get; set; }
        [SourceMember(nameof(Word.Examples))]
        public List<WordExample> Examples { get; set; }
    }
}
