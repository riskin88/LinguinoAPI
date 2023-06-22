using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Topic : EntityBase
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public bool IsFeatured { get; set; } = true;
        [Required]
        public bool IsMain { get; set; } = true;

    }
}
