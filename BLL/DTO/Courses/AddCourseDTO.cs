using DAL.Entities;
using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Courses
{
    public class AddCourseDTO
    {
        public LessonLevel? StartingLevel { get; set; }
        public List<long> SelectedTopicIds { get; set; }
    }
}
