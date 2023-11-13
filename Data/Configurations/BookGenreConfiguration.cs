using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder
                .ToTable("BookGenre");
        }
    }
}
