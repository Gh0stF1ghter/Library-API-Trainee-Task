using AutoMapper;
using Core;
using Core.Models;
using Core.Resources;
using Core.Services;

namespace API.Services
{
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GenreResource>> GetAllGenresAsync()
        {
            var genres = await _unitOfWork.Genres.GetAllAsync();
            var genresResource = _mapper.Map<IEnumerable<GenreResource>>(genres);

            return genresResource;
        }

        public async Task<GenreResource?> GetGenreByIdAsync(int id)
        {
            var genre = await _unitOfWork.Genres.GetByIdAsync(id);

            var genreResource = _mapper.Map<GenreResource>(genre);

            return genreResource;
        }

        public async Task<GenreResource> CreateGenreAsync(SaveGenreResource saveGenreResource)
        {
            var genre = _mapper.Map<Genre>(saveGenreResource);

            await _unitOfWork.Genres.AddAsync(genre);
            await _unitOfWork.CommitAsync();

            var genreResource = _mapper.Map<GenreResource>(genre);

            return genreResource;
        }

        public async Task UpdateGenreAsync(int id, SaveGenreResource newSaveGenreResource)
        {
            var oldGenre = await _unitOfWork.Genres.GetByIdAsync(id);

            if (oldGenre is null)
                return;

            var newGenre = _mapper.Map<Genre>(newSaveGenreResource);

            oldGenre.GenreName = newGenre.GenreName;
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteGenreAsync(GenreResource genreResource)
        {
            var genre = _mapper.Map<Genre>(genreResource);

            _unitOfWork.Genres.Remove(genre);
            await _unitOfWork.CommitAsync();
        }
    }
}
