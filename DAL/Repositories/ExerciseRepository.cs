using DAL.Data;
using DAL.Entities;
using DAL.Identity;
using DAL.Repositories.Contracts;

namespace DAL.Repositories
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        private readonly IRoleGuard _roleGuard;

        public ExerciseRepository(DataContext _dataContext, IRoleGuard roleGuard) : base(_dataContext)
        {
            _roleGuard = roleGuard;
        }

        public void Add(TextExercise textExercise)
        {
            dataContext.Set<TextExercise>().Add(textExercise);
        }

        public void Add(FillInBlankExercise fillInBlankExercise)
        {
            dataContext.Set<FillInBlankExercise>().Add(fillInBlankExercise);
        }

        public void Add(FillInBlankOptionsExercise fillInBlankOptionsExercise)
        {
            dataContext.Set<FillInBlankOptionsExercise>().Add(fillInBlankOptionsExercise);
        }

        public void Add(FillInTableExercise fillInTableExercise)
        {
            dataContext.Set<FillInTableExercise>().Add(fillInTableExercise);
        }
    }
}
