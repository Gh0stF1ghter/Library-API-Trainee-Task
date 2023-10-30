using Core.Models;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Book> Books { get; }
        public IRepository<Genre> Genres { get; }
        public IRepository<Author> Authors { get; }

        Task<int> CommitAsync();
    }
}