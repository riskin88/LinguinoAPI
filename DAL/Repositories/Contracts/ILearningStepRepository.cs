using DAL.Entities;

namespace DAL.Repositories.Contracts
{
    public interface ILearningStepRepository : IRepositoryBase<LearningStep>
    {
        Task AddExercise(long stepId, Exercise exercise);
    }
}