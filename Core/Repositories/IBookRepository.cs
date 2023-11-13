using Core.Models;

namespace Core.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllWithRelateAsync();

        Task<Book?> GetWithRelateByIdAsync(int id);

        Task AddGenresToBookAsync(ICollection<BookGenre> bookGenres);
    }
}
