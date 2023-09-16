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
        public Task<bool> HasUser(long courseId, string userId);
        public Task<Course?> GetWithFeaturedTopics(long courseId);
    }
}