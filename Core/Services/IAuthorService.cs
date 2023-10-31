using Core.Models;

namespace Core.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        ValueTask<Author?> GetAuthorByIdAsync(int id);

        Task<Author> CreateAuthorAsync(Author author);

        Task UpdateAuthorAsync(Author oldAuthor, Author newAuthor);
        Task DeleteAuthor(Author author);
    }
}
