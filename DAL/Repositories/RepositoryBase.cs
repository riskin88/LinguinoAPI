﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly DataContext dataContext;
        public RepositoryBase(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        public void Add(TEntity entity)
        {
            dataContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dataContext.Set<TEntity>().AddRange(entities);

        }

        public async Task<IEnumerable<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> condition, bool trackChanges)
        {
            return await dataContext.Set<TEntity>().Where(condition).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(bool trackChanges)
        {
            return await dataContext.Set<TEntity>().ToListAsync();

        }

        public async Task<TEntity> GetById(long id)
        {
            return await dataContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Remove(TEntity entity)
        {
            dataContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dataContext.Set<TEntity>().RemoveRange(entities);

        }
    }
}
