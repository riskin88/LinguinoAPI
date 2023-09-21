using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Relations
{
    [Table("UserLesson")]
    public class UserLesson : EntityBase
    {
        public string UserId { get; set; }
        public User User { get; set; } = null!;
        public long LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;
        public long ItemsDone { get; set; }
        public long ItemsTotal { get; set; }
        public bool IsVisible { get; set; } = true;
        public bool IsFavorite { get; set; } = true;
    }
}
