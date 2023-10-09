using DAL.Entities.Relations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Course")]
    public class Course : EntityBase
    {
        [Required]
        public string? Language1 { get; set; }
        [Required]
        public string? Language2 { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? ThumbnailURL { get; set; }
        public List<User> Users { get; set; } = new();
        public List<UserCourse> UserCourses { get; set; } = new();
        public List<Topic> Topics { get; set; } = new();
        public List<Lesson> Lessons { get; set; } = new();
    }
}
