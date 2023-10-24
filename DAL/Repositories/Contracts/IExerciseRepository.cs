using DAL.Entities;

namespace DAL.Repositories.Contracts
{
    public interface IExerciseRepository : IRepositoryBase<Exercise>
    {
        void Add(TextExercise textExercise);
        void Add(FillInBlankExercise fillInBlankExercise);
        void Add(FillInBlankOptionsExercise fillInBlankOptionsExercise);
        void Add(FillInTableExercise fillInTableExercise);
    }
}