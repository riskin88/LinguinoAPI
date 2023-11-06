using DAL.Configs;
using DAL.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
    [EntityTypeConfiguration(typeof(ExerciseConfiguration))]
    [Table("Exercise")]
    public class Exercise : EntityBase
    {
        public double? OrderInItem { get; set; }
        public long EstimatedTimeMs { get; set; }
        public long? LessonItemId { get; set; }
        public LessonItem? LessonItem { get; set; }
        public List<LearningStep> LearningSteps { get; set; } = new();
        public List<LearningStepExercise> LearningStepExercises { get; set; } = new();
    }
}
