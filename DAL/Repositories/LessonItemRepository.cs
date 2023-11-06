using DAL.Data;
using DAL.Entities;
using DAL.Identity;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class LessonItemRepository : RepositoryBase<LessonItem>, ILessonItemRepository
    {
        public LessonItemRepository(DataContext _dataContext) : base(_dataContext)
        {
        }

        public void AddWord(Word word)
        {
            dataContext.Set<Word>().Add(word);
        }

        public LessonItem CreateNew()
        {
            var item = new LessonItem();
            dataContext.Set<LessonItem>().Add(item);
            return item;
        }

        public Task<Word?> GetWordById(long wordId)
        {
            dataContext.Set<Word>().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
