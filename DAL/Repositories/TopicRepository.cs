using DAL.Data;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.Repositories.Contracts;

namespace DAL.Repositories
{

    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        public TopicRepository(DataContext _dataContext) : base(_dataContext) { }
    }
}
