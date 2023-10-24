using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class TextExercise : Exercise
    {
        [Required]
        public string? Question { get; set; }
        [Required]
        public string? Answer { get; set; }
        public string? Explanation { get; set; }
        public string? ImageURL { get; set; }
        public string? AnswerAudioURL { get; set; }
    }
}
