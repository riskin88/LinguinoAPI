using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Relations
{
    [Table("UserCourse")]
    public class UserCourse : EntityBase
    {
        public string UserId { get; set; }
        public User User { get; set; } = null!;
        public long CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public Lesson? SelectedLesson { get; set; }
        public long? SelectedLessonId { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}
