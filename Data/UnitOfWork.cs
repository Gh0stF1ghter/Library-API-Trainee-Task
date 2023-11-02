using Core;
using Core.Models;
using Core.Repositories;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;

        public UnitOfWork(LibraryContext context) => _context = context;

        public IRepository<Author> Authors => new Repository<Author>(_context);
        public IRepository<Genre> Genres => new Repository<Genre>(_context);
        public IBookRepository Books => new BookRepository(_context);

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
