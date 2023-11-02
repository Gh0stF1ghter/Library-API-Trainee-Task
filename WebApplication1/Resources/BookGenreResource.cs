using Core.Models;

namespace API.Resources
{
    public class BookGenreResource
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public GenreResource Genre { get; set; } = null!;
    }
}
