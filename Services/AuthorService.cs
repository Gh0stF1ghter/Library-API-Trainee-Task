using Core;
using Core.Models;
using Core.Services;

namespace Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        
        public async Task<IEnumerable<Author>> GetAllAuthorsAsync() => await _unitOfWork.Authors.GetAllAsync();
        public async ValueTask<Author?> GetAuthorByIdAsync(int id) => await _unitOfWork.Authors.GetByIdAsync(id);

        public async Task<Author> CreateAuthorAsync(Author author)
        {
            await _unitOfWork.Authors.AddAsync(author);
            await _unitOfWork.CommitAsync();
            return author;
        }

        public async Task UpdateAuthorAsync(Author oldAuthor, Author newAuthor)
        {
            oldAuthor.AuthorFirstMidName = newAuthor.AuthorFirstMidName;
            oldAuthor.AuthorLastName = newAuthor.AuthorLastName;
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAuthor(Author author)
        {
            _unitOfWork.Authors.Remove(author);
            await _unitOfWork.CommitAsync();
        }
    }
}