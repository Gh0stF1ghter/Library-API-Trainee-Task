using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        ValueTask<Genre?> GetGenreByIdAsync(int id);

        Task<Genre> CreateGenreAsync(Genre genre);

        Task UpdateGenreAsync(Genre oldGenre, Genre newGenre);
        Task DeleteGenreAsync(Genre genre);
    }
}
