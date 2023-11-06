using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Relations
{
    [Table("LearningStepExercise")]
    public class LearningStepExercise : EntityBase
    {
        public long LearningStepId { get; set; }
        public LearningStep LearningStep { get; set; } = null!;
        public long ExerciseId { get; set; }
        public Exercise Exercise { get; set; } = null!;
    }
}
