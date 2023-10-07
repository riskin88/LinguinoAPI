using DAL.Entities.Enums;
using DAL.Entities.Relations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("LessonFeedback")]
    public class LessonFeedback : EntityBase
    {
        public string? Text { get; set; }
        public FeedbackState? State { get; set; } = FeedbackState.UNDEFINED;
    }
}
