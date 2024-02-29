using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class SpeechExercise : Exercise
    {
        [Required]
        public string? AssignmentTopicL2 { get; set; }
        [Required]
        public int TimeMs { get; set; }
        public string[] Questions { get; set; }
    }
}
