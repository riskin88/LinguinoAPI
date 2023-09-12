using DAL.Data;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.Migrations;
using DAL.Repositories.Contracts;

namespace DAL.Repositories
{

    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        private readonly IRoleGuard _roleGuard;

        public TopicRepository(DataContext _dataContext, IRoleGuard roleGuard) : base(_dataContext)
        {
            _roleGuard = roleGuard;
        }

        public async Task AddUserToMany(IEnumerable<long> topicId, string userId)
        {
            if (userId == _roleGuard.user.Id)
            {
                var user = _roleGuard.user;
                foreach (long id in topicId)
                {
                    var topic = await GetById(id);
                    topic.Users.Add(user);
                }
            }
            else throw new AccessDeniedException("Not authorized to do this.");
        }
    }
}
