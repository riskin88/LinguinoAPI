using DAL.Data;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.Repositories.Contracts;
using Microsoft.SqlServer.Server;

namespace DAL.Repositories
{

    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        private readonly IRoleGuard _roleGuard;
        public CourseRepository(DataContext _dataContext, IRoleGuard roleGuard) : base(_dataContext)
        {
            _roleGuard = roleGuard;
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
    }
}
