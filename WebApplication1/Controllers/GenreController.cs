using API.Resources;
using API.Validators;
using AutoMapper;
using Core.Models;
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
        private readonly IMapper _mapper;
        
        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreResource>>> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenresAsync();
            var genresResource = _mapper.Map<IEnumerable<GenreResource>>(genres);

            return Ok(genresResource);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GenreResource>> GetGenreById(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);

            if(genre == null)
                return NotFound("Genre with id: " + id + "does not exist");
            
            var genreResource = _mapper.Map<GenreResource>(genre);

            return Ok(genreResource);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenreResource>> PostGenre(SaveGenreResource saveGenreResource)
        {
            var validator = new SaveGenreResourceValidator();
            var validation = validator.Validate(saveGenreResource);

            if (!validation.IsValid)
                return BadRequest("Request has one or more validation errors:\n" + validation.Errors);

            var genre = _mapper.Map<Genre>(saveGenreResource);
            var newGenre = await _genreService.CreateGenreAsync(genre);

            var genreResource = _mapper.Map<GenreResource>(newGenre);

            return CreatedAtAction(nameof(PostGenre), genreResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutGenre(int id, [FromBody] SaveGenreResource newSaveGenreResource)
        {
            var oldGenre = await _genreService.GetGenreByIdAsync(id);

            if (oldGenre is null)
                return BadRequest("Genre with id: " + id + "does not exist");

            var validator = new SaveGenreResourceValidator();
            var validation = validator.Validate(newSaveGenreResource);

            if (!validation.IsValid)
                return BadRequest("Request has one or more validation errors:\n" + validation.Errors);


            var newGenre = _mapper.Map<Genre>(newSaveGenreResource);
            await _genreService.UpdateGenreAsync(oldGenre, newGenre);

            var updatedgenre = await _genreService.GetGenreByIdAsync(id);
            var updatedGenreResource = _mapper.Map<GenreResource>(updatedgenre);

            return Ok(updatedGenreResource);
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
