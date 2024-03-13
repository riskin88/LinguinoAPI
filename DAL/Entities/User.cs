using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using DAL.Configs;
using Microsoft.AspNetCore.Identity;
using DAL.Entities.Relations;

namespace DAL.Entities
{
    [EntityTypeConfiguration(typeof(UserConfiguration))]
    [Table("User")]
    public class User : IdentityUser
    {
        [Required]
        public string? Name { get; set; }
        public long? Streak { get; set; } = 0;
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? LastSessionDate { get; set; }
        public long? Balance { get; set; } = 0;
        public long? DailyGoalMs { get; set; }
        [Required]
        public bool? AccountInitialized { get; set; } = false;
        public List<User> Following { get; set; } = new();
        public List<User> Followers { get; set; } = new();
        public List<Course> Courses { get; set; } = new();
        public List<UserCourse> UserCourses { get; set; } = new();
        public List<Topic> Topics { get; set; } = new();
        public List<UserTopic> UserTopics { get; set; } = new();
        public List<Lesson> Lessons { get; set; } = new();
        public List<UserLesson> UserLessons { get; set; } = new();
        public List<Lesson> LessonsCreated { get; set; } = new();
        public List<LessonItem> LessonItems { get; set; } = new();
        public List<UserLessonItem> UserLessonItems { get; set; } = new();

    }
}
