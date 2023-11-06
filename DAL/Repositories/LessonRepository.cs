using DAL.Data;
using DAL.Entities;
using DAL.Entities.Relations;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Runtime.CompilerServices;

namespace DAL.Repositories
{

    public class LessonRepository : RepositoryBase<Lesson>, ILessonRepository
    {
        private readonly IRoleGuard _roleGuard;

        public LessonRepository(DataContext _dataContext, IRoleGuard roleGuard) : base(_dataContext)
        {
            _roleGuard = roleGuard;
        }

        public async Task AddLessonItem(long lessonId, LessonItem item)
        {
            var lesson = await dataContext.Set<Lesson>().Include(l => l.LessonItems).FirstOrDefaultAsync(e => e.Id == lessonId);
            if (lesson != null)
            {
                if (!lesson.LessonItems.Contains(item))
                {
                    lesson.LessonItems.Add(item);
                }
            }
            else throw new InvalidIDException("Lesson does not exist.");

        }

        public async Task AddLessonItemWithOrder(long lessonId, LessonItem item, double? orderInLesson)
        {
            var lesson = await dataContext.Set<Lesson>().Include(l => l.LessonItems).FirstOrDefaultAsync(e => e.Id == lessonId);
            if (lesson != null)
            {
                if (!lesson.LessonItems.Contains(item))
                {
                    lesson.LessonItems.Add(item);
                }
                var lessonItemLesson = await dataContext.Set<LessonItemLesson>().FirstOrDefaultAsync(e => e.LessonId == lesson.Id && e.LessonItemId == item.Id);
                if (lessonItemLesson != null)
                {
                    lessonItemLesson.OrderInLesson = orderInLesson;
                }
                else throw new MyBadException(null);
            }
            else throw new InvalidIDException("Lesson does not exist.");

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
                    else throw new CourseMismatchException("The topic and lesson belong to different course.");
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
            if (filter.Visible != null)
            {
                lessons = lessons.Where(l => filter.Visible == IsVisibleToSelf(l.Id)).ToList();
            }


            if (filter.Custom != null)
            {
                if (filter.Custom == false)
                    return lessons.Where(l => !l.IsCustom).ToList();

                return lessons.Where(l => l.IsCustom && l.Author == _roleGuard.user).ToList();
            }

            return lessons.Where(l => !l.IsCustom || (l.IsCustom && l.Author == _roleGuard.user)).ToList();

        }

        public async Task<Lesson> GetForUser(long lessonId)
        {
            var lesson = await dataContext.Set<Lesson>().Include(l => l.LessonItems).Include(l => l.Author).FirstOrDefaultAsync(l => l.Id == lessonId);
            if (lesson != null)
            {
                if (lesson.IsCustom && lesson.Author != _roleGuard.user)
                    throw new AccessDeniedException("You are not allowed to access this lesson.");
                return lesson;
            }
            else throw new InvalidIDException("Lesson does not exist.");
        }

        public bool IsFavorite(long lessonId)
        {
            string userId = _roleGuard.user.Id;
            var userLesson = dataContext.Set<UserLesson>().FirstOrDefault(e => e.LessonId == lessonId && e.UserId == userId);

            if (userLesson != null)
            {
                return userLesson.IsFavorite;

            }
            else throw new InvalidIDException("Lesson does not exist or is not available for this user.");
        }

        public bool IsVisibleToSelf(long lessonId)
        {
            string userId = _roleGuard.user.Id;
            var userLesson = dataContext.Set<UserLesson>().FirstOrDefault(e => e.LessonId == lessonId && e.UserId == userId);

            if (userLesson != null)
            {
                return userLesson.IsVisible;

            }
            else throw new InvalidIDException("Lesson does not exist or is not available for this user.");
        }

        public bool IsVisible(string userId, long lessonId)
        {
            var userLesson = dataContext.Set<UserLesson>().FirstOrDefault(e => e.LessonId == lessonId && e.UserId == userId);

            if (userLesson != null)
            {
                return userLesson.IsVisible;

            }
            else throw new InvalidIDException("Lesson does not exist or is not available for this user.");
        }

        public async Task<IEnumerable<UserTopic>> GetUserTopics(long lessonId)
        {
            var lesson = await dataContext.Set<Lesson>().Include(l => l.Topics).ThenInclude(t => t.UserTopics).FirstOrDefaultAsync(e => e.Id == lessonId);
            if (lesson != null)
            {
                string userId = _roleGuard.user.Id;
                return lesson.Topics.AsQueryable().SelectMany(t => t.UserTopics).Include(ut => ut.Topic).Where(ut => ut.UserId == userId).ToList();

            }
            else throw new InvalidIDException("Lesson does not exist.");

        }

