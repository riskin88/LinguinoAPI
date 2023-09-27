using DAL.Entities;
using DAL.Entities.Relations;
using DAL.Filters;

namespace DAL.Repositories.Contracts
{
    public interface ITopicRepository : IRepositoryBase<Topic>
    {
        public Task<IEnumerable<Topic>> GetOwn();
        public bool IsEnabled(Topic topic);
        public Task<Topic?> GetWithCourse(long topicId);
        public Task<UserTopic> GetUserTopic(long topicId);
        public Task<IEnumerable<UserLesson>> GetUserLessons(long topicId);
    }
}