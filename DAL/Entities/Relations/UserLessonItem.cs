using DAL.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Relations
{
    [Table("UserLessonItem")]
    public class UserLessonItem : EntityBase
    {
        public string UserId { get; set; }
        public User User { get; set; } = null!;
        public long LessonItemId { get; set; }
        public LessonItem LessonItem { get; set; } = null!;
        public bool IsFavorite { get; set; } = false;
        public int Repetitions { get; set; } = 0;
        public int Interval { get; set; } = 1;
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? DateToReview { get; set; }
        public double Easiness { get; set; } = 2.5;
        public LessonItemState ItemState { get; set; } = LessonItemState.NEW;
    }
}
