using Core.Models;
using Core.Repositories;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        public IBookRepository Books { get; }
        public IRepository<Genre> Genres { get; }
        public IRepository<Author> Authors { get; }

        Task<int> CommitAsync();
    }
}