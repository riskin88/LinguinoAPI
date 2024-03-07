using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class FillInSentenceExercise : Exercise
    {
        [Required]
        public string? TextL1 { get; set; }
        [Required]
        public string? TextL2 { get; set; }
        public int[] BlankIndexes { get; set; }
        public string[] Options { get; set; }
        public string? ImageUrl { get; set; }
    }
}
