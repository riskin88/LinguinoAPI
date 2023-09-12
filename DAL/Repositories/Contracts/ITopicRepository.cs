using DAL.Entities;
using DAL.Filters;

namespace DAL.Repositories.Contracts
{
    public interface ITopicRepository : IRepositoryBase<Topic>
    {
        public Task AddUserToMany(IEnumerable<long> topicId, string userId);
    }
}