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

        public async Task<Topic?> GetWithUsers(long topicId)
        {
            return await dataContext.Set<Topic>().Include(t => t.Users).FirstOrDefaultAsync(e => e.Id == topicId);
        }

        public async Task AddUser(Topic topic, string userId)
        {
            if (userId == _roleGuard.user.Id)
            {
                if (!topic.Users.Contains(_roleGuard.user))
                    topic.Users.Add(_roleGuard.user);

                var lessons = await GetLessons(topic.Id);
                foreach (var lesson in lessons)
                {
                    if (!lesson.Users.Contains(_roleGuard.user))
                        lesson.Users.Add(_roleGuard.user);
                }
            }
            else throw new AccessDeniedException("Not authorized to do this.");
        }

        public async Task RemoveUser(Topic topic, string userId)
        {
                if (userId == _roleGuard.user.Id)
                {
                    topic.Users.Remove(_roleGuard.user);
                var lessons = await GetLessons(topic.Id);
                foreach (var lesson in lessons)
                {
                    lesson.Users.Remove(_roleGuard.user);
                }
            }
                else throw new AccessDeniedException("Not authorized to do this.");

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

        private async Task<IEnumerable<Lesson>> GetLessons(long topicId)
        {
            var topic = await dataContext.Set<Topic>().Include(t => t.Lessons).FirstOrDefaultAsync(e => e.Id == topicId);
            if (topic != null)
                return topic.Lessons;
            else return new List<Lesson>();
        }
    }


}
