using DAL.Entities;
using DAL.Filters;

namespace DAL.Repositories.Contracts
{
    public interface ITopicRepository : IRepositoryBase<Topic>
    {
        public Task<IEnumerable<Topic>> GetOwn();
        public Task AddUserToOne(string userId, long topicId);
        public Task RemoveUserFromOne(string userId, long topicId);
        public Task<bool> IsEnabled(long topicId);
        public Task<Topic?> GetWithCourse(long topicId);
    }
}