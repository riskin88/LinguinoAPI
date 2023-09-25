using AutoMapper;
using DAL.Entities;
using DAL.Entities.Enums;
using DAL.Entities.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    [AutoMap(typeof(Lesson))]
    public class CreateLessonRespDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public LessonType? Type { get; set; }
        public LessonLevel? Level { get; set; }
        public long? OrderOnMap { get; set; }
        public bool IsCustom { get; set; }
        public long? CourseId { get; set; }
        public string? AuthorId { get; set; }
    }
}
