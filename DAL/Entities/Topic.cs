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
        public bool IsFeatured { get; set; } = true;
        [Required]
        public bool IsMain { get; set; } = true;

    }
}
