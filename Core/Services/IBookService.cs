using Core.Models;

namespace Core.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        ValueTask<Book?> GetBookByIdAsync(int id);

        Task<Book> CreateBookAsync(Book book);

        Task<Book?> GetBookByIsbnAsync(string bookIsbn);

        Task UpdateBookAsync(Book oldBook, Book newBook);
        Task DeleteBookAsync(Book book);
    }
}
