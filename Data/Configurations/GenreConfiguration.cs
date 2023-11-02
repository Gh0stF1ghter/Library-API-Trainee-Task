using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
                .HasKey(g => g.GenreId);
            builder
                .Property(g => g.GenreId)
                .UseIdentityColumn();
            builder
                .Property(g => g.GenreName)
                .IsRequired()
                .HasMaxLength(30);
            builder
                .HasMany(g => g.BookGenres)
                .WithOne(bg => bg.Genre)
                .HasForeignKey(bg => bg.GenreId);
            builder
                .ToTable("Genre");
            builder.HasData(
                new Genre { GenreId = 1, GenreName = "Science fiction" },
                new Genre { GenreId = 2, GenreName = "Action" },
                new Genre { GenreId = 3, GenreName = "Thriller" },
                new Genre { GenreId = 4, GenreName = "Detective novel" },
                new Genre { GenreId = 5, GenreName = "Fantasy" },
                new Genre { GenreId = 6, GenreName = "Realism" },
                new Genre { GenreId = 7, GenreName = "Satire" },
                new Genre { GenreId = 8, GenreName = "Bildungsroman" },
                new Genre { GenreId = 9, GenreName = "Dystopian" },
                new Genre { GenreId = 10, GenreName = "Horror" },
                new Genre { GenreId = 11, GenreName = "Political fiction" },
                new Genre { GenreId = 12, GenreName = "Social novel" },
                new Genre { GenreId = 13, GenreName = "Southern Gothic" },
                new Genre { GenreId = 14, GenreName = "Historical fiction" }
                );
        }
    }
}
