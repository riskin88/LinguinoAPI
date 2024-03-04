using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;

namespace BLL.DTO
{
    public class ExerciseAnswerDTO
    {
        public long ExerciseId { get; set; }
        public long LessonItemId { get; set; }
        public int AnswerRating { get; set; }
    }
}
