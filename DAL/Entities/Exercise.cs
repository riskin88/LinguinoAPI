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
        public long EstimatedTimeMs { get; set; }
        public long? LessonItemId { get; set; }
        [JsonIgnore]
        public LessonItem? LessonItem { get; set; }
        [JsonIgnore]
        public List<LearningStep> LearningSteps { get; set; } = new();
        [JsonIgnore]
        public List<LearningStepExercise> LearningStepExercises { get; set; } = new();
    }
}
