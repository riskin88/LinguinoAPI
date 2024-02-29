using DAL.Entities;

namespace DAL.Repositories.Contracts
{
    public interface IExerciseRepository : IRepositoryBase<Exercise>
    {
        void AddExercise(Exercise exercise);
        Task<IEnumerable<Exercise>> GetFromStep(long stepId);
        Task<IEnumerable<Exercise>> GetRandomFromItem(long itemId, int numberOfExercises);
    }
}