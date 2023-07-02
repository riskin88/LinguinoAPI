using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Course")]
    public class Course : EntityBase
    {
        public string? LanguageFrom { get; set; }
        public string? LanguageTo { get; set; }
        public List<User> Users { get; set; } = new();
        public List<CourseProgress> CourseProgresses { get; set; } = new();
    }
}
