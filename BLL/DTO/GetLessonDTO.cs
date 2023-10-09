﻿using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;
using DAL.Entities.Enums;

namespace BLL.DTO
{
    [AutoMap(typeof(Lesson))]
    public class GetLessonDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public LessonType? Type { get; set; }
        public LessonLevel? Level { get; set; }
        public string? BackgroundURL { get; set; }
        public string? VideoURL { get; set; }
        public long? OrderOnMap { get; set; }
        public bool IsCustom { get; set; } = false;
        public bool Visible { get; set; } = false;
        public bool Favorite { get; set; } = false;
        public LessonFeedbackDTO? Feedback { get; set; }
        [SourceMember(nameof(Lesson.LessonItems))]
        public List<LessonItemDTO> LessonItems { get; set; }
    }
}