using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;

namespace BLL.DTO
{
    [AutoMap(typeof(LearningStep), ReverseMap = true)]
    public class CreateLearningStepDTO
    {
        public int FromInterval { get; set; }
        [Ignore]
        public List<IdDTO> Excercises { get; set; }
    }
}
