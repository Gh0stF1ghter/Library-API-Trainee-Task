using System.Collections.ObjectModel;

namespace Core.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorFirstMidName { get; set; } = null!;
        public string AuthorLastName { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new Collection<Book>();
    }
}
