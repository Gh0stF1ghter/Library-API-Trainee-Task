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
            var bookResource = _mapper.Map<BookResource>(book);

            return Ok(bookResource);
        }

        [HttpPost]
        public async Task<ActionResult<BookResource>> PostBook(SaveBookResource saveBookResource)
        {
            var validator = new SaveBookResourceValidator();
            validator.Validate(saveBookResource);

            var book = _mapper.Map<Book>(saveBookResource);
            var newBook = await _bookService.CreateBookAsync(book);

            var bookResource = _mapper.Map<BookResource>(newBook);

            return Ok(bookResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutBook(int id, [FromBody] SaveBookResource newSaveBookResource)
        {
            var validator = new SaveBookResourceValidator();
            validator.Validate(newSaveBookResource);

            var oldBook = await _bookService.GetBookByIdAsync(id);

            if (oldBook is null)
                return BadRequest();

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
                return BadRequest();

            await _bookService.DeleteBookAsync(genre);

            return NoContent();
        }
    }
}

