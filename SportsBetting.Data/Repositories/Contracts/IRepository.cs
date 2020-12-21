﻿using SportsBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SportsBetting.Data.Repositories.Contracts
{
    public interface IRepository<TEntity>
      where TEntity : class, IEntity
    {
        Task<TEntity> GetAsync(int primaryKey);

        Task<ICollection<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(int primaryKey);
    }
}
