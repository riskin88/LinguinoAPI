using DAL.Entities;
using DAL.Entities.Relations;

namespace DAL.Repositories.Contracts
{
    public interface ILessonItemRepository : IRepositoryBase<LessonItem>
    {
        void AddWord(Word word);
        LessonItem CreateNew();
        Task<Word?> GetWordById(long wordId);
    }
}