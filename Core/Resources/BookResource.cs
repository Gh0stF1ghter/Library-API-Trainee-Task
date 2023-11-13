using System.Collections.ObjectModel;

namespace Core.Resources
{
    public class BookResource
    {
        public int BookId { get; set; }
        public int BookAuthorId { get; set; }

        public string BookName { get; set; } = null!;
        public string BookISBN { get; set; } = null!;
        public string? BookDescription { get; set; }
        public DateTime BookTakeDate { get; set; }
        public DateTime BookReturnDate { get; set; }

        public AuthorResource Author { get; set; } = null!;
        public ICollection<BookGenreResource> BookGenres { get; set; } = new Collection<BookGenreResource>();
    }
}
