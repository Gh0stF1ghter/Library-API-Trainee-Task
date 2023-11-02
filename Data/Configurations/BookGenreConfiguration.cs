using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    internal class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder
                .HasKey(bg => new { bg.GenreId, bg.BookId });
            builder
                .HasIndex(bg => new { bg.GenreId, bg.BookId });
            builder.ToTable("BookGenre");
            builder.HasData(
                new BookGenre { BookId = 1, GenreId = 1 },
                new BookGenre { BookId = 2, GenreId = 2 },
                new BookGenre { BookId = 2, GenreId = 9 },
                new BookGenre { BookId = 3, GenreId = 3 },
                new BookGenre { BookId = 4, GenreId = 5 },
                new BookGenre { BookId = 5, GenreId = 8 },
                new BookGenre { BookId = 5, GenreId = 6 },
                new BookGenre { BookId = 5, GenreId = 7 },
                new BookGenre { BookId = 6, GenreId =8 },
                new BookGenre { BookId = 6, GenreId = 12 },
                new BookGenre { BookId = 7, GenreId = 5 },
                new BookGenre { BookId = 9, GenreId = 12 },
                new BookGenre { BookId = 8, GenreId = 9 },
                new BookGenre { BookId = 8, GenreId = 10 },
                new BookGenre { BookId = 8, GenreId = 11 },
                new BookGenre { BookId = 10, GenreId = 4 },
                new BookGenre { BookId = 10, GenreId = 3 }
                );
        }

    }
}
