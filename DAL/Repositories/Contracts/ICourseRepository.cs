using DAL.Entities;
using DAL.Filters;
using System.Threading.Tasks;

namespace DAL.Repositories.Contracts
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        public Task<IEnumerable<Course>> FindByFilter(CourseFilter filter);
        public Task<IEnumerable<Course>> GetOwn();
        public Task<Course> AddUser(long courseId);
        public Task<IEnumerable<Topic>> GetTopics(long courseId, TopicFilter filter);
        public Task AddTopic(long courseId, Topic topic);
        public Task<bool> IsEnrolled(long courseId);
        public Task<Course?> GetWithFeaturedTopics(long courseId);
        Task<IEnumerable<Topic>> GetDefaultTopics(long courseId);
        Task InitAllInCourse(long courseId);
        public Task<IEnumerable<User>> GetUsersWithTopics(long courseId);
        Task<IEnumerable<User>> GetUsersWithLessons(long courseId);
    }
}