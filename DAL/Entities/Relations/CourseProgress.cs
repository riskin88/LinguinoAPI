using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class CourseProgress : EntityBase
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; set; }
        [Required]
        public long PositionOnMap { get; set; } = 0;
    }
}
