using DAL.Entities.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("LearningStep")]
    public class LearningStep : EntityBase
    {
        public int ToInterval { get; set; }
        public int ExercisesInSession { get; set; }
        [JsonIgnore]
        public List<Exercise> Exercises { get; set; } = new();
        [JsonIgnore]
        public List<LearningStepExercise> LearningStepExercises { get; set; } = new();
        public long? LessonItemId { get; set; }
        [JsonIgnore]
        public LessonItem? LessonItem { get; set; }
    }
}
