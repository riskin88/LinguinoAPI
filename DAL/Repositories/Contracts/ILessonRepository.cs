using DAL.Entities;
using DAL.Entities.Relations;
using DAL.Filters;

namespace DAL.Repositories.Contracts
{
    public interface ILessonRepository : IRepositoryBase<Lesson>
    {
        void AddLessonItem(Lesson lesson, LessonItem item);
        void AddAuthor(Lesson lesson);
        Task AddTopic(long lessonId, Topic topic);
        Task RemoveTopic(long lessonId, Topic topic);
        public Task<IEnumerable<Lesson>> GetLessonsFromCourse(long courseId, LessonFilter filter);
        public bool IsFavorite(long id);
        public Task<IEnumerable<UserTopic>> GetUserTopics(long lessonId, string userId);
    }
}