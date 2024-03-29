﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CrudDemo.Data.Services.Internal
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ILogger logger;
        internal DbSet<T> dbSet;

        protected GenericRepository(DemoDbContext dbContext, ILogger logger)
        {
            this.logger = logger;
            this.dbSet = dbContext.Set<T>();
        }

        public virtual async Task<bool> Add(T entity, CancellationToken cancellationToken)
        {
            await this.dbSet.AddAsync(entity, cancellationToken);
            return true;
        }

        public virtual Task<IQueryable<T>> All()
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IQueryable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(dbSet.Where(predicate));
        }

        public virtual async Task<T> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await dbSet.FindAsync(id, cancellationToken);
        }

        public virtual Task<bool> Upsert(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
