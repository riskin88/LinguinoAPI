using DAL.Configs;
using DAL.Entities.Enums;
using DAL.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [EntityTypeConfiguration(typeof(LessonItemConfiguration))]
    [Table("LessonItem")]
    public class LessonItem : EntityBase
    {
        public LessonType Type { get; set; }
        public List<Lesson> Lessons { get; set; } = new();
        public List<LessonItemLesson> LessonItemLessons { get; set; } = new();
        public List<User> Users { get; set; } = new();
        public List<UserLessonItem> UserLessonItems { get; set; } = new();
        public List<Exercise> Exercises { get; set; } = new();
        public List<LearningStep> LearningSteps { get; set; } = new();
    }
}
