using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Course : EntityBase
    {
        public string? LanguageFrom { get; set; }
        public string? LanguageTo { get; set; }
        public IEnumerable<CourseProgress> CourseProgresses { get; set; }
    }
}
