using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User : EntityBase
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Username { get; set; }
        public long? Streak { get; set; }
        public long? Cash { get; set; }
        public bool? Premium { get; set; }
        public IEnumerable<CourseProgress> CourseProgresses { get; set; }

    }
}
