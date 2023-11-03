using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly LibraryContext libraryContext;

        public BookRepository(LibraryContext context) : base(context)
        {
            libraryContext = context;
        }

        public async Task<IEnumerable<Book>> GetAllWithRelateAsync() => await libraryContext.Books.Include(b => b.Author).Include(b => b.BookGenres).ThenInclude(bg => bg.Genre).ToListAsync();

        public async ValueTask<Book?> GetWithRelateByIdAsync(int id) => await libraryContext.Books.Include(b => b.Author).Include(b => b.BookGenres).ThenInclude(bg => bg.Genre).SingleOrDefaultAsync(b => b.BookId == id);

        public async Task AddGenresToBookAsync(ICollection<BookGenre> bookGenres) => await libraryContext.BookGenres.AddRangeAsync(bookGenres);
    }
}
