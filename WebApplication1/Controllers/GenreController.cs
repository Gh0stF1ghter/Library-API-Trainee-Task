using Core.Resources;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GenreResource>> GetGenreById(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);

            if (genre == null)
                return NotFound("Genre with id: " + id + "does not exist");

            return Ok(genre);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenreResource>> PostGenre(SaveGenreResource saveGenreResource)
        {
            var newGenre = await _genreService.CreateGenreAsync(saveGenreResource);

            return CreatedAtAction(nameof(PostGenre), newGenre);
        }

        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutGenre(int id, [FromBody] SaveGenreResource newSaveGenreResource)
        {
            await _genreService.UpdateGenreAsync(id, newSaveGenreResource);

            var updatedGenre = await _genreService.GetGenreByIdAsync(id);

            if (updatedGenre == null)
                return BadRequest("Genre with id: " + id + "does not exist");

            return Ok(updatedGenre);
        }

        [HttpDelete("{id}")]
        [Authorize]
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
