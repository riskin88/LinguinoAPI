using DAL.Data;
using DAL.Entities;
using DAL.Identity;
using DAL.Repositories.Contracts;

namespace DAL.Repositories
{
    public class LessonItemRepository : RepositoryBase<LessonItem>, ILessonItemRepository
    {
        public LessonItemRepository(DataContext _dataContext) : base(_dataContext)
        {
        }
    }
}
