using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using DAL.Configs;

namespace DAL.Entities
{
    [EntityTypeConfiguration(typeof(UserConfiguration))]
    [Table("User")]
    public class User : EntityBase
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Username { get; set; }
        public long? Streak { get; set; }
        public long? Cash { get; set; }
        public bool? Premium { get; set; }
        public List<Course> Courses { get; set; } = new();
        public List<CourseProgress> CourseProgresses { get; set; } = new();

    }
}
