using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
