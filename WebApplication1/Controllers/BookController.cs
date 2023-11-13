using Core.Resources;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;

        public BookController(IBookService bookService, IGenreService genreService)
        {
            _bookService = bookService;
            _genreService = genreService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookResource>>> GetAllBooks()
        {
            var booksResource = await _bookService.GetAllBooksAsync();

            return Ok(booksResource);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookResource>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
                return NotFound("Book with id: " + id + " does not exist");

            return Ok(book);
        }

        [HttpGet("isbn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookResource>> GetBookByIsbn(string isbn)
        {
            var book = await _bookService.GetBookByIsbnAsync(isbn);

            if (book == null)
                return NotFound("Book with isbn: " + isbn + " does not exist");

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookResource>> PostBook([FromBody] SaveBookResource saveBookResource)
        {
            if (await _bookService.GetBookByIsbnAsync(saveBookResource.BookISBN) != null)
                return BadRequest("Book with such ISBN already exists");

            var newBook = await _bookService.CreateBookAsync(saveBookResource);

            return CreatedAtAction(nameof(PostBook), newBook);
        }

        [HttpPost("{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddGenresToBook(int bookId, [FromBody] ICollection<int> genreIds)
        {
            var book = await _bookService.GetBookByIdAsync(bookId);

            if (book == null)
                return NotFound("Book with id: " + bookId + " does not exist");

            List<BookGenreResource> bookGenres = new();

            foreach (var id in genreIds)
            {
                var genre = await _genreService.GetGenreByIdAsync(id);
                if (genre == null)
                    return BadRequest();

                var bookGenre = new BookGenreResource { BookId = book.BookId, GenreId = id };

                bookGenres.Add(bookGenre);
            }

            await _bookService.AddGenresToBookAsync(bookGenres);

            var bookwithGenresResource = await _bookService.GetBookByIdAsync(bookId);

            return Ok(bookwithGenresResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutBook(int id, [FromBody] SaveBookResource newSaveBookResource)
        {
            var oldBook = await _bookService.GetBookByIdAsync(id);

            if (oldBook is null)
                return BadRequest("Book with id: " + id + " does not exist");

            await _bookService.UpdateBookAsync(oldBook, newSaveBookResource);

            var updatedBookResource = await _bookService.GetBookByIdAsync(id);

            return Ok(updatedBookResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book is null)
                return BadRequest("Book with id: " + id + " does not exist");

            await _bookService.DeleteBookAsync(book);

            return NoContent();
        }
    }
}

