using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public int BookAuthorId { get; set; }

        public string BookName { get; set; } = null!;
        public string BookISBN { get; set; } = null!;
        public string? BookDescription { get; set; }
        public DateOnly? BookTakeDate { get; set; }
        public DateOnly? BookReturnDate { get; set; }

        public Author Author { get; set; } = null!;

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
