using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class AddCourseDTO
    {
        [Required]
        public long CourseId { get; set; }
        public List<IdDTO> SelectedTopics { get; set; }
    }
}
