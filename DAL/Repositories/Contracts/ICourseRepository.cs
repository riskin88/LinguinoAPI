using DAL.Entities;
using DAL.Entities.Relations;
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
        public Task<IEnumerable<Topic>> GetTopics(long courseId);
        public Task<IEnumerable<Lesson>> GetBuiltinLessons(long courseId);

        public Task AddTopic(long courseId, Topic topic);
        public Task<bool> IsEnrolled(long courseId);
        public Task<Course?> GetWithFeaturedTopics(long courseId);
        Task<IEnumerable<Topic>> GetDefaultTopics(long courseId);
        public Task<IEnumerable<User>> GetUsersWithTopics(long courseId);
        public Task<IEnumerable<User>> GetUsers(long courseId);
        public Task<long> GetCurrentLessonId(long courseId);
        public Task MovePositionOnMap(long courseId);
        Task<UserCourse> GetUserCourse(long courseId);
    }
}