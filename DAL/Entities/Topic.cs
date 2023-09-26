using DAL.Entities.Enums;
using DAL.Entities.Relations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Topic")]
    public class Topic : EntityBase
    {
        [Required]
        public string? Name { get; set; }
        public string? ThumbnailURL { get; set; }
        [Required]
        public bool IsDefault { get; set; } = true;
        [Required]
        public bool IsFeatured { get; set; } = true;
        public TopicCategory? Category { get; set; }
        public long LessonsTotal { get; set; } = 0;
        public List<User> Users { get; set; } = new();
        public List<UserTopic> UserTopics { get; set; } = new();
        public List<Lesson> Lessons { get; set; } = new();
        public List<TopicLesson> TopicLessons { get; set; } = new();
        public long CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}
