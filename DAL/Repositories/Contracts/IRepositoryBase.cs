using DAL.Entities;
using System.Linq.Expressions;

namespace DAL.Repositories.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> GetById(long id);
        Task<IEnumerable<TEntity>> GetAll(bool trackChanges);
        Task<IEnumerable<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> condition, bool trackChanges);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);


    }
}
