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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorResource>>> GetAllAuthors()
        { 
            var authors = await _authorService.GetAllAuthorsAsync();
            var authorsResource = _mapper.Map<IEnumerable<AuthorResource>>(authors);

            return Ok(authorsResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResource>> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);

            if (author == null)
                return NotFound("author with id: " + id + " does not exist");

            var authorResource = _mapper.Map<AuthorResource>(author);

            return Ok(authorResource);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorResource>> PostAuthor( SaveAuthorResource saveAuthorResource)
        {
            var validator = new SaveAuthorResourceValidator();

            var validation = validator.Validate(saveAuthorResource);
            if (!validation.IsValid)
                return BadRequest("Request has one or more validation errors:\n" + validation.Errors);

            var author = _mapper.Map<SaveAuthorResource, Author>(saveAuthorResource);
            var newAuthor = await _authorService.CreateAuthorAsync(author);

            var authorResource = _mapper.Map<Author, AuthorResource>(newAuthor);

            return Ok(authorResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAuthor(int id, [FromBody] SaveAuthorResource newSaveAuthorResource)
        {
            var oldAuthor = await _authorService.GetAuthorByIdAsync(id);

            if (oldAuthor is null)
                return BadRequest("author with id: " + id + " does not exist");

            var validator = new SaveAuthorResourceValidator();

            var validation = validator.Validate(newSaveAuthorResource);
            if (!validation.IsValid)
                return BadRequest("Request has one or more validation errors:\n" + validation.Errors);

            var newAuthor = _mapper.Map<Author>(newSaveAuthorResource);
            await _authorService.UpdateAuthorAsync(oldAuthor, newAuthor);

            var updatedAuthor = await _authorService.GetAuthorByIdAsync(id);
            var updatedAuthorResource = _mapper.Map<AuthorResource>(updatedAuthor);

            return Ok(updatedAuthorResource);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);

            if (author is null)
                return BadRequest("author with id: " + id + " does not exist");

            await _authorService.DeleteAuthor(author);

            return NoContent();
        }
    }
}
