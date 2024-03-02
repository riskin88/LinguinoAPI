using BLL.DTO;
using BLL.DTO.Exercises.Inbound;
using DAL.Entities;

namespace BLL.Services.Contracts
{
    public interface IExerciseService
    {
        Task<LearningStep> CreateLearningStep(CreateLearningStepDTO createLearningStepDTO, long lessonItemId);
        Task<Exercise> CreateExercise(CreateExerciseDTO exerciseDTO, long lessonItemId);
    }
}