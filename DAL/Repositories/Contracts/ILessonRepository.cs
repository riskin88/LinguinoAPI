using DAL.Entities;

namespace DAL.Repositories.Contracts
{
    public interface ILessonRepository : IRepositoryBase<Lesson>
    {
        void AddLessonItem(Lesson lesson, LessonItem item);
        void AddAuthor(Lesson lesson);
        Task AddTopic(long lessonId, Topic topic);
        Task RemoveTopic(long lessonId, Topic topic);
    }
}