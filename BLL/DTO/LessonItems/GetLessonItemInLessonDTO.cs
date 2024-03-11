using AutoMapper;
using BLL.DTO.Exercises.Outbound;
using DAL.Entities;
using DAL.Entities.Enums;
using System.Text.Json.Serialization;

namespace BLL.DTO.LessonItems
{
    [JsonDerivedType(typeof(GetWordInLessonDTO))]
    public class GetLessonItemInLessonDTO
    {
        public long Id { get; set; }
        public LessonType? Type { get; set; }
    }
}
