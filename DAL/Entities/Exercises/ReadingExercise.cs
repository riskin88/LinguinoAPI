using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ReadingExercise : Exercise
    {
        [Required]
        public string? Article { get; set; }
        [Required]
        public string? QuestionL2 { get; set; }
        [Required]
        public string? AnswerL2 { get; set; }
        public string? ImageURL { get; set; }
    }
}
