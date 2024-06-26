﻿using AutoMapper;
using DAL.Entities;
using DAL.Entities.Enums;

namespace BLL.DTO.Lessons
{
    [AutoMap(typeof(Lesson))]
    public class CreateLessonRespDTO
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public LessonType? Type { get; set; }
        public LessonLevel? Level { get; set; }
        public double? OrderOnMap { get; set; }
        public bool IsCustom { get; set; }
        public long? CourseId { get; set; }
        public string? AuthorId { get; set; }
    }
}
