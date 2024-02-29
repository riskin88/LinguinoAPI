using BLL.DTO;
using BLL.DTO.Exercises.Inbound;
using DAL.Entities;

namespace BLL.Services.Contracts
{
    public interface IExerciseService
    {
        Task CreateLearningStep(CreateLearningStepDTO createLearningStepDTO, long lessonItemId);
        Task CreateExercise(CreateExerciseDTO exerciseDTO, long lessonItemId);
    }
}