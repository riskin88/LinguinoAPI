using DAL.Data;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{

    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        private readonly IRoleGuard _roleGuard;

        public TopicRepository(DataContext _dataContext, IRoleGuard roleGuard) : base(_dataContext)
        {
            _roleGuard = roleGuard;
        }

        private async Task<Topic?> GetWithUsers(long topicId)
        {
            return await dataContext.Set<Topic>().Include(t => t.Users).FirstOrDefaultAsync(e => e.Id == topicId);
        }

        public async Task AddUserToOne(string userId, long topicId)
        {
            var topic = await GetById(topicId);
            if (topic != null)
            {
                if (!await IsEnabled(topicId))
                {
                    if (userId == _roleGuard.user.Id)
                    {
                        topic.Users.Add(_roleGuard.user);
                    }
                    else throw new AccessDeniedException("Not authorized to do this.");
                }
                
            }
            else throw new InvalidIDException("Topic " + topicId + " does not exist.");
        }

        public async Task RemoveUserFromOne(string userId, long topicId)
        {
            var topic = await GetWithUsers(topicId);
            if (topic != null)
                if (userId == _roleGuard.user.Id)
                {
                    topic.Users.Remove(_roleGuard.user);
                }
                else throw new AccessDeniedException("Not authorized to do this.");
            
            else throw new InvalidIDException("Topic does not exist.");
        }

        public async Task<IEnumerable<Topic>> GetOwn()
        {
            return await FindByCondition(c => c.Users.Contains(_roleGuard.user));
        }

        public async Task<bool> IsEnabled(long topicId)
        {
            var topic = await GetWithUsers(topicId);
            if (topic != null)
            {
                if (topic.Users.Contains(_roleGuard.user))
                    return true;
                else return false;
            }
            else throw new InvalidIDException("Topic does not exist.");
        }

        public async Task<Topic?> GetWithCourse(long topicId)
        {
            return await dataContext.Set<Topic>().Include(t => t.Course).FirstOrDefaultAsync(e => e.Id == topicId);
        }
    }


}
