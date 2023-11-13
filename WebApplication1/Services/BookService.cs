using AutoMapper;
using Core;
using Core.Models;
using Core.Resources;
using Core.Services;

namespace API.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<IEnumerable<BookResource>> GetAllBooksAsync()
        {
            var books = await _unitOfWork.Books.GetAllWithRelateAsync();

            var booksResource = _mapper.Map<IEnumerable<BookResource>>(books);

            return booksResource;

        }

        public async Task<BookResource?> GetBookByIdAsync(int id)
        {
            var book = await _unitOfWork.Books.GetWithRelateByIdAsync(id);

            var bookResource = _mapper.Map<BookResource>(book);

            return bookResource;
        }

        public async Task<BookResource> CreateBookAsync(SaveBookResource saveBookResource)
        {
            var book = _mapper.Map<Book>(saveBookResource);

            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.CommitAsync();

            var bookResource = _mapper.Map<BookResource>(book);

            return bookResource;
        }

        public async Task AddGenresToBookAsync(ICollection<BookGenreResource> bookGenresResources)
        {
            var bookGenres = _mapper.Map<ICollection<BookGenre>>(bookGenresResources);

            await _unitOfWork.Books.AddGenresToBookAsync(bookGenres);

            await _unitOfWork.CommitAsync();
        }

        public async Task<BookResource?> GetBookByIsbnAsync(string bookIsbn)
        {
            var book = await _unitOfWork.Books.SingleOrDefaultAsync(b => b.BookISBN == bookIsbn);

            var bookResource = _mapper.Map<BookResource>(book);

            return bookResource;
        }

        public async Task UpdateBookAsync(BookResource oldBookResource, SaveBookResource newBookResource)
        {
            var oldBook = _mapper.Map<Book>(oldBookResource);
            var newBook = _mapper.Map<Book>(newBookResource);

            oldBook.BookName = newBook.BookName;
            oldBook.BookDescription = newBook.BookDescription;
            oldBook.BookTakeDate = newBook.BookTakeDate;
            oldBook.BookReturnDate = newBook.BookReturnDate;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteBookAsync(BookResource bookResoource)
        {
            var book = _mapper.Map<Book>(bookResoource);

            _unitOfWork.Books.Remove(book);

            await _unitOfWork.CommitAsync();
        }
    }
}
