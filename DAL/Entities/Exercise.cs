using DAL.Configs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
    [EntityTypeConfiguration(typeof(ExerciseConfiguration))]
    [Table("Exercise")]
    public class Exercise : EntityBase
    {
        public long? LessonItemId { get; set; }
        public LessonItem? LessonItem { get; set; }
        public double? OrderInItem { get; set; }
        public long EstimatedTimeMs { get; set; }
    }
}
