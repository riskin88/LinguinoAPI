using DAL.Data;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Identity;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{

    public class LearningStepRepository : RepositoryBase<LearningStep>, ILearningStepRepository
    {
        public LearningStepRepository(DataContext _dataContext) : base(_dataContext)
        {
        }

        public async Task AddExercise(long stepId, Exercise exercise)
        {
            var step = await dataContext.Set<LearningStep>().Include(l => l.Exercises).FirstOrDefaultAsync(e => e.Id == stepId);
            if (step != null)
            {

                if (!step.Exercises.Contains(exercise))
                {
                    step.Exercises.Add(exercise);
                }


            }
            else throw new InvalidIDException("Learning step does not exist.");
        }



    }


}
