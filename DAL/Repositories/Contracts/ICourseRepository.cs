using DAL.Entities;
using DAL.Filters;

namespace DAL.Repositories.Contracts
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        public Task<IEnumerable<Course>> FindByFilter(CourseFilter filter);
        public Task<IEnumerable<Course>> GetOwn(string id);
        public Task<Course> AddUser(long courseId, string userId);
    }
}