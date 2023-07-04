using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("CourseProgress")]
    public class CourseProgress : EntityBase
    {
        public string UserId { get; set; }
        public User User { get; set; } = null!;
        public long CourseId { get; set; }
        public Course Course { get; set; } = null!;
        [Required]
        public long PositionOnMap { get; set; } = 0;
    }
}
