using DAL.Data;
using DAL.Entities;
using DAL.Entities.Relations;
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

        public async Task<UserTopic> GetUserTopic(long topicId)
        {
            string userId = _roleGuard.user.Id;
            var userTopic = await dataContext.Set<UserTopic>().Include(ut => ut.Topic).FirstOrDefaultAsync(e => e.TopicId == topicId && e.UserId == userId);
            if (userTopic != null)
            {
                return userTopic;
            }
            else throw new InvalidIDException("Topic does not exist.");

        }


        public async Task<IEnumerable<UserTopic>> GetUserTopics(long topicId)
        {
            return await dataContext.Set<UserTopic>().Include(ut => ut.Topic).Where(e => e.TopicId == topicId).ToListAsync();
        }


        public async Task<IEnumerable<Topic>> GetOwn()
        {
            return await FindByCondition(c => c.Users.Contains(_roleGuard.user));
        }

        public bool IsEnabled(Topic topic)
        {
            {
                if (topic.Users.Contains(_roleGuard.user))
                    return true;
                else return false;
            }
        }

        public async Task<Topic?> GetWithCourse(long topicId)
        {
            return await dataContext.Set<Topic>().Include(t => t.Course).FirstOrDefaultAsync(e => e.Id == topicId);
        }

        public async Task<IEnumerable<UserLesson>> GetUserLessons(long topicId)
        {
            string userId = _roleGuard.user.Id;
            var topic = await dataContext.Set<Topic>().Include(t => t.Lessons).ThenInclude(l => l.UserLessons).FirstOrDefaultAsync(e => e.Id == topicId);
            if (topic != null)
            {
                return topic.Lessons.AsQueryable().SelectMany(l => l.UserLessons).Include(ul => ul.Lesson).Where(ul => ul.UserId == userId).ToList();

            }
            else throw new InvalidIDException("Topic does not exist.");

        }

    }


}
