using DAL.Entities;
using DAL.Filters;

namespace DAL.Repositories.Contracts
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        public Task<IEnumerable<Course>> FindByFilter(CourseFilter filter);
        public Task<IEnumerable<Course>> GetOwn(string id);
        public Task<Course> AddUser(long courseId, string userId);
        public Task<IEnumerable<Topic>> GetTopics(long courseId, TopicFilter filter);
        public Task AddTopic(long courseId, Topic topic);
        public Task<bool> IsEnrolled(long courseId);
        public Task<Course?> GetWithFeaturedTopics(long courseId);
        Task<IEnumerable<Topic>> GetDefaultTopics(long courseId);
        Task InitAllInCourse(long courseId);
    }
}