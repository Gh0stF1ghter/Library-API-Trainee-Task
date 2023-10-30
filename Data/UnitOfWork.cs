using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;
        private readonly Repository<Author>? _authorRepository;
        private readonly Repository<Genre>? _genreRepository;
        private readonly Repository<Book>? _bookRepository;

        public UnitOfWork(LibraryContext context) => _context = context;

        public IRepository<Author> Authors => _authorRepository ?? new Repository<Author>(_context);
        public IRepository<Genre> Genres => _genreRepository ?? new Repository<Genre>(_context);
        public IRepository<Book> Books => _bookRepository ?? new Repository<Book>(_context);

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
