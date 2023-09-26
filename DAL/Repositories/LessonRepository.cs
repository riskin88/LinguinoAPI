using DAL.Data;
using DAL.Entities;
using DAL.Entities.Relations;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{

    public class LessonRepository : RepositoryBase<Lesson>, ILessonRepository
    {
        private readonly IRoleGuard _roleGuard;

        public LessonRepository(DataContext _dataContext, IRoleGuard roleGuard) : base(_dataContext)
        {
            _roleGuard = roleGuard;
        }

        public void AddLessonItem(Lesson lesson, LessonItem item)
        {

            if (!lesson.LessonItems.Contains(item))
            {
                lesson.LessonItems.Add(item);
            }
        }

        private async Task<Lesson?> GetWithTopics(long lessonId)
        {
            return await dataContext.Set<Lesson>().Include(l => l.Topics).FirstOrDefaultAsync(e => e.Id == lessonId);
        }

        public void AddAuthor(Lesson lesson)
        {
            lesson.Author = _roleGuard.user;
        }

        public async Task AddTopic(long lessonId, Topic topic)
        {
            var lesson = await GetWithTopics(lessonId);
            if (lesson != null)
            {
                if (!lesson.IsCustom)
                {
                    if (lesson.CourseId == topic.CourseId)
                    {
                        if (!lesson.Topics.Contains(topic))
                        {
                            lesson.Topics.Add(topic);
                        }
                    }
                    else throw new InvalidIDException("The topic and lesson belong to different course.");
                }
                else throw new InvalidIDException("This is a custom lesson.");
            }
            else throw new InvalidIDException("Lesson does not exist.");
        }

        public async Task RemoveTopic(long lessonId, Topic topic)
        {
            var lesson = await GetWithTopics(lessonId);
            if (lesson != null)
            {
                lesson.Topics.Remove(topic);
            }
            else throw new InvalidIDException("Lesson does not exist.");
        }

        public async Task<IEnumerable<Lesson>> GetLessonsFromCourse(long courseId, LessonFilter filter)
        {
            var lessons = await dataContext.Set<Lesson>().Include(l => l.Author).Where(
                l => l.CourseId == courseId &&
            (filter.Type == null || filter.Type == l.Type) &&
            (filter.Level == null || filter.Level == l.Level)).ToListAsync();
            if (filter.Favorite != null)
            {
                lessons = lessons.Where(l => filter.Favorite == IsFavorite(l.Id)).ToList();
            }
            if (filter.Custom != null)
            {
                if (filter.Custom == false)
                    return lessons.Where(l => !l.IsCustom).ToList();

                return lessons.Where(l => l.IsCustom && l.Author == _roleGuard.user).ToList();
            }

            return lessons.Where(l => !l.IsCustom || (l.IsCustom && l.Author == _roleGuard.user)).ToList();

        }
         
        public bool IsFavorite(long id)
        {
            var lesson = dataContext.Set<Lesson>().Include(l => l.UserLessons).FirstOrDefault(l => l.Id == id);
            if (lesson != null)
            {
                var userLesson = lesson.UserLessons.AsQueryable().FirstOrDefault(ul => ul.User == _roleGuard.user);

                if (userLesson != null)
                {
                    return userLesson.IsFavorite;
                }
                return false;
            }
            else throw new InvalidIDException("Lesson does not exist.");
        }

        public async Task<IEnumerable<UserTopic>> GetUserTopics(long lessonId, string userId)
        {
            if (userId == _roleGuard.user.Id)
            {
                var lesson = await dataContext.Set<Lesson>().Include(l => l.Topics).ThenInclude(t => t.UserTopics).FirstOrDefaultAsync(e => e.Id == lessonId);
                if (lesson != null)
                {
                    return await lesson.Topics.AsQueryable().SelectMany(t => t.UserTopics).Include(ut => ut.Topic).Where(ut => ut.UserId == userId).ToListAsync();

                }
                else throw new InvalidIDException("Lesson does not exist.");

            }
            else throw new AccessDeniedException("Not authorized to do this.");
        }
    }


}
