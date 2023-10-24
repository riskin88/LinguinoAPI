using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Relations
{
    [Table("LessonItemLesson")]
    public class LessonItemLesson : EntityBase
    {
        public long LessonItemId { get; set; }
        public LessonItem LessonItem { get; set; } = null!;
        public long LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;
        public double? OrderInLesson { get; set; }
    }
}