        public async Task<bool> EnableOwn(long lessonId)
        {
            string userId = _roleGuard.user.Id;
            var userLesson = await dataContext.Set<UserLesson>().FirstOrDefaultAsync(e => e.LessonId == lessonId && e.UserId == userId);
            if (userLesson != null)
            {
                if (userLesson.IsVisible)
                {
                    return false;
                }
                userLesson.IsVisible = true;
                return true;
            }
            else throw new InvalidIDException("Lesson could not be found.");
        }

        public async Task<bool> EnableLesson(string userId, long lessonId)
        {
            var userLesson = await dataContext.Set<UserLesson>().FirstOrDefaultAsync(e => e.LessonId == lessonId && e.UserId == userId);
            if (userLesson != null)
            {
                if (userLesson.IsVisible)
                {
                    return false;
                }
                userLesson.IsVisible = true;
                return true;
            }
            else throw new InvalidIDException("Lesson could not be found.");
        }

        public async Task<bool> DisableOwn(long lessonId)
        {
            string userId = _roleGuard.user.Id;
            var userLesson = await dataContext.Set<UserLesson>().FirstOrDefaultAsync(e => e.LessonId == lessonId && e.UserId == userId);
            if (userLesson != null)
            {
                if (!userLesson.IsVisible)
                {
                    return false;
                }
                userLesson.IsVisible = false;
                return true;
            }
            else throw new InvalidIDException("Lesson could not be found.");
        }

        public async Task<LessonFeedback?> GetFeedback(long lessonId)
        {
            string userId = _roleGuard.user.Id;
            var userLesson = await dataContext.Set<UserLesson>().Include(ul => ul.Feedback).FirstOrDefaultAsync(e => e.LessonId == lessonId && e.UserId == userId);
            if (userLesson != null)
            {
                return userLesson.Feedback;
            }
            else throw new InvalidIDException("Lesson does not exist or is not available for this user.");
        }

        public async Task AddFeedback(long lessonId, LessonFeedback feedback)
        {
            string userId = _roleGuard.user.Id;
            var userLesson = await dataContext.Set<UserLesson>().Include(ul => ul.Feedback).FirstOrDefaultAsync(e => e.LessonId == lessonId && e.UserId == userId);

            if (userLesson != null)
            {
                userLesson.Feedback = feedback;

            }
            else throw new InvalidIDException("Lesson does not exist or is not available for this user.");
        }

        public async Task SetFavorite(long lessonId, bool favorite)
        {
            string userId = _roleGuard.user.Id;
            var userLesson = await dataContext.Set<UserLesson>().FirstOrDefaultAsync(e => e.LessonId == lessonId && e.UserId == userId);
            if (userLesson != null)
            {
                userLesson.IsFavorite = favorite;
            }
            else throw new InvalidIDException("Lesson could not be found.");
        }

        public async Task DeleteCustom(long lessonId)
        {
            var lesson = await GetById(lessonId);
            if (lesson != null)
            {
                if (lesson.IsCustom && lesson.AuthorId == _roleGuard.user.Id)
                {
                    Remove(lesson);
                }
                else throw new AccessDeniedException();
            }
            else throw new InvalidIDException("Lesson does not exist.");
        }

        public async Task AddToSelf(long lessonId)
        {
            var lesson = await dataContext.Set<Lesson>().Include(l => l.Users).Include(l => l.LessonItems).ThenInclude(l => l.Users).FirstOrDefaultAsync(l => l.Id == lessonId);
            if (lesson != null)
            {
                if (!lesson.Users.Contains(_roleGuard.user))
                    lesson.Users.Add(_roleGuard.user);
                foreach (var item in lesson.LessonItems)
                {
                    if (!item.Users.Contains(_roleGuard.user))
                        item.Users.Add(_roleGuard.user);
                }
            }
            else throw new InvalidIDException("Lesson does not exist.");
        }

        public async Task AddToUser(long lessonId, User user)
        {
            var lesson = await dataContext.Set<Lesson>().Include(l => l.Users).Include(l => l.LessonItems).ThenInclude(l => l.Users).FirstOrDefaultAsync(l => l.Id == lessonId);
            if (lesson != null)
            {
                if (!lesson.Users.Contains(user))
                    lesson.Users.Add(user);
                foreach (var item in lesson.LessonItems)
                {
                    if (!item.Users.Contains(user))
                        item.Users.Add(user);
                }
            }
            else throw new InvalidIDException("Lesson does not exist.");
        }
    }


}
