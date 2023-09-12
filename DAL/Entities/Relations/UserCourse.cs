using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("UserCourse")]
    public class UserCourse : EntityBase
    {
        public string UserId { get; set; }
        public User User { get; set; } = null!;
        public long CourseId { get; set; }
        public Course Course { get; set; } = null!;
        [Required]
        public long PositionOnMap { get; set; } = 0;
        public bool IsSelected { get; set; }
    }
}
