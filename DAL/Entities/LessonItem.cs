using DAL.Entities.Relations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("LessonItem")]
    public class LessonItem : EntityBase
    {
        [Required]
        public string? Name { get; set; }
        public List<Lesson> Lessons { get; set; } = new();
        public List<LessonItemLesson> LessonItemLessons { get; set; } = new();
    }
}
