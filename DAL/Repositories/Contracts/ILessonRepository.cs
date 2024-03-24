using DAL.Entities;
using DAL.Entities.Enums;
using DAL.Entities.Relations;
using DAL.Filters;

namespace DAL.Repositories.Contracts
{
    public interface ILessonRepository : IRepositoryBase<Lesson>
    {
        Task AddLessonItem(long lessonId, LessonItem item);
        Task AddLessonItemWithOrder(long lessonId, LessonItem item, double? orderInLesson);
        void AddAuthor(Lesson lesson);
        Task AddTopic(long lessonId, Topic topic);
        Task RemoveTopic(long lessonId, Topic topic);
        Task<IEnumerable<Lesson>> GetLessonsFromCourse(long courseId, LessonFilter filter);
        Task<IEnumerable<Lesson>> GetBuiltInLessonsFromCourseOrdered(long courseId, StudyMapFilter filter);
        public bool IsFavorite(long id);
        public Task<IEnumerable<UserTopic>> GetUserTopics(long lessonId);
        Task<bool> EnableOwn(long lessonId);
        Task<bool> EnableLesson(string userId, long lessonId);
        Task<bool> DisableOwn(long lessonId);
        Task AddFeedback(long lessonId, LessonFeedback feedback);
        Task SetFavorite(long lessonId, bool favorite);
        Task DeleteCustom(long lessonId);
        bool IsVisible(string userId, long lessonId);
        bool IsVisibleToSelf(long lessonId);
        Task<LessonFeedback?> GetFeedback(long lessonId);
        Task<Lesson> GetForUser(long lessonId);
        Task AddToSelf(long lessonId);
        Task AddToUser(long lessonId, User user);
        Task<bool> UserHasAccess(long lessonId);
        Task<IEnumerable<User>> GetUsers(long lessonId);
        Task<UserLesson> GetUserLesson(long lessonId);
        Task<Lesson> GetWithItems(long lessonId);
        Task RemoveWord(long lessonId, Word item);
        Task<Lesson?> GetFirstInCourseByLevel(long courseId, LessonLevel level);
    }
}