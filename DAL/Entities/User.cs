using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using DAL.Configs;
using Microsoft.AspNetCore.Identity;
using DAL.Entities.Relations;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
    [EntityTypeConfiguration(typeof(UserConfiguration))]
    [Table("User")]
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public string? ProfileImageUrl { get; set; }
        public long? Streak { get; set; } = 0;
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? LastSessionDate { get; set; }
        public long? Balance { get; set; } = 0;
        public long Xp { get; set; } = 0;
        public int Level { get; set; } = 1;
        public long? DailyGoalMs { get; set; }
        [Required]
        public bool? AccountInitialized { get; set; } = false;
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        [JsonIgnore]
        public DateTime? RefreshTokenExpirationDate { get; set; }
        public Subscription? Subscription { get; set; }
        public List<User> Following { get; set; } = new();
        public List<User> Followers { get; set; } = new();
        public List<Course> Courses { get; set; } = new();
        public List<UserCourse> UserCourses { get; set; } = new();
        public long? SelectedCourseId { get; set; }
        public Course? SelectedCourse { get; set; }
        public List<Topic> Topics { get; set; } = new();
        public List<UserTopic> UserTopics { get; set; } = new();
        public List<Lesson> Lessons { get; set; } = new();
        public List<UserLesson> UserLessons { get; set; } = new();
        public List<Lesson> LessonsCreated { get; set; } = new();
        public List<LessonItem> LessonItems { get; set; } = new();
        public List<UserLessonItem> UserLessonItems { get; set; } = new();
        public List<LearningStat> LearningStats { get; set; } = new();

    }
}
