using DAL.Data;
using DAL.Entities;
using DAL.Entities.Relations;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.Repositories.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

namespace DAL.Repositories
{

    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        private readonly IRoleGuard _roleGuard;
        public CourseRepository(DataContext _dataContext, IRoleGuard roleGuard) : base(_dataContext)
        {
            _roleGuard = roleGuard;
        }

        private async Task<Course?> GetWithTopics(long courseId)
        {
            return await dataContext.Set<Course>().Include(c => c.Topics).FirstOrDefaultAsync(e => e.Id == courseId);
        }

        private async Task<Course?> GetWithUsers(long courseId)
        {
            return await dataContext.Set<Course>().Include(c => c.Users).FirstOrDefaultAsync(e => e.Id == courseId);
        }

        public async Task<IEnumerable<Course>> FindByFilter(CourseFilter filter)
        {
            if (filter.Language1 != null && filter.Language2 != null)
                return await FindByCondition(c => c.Language1 == filter.Language1 && c.Language2 == filter.Language2);
            if (filter.Language1 != null)
                return await FindByCondition(c => c.Language1 == filter.Language1);
            if (filter.Language2 != null)
                return await FindByCondition(c => c.Language2 == filter.Language2);

            return await GetAll();

        }

        public async Task<IEnumerable<Course>> GetOwn()
        {
            return await FindByCondition(c => c.Users.Contains(_roleGuard.user));

        }

        public async Task<Course?> GetWithFeaturedTopics(long courseId)
        {
            return await dataContext.Set<Course>().Include(c => c.Topics.Where(t => t.IsFeatured)).FirstOrDefaultAsync(e => e.Id == courseId);
        }

        public async Task<Course> AddUser(long courseId)
        {
            var course = await GetWithUsers(courseId);
            if (course != null)
            {
                if (!course.Users.Contains(_roleGuard.user))
                    course.Users.Add(_roleGuard.user);
                return course;

            }
            else throw new InvalidIDException("Course does not exist.");
        }

        public async Task<bool> IsEnrolled(long courseId)
        {
            var course = await GetWithUsers(courseId);
            if (course != null)
            {
                return course.Users.Contains(_roleGuard.user);
            }
            else throw new InvalidIDException("Course does not exist.");
        }
        public async Task AddTopic(long courseId, Topic topic)
        {
            var course = await GetWithTopics(courseId);
            if (course != null)
            {
                if (!course.Topics.Contains(topic))
                {
                    course.Topics.Add(topic);
                }

            }
            else throw new InvalidIDException("Course does not exist.");
        }
        public async Task<IEnumerable<Topic>> GetTopics(long courseId, TopicFilter filter)
        {
            var course = await GetWithTopics(courseId);
            if (course != null)
            {
                var topics = course.Topics;

                if (filter.IsFeatured != null && filter.Category != null)
                    return topics.AsQueryable().Where(c => c.IsFeatured == filter.IsFeatured && c.Category == filter.Category);
                if (filter.IsFeatured != null)
                    return topics.AsQueryable().Where(c => c.IsFeatured == filter.IsFeatured);
                if (filter.Category != null)
                    return topics.AsQueryable().Where(c => c.Category == filter.Category);

                return topics;
            }

            else throw new InvalidIDException("Course does not exist.");
        }

        public async Task<IEnumerable<Topic>> GetTopics(long courseId)
        {
            return await dataContext.Set<Course>().Include(c => c.Topics).Where(e => e.Id == courseId).SelectMany(c => c.Topics).ToListAsync();
        }


        public async Task<IEnumerable<Lesson>> GetBuiltinLessons(long courseId)
        {
            return await dataContext.Set<Course>().Include(c => c.Lessons).Where(e => e.Id == courseId).SelectMany(c => c.Lessons).Where(l => l.IsCustom == false).ToListAsync();
        }

        public async Task<IEnumerable<Topic>> GetDefaultTopics(long courseId)
        {
            var course = await GetWithTopics(courseId);
            if (course != null)
            {
                return course.Topics.AsQueryable().Where(t => t.IsDefault);
            }

            else throw new InvalidIDException("Course does not exist.");
        }

        public async Task<IEnumerable<User>> GetUsersWithTopics(long courseId)
        {
            return await dataContext.Set<Course>().Where(e => e.Id == courseId).Include(c => c.Users).ThenInclude(u => u.Topics).SelectMany(c => c.Users).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsers(long courseId)
        {
            return await dataContext.Set<Course>().Where(e => e.Id == courseId).Include(c => c.Users).SelectMany(c => c.Users).ToListAsync();
        }

        public async Task<long> GetActiveLessonId(long courseId)
        {
            string userId = _roleGuard.user.Id;
            var userCourse = await GetUserCourse(courseId);

            var lessons = await dataContext.Set<UserLesson>().Where(ul => ul.UserId == userId && ul.IsVisible && !ul.IsLearned).Select(ul => ul.Lesson).Where(l => !l.IsCustom && l.CourseId == courseId).OrderBy(l => l.OrderOnMap).ToListAsync();
            int startPosition = -1;
            if (userCourse.SelectedLesson != null)
            {
                startPosition = lessons.Select((value, idx) => new { Value = value, Index = idx })
              .FirstOrDefault(l => l.Value.Id == userCourse.SelectedLessonId)?.Index ?? -1;
            }

            lessons = lessons.Skip(startPosition).ToList();

            var currentLesson = lessons.FirstOrDefault();
            if (currentLesson != null)
            {
                return currentLesson.Id;
            }

            else throw new MyBadException("No visible lesson on the study map was found.");

        }

        public async Task<UserCourse> GetUserCourse(long courseId)
        {
            string userId = _roleGuard.user.Id;
            var userCourse = await dataContext.Set<UserCourse>().Include(uc => uc.SelectedLesson).FirstOrDefaultAsync(e => e.CourseId == courseId && e.UserId == userId);
            if (userCourse != null)
            {
                return userCourse;

            }
            else throw new InvalidIDException("Course does not exist.");
        }

        public async Task SelectCourse(long courseId)
        {
            var course = await GetById(courseId);
            if (course != null)
            {
                string userId = _roleGuard.user.Id;
                var user = await dataContext.Set<User>().Include(u => u.SelectedCourse).FirstOrDefaultAsync(u => u.Id == userId);
                user.SelectedCourse = course;
            }
            else throw new InvalidIDException("Course does not exist.");
        }
    }


}
