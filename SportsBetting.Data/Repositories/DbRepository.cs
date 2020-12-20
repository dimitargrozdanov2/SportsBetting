﻿using Microsoft.EntityFrameworkCore;
using SportsBetting.Data.Models;
using SportsBetting.Data.Repositories.Contracts;
using SportsBetting.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SportsBetting.Data.Repositories
{
    public class DbRepository<TEntity> : IRepository<TEntity>
       where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext dbContext;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DbRepository{TEntity}" /> class.
        /// </summary>
        public DbRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            ObjectCheck.EntityCheck(entity, $"{nameof(TEntity)} missing.");
            await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> GetAsync(int id)
        {
            ObjectCheck.PrimaryKeyCheck(id, $"primaryKey <= 0 in {nameof(IRepository<TEntity>)}");
            return await dbContext.Set<TEntity>().FindAsync(id);
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return (filter != null ? dbContext.Set<TEntity>().Where(filter).ToList() : dbContext.Set<TEntity>().ToList());
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await dbContext.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            ObjectCheck.EntityCheck(entity, $"{nameof(TEntity)} missing.");
            dbContext.Set<TEntity>().Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc/>
        public virtual async Task DeleteAsync(int id)
        {
            var entityToBeDeleted = await GetAsync(id);
            ObjectCheck.EntityCheck(entityToBeDeleted, $"{nameof(TEntity)} missing.");

            dbContext.Set<TEntity>().Remove(entityToBeDeleted);
            await dbContext.SaveChangesAsync();
        }
    }
}
