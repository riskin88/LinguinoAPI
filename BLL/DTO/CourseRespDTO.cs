using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CourseRespDTO : EntityBase
    {
        public string? LanguageFrom { get; set; }
        public string? LanguageTo { get; set; }
        public string? Name { get; set; }
        public string? ThumbnailURL { get; set; }
    }
}
