using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class FillInBlankExercise : Exercise
    {
        [Required]
        public string? Question { get; set; }
        [Required]
        public string? Answer { get; set; }
        public int[] BlankIndexes { get; set; }
        public string? ImageURL { get; set; }
        public string? AnswerAudioURL { get; set; }
    }
}
