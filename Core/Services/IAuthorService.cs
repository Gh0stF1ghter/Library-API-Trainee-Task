using Core.Resources;

namespace Core.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResource>> GetAllAuthorsAsync();
        Task<AuthorResource?> GetAuthorByIdAsync(int id);

        Task<AuthorResource> CreateAuthorAsync(SaveAuthorResource author);

        Task UpdateAuthorAsync(AuthorResource oldAuthor, SaveAuthorResource newAuthor);
        Task DeleteAuthor(AuthorResource author);
    }
}
