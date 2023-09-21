using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Relations
{
    [Table("TopicLesson")]
    public class TopicLesson : EntityBase
    {
        public long TopicId { get; set; }
        public Topic Topic { get; set; } = null!;
        public long LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;
    }
}
