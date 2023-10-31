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
        public async Task<ActionResult<GenreResource>> GetGenreById(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            var genreResource = _mapper.Map<GenreResource>(genre);

            return Ok(genreResource);
        }

        [HttpPost]
        public async Task<ActionResult<GenreResource>> PostBook(SaveGenreResource saveGenreResource)
        {
            var validator = new SaveGenreResourceValidator();
            validator.Validate(saveGenreResource);

            var genre = _mapper.Map<Genre>(saveGenreResource);
            var newGenre = await _genreService.CreateGenreAsync(genre);

            var genreResource = _mapper.Map<GenreResource>(newGenre);

            return Ok(genreResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutGenre(int id, [FromBody] SaveGenreResource newSaveGenreResource)
        {
            var validator = new SaveGenreResourceValidator();
            validator.Validate(newSaveGenreResource);

            var oldGenre = await _genreService.GetGenreByIdAsync(id);

            if (oldGenre is null)
                return BadRequest();

            var newGenre = _mapper.Map<Genre>(newSaveGenreResource);
            await _genreService.UpdateGenreAsync(oldGenre, newGenre);

            var updatedgenre = await _genreService.GetGenreByIdAsync(id);
            var updatedGenreResource = _mapper.Map<GenreResource>(updatedgenre);

            return Ok(updatedGenreResource);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);

            if (genre is null)
                return BadRequest();

            await _genreService.DeleteGenreAsync(genre);

            return NoContent();
        }
    }
}
