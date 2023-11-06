using BLL.DTO;
using BLL.DTO.Exercises;
using DAL.Entities;

namespace BLL.Services.Contracts
{
    public interface IExerciseService
    {
        Task CreateFillInBlankExercise(CreateFillInBlankExerciseDTO fillInBlankExerciseDTO, long lessonItemId);
        Task CreateFillInBlankOptionsExercise(CreateFillInBlankOptionsExerciseDTO fillInBlankOptionsExerciseDTO, long lessonItemId);
        Task CreateFillInTableExercise(CreateFillInTableExerciseDTO fillInTableExerciseDTO, long lessonItemId);
        Task CreateLearningStep(CreateLearningStepDTO createLearningStepDTO, long lessonItemId);
        Task CreateTextExercise(CreateTextExerciseDTO textExerciseDTO, long lessonItemId);
    }
}