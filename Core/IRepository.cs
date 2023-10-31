﻿using System.Linq.Expressions;

namespace Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        ValueTask<TEntity?> GetByIdAsync(int id);

        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync (TEntity entity);
        void Remove(TEntity entity);
    }
}
