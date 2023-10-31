using System.Collections.ObjectModel;

namespace Core.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public int BookAuthorId { get; set; }

        public string BookName { get; set; } = null!;
        public string BookISBN { get; set; } = null!;
        public string? BookDescription { get; set; }
        public DateTime BookTakeDate { get; set; }
        public DateTime BookReturnDate { get; set; }

        public Author Author { get; set; } = null!;

        public ICollection<BookGenre> BookGenres { get; set; } = new Collection<BookGenre>();
    }
}
