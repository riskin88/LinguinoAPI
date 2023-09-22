using DAL.Data;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


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

        public async Task<IEnumerable<Course>> FindByFilter(CourseFilter filter)
        {
            if (filter.LanguageFrom != null && filter.LanguageTo != null)
                return await FindByCondition(c => c.LanguageFrom == filter.LanguageFrom && c.LanguageTo == filter.LanguageTo);
            if (filter.LanguageFrom != null)
                return await FindByCondition(c => c.LanguageFrom == filter.LanguageFrom);
            if (filter.LanguageTo != null)
                return await FindByCondition(c => c.LanguageTo == filter.LanguageTo);

            return await GetAll();

        }

        public async Task<IEnumerable<Course>> GetOwn(string id)
        {
            if (id == _roleGuard.user.Id)
                return await FindByCondition(c => c.Users.Contains(_roleGuard.user));
            else throw new AccessDeniedException("Not authorized to view this data.");

        }

        public async Task<Course?> GetWithFeaturedTopics(long courseId)
        {
            return await dataContext.Set<Course>().Include(c => c.Topics.Where(t => t.IsFeatured)).FirstOrDefaultAsync(e => e.Id == courseId);
        }

        public async Task<Course> AddUser(long courseId, string userId)
        {
            var course = await GetById(courseId);
            if (course != null)
            {
                if (userId == _roleGuard.user.Id)
                {
                    course.Users.Add(_roleGuard.user);
                    return course;
                }

                else throw new AccessDeniedException("Not authorized to do this.");
            }
            else throw new InvalidIDException("Course does not exist.");
        }

        public async Task<bool> IsEnrolled(long courseId)
        {
            var course = await dataContext.Set<Course>().Include(c => c.Users).FirstOrDefaultAsync(e => e.Id == courseId);
            if (course != null && course.Users.Contains(_roleGuard.user))
                return true;
            else return false;

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
    }


}
