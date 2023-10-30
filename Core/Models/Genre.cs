using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public int GenreName { get; set; }

        public ICollection<BookGenre>? BookGenres { get; set; }
    }
}
