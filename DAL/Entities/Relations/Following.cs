using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Relations
{
    [Table("Following")]
    public class Following : EntityBase
    {
        public string FollowerId { get; set; }
        public string FolloweeId { get; set; }
    }
}
