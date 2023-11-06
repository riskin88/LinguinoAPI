using DAL.Entities.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("LearningStep")]
    public class LearningStep : EntityBase
    {
        public int FromInterval { get; set; }
        public List<Exercise> Exercises { get; set; } = new();
        public List<LearningStepExercise> LearningStepExercises { get; set; } = new();
        public long? LessonItemId { get; set; }
        public LessonItem? LessonItem { get; set; }
    }
}
