using DAL.Entities;
using DAL.Entities.Relations;
using DAL.Filters;

namespace DAL.Repositories.Contracts
{
    public interface ILessonItemRepository : IRepositoryBase<LessonItem>
    {
        void AddWord(Word word);
        void AddItem(LessonItem item);
        Task<IEnumerable<LessonItem>> GetNewInLessonOrdered(long lessonId);
        Task<IEnumerable<LessonItem>> GetOverdueToReviewInCourseOrdered(long courseId);
        Task<IEnumerable<LessonItem>> GetToReviewInLessonOrdered(long lessonId);
        Task<Word?> GetWordById(long wordId);
        Task<UserLessonItem> GetUserLessonItem(long itemId);
        Task RemoveExercise(long lessonItemId, Exercise exercise);
        Task AddToUser(long lessonItemId, User user);
        Task<IEnumerable<UserLesson>> GetUserLessons(long lessonItemId);
        Task<IEnumerable<Word>> GetLessonItemsFromCourse(long courseId, VocabularyFilter filter);
        Task<bool> WordInCourse(long wordId, long courseId);
        bool IsFavorite(long lessonItemId);
    }
}