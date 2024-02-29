using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class RepeatAudioExercise : Exercise
    {
        [Required]
        public string? TextL2 { get; set; }
        [Required]
        public string? AudioURL { get; set; }
    }
}
