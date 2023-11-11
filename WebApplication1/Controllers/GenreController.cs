using API.Validators;
using Core.Resources;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        
        public GenreController(IGenreService genreService) => _genreService = genreService;
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreResource>>> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenresAsync();

            return Ok(genres);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GenreResource>> GetGenreById(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);

            if(genre == null)
                return NotFound("Genre with id: " + id + "does not exist");
            
            return Ok(genre);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenreResource>> PostGenre(SaveGenreResource saveGenreResource)
        {
            //var validation = validator.Validate(saveGenreResource);

            //if (!validation.IsValid)
            //    return BadRequest("Request has one or more validation errors:\n" + validation.Errors);

            var newGenre = await _genreService.CreateGenreAsync(saveGenreResource);


            return CreatedAtAction(nameof(PostGenre), newGenre);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutGenre(int id, [FromBody] SaveGenreResource newSaveGenreResource)
        {
            var oldGenre = await _genreService.GetGenreByIdAsync(id);

            if (oldGenre is null)
                return BadRequest("Genre with id: " + id + "does not exist");

            //var validation = validator.Validate(newSaveGenreResource);

            //if (!validation.IsValid)
            //    return BadRequest("Request has one or more validation errors:\n" + validation.Errors);


            await _genreService.UpdateGenreAsync(oldGenre, newSaveGenreResource);

            var updatedGenre = await _genreService.GetGenreByIdAsync(id);

            return Ok(updatedGenre);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);

            if (genre is null)
                return BadRequest("Genre with id: " + id + "does not exist");

            await _genreService.DeleteGenreAsync(genre);

            return NoContent();
        }
    }
}
