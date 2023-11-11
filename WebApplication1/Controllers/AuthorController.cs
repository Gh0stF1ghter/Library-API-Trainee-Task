using API.Validators;
using Core.Resources;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService) => _authorService = authorService;
        

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AuthorResource>>> GetAllAuthors()
        { 
            var authors = await _authorService.GetAllAuthorsAsync();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuthorResource>> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);

            if (author == null)
                return NotFound("author with id: " + id + " does not exist");

            return Ok(author);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorResource>> PostAuthor( SaveAuthorResource saveAuthorResource)
        {
            var validator = new SaveAuthorResourceValidator();

            //var validation = validator.Validate(saveAuthorResource);
            //if (!validation.IsValid)
            //    return BadRequest("Request has one or more validation errors:\n" + validation.Errors);

            var newAuthor = await _authorService.CreateAuthorAsync(saveAuthorResource);

            return CreatedAtAction(nameof(PostAuthor), newAuthor);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAuthor(int id, [FromBody] SaveAuthorResource newAuthor)
        {
            var oldAuthor = await _authorService.GetAuthorByIdAsync(id);

            if (oldAuthor is null)
                return BadRequest("author with id: " + id + " does not exist");

            //var validation = validator.Validate(newSaveAuthorResource);
            //if (!validation.IsValid)
            //    return BadRequest("Request has one or more validation errors:\n" + validation.Errors);

            await _authorService.UpdateAuthorAsync(oldAuthor, newAuthor);

            var updatedAuthor = await _authorService.GetAuthorByIdAsync(id);

            return Ok(updatedAuthor);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);

            if (author is null)
                return BadRequest("author with id: " + id + " does not exist");

            await _authorService.DeleteAuthor(author);

            return NoContent();
        }
    }
}
