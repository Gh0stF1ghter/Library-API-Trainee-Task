using API.Resources;
using API.Validators;
using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResource>>> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            var BooksResource = _mapper.Map<IEnumerable<BookResource>>(books);

            return Ok(BooksResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookResource>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
                return NotFound("Book with id: " +  id + " does not exist");

            var bookResource = _mapper.Map<BookResource>(book);

            return Ok(bookResource);
        }

        [HttpGet("isbn")]
        public async Task<ActionResult<BookResource>> GetBookByIsbn(string isbn)
        {
            var book = await _bookService.GetBookByIsbnAsync(isbn);
            var bookResource = _mapper.Map<BookResource>(book);

            return Ok(bookResource);
        }

        [HttpPost]
        public async Task<ActionResult<BookResource>> PostBook(SaveBookResource saveBookResource)
        {
            var validator = new SaveBookResourceValidator();
            var validation = validator.Validate(saveBookResource);

            if (!validation.IsValid)
                return BadRequest("Request has one or more validation errors:\n" + validation.Errors);

            var book = _mapper.Map<Book>(saveBookResource);

            if (await _bookService.GetBookByIsbnAsync(book.BookISBN) != null)
                return BadRequest("Book with such ISBN already exists");

            var newBook = await _bookService.CreateBookAsync(book);

            var bookResource = _mapper.Map<BookResource>(newBook);

            return Ok(bookResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutBook(int id, [FromBody] SaveBookResource newSaveBookResource)
        {
            var oldBook = await _bookService.GetBookByIdAsync(id);

            if (oldBook is null)
                return BadRequest("Book with id: " + id + " does not exist");

            var validator = new SaveBookResourceValidator();
            var validation = validator.Validate(newSaveBookResource);
            if (validation.IsValid)
                return BadRequest("Request has one or more validation errors:\n" + validation.Errors);

            var newBook = _mapper.Map<Book>(newSaveBookResource);
            await _bookService.UpdateBookAsync(oldBook, newBook);

            var updatedBook = await _bookService.GetBookByIdAsync(id);
            var updatedBookResource = _mapper.Map<BookResource>(updatedBook);

            return Ok(updatedBookResource);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var genre = await _bookService.GetBookByIdAsync(id);

            if (genre is null)
                return BadRequest("Book with id: " + id + " does not exist");

            await _bookService.DeleteBookAsync(genre);

            return NoContent();
        }
    }
}

