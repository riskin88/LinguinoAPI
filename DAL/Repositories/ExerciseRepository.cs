using DAL.Data;
using DAL.Entities;
using DAL.Entities.Relations;
using DAL.Exceptions;
using DAL.Identity;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        private readonly IRoleGuard _roleGuard;

        public ExerciseRepository(DataContext _dataContext, IRoleGuard roleGuard) : base(_dataContext)
        {
            _roleGuard = roleGuard;
        }

        public void AddExercise(Exercise exercise)
        {
            dataContext.Set<Exercise>().Add(exercise);
        }

        public async Task<IEnumerable<Exercise>> GetFromStep(long stepId)
        {
            var step = await dataContext.Set<LearningStep>().Include(s => s.Exercises).FirstOrDefaultAsync(s => s.Id == stepId);
            if (step != null)
            {
                var exercisesInSession = step.ExercisesInSession;
                var exercises = step.Exercises;
                Random rnd = new Random();
                return exercises.OrderBy(x => rnd.Next()).Take(exercisesInSession);
            }
            else throw new InvalidIDException("Learning step does not exist.");

        }

        public async Task<IEnumerable<Exercise>> GetRandomFromItem(long itemId, int numberOfExercises)
        {
            var item = await dataContext.Set<LessonItem>().Include(l => l.Exercises).FirstOrDefaultAsync(l => l.Id == itemId);
            if (item != null)
            {
                var exercises = item.Exercises;
                Random rnd = new Random();
                return exercises.OrderBy(x => rnd.Next()).Take(numberOfExercises);
            }
            else throw new InvalidIDException("Lesson item does not exist.");
        }
    }
}
