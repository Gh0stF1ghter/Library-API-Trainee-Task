using Core.Resources;

namespace Core.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookResource>> GetAllBooksAsync();
        Task<BookResource?> GetBookByIdAsync(int id);

        Task<BookResource> CreateBookAsync(SaveBookResource book);
        Task AddGenresToBookAsync(ICollection<BookGenreResource> bookGenres);
        Task<BookResource?> GetBookByIsbnAsync(string bookIsbn);

        Task UpdateBookAsync(int id, SaveBookResource newBook);
        Task DeleteBookAsync(BookResource book);
    }
}
