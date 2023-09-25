using DAL.Entities;
using DAL.Filters;

namespace DAL.Repositories.Contracts
{
    public interface ITopicRepository : IRepositoryBase<Topic>
    {
        public Task<IEnumerable<Topic>> GetOwn();
        public Task AddUser(Topic topic, string userId);
        public Task RemoveUser(Topic topic, string userId);
        public bool IsEnabled(Topic topic);
        public Task<Topic?> GetWithCourse(long topicId);
        public Task<Topic?> GetWithUsers(long topicId);
    }
}