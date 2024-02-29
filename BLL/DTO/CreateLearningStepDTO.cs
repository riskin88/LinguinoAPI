using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;

namespace BLL.DTO
{
    [AutoMap(typeof(LearningStep), ReverseMap = true)]
    public class CreateLearningStepDTO
    {
        public int ToInterval { get; set; }
        public int ExercisesInSession { get; set; }
        [Ignore]
        public List<IdDTO> ExercisesId { get; set; }
    }
}
