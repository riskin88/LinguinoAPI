using DAL.Configs;
using DAL.Entities.Enums;
using DAL.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [EntityTypeConfiguration(typeof(LessonConfiguration))]
    [Table("Lesson")]
    public class Lesson : EntityBase
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public LessonType? Type { get; set; }
        public LessonLevel? Level { get; set; }
        public string? BackgroundImageUrl {  get; set; }
        public string? VideoId { get; set; }
        public string? Icon { get; set; }
        public double? OrderOnMap {  get; set; }
        public bool IsCustom { get; set; }
        public long ItemsTotal { get; set; }
        public List<User> Users { get; set; } = new();
        public List<UserLesson> UserLessons { get; set; } = new();
        public List<Topic> Topics { get; set; } = new();
        public List<TopicLesson> TopicLessons { get; set; } = new();
        public List<LessonItem> LessonItems { get; set; } = new();
        public List<LessonItemLesson> LessonItemLessons { get; set; } = new();
        public long? CourseId { get; set; }
        public Course? Course { get; set; }
        public string? AuthorId { get; set; }
        public User? Author { get; set; }

    }
}
