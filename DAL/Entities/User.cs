using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using DAL.Configs;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    [EntityTypeConfiguration(typeof(UserConfiguration))]
    [Table("User")]
    public class User : IdentityUser
    {
        public long? Streak { get; set; }
        public long? Balance { get; set; }
        [Required]
        public bool? AccountInitialized { get; set; } = false;
        public List<Course> Courses { get; set; } = new();
        public List<UserCourse> UserCourses { get; set; } = new();
        public List<Topic> Topics { get; set; } = new();
        public List<UserTopic> UserTopics { get; set; } = new();

    }
}
