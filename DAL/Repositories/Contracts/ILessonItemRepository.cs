using DAL.Entities;
using DAL.Entities.Relations;

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
        Task<UserLessonItem> GetUserProgress(long itemId);
        Task RemoveExercise(long lessonItemId, Exercise exercise);
        Task AddToUser(long lessonItemId, User user);
    }
}