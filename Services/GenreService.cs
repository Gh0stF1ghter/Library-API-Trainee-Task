using Core;
using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenreService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        
        public async Task<IEnumerable<Genre>> GetAllGenresAsync() => await _unitOfWork.Genres.GetAllAsync();
        public async ValueTask<Genre?> GetGenreByIdAsync(int id) => await _unitOfWork.Genres.GetByIdAsync(id);

        public async Task<Genre> CreateGenreAsync(Genre genre)
        {
            await _unitOfWork.Genres.AddAsync(genre);
            await _unitOfWork.CommitAsync();
            return genre;
        }


        public async Task UpdateGenreAsync(Genre oldGenre, Genre newGenre)
        {
            oldGenre.GenreName = newGenre.GenreName;
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteGenreAsync(Genre genre)
        {
            _unitOfWork.Genres.Remove(genre);
            await _unitOfWork.CommitAsync();
        }

    }
}
