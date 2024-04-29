using DAL.Data;
using DAL.Entities;
using DAL.Entities.Enums;
using DAL.Entities.Relations;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories
{
    public class LessonItemRepository : RepositoryBase<LessonItem>, ILessonItemRepository
    {
        private readonly IRoleGuard _roleGuard;
        public LessonItemRepository(DataContext _dataContext, IRoleGuard roleGuard) : base(_dataContext)
        {
            _roleGuard = roleGuard;
        }

        public void AddWord(Word word)
        {
            dataContext.Set<Word>().Add(word);
            word.Type = LessonType.VOCABULARY;
        }

        public void AddItem(LessonItem item)
        {
            dataContext.Set<LessonItem>().Add(item);
        }

        public async Task<IEnumerable<LessonItem>> GetNewInLessonOrdered(long lessonId)
        {
            var lesson = await dataContext.Set<Lesson>().FirstOrDefaultAsync(l => l.Id == lessonId);

            if (lesson != null)
            {
                string userId = _roleGuard.user.Id;
                var items = await dataContext.Set<LessonItem>().Include(li => li.Lessons).Where(li => li.Lessons.Contains(lesson)).SelectMany(li => li.UserLessonItems).Where(ul => ul.UserId == userId && ul.ItemState == LessonItemState.NEW).Select(ul => ul.LessonItem).Distinct().ToListAsync();
                List<LessonItem> res = new();
                foreach (var item in items)
                {
                    res.Add(await dataContext.Set<LessonItem>().Include(li => li.LearningSteps).Include(li => li.Lessons).FirstOrDefaultAsync(li => li.Id == item.Id));
                }
                return res.OrderBy(li => GetOrderInLessonNotNull(lessonId, li.Id)).ToList();

            }
            else throw new InvalidIDException("Lesson does not exist.");
        }

        public async Task<IEnumerable<LessonItem>> GetOverdueToReviewInCourseOrdered(long courseId)
        {
            var course = dataContext.Set<Course>().Include(c => c.Lessons).ThenInclude(l => l.LessonItems).ThenInclude(li => li.UserLessonItems).Where(c => c.Id == courseId);
            if (course != null)
            {
                string userId = _roleGuard.user.Id;
                var items = await course.SelectMany(c => c.Lessons).SelectMany(l => l.LessonItems).SelectMany(li => li.UserLessonItems).Where(ul => ul.UserId == userId && ul.ItemState == LessonItemState.REVIEW && ul.DateToReview <= DateTime.Now).Select(ul => ul.LessonItem).Distinct().ToListAsync();
                List<LessonItem> res = new();
                foreach (var item in items)
                {
                    res.Add(await dataContext.Set<LessonItem>().Include(li => li.LearningSteps).Include(li => li.Lessons).FirstOrDefaultAsync(li => li.Id == item.Id));
                }
                return res.OrderBy(li => GetDateToReview(li.Id)).ToList();
            }
            else throw new InvalidIDException("Course does not exist.");

        }

        public async Task<IEnumerable<LessonItem>> GetToReviewInLessonOrdered(long lessonId)
        {
            var lesson = await dataContext.Set<Lesson>().FirstOrDefaultAsync(l => l.Id == lessonId);

            if (lesson != null)
            {
                string userId = _roleGuard.user.Id;
                var items = await dataContext.Set<UserLessonItem>().Include(ul => ul.LessonItem).ThenInclude(li => li.Lessons).Where(ul => ul.UserId == userId && ul.ItemState == LessonItemState.REVIEW).Select(ul => ul.LessonItem).Where(li => li.Lessons.Contains(lesson)).Distinct().ToListAsync();
                List<LessonItem> res = new();
                foreach (var item in items)
                {
                    res.Add(await dataContext.Set<LessonItem>().Include(li => li.LearningSteps).Include(li => li.Lessons).FirstOrDefaultAsync(li => li.Id == item.Id));
                }
                return res.OrderBy(li => GetDateToReview(li.Id)).ToList();
            }
            else throw new InvalidIDException("Lesson does not exist.");
        }

        public Task<Word?> GetWordById(long wordId)
        {
           return  dataContext.Set<Word>().FirstOrDefaultAsync(e => e.Id == wordId);
        }

        public async Task<UserLessonItem> GetUserLessonItem (long itemId)
        {
            string userId = _roleGuard.user.Id;
            var ul = await dataContext.Set<UserLessonItem>().FirstOrDefaultAsync(ul => ul.UserId == userId && ul.LessonItemId == itemId);

            if (ul != null)
            {
                return ul;
            }
            else throw new InvalidIDException("Lesson item does not exist.");
        }

        public async Task RemoveExercise(long lessonItemId, Exercise exercise)
        {
            var item = await dataContext.Set<LessonItem>().Include(l => l.Exercises).FirstOrDefaultAsync(e => e.Id == lessonItemId);
            if (item != null)
            {

                if (item.Exercises.Contains(exercise))
                {
                    item.Exercises.Remove(exercise);
                }


            }
            else throw new InvalidIDException("Lesson item does not exist.");
        }

        private double GetOrderInLessonNotNull(long lessonId, long lessonItemId)
        {
            var order = dataContext.Set<LessonItemLesson>().FirstOrDefault(lil => lil.LessonId == lessonId && lil.LessonItemId == lessonItemId).OrderInLesson;
            return order ?? double.MaxValue;
        }

        private DateTime? GetDateToReview(long lessonItemId)
        {
            string userId = _roleGuard.user.Id;
            return dataContext.Set<UserLessonItem>().FirstOrDefault(ul => ul.UserId == userId && ul.LessonItemId == lessonItemId).DateToReview;
        }

        public async Task AddToUser(long lessonItemId, User user)
        {
            var lessonItem = await dataContext.Set<LessonItem>().Include(l => l.Users).FirstOrDefaultAsync(l => l.Id == lessonItemId);
            if (lessonItem != null)
            {
                if (!lessonItem.Users.Contains(user))
                    lessonItem.Users.Add(user);
            }
            else throw new InvalidIDException("Lesson item does not exist.");
        }

        public async Task<IEnumerable<UserLesson>> GetUserLessons(long lessonItemId)
        {
                string userId = _roleGuard.user.Id;
                return await dataContext.Set<LessonItem>().Where(li => li.Id == lessonItemId).SelectMany(li => li.Lessons).SelectMany(l => l.UserLessons).Include(l => l.Lesson).Where(ul => ul.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Word>> GetVocabularyInCourse(long courseId, VocabularyFilter filter)
        {
            var course = await GetById(courseId);
            if (course != null)
            {
                var vocab = await dataContext.Set<Course>().Where(c => c.Id == courseId).SelectMany(c => c.Lessons).SelectMany(l => l.LessonItems).OfType<Word>().Distinct()
                    .Where(w => filter.SearchName == null || (w.NameL1 != null && w.NameL1.StartsWith(filter.SearchName)) || (w.NameL2 != null && w.NameL2.StartsWith(filter.SearchName))).ToListAsync();


                if (filter.Favorite != null)
                {
                    vocab = vocab.Where(w => filter.Favorite == IsFavorite(w.Id)).ToList();
                }

                return vocab;
            }
            else throw new InvalidIDException("Course does not exist.");

        }

        public bool IsFavorite(long lessonItemId)
        {
            string userId = _roleGuard.user.Id;
            var userLessonItem = dataContext.Set<UserLessonItem>().FirstOrDefault(e => e.LessonItemId == lessonItemId && e.UserId == userId);

            if (userLessonItem != null)
            {
                return userLessonItem.IsFavorite;

            }
            else throw new InvalidIDException("Lesson item does not exist.");
        }

        public async Task<bool> WordInCourse(long wordId, long courseId)
        {
            var lessons = await dataContext.Set<Word>().Where(li => li.Id == wordId).SelectMany(li => li.Lessons).ToListAsync();
            foreach (var lesson in lessons)
            {
                if (lesson.CourseId == courseId)
                    return true;
            }
            return false;
        }
    }
}
