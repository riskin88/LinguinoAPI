using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ListeningExercise : Exercise
    {
        [Required]
        public string? AudioURL { get; set; }
        [Required]
        public string? QuestionL2 { get; set; }
        [Required]
        public string? AnswerL2 { get; set; }
        public string? ImageURL { get; set; }
    }
}
