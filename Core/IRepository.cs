using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        ValueTask<TEntity> GetByIdAsync(int id);

        Task<TEntity>? SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync (TEntity entity);
        void Remove(TEntity entity);
    }
}
