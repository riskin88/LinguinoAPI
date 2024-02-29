using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ReadAloudExercise : Exercise
    {
        [Required]
        public string? TextL2 { get; set; }
        public string? ImageURL { get; set; }
    }
}
