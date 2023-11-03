using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllWithRelateAsync();

        ValueTask<Book?> GetWithRelateByIdAsync(int id);

        Task AddGenresToBookAsync(ICollection<BookGenre> bookGenres);
    }
}
