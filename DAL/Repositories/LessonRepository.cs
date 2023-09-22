using DAL.Data;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Identity;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{

    public class LessonRepository : RepositoryBase<Lesson>, ILessonRepository
    {
        private readonly IRoleGuard _roleGuard;

        public LessonRepository(DataContext _dataContext, IRoleGuard roleGuard) : base(_dataContext)
        {
            _roleGuard = roleGuard;
        }

        public void AddLessonItem(Lesson lesson, LessonItem item)
        {

            if (!lesson.LessonItems.Contains(item))
            {
                lesson.LessonItems.Add(item);
            }
        }

        private async Task<Lesson?> GetWithTopics(long lessonId)
        {
            return await dataContext.Set<Lesson>().Include(l => l.Topics).FirstOrDefaultAsync(e => e.Id == lessonId);
        }

        public void AddAuthor(Lesson lesson)
        {
            lesson.Author = _roleGuard.user;
        }

        public async Task AddTopic(long lessonId, Topic topic)
        {
            var lesson = await GetWithTopics(lessonId);
            if (lesson != null)
            {
                if (!lesson.IsCustom)
                {
                    if (lesson.CourseId == topic.CourseId)
                    {
                        if (!lesson.Topics.Contains(topic))
                        {
                            lesson.Topics.Add(topic);
                        }
                    }
                    else throw new InvalidIDException("The topic and lesson belong to different course.");
                }
                else throw new InvalidIDException("This is a custom lesson.");
            }
            else throw new InvalidIDException("Lesson does not exist.");
        }

        public async Task RemoveTopic(long lessonId, Topic topic)
        {
            var lesson = await GetWithTopics(lessonId);
            if (lesson != null)
            {
                lesson.Topics.Remove(topic);
            }
            else throw new InvalidIDException("Lesson does not exist.");
        }
    }


}
