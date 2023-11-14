using Core.Resources;

namespace Core.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResource>> GetAllGenresAsync();
        Task<GenreResource?> GetGenreByIdAsync(int id);

        Task<GenreResource> CreateGenreAsync(SaveGenreResource genre);

        Task UpdateGenreAsync(int id, SaveGenreResource newGenre);
        Task DeleteGenreAsync(GenreResource genre);
    }
}
