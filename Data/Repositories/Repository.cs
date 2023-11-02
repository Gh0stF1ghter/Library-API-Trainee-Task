using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context) => _context = context;

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();
        public async ValueTask<TEntity?> GetByIdAsync(int id) => await _context.Set<TEntity>().FindAsync(id);

        public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);

        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);

        public void Remove(TEntity entity) => _context.Remove(entity);
    }
}
