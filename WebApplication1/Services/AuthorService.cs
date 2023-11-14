using AutoMapper;
using Core;
using Core.Models;
using Core.Resources;
using Core.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorResource>> GetAllAuthorsAsync()
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();

            var authorsResource = _mapper.Map<IEnumerable<AuthorResource>>(authors);

            return authorsResource;
        }
        public async Task<AuthorResource?> GetAuthorByIdAsync(int id)
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(id);

            var authorResource = _mapper.Map<AuthorResource>(author);

            return authorResource;
        }

        public async Task<AuthorResource> CreateAuthorAsync(SaveAuthorResource saveAuthorResource)
        {
            var author = _mapper.Map<Author>(saveAuthorResource);

            await _unitOfWork.Authors.AddAsync(author);
            await _unitOfWork.CommitAsync();

            var authorResource = _mapper.Map<AuthorResource>(author);

            return authorResource;
        }

        public async Task UpdateAuthorAsync(int id, SaveAuthorResource newSaveAuthorResource)
        {
            var oldAuthor = await _unitOfWork.Authors.GetByIdAsync(id);

            if (oldAuthor is null)
                return;

            var newAuthor = _mapper.Map<Author>(newSaveAuthorResource);

            oldAuthor.AuthorFirstMidName = newAuthor.AuthorFirstMidName;
            oldAuthor.AuthorLastName = newAuthor.AuthorLastName;
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAuthor(AuthorResource authorResource)
        {
            var author = _mapper.Map<Author>(authorResource);

            _unitOfWork.Authors.Remove(author);
            await _unitOfWork.CommitAsync();
        }
    }
}