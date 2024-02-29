using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ShortListeningExercise : Exercise
    {
        [Required]
        public string? TextL2 { get; set; }
        [Required]
        public string? TextL2AudioURL { get; set; }
    }
}
