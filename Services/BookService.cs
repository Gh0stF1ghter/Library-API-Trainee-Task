using Core;
using Core.Models;
using Core.Services;

namespace Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Book>> GetAllBooksAsync() => await _unitOfWork.Books.GetAllWithRelateAsync();

        public async ValueTask<Book?> GetBookByIdAsync(int id) => await _unitOfWork.Books.GetWithRelateByIdAsync(id);

        public async Task<Book> CreateBookAsync(Book book)
        {
            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.CommitAsync();
            return book;
        }

        public async Task<Book?> GetBookByIsbnAsync(string bookIsbn) => await _unitOfWork.Books.SingleOrDefaultAsync(b => b.BookISBN == bookIsbn);

        public async Task UpdateBookAsync(Book oldBook, Book newBook)
        {
            oldBook.BookName = newBook.BookName;
            oldBook.BookDescription = newBook.BookDescription;
            oldBook.BookTakeDate = newBook.BookTakeDate;
            oldBook.BookReturnDate = newBook.BookReturnDate;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            _unitOfWork.Books.Remove(book);
            await _unitOfWork.CommitAsync();
        }

    }
}
